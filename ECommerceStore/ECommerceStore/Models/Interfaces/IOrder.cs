using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.Interfaces
{
    public interface IOrder
    {
        Task<string> Add(Order order);
        Task<string> Update(Order order);
        Order Get(int id);
        Task<string> Remove(int id);


    }
}
