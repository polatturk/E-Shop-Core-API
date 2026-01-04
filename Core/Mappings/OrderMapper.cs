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
    public partial class OrderMapper
    {
        public partial Order ToEntity(OrderCreateDto dto);

        public partial OrderResponseDto ToResponseDto(Order order);

        public partial List<OrderResponseDto> ToResponseDtoList(List<Order> orders);
    }
}
