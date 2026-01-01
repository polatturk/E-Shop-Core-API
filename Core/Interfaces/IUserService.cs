using Core.Entities;
using Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<Response<List<User>>> GetAllAsync();
        Task<Response<User>> GetByIdAsync(Guid id);
        Task<Response<User>> CreateAsync(User user);
        Task<Response<bool>> Update(User user);
        Task<Response<bool>> Remove(Guid id);
    }
}
