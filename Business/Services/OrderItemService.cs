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
    public class OrderItemService(IGenericRepository<OrderItem> _repository) : IOrderItemService
    {
        public async Task<Response<List<OrderItem>>> GetAllAsync()
        {
            var data = await _repository.GetAll().ToListAsync();
            return Response<List<OrderItem>>.Success(data, 200);
        }

        public async Task<Response<OrderItem>> GetByIdAsync(Guid id)
        {
            var data = await _repository.GetByIdAsync(id);
            return data == null
                ? Response<OrderItem>.Fail("Sipariş kalemi bulunamadı", 404)
                : Response<OrderItem>.Success(data, 200);
        }

        public async Task<Response<OrderItem>> CreateAsync(OrderItem entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return Response<OrderItem>.Success(entity, 201);
        }

        public async Task<Response<bool>> Update(OrderItem entity)
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }

        public async Task<Response<bool>> Remove(Guid id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null) return Response<bool>.Fail("Sipariş kalemi bulunamadı", 404);

            _repository.Remove(data);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }
    }
}
