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
    public partial class CartItemMapper
    {
        [MapProperty("Product.Name", nameof(CartItemResponseDto.ProductName))]

        [MapProperty("Product.ImageUrl", nameof(CartItemResponseDto.ImageUrl))]

        [MapProperty("Product.Price", nameof(CartItemResponseDto.UnitPrice))]

        [MapProperty(nameof(CartItem.Quantity), nameof(CartItemResponseDto.TotalPrice))]

        public static partial CartItemResponseDto ToResponseDto(CartItem item);

        private static decimal MapTotalPrice(CartItem item)
        {
            return item.Quantity * item.Product.Price;
        }
    }
}
