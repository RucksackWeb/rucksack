using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceStore.Models;
using ECommerceStore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceStore.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
         //View
        public IActionResult Index()
        {
            return View();
        }

        // Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, isPersistent: true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(lvm.Email);

                if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Admin))
                {
                    return RedirectToAction("Index", "Admin");
                }

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = rvm.Email,
                Email = rvm.Email,
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                Subscribe = rvm.Subscribe
            };

            var result = await _userManager.CreateAsync(user, rvm.Password);

            if (result.Succeeded)
            {
                List<Claim> claimList = new List<Claim>();

                Claim nameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                Claim emailClaim = new Claim(ClaimTypes.Email, user.Email);
                Claim roleClaim = new Claim(ClaimTypes.Role, "Member");

                if (user.Subscribe)
                {
                    Claim subscribeClaim = new Claim("Subscription", $"{user.Subscribe}");
                    claimList.Add(subscribeClaim);
                }

                claimList.Add(nameClaim);
                claimList.Add(emailClaim);
                claimList.Add(roleClaim);

                await _userManager.AddClaimsAsync(user, claimList);

                await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);

                await _signInManager.SignInAsync(user, false);

                
                if (user.Email.Contains("@codefellows.com"))
                {
                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                    Claim adminRoleClaim = new Claim(ClaimTypes.Role, ApplicationRoles.Admin);
                    await _userManager.AddClaimAsync(user, adminRoleClaim);

                    return RedirectToAction("Index", "Admin");
                }

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //Log Out
        public async Task<IActionResult> LogOut()
        {
            if (_signInManager.IsSignedIn(User))
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}