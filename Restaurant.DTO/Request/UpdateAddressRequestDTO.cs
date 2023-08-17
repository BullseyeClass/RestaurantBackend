using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant.DTO.Request
{
    public class UpdateAddressRequestDTO
    {
        [JsonIgnore]
        public Guid AddressId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int PostalCode { get; set; } = 0;
        public string Country { get; set; } = string.Empty;
        public bool IsShippingAddress { get; set; }
        [JsonIgnore]
        public Guid UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
    }
}
