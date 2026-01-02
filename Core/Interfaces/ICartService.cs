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
        Task<Response<List<Cart>>> GetAllAsync();
        Task<Response<Cart>> GetByIdAsync(Guid id);
        Task<Response<Cart>> CreateAsync(Cart cart);
        Task<Response<bool>> Update(Cart cart);
        Task<Response<bool>> Remove(Guid id);
    }
}
