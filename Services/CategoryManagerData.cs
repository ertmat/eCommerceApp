using System.Collections.Generic;
using System.Linq;
using eCommerceApp.Entities;
using eCommerceApp.Context;

namespace eCommerceApp.Services
{
    public interface ICategory
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Insert(Category category);
        void Update(Category category);
        void Delete(int id);
        int Count();
        void Save();
    }

    public class CategoryManagerData : ICategory
    {
        private readonly AppDbContext _db;

        public CategoryManagerData(AppDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Category.Count();
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if(category != null)
            {
                _db.Category.Remove(category);
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Category;
        }

        public Category GetById(int id)
        {
            return _db.Category.FirstOrDefault(i => i.CategoryId == id);
        }

        public void Insert(Category category)
        {
            _db.Category.Add(category);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            _db.Category.Update(category);
        }
    }
}
