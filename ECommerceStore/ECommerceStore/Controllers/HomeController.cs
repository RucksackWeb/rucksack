using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
            var featured = await _context.GetById(5);

            return View(featured);
        }

    }
}