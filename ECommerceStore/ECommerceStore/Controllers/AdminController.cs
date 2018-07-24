using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ECommerceStore.Models.Interfaces;
using ECommerceStore.Models.ViewModels;

namespace ECommerceStore.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IInventory _inventory;
        private IOrder _order;

        public AdminController(UserManager<ApplicationUser> userManager, IInventory inventory, IOrder order)
        {
            _userManager = userManager;
            _inventory = inventory;
            _order = order;
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.GetUsersInRoleAsync(ApplicationRoles.Member);
            var products = await _inventory.GetAll();
            var orders = _order.GetAllClosed();

            AdminDashboardViewModel advm = new AdminDashboardViewModel
            {
                Users = users.ToList(),
                Products = products,
                Orders = orders
            };
            return View(advm);
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.GetUsersInRoleAsync(ApplicationRoles.Member);
            AdminDashboardViewModel advm = new AdminDashboardViewModel
            {
                Users = users.ToList()
            };
            return View(advm);
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult OrderList()
        {
            var orders = _order.GetAllClosed();

            AdminDashboardViewModel advm = new AdminDashboardViewModel
            {
                Orders = orders
            };

            return View(advm);
        }
        
    }
}