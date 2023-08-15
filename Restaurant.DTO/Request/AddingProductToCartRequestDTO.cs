using Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.Request
{
    public class AddingProductToCartRequestDTO
    {
        [Required]
        public int Quantity { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
