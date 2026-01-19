using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum OrderStatus
    {
        Pending = 1,    // Beklemede
        Processing = 2, // Hazırlanıyor
        Shipped = 3,    // Kargolandı
        Completed = 4,  // Teslim Edildi
        Cancelled = 5   // İptal Edildi
    }
}
