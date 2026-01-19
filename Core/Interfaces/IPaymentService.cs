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
    public interface IPaymentService
    {
        Task<Response<List<PaymentResponseDto>>> GetAllAsync();

        Task<Response<PaymentResponseDto>> GetByIdAsync(Guid id);

        Task<Response<PaymentResponseDto>> CreateAsync(PaymentCreateDto dto, Guid userId);

        Task<Response<bool>> UpdateStatusAsync(PaymentStatusUpdateDto dto);

        Task<Response<bool>> RemoveAsync(Guid id);
    }
}
