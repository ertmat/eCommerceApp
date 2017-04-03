using eCommerceApp.Context;
using eCommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Services
{
    public interface ISubCategory
    {
        IEnumerable<SubCategory> GetAll();
        SubCategory GetById(int id);
        void Insert(SubCategory subCategory);
        void Update(SubCategory subCategory);
        void Delete(int id);
        int Count();
        void Save();
    }

    public class SubCategoryManagerData : ISubCategory
    {
        private AppDbContext _db;

        public SubCategoryManagerData(AppDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.SubCategory.Count();
        }

        public void Delete(int id)
        {
            var subCategory = GetById(id);
            if(subCategory != null)
            {
                _db.SubCategory.Remove(subCategory);
            }
        }

        public IEnumerable<SubCategory> GetAll()
        {
            return _db.SubCategory;
        }

        public SubCategory GetById(int id)
        {
            return _db.SubCategory.FirstOrDefault(i => i.CategoryId == id);
        }

        public void Insert(SubCategory subCategory)
        {
            _db.SubCategory.Add(subCategory);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(SubCategory subCategory)
        {
            _db.SubCategory.Update(subCategory);
        }
    }
}
