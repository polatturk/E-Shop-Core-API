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
        Task<Response<List<CartItemResponseDto>>> GetAllAsync();
        Task<Response<CartItemResponseDto>> GetByIdAsync(Guid id);
        Task<Response<CartItemResponseDto>> CreateAsync(AddToCartDto dto);
        Task<Response<bool>> UpdateAsync(CartItemUpdateDto dto);
        Task<Response<bool>> RemoveAsync(Guid id);
    }
}
