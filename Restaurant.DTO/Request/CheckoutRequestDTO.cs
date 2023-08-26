using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.Request
{
    public class CheckoutRequestDTO
    {
        public Guid CustomerId { get; set; } // Assuming you have a way to identify the customer
        public List<OrderItemRequestDTO> Items { get; set; } // List of selected items

    }
}
