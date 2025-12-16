using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public Guid ShippingAddressId { get; set; }
        public Address ShippingAddress { get; set; }

        public Guid BillingAddressId { get; set; }
        public Address BillingAddress { get; set; }

        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
