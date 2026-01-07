using Core.DTOs;
using Core.Entities;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappings
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public static partial class OrderItemMapper 
    {
        public static partial OrderItem ToEntity(OrderItemCreateDto dto);

        public static partial List<OrderItemResponseDto> ToResponseDtoList(List<OrderItem> items);

        [MapProperty("Product.Name", nameof(OrderItemResponseDto.ProductName))]
        [MapProperty(nameof(OrderItem.Quantity), nameof(OrderItemResponseDto.TotalPrice))]
        public static partial OrderItemResponseDto ToResponseDto(OrderItem item);
        public static partial void UpdateEntityFromDto(OrderItemUpdateDto dto, OrderItem entity);

        private static decimal MapTotalPrice(OrderItem item)
        {
            return item.Quantity * item.UnitPrice;
        }
    }
}
