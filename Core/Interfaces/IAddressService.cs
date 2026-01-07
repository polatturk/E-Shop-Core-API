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
    public interface IAddressService
    {
        Task<Response<List<AddressResponseDto>>> GetAllAsync();

        Task<Response<AddressResponseDto>> GetByIdAsync(Guid id);

        Task<Response<AddressResponseDto>> CreateAsync(AddressCreateDto dto);

        Task<Response<bool>> UpdateAsync(AddressUpdateDto dto);

        Task<Response<bool>> RemoveAsync(Guid id);
    }
}
