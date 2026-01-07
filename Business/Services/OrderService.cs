using Core.Entities;
using Core.Interfaces;
using Core.Response;
using Core.DTOs;
using Core.Mappings;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class OrderService(IUnitOfWork _unitOfWork) : IOrderService
{
    public async Task<Response<List<OrderResponseDto>>> GetAllAsync()
    {
        var orders = await _unitOfWork.GetRepository<Order>()
            .GetAllAsync(include: q => q.Include(o => o.OrderItems));

        var dtos = OrderMapper.ToResponseDtoList(orders.ToList());
        return Response<List<OrderResponseDto>>.Success(dtos, 200);
    }

    public async Task<Response<OrderResponseDto>> GetByIdAsync(Guid id)
    {
        var order = await _unitOfWork.GetRepository<Order>().GetByIdAsync(id);

        if (order == null)
            return Response<OrderResponseDto>.Fail("Sipariş kaydı bulunamadı", 404);

        var dto = OrderMapper.ToResponseDto(order);
        return Response<OrderResponseDto>.Success(dto, 200);
    }

    public async Task<Response<OrderResponseDto>> CreateAsync(OrderCreateDto dto)
    {
        var entity = OrderMapper.ToEntity(dto);

        await _unitOfWork.GetRepository<Order>().AddAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        var responseDto = OrderMapper.ToResponseDto(entity);
        return Response<OrderResponseDto>.Success(responseDto, 201);
    }

    public async Task<Response<bool>> UpdateAsync(OrderUpdateDto dto)
    {
        var existingOrder = await _unitOfWork.GetRepository<Order>().GetByIdAsync(dto.Id);

        if (existingOrder == null)
            return Response<bool>.Fail("Sipariş kaydı bulunamadı", 404);

        OrderMapper.UpdateEntityFromDto(dto, existingOrder);

        _unitOfWork.GetRepository<Order>().Update(existingOrder);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }

    public async Task<Response<bool>> RemoveAsync(Guid id)
    {
        var order = await _unitOfWork.GetRepository<Order>().GetByIdAsync(id);

        if (order == null)
            return Response<bool>.Fail("Sipariş kaydı bulunamadı", 404);

        _unitOfWork.GetRepository<Order>().Delete(order);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }
}