using Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.Request
{
    public class PaymentRequestDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string PaymentMethod { get; set; } // E.g., Credit Card, PayPal, etc.
        public virtual Order Order { get; set; }
        public virtual Guid OrderId { get; set; }
    }
}
