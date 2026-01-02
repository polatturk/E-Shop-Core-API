using Core.Entities;
using Core.Interfaces;
using DataAccess.Repository;
using Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class PaymentService(IGenericRepository<Payment> _repository) : IPaymentService
    {
        public async Task<Response<List<Payment>>?> GetAllAsync()
        {
            var data = await _repository.GetAll().ToListAsync();
            return Response<List<Payment>>.Success(data, 200);
        }

        public async Task<Response<Payment>> GetByIdAsync(Guid id)
        {
            var data = await _repository.GetByIdAsync(id);
            return data == null ? Response<Payment>.Fail("Ödeme kaydı bulunamadı", 404) : Response<Payment>.Success(data, 200);
        }

        public async Task<Response<Payment>> CreateAsync(Payment entity)
        {
            // İleride buraya banka entegrasyonu kodları gelecek
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return Response<Payment>.Success(entity, 201);
        }

        public async Task<Response<bool>> Update(Payment entity)
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }

        public async Task<Response<bool>> Remove(Guid id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null) return Response<bool>.Fail("Ödeme kaydı bulunamadı", 404);
            _repository.Remove(data);
            await _repository.SaveAsync();
            return Response<bool>.Success(204);
        }
    }
}
