using eCommerceApp.Context;
using eCommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Services
{
    public interface ICartItem
    {
        IEnumerable<CartItem> GetAll();
        CartItem GetById(int id);
        void Insert(CartItem cart);
        void Update(CartItem cart);
        void Delete(int id);
        int Count();
        void Save();
    }

    public class CartItemManagerData : ICartItem
    {
        private AppDbContext _db;

        public CartItemManagerData(AppDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.CartItem.Count();
        }

        public void Delete(int id)
        {
            var cartItem = GetById(id);
            if(cartItem != null)
            {
                _db.CartItem.Remove(cartItem);
            }
        }

        public IEnumerable<CartItem> GetAll()
        {
            return _db.CartItem;
        }

        public CartItem GetById(int id)
        {
            return _db.CartItem.FirstOrDefault(i => i.CartId == id);
        }

        public void Insert(CartItem cart)
        {
            _db.CartItem.Add(cart);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(CartItem cart)
        {
            _db.CartItem.Update(cart);
        }
    }
}
