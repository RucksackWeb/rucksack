using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.Interfaces
{
    public interface IInventory
    {
        Task<string> Create(Product product);
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<string> Update(int id, Product product);
        Task<string> Delete(int id);
    }
}
