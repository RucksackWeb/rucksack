using ECommerceStore.Data;
using ECommerceStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models
{
    public class DevBasket : IBasket
    {
        private WarehouseDbContext _context;

        public DevBasket(WarehouseDbContext context)
        {
            _context = context;
        }


        public async Task<string> CreateBasket(Basket basket)
        {
            await _context.Baskets.AddAsync(basket);
            await _context.SaveChangesAsync();
            return "complete";
        }

        public async Task<string> CreateItem(BasketItem item)
        {
            await _context.CartItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return "complete";
        }

        public async Task<string> SaveBasket(Basket basket)
        {
            _context.Baskets.Update(basket);
            await _context.SaveChangesAsync();
            return "complete";
        }

        public async Task<string> SaveItem(BasketItem item)
        {
            _context.CartItems.Update(item);
            await _context.SaveChangesAsync();
            return "complete";
        }


        public Basket GetBasketById(string userid)
        {
            var basket = _context.Baskets.Where(b => b.UserId == userid).FirstOrDefault(b => b.IsComplete == false);
            return basket;
        }


        public BasketItem GetItemById(int basketid)
        {
            var cartItem = _context.CartItems.FirstOrDefault(i => i.BasketId == basketid);
            return cartItem;
        }

        public List<BasketItem> GetItems(int basketId)
        {
            var items = _context.CartItems.Where(i => i.BasketId == basketId).ToList();
            return items;
        }


        // need to move this method to somewhere else
        // being used for view component
        //public async Task<Basket> GetBasket(string userId)
        //{
        //    if (GetBasketById(userId) == null)
        //    {
        //        Basket newBasket = new Basket();
        //        newBasket.UserId = userId;
        //        await _context.Baskets.AddAsync(newBasket);
        //    }

        //    Basket basket = _context.Baskets.Where(b => b.UserId == userId).FirstOrDefault(b => b.IsComplete == false);
        //    List<BasketItem> items = _context.CartItems.Where(i => i.BasketId == basket.Id).ToList();

        //    if (items != null)
        //    {
        //        basket.TotalCost = 0;
        //        foreach (BasketItem item in items)
        //        {
        //            Product product = _context.Products.FirstOrDefault(p => p.ID == item.ItemId);
        //            item.Product = product;

        //            item.Cost = decimal.Multiply(Convert.ToDecimal(item.Quantity), product.Price);
        //            basket.TotalCost += item.Cost;
        //        }
        //        _context.Baskets.Update(basket);
        //        await _context.SaveChangesAsync();
        //    }

        //    basket.CartItem = items;
        //    return basket;
        //}


        public async Task<string> Update(int id, BasketItem item)
        {
            var dbItem = _context.CartItems.FirstOrDefault(i => i.Id == id);
            if (dbItem.Id == item.Id)
            {
                dbItem.Quantity = item.Quantity;
                dbItem.Cost = item.Cost;

                _context.CartItems.Update(dbItem);
                await _context.SaveChangesAsync();
            }
            return "complete";
        }


        public async Task<string> RemoveItem(int id)
        {
            var item = _context.CartItems.FirstOrDefault(i => i.Id == id);
            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
            return "complete";
        }
    }
}
