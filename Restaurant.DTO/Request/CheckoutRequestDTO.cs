using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant.DTO.Request
{
    public class CheckoutRequestDTO
    {
        [JsonIgnore]
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemRequestDTO> Items { get; set; } // List of selected items

    }
}
