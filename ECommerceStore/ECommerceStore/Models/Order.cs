using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public int BasketId { get; set; }

        [Display(Name = "Shipping Address")]
        public string Address { get; set; }

        [Display(Name = "Time of Transaction")]
        public DateTime Date { get; set; }

        public List<BasketItem> Items { get; set; }

        public decimal Subtotal { get; set; }
        public bool IsComplete { get; set; } = false;

    }
}
