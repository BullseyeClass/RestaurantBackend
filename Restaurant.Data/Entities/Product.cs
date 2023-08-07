using Restaurant.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities
{
    public class Product : EntitiesCommon
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Tag { get; set; }
        public string Image { get; set; }
        public int SKU { get; set; }
        public bool MostPopular { get; set; }
        public bool BestDeal { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string ProductInfo { get; set; }
        public string ReturnPolicy { get; set; }
        public string DeliveryInfo { get; set; }
        public int QuantityInStock { get; set; }
        //public virtual OrderItem OrderItem { get; set; }
        //public virtual Guid OrderItemsId { get; set; }
    }
}
