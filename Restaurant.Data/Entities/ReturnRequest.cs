using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities
{
    public class ReturnRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Reason { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsApproved { get; set; }
        public virtual OrderItem OrderItem { get; set; }
        public  Guid OrderItemId { get; set; }
    }

}
