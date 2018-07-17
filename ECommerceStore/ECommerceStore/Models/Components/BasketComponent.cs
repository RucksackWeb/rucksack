using ECommerceStore.Data;
using ECommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.Components
{
    public class BasketComponent : ViewComponent
    {
        private IBasket _allItems; //

        public BasketComponent(IBasket allItems)
        {
            _allItems = allItems;
        }

        public IViewComponentResult Invoke(int userId)
        {
            var userCart = _allItems.GetBasket(userId);

            return View(userCart);
        }
    }
}
