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

            return View(basket);
        }


        [HttpGet]
        public async Task<IActionResult> Checkout(int basketId)
        {
            string userId = _userManager.GetUserId(User);
            var basket = await _basket.GetBasket(userId);
            List<BasketItem> items = _basket.GetItems(basketId);
            
            if(items == null)
            {
                return RedirectToAction("CartPage");
            }


            foreach(BasketItem item in items)
            {
                var product = await _context.GetById(item.ItemId);
                item.Product = product;
            }

            if(_order.Get(basketId) == null)
            {
                Order newOrder = new Order
                {
                    UserId = userId,
                    BasketId = basketId,
                    Subtotal = basket.TotalCost,
                    Items = items
                };
                
                await _order.Add(newOrder);
            }

            Order order = _order.Get(basketId);

            return View(order);
        }
    }
}