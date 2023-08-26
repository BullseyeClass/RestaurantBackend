using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.Request
{
    public class OrderItemRequestDTO
    {
        public Guid ProductId { get; set; } // Assuming you have a way to identify the product
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
    }
}
