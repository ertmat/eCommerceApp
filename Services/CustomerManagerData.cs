using eCommerceApp.Context;
using eCommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Services
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(string id);
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(string id);
        void Save();
    }

    public class CustomerManagerData : ICustomer
    {
        private AppDbContext _db;

        public CustomerManagerData(AppDbContext db)
        {
            _db = db;
        }

        public void Delete(string id)
        {
            var customer = GetById(id);
            if(customer != null)
            {
                _db.Customer.Remove(customer);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            return _db.Customer;
        }

        public Customer GetById(string id)
        {
            return _db.Customer.FirstOrDefault(i => i.Id == id);
        }

        public void Insert(Customer customer)
        {
            _db.Customer.Add(customer);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _db.Customer.Update(customer);
        }
    }
}
