using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record OrderItemCreateDto(Guid ProductId, int Quantity, decimal UnitPrice);

    public record OrderItemResponseDto(Guid Id, Guid ProductId, string ProductName, int Quantity, decimal UnitPrice, decimal TotalPrice);
}
