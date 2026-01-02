using Core.Entities;
using Core.Interfaces;
using Core.Response;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AddressService(IGenericRepository<Address> _repository) : IAddressService
    {
        public async Task<Response<List<Address>>> GetAllAsync()
        {
            var addresses = await _repository.GetAll().ToListAsync();
            return Response<List<Address>>.Success(addresses, 200);
        }

        public async Task<Response<Address>> GetByIdAsync(Guid id)
        {
            var address = await _repository.GetByIdAsync(id);

            if (address == null)
                return Response<Address>.Fail("Adres bulunamadı", 404);

            return Response<Address>.Success(address, 200);
        }

        public async Task<Response<Address>> CreateAsync(Address entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return Response<Address>.Success(entity, 201);
        }

        public async Task<Response<bool>> Update(Address entity)
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }

        public async Task<Response<bool>> Remove(Guid id)
        {
            var address = await _repository.GetByIdAsync(id);
            if (address == null)
                return Response<bool>.Fail("Adres bulunamadı", 404);

            _repository.Remove(address);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }
    }
}
