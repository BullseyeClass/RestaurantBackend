using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTO.Response
{
    public class GetProductByIdResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int SKU { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string ProductInfo { get; set; }
        public string ReturnPolicy { get; set; }
        public string DeliveryInfo { get; set; }
        public int QuantityInStock { get; set; }

    }
}
