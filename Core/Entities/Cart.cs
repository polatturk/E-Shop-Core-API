using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> Items { get; set; }
    }
}
