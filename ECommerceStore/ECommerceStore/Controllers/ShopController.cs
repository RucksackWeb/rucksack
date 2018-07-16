using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceStore.Models.Interfaces;
using ECommerceStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceStore.Controllers
{
    public class ShopController : Controller
    {
        private IInventory _context { get; set; }

        public ShopController(IInventory context)
        {
            _context = context;
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
    }
}