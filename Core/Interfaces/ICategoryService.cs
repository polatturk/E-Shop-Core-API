using Core.DTOs;
using Core.Entities;
using Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryResponseDto>>> GetAllAsync();

        Task<Response<CategoryResponseDto>> GetByIdAsync(Guid id);

        Task<Response<CategoryResponseDto>> CreateAsync(CategoryCreateDto dto);

        Task<Response<bool>> UpdateAsync(CategoryUpdateDto dto);

        Task<Response<bool>> RemoveAsync(Guid id);
    }
}
