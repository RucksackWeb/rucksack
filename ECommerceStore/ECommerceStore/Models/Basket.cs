using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool IsComplete { get; set; } = false;
        public decimal TotalCost { get; set; } = 0;
        public List<BasketItem> CartItem { get; set; }
    }
}
