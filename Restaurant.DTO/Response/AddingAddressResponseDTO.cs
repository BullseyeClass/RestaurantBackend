using Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.Response
{
    public class AddingAddressResponseDTO
    {
        public Guid Id { get; set; } 
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int PostalCode { get; set; } = 0;
        public string Country { get; set; } = string.Empty;
        public virtual Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsShippingAddress { get; set; }
    }
}
