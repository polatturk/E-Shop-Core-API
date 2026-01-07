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
    public static partial class ProductMapper
    {
        public static partial Product ToEntity(ProductCreateDto dto);

        [MapProperty("Category.Name", nameof(ProductResponseDto.CategoryName))]
        public static partial ProductResponseDto ToResponseDto(Product product);

        public static partial List<ProductResponseDto> ToResponseDtoList(List<Product> products);

        public static partial void UpdateEntityFromDto(ProductUpdateDto dto, Product entity);
    }
}
