using ECommerceStore.Models;
using ECommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private IBasket _basket;
        private IInventory _context;

        private SignInManager<ApplicationUser> _signInManager { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }

        public BasketController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IBasket basket, IInventory context)
        {
            _context = context;
            _basket = basket;
            _signInManager = signInManager;
            _userManager = userManager;

        }

        // AddProduct, add a new product to a basket
        public async Task<IActionResult> AddToCart(int productId)
        {

            string userId = _userManager.GetUserId(User);
            Product product = await _context.GetById(productId);
            if(_basket.GetBasketById(userId) == null)
            {
                Basket newBasket = new Basket();
                newBasket.UserId = userId;
                await _basket.CreateBasket(newBasket);
            }

            Basket basket = _basket.GetBasketById(userId);
            //BasketItem item = _basket.GetItemById(basket.Id);
            List<BasketItem> items = _basket.GetItems(basket.Id);

            if (items == null || items.FirstOrDefault(i => i.ItemId == product.ID) == null)
            {
                BasketItem cartItem = new BasketItem
                {
                    BasketId = basket.Id,
                    ItemId = product.ID,
                    Product = product,
                    Quantity = 1,
                    Cost = product.Price
                };
                basket.TotalCost += cartItem.Cost;

                // _basket.SaveBasket(basket);
               await  _basket.CreateItem(cartItem);
            }
            else
            {
                BasketItem item = items.FirstOrDefault(i => i.ItemId == product.ID);
                item.Quantity += 1;
                basket.TotalCost -= item.Cost;
                item.Cost = decimal.Multiply(Convert.ToDecimal(item.Quantity), item.Product.Price);
                basket.TotalCost += item.Cost;

                await _basket.SaveItem(item);
            }
            await _basket.SaveBasket(basket);

            return RedirectToAction("Index", "Shop");
        }




        // retreive basket object with list of basketitems for view component
        public async Task<Basket> GetBasket(string userId)
        {
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
            return basket;
        }



            // Update quantity of a product
            // Update quantity of a product in the cart view
            [HttpPost]
            public void Update(int itemId, int quantity)
            {
                BasketItem item = _basket.GetItemById(itemId);

                if (quantity == 0)
                {
                    _basket.RemoveItem(itemId);
                }
                else
                {
                    item.Quantity = quantity;
                    item.Cost = decimal.Multiply(Convert.ToDecimal(quantity), item.Product.Price);

                    _basket.SaveItem(item);
                }
            }




            // Delete, a product from basket
            public IActionResult RemoveProduct(int id)
            {
                _basket.RemoveItem(id);
                return RedirectToAction("CartPage", "Shop");
            }
        
        
    }
}