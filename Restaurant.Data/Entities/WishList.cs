using Restaurant.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities
{
    public class WishList : EntitiesCommon
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual Customer Customer { get; set; }
        public virtual Guid CustomerId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Guid ProductId { get; set; } 
    }
}
