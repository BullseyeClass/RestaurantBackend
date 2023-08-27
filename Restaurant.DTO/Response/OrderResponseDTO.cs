using Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.Response
{
    public class OrderResponseDTO
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string TrxRef { get; set; }
        public  Guid CustomerId { get; set; }
        
    }
}
