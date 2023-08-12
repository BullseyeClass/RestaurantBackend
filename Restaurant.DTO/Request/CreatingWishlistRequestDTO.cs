using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.Request
{
    public class CreatingWishlistRequestDTO
    {
        public  Guid ProductId { get; set; }
        public  string CustomerId { get; set; }

    }
}
