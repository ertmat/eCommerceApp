using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Entities
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            OrderLines = new HashSet<OrderLine>();
        }

        public int ProductId { get; set; }
        [Required, Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string ProductDetails { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public byte[] ImagePath { get; set; }

        public int? CategoryId { get; set; }
        public int? PictureId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
