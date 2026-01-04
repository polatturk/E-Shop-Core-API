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
    [UseStaticMapper(typeof(CartItemMapper))] 
    public partial class CartMapper
    {
        public partial CartResponseDto ToResponseDto(Cart cart);
    }
}
