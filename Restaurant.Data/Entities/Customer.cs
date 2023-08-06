using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public virtual CustomerSupport CustomerSupport { get; set; }
        public virtual IQueryable<Address> Addresses { get; set; }
        public virtual IQueryable<Order> Orders { get; set;}
        public virtual IQueryable<OrderItem> OrderItems { get; set; }
        public virtual IQueryable<WishList> WishLists { get; set; }
    }
}
