using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
        public Order Order { get; set; }
    }
}
