using Restaurant.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities
{
    public class Payment : EntitiesCommon
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string TrxRef { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // E.g., Credit Card, PayPal, etc.
        public virtual Order? Order { get; set; }
        public virtual Guid? OrderId { get; set; }
    }

}
