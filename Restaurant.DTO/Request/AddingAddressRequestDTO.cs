﻿using Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant.DTO.Request
{
    public class AddingAddressRequestDTO
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int PostalCode { get; set; } = 0;
        public string Country { get; set; } = string.Empty;
        //public  Customer Customer { get; set; }
        [JsonIgnore]
        public Guid CustomerId { get; set; }
        public bool IsShippingAddress { get; set; }
    }
}
