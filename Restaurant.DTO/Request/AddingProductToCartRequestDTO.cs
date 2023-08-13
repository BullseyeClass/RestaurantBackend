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
        public virtual Customer Customer { get; set; }
        public virtual Guid CustomerId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Guid ProductId { get; set; }
    }
}
