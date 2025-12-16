using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }

        // --- Navigation Property'ler ---
        public ICollection<Address> Addresses { get; set; } // Bir kullanıcının birden çok adresi olabilir
        public ICollection<Order> Orders { get; set; } // Bir kullanıcının birden çok siparişi olabilir
        public Cart Cart { get; set; } // Kullanıcının tek bir sepeti vardır
    }
}
