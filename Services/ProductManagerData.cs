using eCommerceApp.Context;
using eCommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Services
{
    public interface IProduct
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Insert(Product product);
        void Update(Product product);
        void Delete(int id);
        int Count();
        void Save();
    }

    public class ProductManagerData : IProduct
    {
        private AppDbContext _db;

        public ProductManagerData(AppDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Product.Count();
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if(product != null)
            {
                _db.Product.Remove(product);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Product;
        }

        public Product GetById(int id)
        {
            return _db.Product.FirstOrDefault(i => i.ProductId == id);
        }

        public void Insert(Product product)
        {
            _db.Product.Add(product);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product product)
        {
            _db.Product.Update(product);
        }
    }
}
