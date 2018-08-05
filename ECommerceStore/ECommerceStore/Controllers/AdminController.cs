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
        private IBasket _basket;

        public AdminController(UserManager<ApplicationUser> userManager, IInventory inventory, IOrder order, IBasket basket)
        {
            _userManager = userManager;
            _inventory = inventory;
            _order = order;
            _basket = basket;
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
        public async Task<IActionResult> OrderList()
        {
            var orders = _order.GetAllClosed();
            var users = await _userManager.GetUsersInRoleAsync(ApplicationRoles.Member);
            var filteredOrders = orders.OrderByDescending(o => o.Date).Take(20).ToList();

            foreach(Order order in filteredOrders)
            {
                order.Items = _basket.GetItems(order.BasketId);
            }

            var products = await _inventory.GetAll();

            AdminDashboardViewModel advm = new AdminDashboardViewModel
            {
                Orders = filteredOrders,
                Products = products,
                Users = users.ToList()
            };

            return View(advm);
        }


        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> OrderDetail(int id)
        {
            var users = await _userManager.GetUsersInRoleAsync(ApplicationRoles.Member);
            var orders = _order.GetAllClosed();
            var order = orders.FirstOrDefault(o => o.ID == id);
            order.Items = _basket.GetItems(order.BasketId);

            List<Product> products = new List<Product>();
            foreach(BasketItem item in order.Items)
            {
                var product = await _inventory.GetById(item.ItemId);
                products.Add(product);
            }

            AdminDashboardViewModel advm = new AdminDashboardViewModel
            {
                Products = products,
                Order = order,
                Users = users.ToList()
            };

            return View(advm);
        }
    }
}