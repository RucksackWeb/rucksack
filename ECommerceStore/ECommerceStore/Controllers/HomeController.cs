using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceStore.Models;
using ECommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceStore.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IInventory _context;

        public HomeController(IInventory context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Randomly displaying the feature product
            var products = await _context.GetAll();
            int[] ids = new int[products.Count];
            int counter = 0;

            foreach (Product product in products)
            {
                ids[counter] = product.ID;
                counter++;
            }

            Random rdm = new Random();

            int index = rdm.Next(0, counter - 1);
            int id = ids[index];

            var featured = await _context.GetById(id);

            return View(featured);
        }

    }
}