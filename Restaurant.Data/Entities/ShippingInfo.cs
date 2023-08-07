using Restaurant.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities
{
    public class ShippingInfo : EntitiesCommon
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string RecipientName { get; set; }

        // Reference the Address class for shipping address details
        public virtual Address ShippingAddress { get; set; }
        public  Guid ShippingAddressId { get; set; }

        public virtual Order Order { get; set; }
        public  Guid OrderId { get; set; }
    }


}
