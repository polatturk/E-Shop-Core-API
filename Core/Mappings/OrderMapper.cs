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
    [UseStaticMapper(typeof(OrderItemMapper))]
    public static partial class OrderMapper
    {
        public static partial Order ToEntity(OrderCreateDto dto);

        public static partial OrderResponseDto ToResponseDto(Order order);

        public static partial List<OrderResponseDto> ToResponseDtoList(List<Order> orders);

        public static partial void UpdateEntityFromDto(OrderUpdateDto dto, Order entity);

    }
}
