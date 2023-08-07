using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities
{
    public class Customer : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public virtual CustomerSupport? CustomerSupport { get; set; }
        public virtual IQueryable<Address>? Addresses { get; set; }
        public virtual IQueryable<Order>? Orders { get; set;}
        public virtual IQueryable<WishList>? WishLists { get; set; }
    }
}
