using ECommerceStore.Data;
using ECommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models
{
    public class DevInventory : IInventory
    {
        private WarehouseDbContext _context;

        public DevInventory(WarehouseDbContext context)
        {
            _context = context;
        }



        public async Task<string> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return "Successfully created a product";
        }


        public async Task<string> Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ID == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            
            if(product == null)
            {
                return "Successfully Deleted a product";
            }
            else
            {
                return "Product has not been deleted";
            }
        }

        
        public async Task<List<Product>> GetAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products; ;
        }


        public async Task<Product> GetById(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.ID == id);
            return product;
        }


        public async Task<string> Update(int id, Product product)
        {
            var dbproduct = _context.Products.FirstOrDefault(p => p.ID == id);
            if(dbproduct.ID == product.ID)
            {
                dbproduct.SKU = product.SKU;
                dbproduct.Name = product.Name;
                dbproduct.Price = product.Price;
                dbproduct.Description = product.Description;
                dbproduct.Image = product.Image;
                dbproduct.Quantity = product.Quantity;
                dbproduct.ProductCategory = product.ProductCategory;

                _context.Products.Update(dbproduct);
                await _context.SaveChangesAsync();

                return "Update complete";
            }
            else
            {
                return "Failed to update";
            }
            
        }
    }
}
