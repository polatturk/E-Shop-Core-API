using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record OrderCreateDto(Guid UserId, Guid ShippingAddressId, Guid BillingAddressId, List<OrderItemCreateDto> OrderItems);
    public record OrderResponseDto(Guid Id, DateTime OrderDate, decimal TotalAmount, OrderStatus Status, List<OrderItemResponseDto> OrderItems);
}
