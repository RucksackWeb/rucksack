using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private IBasket _basket;
        private IInventory _inventory;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public ApplicationUser profileInfo { get; set; }
        public List<Order> userOrders { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }
            


        public UserProfileModel(IOrder orders, IBasket basket, IInventory inventory, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _orders = orders;
            _basket = basket;
            _inventory = inventory;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            profileInfo = user;
            userOrders = _orders.GetUserClosedOrders(user.Id, 3);

            foreach (var order in userOrders)
            {
                order.Items = _basket.GetItems(order.BasketId);

                foreach (var item in order.Items)
                {
                    item.Product = await _inventory.GetById(item.ItemId);
                }

            };
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userManager.GetUserAsync(User);

            user.FirstName = FirstName;
            user.LastName = LastName;

            await _userManager.UpdateAsync(user);

            Claim claim = User.Claims.First(c => c.Type == "FullName");
            Claim newClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

            await _userManager.RemoveClaimAsync(user, claim);
            await _userManager.AddClaimAsync(user, newClaim);

            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, false);

            profileInfo = user;
            userOrders = _orders.GetUserClosedOrders(user.Id, 3);

            return new RedirectToPageResult("UserProfile");
        }
    }
}