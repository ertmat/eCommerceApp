using eCommerceApp.Context;
using eCommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Services
{
    public interface IPicture
    {
        Picture GetById(int id);
        void Insert(Picture picture);
        void Update(Picture picture);
        void Delete(int id);
        void Save();
    }

    public class PictureManagerData : IPicture
    {
        private AppDbContext _db;

        public PictureManagerData(AppDbContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var picture = GetById(id);
            if(picture != null)
            {
                _db.Picture.Remove(picture);
            }
        }

        public Picture GetById(int id)
        {
            return _db.Picture.FirstOrDefault(i => i.PictureId == id);
        }

        public void Insert(Picture picture)
        {
            _db.Picture.Add(picture);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Picture picture)
        {
            _db.Picture.Update(picture);
        }
    }
}
