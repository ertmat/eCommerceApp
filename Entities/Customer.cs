using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Entities
{
    [Table("Customer")]
    public class Customer : IdentityUser
    {
        public Customer()
        {
            CartItems = new HashSet<CartItem>();
            Orders = new HashSet<Order>();
        }
        
        [Required(ErrorMessage = "Customer name is required")]
        public string CustomerName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }
        public DateTime? DateEntered { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
