using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record CartResponseDto(Guid Id, Guid UserId, decimal TotalAmount, List<CartItemResponseDto> Items);
}
