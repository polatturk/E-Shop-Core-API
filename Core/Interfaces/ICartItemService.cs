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
        Task<Response<List<CartItem>>> GetAllAsync();
        Task<Response<CartItem>> GetByIdAsync(Guid id);
        Task<Response<CartItem>> CreateAsync(CartItem cartItem);
        Task<Response<bool>> Update(CartItem cartItem);
        Task<Response<bool>> Remove(Guid id);
    }
}
