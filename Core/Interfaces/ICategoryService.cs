using Core.Entities;
using Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoryService
    {
        Task<Response<List<Category>>> GetAllAsync();
        Task<Response<Category>> GetByIdAsync(Guid id);
        Task<Response<Category>> CreateAsync(Category category);
        Task<Response<bool>> Update(Category category);
        Task<Response<bool>> Remove(Guid id);
    }
}
