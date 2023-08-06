using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities
{
    public class CustomerSupport
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Guid CustomerId { get; set; }
    }
}
