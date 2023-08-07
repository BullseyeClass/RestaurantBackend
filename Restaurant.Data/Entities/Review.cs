using Restaurant.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities
{
    public class Review : EntitiesCommon
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; } // E.g., on a scale of 1 to 5.
        public DateTime DatePosted { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Guid CustomerId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Guid ProductId { get; set; }
    }

}
