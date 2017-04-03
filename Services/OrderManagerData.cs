using eCommerceApp.Context;
using eCommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Services
{
    public interface IOrder
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Insert(Order order);
        void Delete(int id);
        int Count();
        void Save();
    }

    public class OrderManagerData : IOrder
    {
        private AppDbContext _db;

        public OrderManagerData(AppDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Order.Count();
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if(order != null)
            {
                _db.Order.Remove(order);
            }
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Order;
        }

        public Order GetById(int id)
        {
            return _db.Order.FirstOrDefault(i => i.OrderId == id);
        }

        public void Insert(Order order)
        {
            _db.Order.Add(order);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
