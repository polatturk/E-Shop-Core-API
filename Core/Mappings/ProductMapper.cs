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
    public partial class ProductMapper
    {
        public partial Product ToEntity(ProductCreateDto dto);

        public partial Product ToEntity(ProductUpdateDto dto);

        [MapProperty(nameof(Product.Category.Name), nameof(ProductResponseDto.CategoryName))]
        public partial ProductResponseDto ToResponseDto(Product product);

        public partial List<ProductResponseDto> ToResponseDtoList(List<Product> products);
    }
}
