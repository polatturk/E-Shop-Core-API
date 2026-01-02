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
    public class CartItemService(IGenericRepository<CartItem> _repository) : ICartItemService
    {
        public async Task<Response<List<CartItem>>> GetAllAsync()
        {
            var data = await _repository.GetAll().ToListAsync();
            return Response<List<CartItem>>.Success(data, 200);
        }

        public async Task<Response<CartItem>> GetByIdAsync(Guid id)
        {
            var data = await _repository.GetByIdAsync(id); 
            return data == null ? Response<CartItem>.Fail("Sepet öğesi bulunamadı", 404) : Response<CartItem>.Success(data, 200);
        }

        public async Task<Response<CartItem>> CreateAsync(CartItem entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return Response<CartItem>.Success(entity, 201);
        }

        public async Task<Response<bool>> Update(CartItem entity)
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }

        public async Task<Response<bool>> Remove(Guid id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null) return Response<bool>.Fail("Sepet öğesi bulunamadı", 404);
            _repository.Remove(data);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }
    }
}
