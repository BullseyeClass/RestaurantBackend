using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Quantity { get; set; }
        public virtual Customer Customer { get; set; } = new Customer();
        public virtual Order Order { get; set; } = new Order();
        public virtual Guid OrderId { get; set; }
        public virtual IQueryable<Product>? Products { get; set; }

    }
}
