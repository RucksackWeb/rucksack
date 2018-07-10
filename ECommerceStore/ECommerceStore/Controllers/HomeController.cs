using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceStore.Controllers
{
    public class HomeController : Controller
    {
        private IInventory _context;

        public HomeController(IInventory context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}