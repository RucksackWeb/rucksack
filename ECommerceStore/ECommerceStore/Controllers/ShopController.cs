using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceStore.Models;
using ECommerceStore.Models.Interfaces;
using ECommerceStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ECommerceStore.Controllers
{
    public class ShopController : Controller
    {
        private IConfiguration Configuration;
        private IInventory _context;
        private IBasket _basket;
        private IOrder _order;
        private SignInManager<ApplicationUser> _signInManager { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }
        private IEmailSender _emailSender { get; set; }

        public ShopController(IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IInventory context, IBasket basket, IOrder order, IEmailSender emailSender)
        {
            Configuration = configuration;
            _context = context;
            _basket = basket;
            _order = order;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }


        public async Task<IActionResult> Index()
        {
            var products = await _context.GetAll();
            DisplayProducts dp = new DisplayProducts();
            dp.Products = products;
            return View(dp);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var product = await _context.GetById(id);

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> CartPage()
        {
            string userId = _userManager.GetUserId(User);
            if (_basket.GetBasketById(userId) == null)
            {
                Basket newBasket = new Basket();
                newBasket.UserId = userId;
                await _basket.CreateBasket(newBasket);
            }

            Basket basket = _basket.GetBasketById(userId);
            List<BasketItem> items = _basket.GetItems(basket.Id);

            if (items != null)
            {
                basket.TotalCost = 0;
                foreach (BasketItem item in items)
                {
                    Product product = await _context.GetById(item.ItemId);
                    item.Product = product;

                    item.Cost = decimal.Multiply(Convert.ToDecimal(item.Quantity), product.Price);
                    basket.TotalCost += item.Cost;
                }
                await _basket.SaveBasket(basket);
            }

            basket.CartItem = items;
            BasketViewModels bvm = new BasketViewModels();
            bvm.Package = basket;

            return View(bvm);
        }

        [HttpPost]
        public async Task<IActionResult> CartPage(BasketViewModels bvm)
        {

            var singleitem = _basket.GetItemById(bvm.basketItemId);
            singleitem.Quantity = bvm.basketItemQuantity;
            await _basket.SaveItem(singleitem);

            string userId = _userManager.GetUserId(User);
            if (_basket.GetBasketById(userId) == null)
            {
                Basket newBasket = new Basket();
                newBasket.UserId = userId;
                await _basket.CreateBasket(newBasket);
            }

            Basket basket = _basket.GetBasketById(userId);
            List<BasketItem> items = _basket.GetItems(basket.Id);

            if (items != null)
            {
                basket.TotalCost = 0;
                foreach (BasketItem item in items)
                {
                    Product product = await _context.GetById(item.ItemId);
                    item.Product = product;

                    item.Cost = decimal.Multiply(Convert.ToDecimal(item.Quantity), product.Price);
                    basket.TotalCost += item.Cost;
                }
                await _basket.SaveBasket(basket);
            }

            basket.CartItem = items;
            BasketViewModels bvm2 = new BasketViewModels();
            bvm2.Package = basket;

            return View(bvm2);
        }


        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            var basket = _basket.GetBasketById(user.Id);
            List<BasketItem> items = _basket.GetItems(basket.Id);

            if (items.Count == 0)
            {
                TempData["ErrorMessage"] = "Shopping Cart is empty";
                return RedirectToAction("CartPage");
            }
            basket.TotalCost = 0;

            foreach (BasketItem item in items)
            {
                var product = await _context.GetById(item.ItemId);
                item.Product = product;
                basket.TotalCost += Convert.ToDecimal(item.Quantity) * product.Price;
            }

            if(_order.Get(basket.Id) == null)
            {
                Order newOrder = new Order
                {
                    UserId = user.Id,
                    BasketId = basket.Id,
                    Subtotal = basket.TotalCost,
                };
                
                await _order.Add(newOrder);
            }

            Order order = _order.Get(basket.Id);
            order.Subtotal = basket.TotalCost;

            await _basket.SaveBasket(basket);
            await _order.Update(order);

            CheckoutViewModel cvm = new CheckoutViewModel();
            order.Items = items;
            cvm.Order = order;

            return View(cvm);
        }


        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel cvm)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            Order dbOrder = _order.Get(user.Id);
            dbOrder.Address = cvm.Order.Address;
            dbOrder.City = cvm.Order.City;
            dbOrder.State = cvm.Order.State;
            dbOrder.Zipcode = cvm.Order.Zipcode;

            cvm.User = user;
            cvm.Order = dbOrder;

            // Runs payment
            Payment payment = new Payment(Configuration);
            var result = payment.RunPayment(cvm);

            if (result.Contains("failed"))
            {
                TempData["PaymentError"] = $"{result}";
                return RedirectToAction("CartPage", "Shop");
            }
            else
            {
                await _order.Update(dbOrder);
                return RedirectToAction("CheckoutConfirmation", new { id = user.Id });
            }
        }

        public async Task<IActionResult> CheckoutConfirmation(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            
            Order order = _order.Get(id);

            if (order.UserId != id)
            {
                return RedirectToAction("CartPage");
            }


            var userId = _userManager.GetUserId(User);
            Basket basket = _basket.GetBasketById(userId);
            basket.IsComplete = true;
            order.IsComplete = true;
            order.Date = DateTime.Now;
            await _basket.SaveBasket(basket);
            await _order.Update(order);

            order.Items = _basket.GetItems(basket.Id);
            List<Product> products = new List<Product>();

            foreach (BasketItem item in order.Items)
            {
                item.Product = await _context.GetById(item.ItemId);
            }
            
            // Sends Receipt email to user
            string msgTitle = "Your order is on its way!";

            string msgContent = "<div>" +
                                $"<h3> Your order #{order.ID} placed on {order.Date}, is getting ready for a shipment! </h3>" +
                                 $"<p> {user.FirstName} {user.LastName}, Thank you for your order at RuckSack. Your order will be shipped out as soon as possible. </div>" +
                                
                                 "<div>" +
                                 "<h4> Shipping Address: </h5>" +
                                 $"<p>{user.FirstName} {user.LastName}</p>" +
                                 $"<p>{order.Address}</p>" +
                                 $"<p>{order.City} {order.State}, {order.Zipcode}</p>" +

                                 "<h4> Items : </h4>";
                
            foreach(BasketItem item in order.Items) 
            {
                msgContent += $"<p><strong>{item.Product.Name}</strong> X {item.Quantity}, ${item.Cost}</p>";
            };
            msgContent += $"<h4>Damage on your Wallet: ${order.Subtotal}</h5>";        

            await _emailSender.SendEmailAsync(user.Email, msgTitle, msgContent);
    

            return View(order);
        }
    }
}