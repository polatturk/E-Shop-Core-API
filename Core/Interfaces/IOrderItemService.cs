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
    public interface IOrderItemService
    {
        Task<Response<List<OrderItemResponseDto>>> GetAllAsync();

        Task<Response<OrderItemResponseDto>> GetByIdAsync(Guid id);

        Task<Response<OrderItemResponseDto>> CreateAsync(OrderItemCreateDto dto);

        Task<Response<bool>> UpdateAsync(OrderItemUpdateDto dto);

        Task<Response<bool>> RemoveAsync(Guid id);
    }
}
