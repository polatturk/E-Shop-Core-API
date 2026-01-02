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
        Task<Response<List<Order>>> GetAllAsync();
        Task<Response<Order>> GetByIdAsync(Guid id);
        Task<Response<Order>> CreateAsync(Order order);
        Task<Response<bool>> Update(Order order);
        Task<Response<bool>> Remove(Guid id);
    }
}
