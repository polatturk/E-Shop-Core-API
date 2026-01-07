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
    public static partial class CategoryMapper
    {
        public static partial Category ToEntity(CategoryCreateDto dto);

        public static partial CategoryResponseDto ToResponseDto(Category category);

        public static partial List<CategoryResponseDto> ToResponseDtoList(List<Category> categories);

        public static partial void UpdateEntityFromDto(CategoryUpdateDto dto, Category entity);

    }
}
