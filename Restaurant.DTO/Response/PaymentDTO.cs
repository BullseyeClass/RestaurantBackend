using Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.Response
{
    public class PaymentDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // E.g., Credit Card, PayPal, etc.
        public virtual Order Order { get; set; }
        public virtual Guid OrderId { get; set; }
    }
}
