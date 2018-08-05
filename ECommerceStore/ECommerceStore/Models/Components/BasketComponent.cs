using ECommerceStore.Data;
using ECommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.Components
{
    public class BasketComponent : ViewComponent
    {
        private IInventory _context;
        private IBasket _basket;
        private SignInManager<ApplicationUser> _signInManager { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }

        public BasketComponent(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IInventory context, IBasket basket)
        {
            _context = context;
            _basket = basket;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
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

            return View(basket);
        }
    }
}
