using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.Interfaces
{
    public interface IBasket
    {
        Task<string> CreateBasket(Basket basket);
        Task<string> CreateItem(BasketItem item);

        Task<string> SaveBasket(Basket basket);
        Task<string> SaveItem(BasketItem item);

        Basket GetBasketById(string userid);
        BasketItem GetItemById(int basketid);

        List<BasketItem> GetItems(int basketId);

        Task<string> Update(int id, BasketItem item);
        Task<string> RemoveItem(int id);
    }
}
