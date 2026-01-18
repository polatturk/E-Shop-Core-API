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
    public interface IOrderService
    {
        Task<Response<List<OrderResponseDto>>> GetAllAsync();

        Task<Response<OrderResponseDto>> GetByIdAsync(Guid id);

        Task<Response<OrderResponseDto>> CreateAsync(OrderCreateDto dto, Guid userId);

        Task<Response<bool>> UpdateAsync(OrderUpdateDto dto);

        Task<Response<bool>> RemoveAsync(Guid id);
    }
}
