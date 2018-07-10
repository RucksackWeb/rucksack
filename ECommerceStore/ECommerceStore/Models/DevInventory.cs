using ECommerceStore.Data;
using ECommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
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



        public Task<IActionResult> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Update(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
