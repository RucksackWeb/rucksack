using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceStore.Models;
using ECommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceStore.Pages
{
    [Authorize]
    public class UserProfileModel : PageModel
    {
        private IOrder _orders;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public ApplicationUser profileInfo { get; set; }
        public List<Order> userOrders { get; set; }


        public UserProfileModel(IOrder orders, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _orders = orders;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            profileInfo = user;

            userOrders = _orders.GetUserClosedOrders(user.Id, 3);
        }
    }
}