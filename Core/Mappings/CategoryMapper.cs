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
    public partial class CategoryMapper
    {
        // CreateDto -> Entity
        public static partial Category ToEntity(CategoryCreateDto dto);

        // UpdateDto -> Entity
        public static partial Category ToEntity(CategoryUpdateDto dto);

        // Entity -> ResponseDto
        public static partial CategoryResponseDto ToResponseDto(Category category);

        // Liste halindeki kategorileri dönüştürmek için
        public static partial List<CategoryResponseDto> ToResponseDtoList(List<Category> categories);
    }
}
