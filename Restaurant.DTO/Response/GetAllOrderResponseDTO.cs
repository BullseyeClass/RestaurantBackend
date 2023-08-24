using Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.Response
{
    public class GetAllOrderResponseDTO
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual Guid CustomerId { get; set; }
    }
}
