using Core.Entities;
using Core.Interfaces;
using Core.Response;
using Core.DTOs;
using Core.Mappings;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class OrderItemService(IUnitOfWork _unitOfWork) : IOrderItemService
{
    public async Task<Response<List<OrderItemResponseDto>>> GetAllAsync()
    {
        var items = await _unitOfWork.GetRepository<OrderItem>().GetAllAsync();

        var dtos = OrderItemMapper.ToResponseDtoList(items.ToList());

        return Response<List<OrderItemResponseDto>>.Success(dtos, 200);
    }

    public async Task<Response<OrderItemResponseDto>> GetByIdAsync(Guid id)
    {
        var item = await _unitOfWork.GetRepository<OrderItem>().GetByIdAsync(id);

        if (item == null)
            return Response<OrderItemResponseDto>.Fail("Sipariş kalemi bulunamadı", 404);

        var dto = OrderItemMapper.ToResponseDto(item);
        return Response<OrderItemResponseDto>.Success(dto, 200);
    }

    public async Task<Response<OrderItemResponseDto>> CreateAsync(OrderItemCreateDto dto)
    {
        var entity = OrderItemMapper.ToEntity(dto);

        await _unitOfWork.GetRepository<OrderItem>().AddAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        var responseDto = OrderItemMapper.ToResponseDto(entity);
        return Response<OrderItemResponseDto>.Success(responseDto, 201);
    }

    public async Task<Response<bool>> UpdateAsync(OrderItemUpdateDto dto)
    {
        var existingItem = await _unitOfWork.GetRepository<OrderItem>().GetByIdAsync(dto.Id);

        if (existingItem == null)
            return Response<bool>.Fail("Sipariş kalemi bulunamadı", 404);

        OrderItemMapper.UpdateEntityFromDto(dto, existingItem);

        _unitOfWork.GetRepository<OrderItem>().Update(existingItem);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }

    public async Task<Response<bool>> RemoveAsync(Guid id)
    {
        var item = await _unitOfWork.GetRepository<OrderItem>().GetByIdAsync(id);

        if (item == null)
            return Response<bool>.Fail("Sipariş kalemi bulunamadı", 404);

        _unitOfWork.GetRepository<OrderItem>().Delete(item);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }
}