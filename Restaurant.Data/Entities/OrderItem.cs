using Restaurant.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities
{
    public class OrderItem : EntitiesCommon
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Quantity { get; set; }
        public virtual Customer Customer { get; set; } = new Customer();
        public virtual Order Order { get; set; } = new Order();
        public  Guid OrderId { get; set; }
        public virtual Product Products { get; set; }
        public Guid ProductId { get; set; }

    }
}
