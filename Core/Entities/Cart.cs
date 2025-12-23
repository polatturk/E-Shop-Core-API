using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cart : BaseEntity
    {
        public DateTime? UpdatedDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> Items { get; set; }
    }
}
