using Core.Entities;
using Core.Interfaces;
using Core.Response;
using Core.DTOs;
using Core.Mappings;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class CartItemService(IUnitOfWork _unitOfWork) : ICartItemService
{
    public async Task<Response<List<CartItemResponseDto>>> GetAllAsync()
    {
        var items = await _unitOfWork.GetRepository<CartItem>()
            .GetAllAsync(include: q => q.Include(ci => ci.Product));

        var dtos = CartItemMapper.ToResponseDtoList(items.ToList());
        return Response<List<CartItemResponseDto>>.Success(dtos, 200);
    }

    public async Task<Response<CartItemResponseDto>> GetByIdAsync(Guid id)
    {
        var item = await _unitOfWork.GetRepository<CartItem>().GetByIdAsync(id);

        if (item == null)
            return Response<CartItemResponseDto>.Fail("Sepet öğesi bulunamadı", 404);

        var dto = CartItemMapper.ToResponseDto(item);
        return Response<CartItemResponseDto>.Success(dto, 200);
    }

    public async Task<Response<CartItemResponseDto>> CreateAsync(AddToCartDto dto)
    {
        var entity = CartItemMapper.ToEntity(dto);

        await _unitOfWork.GetRepository<CartItem>().AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        var responseDto = CartItemMapper.ToResponseDto(entity);
        return Response<CartItemResponseDto>.Success(responseDto, 201);
    }

    public async Task<Response<bool>> UpdateAsync(CartItemUpdateDto dto)
    {
        var existingItem = await _unitOfWork.GetRepository<CartItem>().GetByIdAsync(dto.Id);

        if (existingItem == null)
            return Response<bool>.Fail("Sepet öğesi bulunamadı", 404);

        CartItemMapper.UpdateEntityFromDto(dto, existingItem);

        _unitOfWork.GetRepository<CartItem>().Update(existingItem);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }

    public async Task<Response<bool>> RemoveAsync(Guid id)
    {
        var item = await _unitOfWork.GetRepository<CartItem>().GetByIdAsync(id);

        if (item == null)
            return Response<bool>.Fail("Sepet öğesi bulunamadı", 404);

        _unitOfWork.GetRepository<CartItem>().Delete(item);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }
}