using eCommerceApp.Context;
using eCommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Services
{
    public interface IOrderLine
    {
        IEnumerable<OrderLine> GetAll();
        OrderLine GetById(int id);
        void Insert(OrderLine orderLine);
        void Update(OrderLine orderLine);
        int Count();
        void Save();
    }

    public class OrderLineManagerData : IOrderLine
    {
        private AppDbContext _db;

        public OrderLineManagerData(AppDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.OrderLine.Count();
        }

        public IEnumerable<OrderLine> GetAll()
        {
            return _db.OrderLine;
        }

        public OrderLine GetById(int id)
        {
            return _db.OrderLine.FirstOrDefault(i => i.OrderLineId == id);
        }

        public void Insert(OrderLine orderLine)
        {
            _db.OrderLine.Add(orderLine);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(OrderLine orderLine)
        {
            _db.OrderLine.Update(orderLine);
        }
    }
}
