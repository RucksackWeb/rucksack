using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.Interfaces
{
    public interface IInventory
    {
        Task<IActionResult> Create(Product product);
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Update(int id, Product product);
        Task<IActionResult> Delete(int id);
    }
}
