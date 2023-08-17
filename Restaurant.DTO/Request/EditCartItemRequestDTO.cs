using Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant.DTO.Request
{
    public class EditCartItemRequestDTO
    {
        [JsonIgnore]
        public Guid CartItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [JsonIgnore]
        public Guid UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
    }
}
