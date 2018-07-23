using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceStore.Models;
using ECommerceStore.Models.Interfaces;
using ECommerceStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceStore.Controllers
{
    public class ShopController : Controller
    {
        private IInventory _context;
        private IBasket _basket;
        private IOrder _order;
        private SignInManager<ApplicationUser> _signInManager { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }

        public ShopController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IInventory context, IBasket basket, IOrder order)
        {
            _context = context;
            _basket = basket;
            _order = order;
            _userManager = userManager;
            _signInManager = signInManager;
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

            return View(basket);
        }


        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            string userId = _userManager.GetUserId(User);
            var basket = _basket.GetBasketById(userId);
            List<BasketItem> items = _basket.GetItems(basket.Id);

            if (items.Count == 0)
            {
                TempData["ErrorMessage"] = "Shopping Cart is empty";
                return RedirectToAction("CartPage");
            }


            if(_order.Get(basket.Id) == null)
            {
                Order newOrder = new Order
                {
                    UserId = userId,
                    BasketId = basket.Id,
                    Subtotal = basket.TotalCost,
                };
                
                await _order.Add(newOrder);
            }

            Order order = _order.Get(basket.Id);

            foreach (BasketItem item in items)
            {
                var product = await _context.GetById(item.ItemId);
                item.Product = product;
            }
            order.Items = items;

            return View(order);
        }


        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            string userId = _userManager.GetUserId(User);
            Order dbOrder = _order.Get(userId);
            dbOrder.Address = order.Address;
            dbOrder.City = order.City;
            dbOrder.State = order.State;
            dbOrder.Zipcode = order.Zipcode;

            await _order.Update(dbOrder);
            return RedirectToAction("Checkout");
        }


        public async Task<IActionResult> CheckoutConfirmation(int id)
            {
            string userId = _userManager.GetUserId(User);
            Order order = _order.Get(userId);

            if(order.ID != id)
            {
                return RedirectToAction("CartPage");
            }

            Basket basket = _basket.GetBasketById(userId);
            basket.IsComplete = true;
            order.IsComplete = true;
            order.Date = DateTime.Now;
            await _basket.SaveBasket(basket);
            await _order.Update(order);

            order.Items = _basket.GetItems(basket.Id);
            
            foreach(BasketItem item in order.Items)
            {
                item.Product = await _context.GetById(item.ItemId);
            }

            return View(order);
        }
    }
}