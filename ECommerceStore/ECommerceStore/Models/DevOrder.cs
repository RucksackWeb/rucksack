using ECommerceStore.Data;
using ECommerceStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models
{
    public class DevOrder : IOrder
    {
        private UserDbContext _context { get; set; }

        public DevOrder(UserDbContext context)
        {
            _context = context;
        }

        public async Task<string> Add(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return "complete";
        }

        public async Task<string> Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return "complete";
        }

        public Order Get(int basketId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.BasketId == basketId);
            return order;
        }

        public Order Get(string userId)
        {
            var order = _context.Orders.Where(o => o.UserId == userId).FirstOrDefault(o => o.IsComplete == false);
            return order;
        }

        public List<Order> GetAllClosed()
        {
            var orders = _context.Orders.Where(o => o.IsComplete == true).ToList();
            return orders;
        }

        public async Task<string> Remove(int id)
        {
            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return "complete";
        }
    }
}
