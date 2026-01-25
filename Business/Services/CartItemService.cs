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
    public async Task<Response<List<CartItemResponseDto>>> GetAllByUserIdAsync(Guid userId)
    {
        var items = await _unitOfWork.GetRepository<CartItem>()
            .GetAllAsync(
                filter: x => x.Cart.UserId == userId, 
                include: q => q.Include(ci => ci.Product)
            );

        var dtos = CartItemMapper.ToResponseDtoList(items.ToList());
        return Response<List<CartItemResponseDto>>.Success(dtos, 200);
    }

    public async Task<Response<CartItemResponseDto>> GetByIdAsync(Guid id, Guid userId)
    {
        var item = await _unitOfWork.GetRepository<CartItem>()
            .GetSingleAsync(x => x.Id == id && x.Cart.UserId == userId);

        if (item == null)
            return Response<CartItemResponseDto>.Fail("Ürün sepetinizde bulunamadı.", 404);

        var dto = CartItemMapper.ToResponseDto(item);
        return Response<CartItemResponseDto>.Success(dto, 200);
    }

    public async Task<Response<CartItemResponseDto>> CreateAsync(AddToCartDto dto, Guid userId)
    {
        var cart = await _unitOfWork.GetRepository<Cart>()
            .GetSingleAsync(x => x.UserId == userId);

        if (cart == null) return Response<CartItemResponseDto>.Fail("Sepet bulunamadı.", 404);

        var existingItem = await _unitOfWork.GetRepository<CartItem>()
            .GetSingleAsync(x => x.CartId == cart.Id && x.ProductId == dto.ProductId);

        if (existingItem != null)
        {
            existingItem.Quantity += dto.Quantity;
            _unitOfWork.GetRepository<CartItem>().Update(existingItem);
        }
        else
        {
            var newItem = CartItemMapper.ToEntity(dto);
            newItem.CartId = cart.Id; // Sepete bağla
            await _unitOfWork.GetRepository<CartItem>().AddAsync(newItem);
            existingItem = newItem;
        }

        await _unitOfWork.SaveChangesAsync();
        var responseDto = CartItemMapper.ToResponseDto(existingItem);
        return Response<CartItemResponseDto>.Success(responseDto, 201);
    }

    public async Task<Response<bool>> UpdateAsync(CartItemUpdateDto dto, Guid userId)
    {
        var existingItem = await _unitOfWork.GetRepository<CartItem>()
            .GetSingleAsync(
                expression: x => x.Id == dto.Id && x.Cart.UserId == userId
            );

        if (existingItem == null)
            return Response<bool>.Fail("Sepet öğesi bulunamadı veya bu işlem için yetkiniz yok.", 404);

        CartItemMapper.UpdateEntityFromDto(dto, existingItem);

        _unitOfWork.GetRepository<CartItem>().Update(existingItem);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }

    public async Task<Response<bool>> RemoveAsync(Guid id, Guid userId)
    {
        var item = await _unitOfWork.GetRepository<CartItem>()
            .GetSingleAsync(x => x.Id == id && x.Cart.UserId == userId);

        if (item == null)
            return Response<bool>.Fail("Ürün sepetinizde bulunamadı.", 404);

        _unitOfWork.GetRepository<CartItem>().Delete(item);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }
}