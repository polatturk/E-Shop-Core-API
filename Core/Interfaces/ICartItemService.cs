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
    public interface ICartItemService
    {
        Task<Response<List<CartItemResponseDto>>> GetAllByUserIdAsync(Guid userId);
        Task<Response<CartItemResponseDto>> GetByIdAsync(Guid id, Guid userId);
        Task<Response<CartItemResponseDto>> CreateAsync(AddToCartDto dto, Guid userId);
        Task<Response<bool>> UpdateAsync(CartItemUpdateDto dto, Guid userId);
        Task<Response<bool>> RemoveAsync(Guid id, Guid userId);
    }
}
