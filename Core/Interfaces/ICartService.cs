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
    public interface ICartService
    {
        Task<Response<List<CartResponseDto>>> GetAllAsync();

        Task<Response<CartResponseDto>> GetByIdAsync(Guid id);

        Task<Response<bool>> RemoveAsync(Guid id);
    }
}
