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
    public interface IUserService
    {
        Task<Response<List<UserResponseDto>>> GetAllAsync();

        Task<Response<UserResponseDto>> GetByIdAsync(Guid id);

        Task<Response<UserResponseDto>> CreateAsync(UserRegisterDto dto);

        Task<Response<bool>> UpdateAsync(UserUpdateDto dto);

        Task<Response<bool>> RemoveAsync(Guid id);
    }
}
