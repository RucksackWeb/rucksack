using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.ViewModels
{
    public class BasketViewModels
    {
        public Basket Package { get; set; }
        public int basketItemId { get; set; }
        public int basketItemQuantity { get; set; }
    }
}
