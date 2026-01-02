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
        Task<Response<List<Address>>> GetAllAsync();
        Task<Response<Address>> GetByIdAsync(Guid id);
        Task<Response<Address>> CreateAsync(Address address);
        Task<Response<bool>> Update(Address address);
        Task<Response<bool>> Remove(Guid id);
    }
}
