using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.Request
{
    public class RequestingCustomerSupportDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Message Field is required")]
        public string Message { get; set; }
        public string CustomerId { get; set; }
    }
}
