using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record AddToCartDto(Guid ProductId, int Quantity);

    public record CartItemUpdateDto(Guid Id, int Quantity);

    public record CartItemResponseDto(Guid Id, Guid ProductId, string ProductName, string ImageUrl, int Quantity, decimal UnitPrice, decimal TotalPrice);
}
