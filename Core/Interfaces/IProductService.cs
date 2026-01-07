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
    public interface IProductService
    {
        Task<Response<List<ProductResponseDto>>> GetAllAsync();
        Task<Response<ProductResponseDto>> GetByIdAsync(Guid id);
        Task<Response<ProductResponseDto>> CreateAsync(ProductCreateDto dto);
        Task<Response<bool>> UpdateAsync(ProductUpdateDto dto);
        Task<Response<bool>> RemoveAsync(Guid id);
    }
}
