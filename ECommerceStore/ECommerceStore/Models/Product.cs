using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Display(Name = "Model Number")]
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        [Display(Name = "Product Image")]
        public string Image { get; set; }
        public int Quantity { get; set; }

        [Display(Name = "Product Category")]
        public Category ProductCategory { get; set; }
    }

    public enum Category
    {
        Gadget,
        Speaker,
        Bags
    }
}
