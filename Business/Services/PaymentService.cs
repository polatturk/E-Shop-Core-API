using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Core.Response;
using Core.DTOs;
using Core.Mappings;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
    
namespace Business.Services;

public class PaymentService(IUnitOfWork _unitOfWork) : IPaymentService
{
    public async Task<Response<List<PaymentResponseDto>>> GetAllAsync()
    {
        var payments = await _unitOfWork.GetRepository<Payment>().GetAllAsync();

        var dtos = PaymentMapper.ToResponseDtoList(payments.ToList());
        return Response<List<PaymentResponseDto>>.Success(dtos, 200);
    }

    public async Task<Response<PaymentResponseDto>> GetByIdAsync(Guid id)
    {
        var payment = await _unitOfWork.GetRepository<Payment>().GetByIdAsync(id);

        if (payment == null)
            return Response<PaymentResponseDto>.Fail("Ödeme kaydı bulunamadı", 404);

        var dto = PaymentMapper.ToResponseDto(payment);
        return Response<PaymentResponseDto>.Success(dto, 200);
    }

    public async Task<Response<PaymentResponseDto>> CreateAsync(PaymentCreateDto dto, Guid userId)
    {
        // 1. Ödeme yapılmak istenen siparişi bulma
        var order = await _unitOfWork.GetRepository<Order>()
            .GetByIdAsync(dto.OrderId);

        // 2. Güvenlik ve Mantık Kontrolleri
        if (order == null)
            return Response<PaymentResponseDto>.Fail("Ödeme yapılacak sipariş bulunamadı.", 404);

        if (order.UserId != userId)
            return Response<PaymentResponseDto>.Fail("Size ait olmayan bir sipariş için ödeme yapamazsınız!", 403);

        if (order.Status == OrderStatus.Shipped || order.Status == OrderStatus.Completed)
            return Response<PaymentResponseDto>.Fail("Bu sipariş zaten kargolanmış veya teslim edilmiş.", 400);

        var entity = PaymentMapper.ToEntity(dto);
        entity.PaymentDate = DateTime.Now;

        entity.Status = PaymentStatus.Success;

        order.Status = OrderStatus.Processing;

        await _unitOfWork.GetRepository<Payment>().AddAsync(entity);
        _unitOfWork.GetRepository<Order>().Update(order);

        await _unitOfWork.SaveChangesAsync();

        var responseDto = PaymentMapper.ToResponseDto(entity);
        return Response<PaymentResponseDto>.Success(responseDto, 201);
    }

    public async Task<Response<bool>> UpdateStatusAsync(PaymentStatusUpdateDto dto)
    {
        var existingPayment = await _unitOfWork.GetRepository<Payment>().GetByIdAsync(dto.Id);

        if (existingPayment == null)
            return Response<bool>.Fail("Ödeme kaydı bulunamadı", 404);

        PaymentMapper.UpdateStatusFromDto(dto, existingPayment);

        _unitOfWork.GetRepository<Payment>().Update(existingPayment);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }

    public async Task<Response<bool>> RemoveAsync(Guid id)
    {
        var payment = await _unitOfWork.GetRepository<Payment>().GetByIdAsync(id);

        if (payment == null)
            return Response<bool>.Fail("Ödeme kaydı bulunamadı", 404);

        _unitOfWork.GetRepository<Payment>().Delete(payment);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }
}