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
    public partial class OrderItemMapper
    {
        [MapProperty("Product.Name", nameof(OrderItemResponseDto.ProductName))]

        [MapProperty(nameof(OrderItem.Quantity), nameof(OrderItemResponseDto.TotalPrice))]
        public static partial OrderItemResponseDto ToResponseDto(OrderItem item);

        private static decimal MapTotalPrice(OrderItem item)
        {
            return item.Quantity * item.UnitPrice;
        }
    }
}
