using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsComplete { get; set; }
        public decimal TotalCost { get; set; }
        public List<BasketItem> CartItem { get; set; }
    }
}
