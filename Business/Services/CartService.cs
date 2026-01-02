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
    public class CartService(IGenericRepository<Cart> _repository) : ICartService
    {
        public async Task<Response<List<Cart>>> GetAllAsync()
        {
            var data = await _repository.GetAll().ToListAsync();
            return Response<List<Cart>>.Success(data, 200);
        }

        public async Task<Response<Cart>> GetByIdAsync(Guid id)
        {
            var data = await _repository.GetByIdAsync(id);
            return data == null ? Response<Cart>.Fail("Sepet bulunamadı", 404) : Response<Cart>.Success(data, 200);
        }

        public async Task<Response<Cart>> CreateAsync(Cart entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return Response<Cart>.Success(entity, 201);
        }

        public async Task<Response<bool>> Update(Cart entity)
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }

        public async Task<Response<bool>> Remove(Guid id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null) return Response<bool>.Fail("Sepet bulunamadı", 404);
            _repository.Remove(data);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }
    }
}
