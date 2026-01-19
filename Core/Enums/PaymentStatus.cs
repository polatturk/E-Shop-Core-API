using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum PaymentStatus
    {
        Pending = 1,   // Ödeme bekleniyor
        Success = 2, // Ödeme başarıyla tamamlandı
        Failed = 3,    // Ödeme başarısız/Hatalı
        Refunded = 4   // İade edildi
    }
}
