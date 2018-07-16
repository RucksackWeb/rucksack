using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceStore.Data;
using ECommerceStore.Models;
using ECommerceStore.Models.Interfaces;
using ECommerceStore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceStore.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

        private IInventory _context { get; set; }

        public ProductController(IInventory context)
        {
            _context = context;
        }



        public IActionResult index()
        {
            return View();
        }


        public async Task<IActionResult> GetAll()
        {
            List<Product> products= await _context.GetAll();
            DisplayProducts allProducts = new DisplayProducts();
            allProducts.Products = products; 
            return View(allProducts);
        }


        public async Task<IActionResult> GetById(int id)
        {
            Product product =  await _context.GetById(id);
            return View(product);
        }



        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var result = await _context.Create(product);
                return View();
            }

            else
            {

                ModelState.AddModelError(string.Empty, "");
                return View();

            }
        }




        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _context.GetById(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Product product)
        {
            string result = await _context.Update(id, product);
            if(result == "Update complete")
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                //ModelState.AddModelError(string.Empty, "Your Credential Is Incorrect");
                return View(product);
            }
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Delete(id);
            return Redirect("GetAll");
        }
    }
}
