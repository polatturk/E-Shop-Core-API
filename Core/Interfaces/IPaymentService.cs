using Core.Entities;
using Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPaymentService
    {
        Task<Response<List<Payment>>> GetAllAsync();
        Task<Response<Payment>> GetByIdAsync(Guid id);
        Task<Response<Payment>> CreateAsync(Payment payment); // Ödemeyi kaydet
        Task<Response<bool>> Update(Payment payment);
        Task<Response<bool>> Remove(Guid id);
    }
}
