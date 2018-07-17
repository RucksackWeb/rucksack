using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}