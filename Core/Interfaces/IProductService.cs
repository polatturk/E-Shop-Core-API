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
        Task<Response<List<Product>>> GetAllAsync();
        Task<Response<Product>> GetByIdAsync(Guid id);
        Task<Response<Product>> CreateAsync(Product product);
        Task<Response<bool>> Update(Product product);
        Task<Response<bool>> Remove(Guid id);
    }
}
