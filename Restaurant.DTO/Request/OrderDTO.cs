using Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.Request
{
    public class OrderDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string TrxRef { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Guid CustomerId { get; set; }
        public virtual IQueryable<OrderItem> OrderItems { get; set; }
    }
}
