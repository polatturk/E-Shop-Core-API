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
    public class OrderService(IGenericRepository<Order> _repository) : IOrderService
    {
        public async Task<Response<List<Order>>?> GetAllAsync()
        {
            var data = await _repository.GetAll().ToListAsync();
            return Response<List<Order>>.Success(data, 200);
        }

        public async Task<Response<Order>> GetByIdAsync(Guid id)
        {
            var data = await _repository.GetByIdAsync(id);
            return data == null ? Response<Order>.Fail("Sipariş kaydı bulunamadı", 404) : Response<Order>.Success(data, 200);
        }

        public async Task<Response<Order>> CreateAsync(Order entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return Response<Order>.Success(entity, 201);
        }

        public async Task<Response<bool>> Update(Order entity)
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }

        public async Task<Response<bool>> Remove(Guid id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null) return Response<bool>.Fail("Sipariş kaydı bulunamadı", 404);
            _repository.Remove(data);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }
    }
}
