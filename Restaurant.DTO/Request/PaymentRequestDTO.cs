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
    public class PaymentRequestDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]  
        public string Name { get; set; }
        [JsonIgnore]
        public string? Reference { get; set; }
        [JsonIgnore]
        public Guid CustomerId { get; set; }
        [JsonIgnore]
        public string? CallbackUrl { get; set; }
        //public DateTime PaymentDate { get; set; } = DateTime.Now;
        //public string PaymentMethod { get; set; } // E.g., Credit Card, PayPal, etc.
        //public virtual Order Order { get; set; }
        //public virtual Guid OrderId { get; set; }
    }
}
