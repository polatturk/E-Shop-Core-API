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
        Task<Response<List<OrderItem>>> GetAllAsync();
        Task<Response<OrderItem>> GetByIdAsync(Guid id);
        Task<Response<OrderItem>> CreateAsync(OrderItem orderItem);
        Task<Response<bool>> Update(OrderItem orderItem);
        Task<Response<bool>> Remove(Guid id);
    }
}
