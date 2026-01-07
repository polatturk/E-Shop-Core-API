using Core.Entities;
using Core.Interfaces;
using Core.Response;
using Core.DTOs;
using Core.Mappings;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class CartService(IUnitOfWork _unitOfWork) : ICartService
{
    public async Task<Response<List<CartResponseDto>>> GetAllAsync()
    {
        var carts = await _unitOfWork.GetRepository<Cart>()
            .GetAllAsync(include: q => q.Include(c => c.Items));

        var dtos = CartMapper.ToResponseDtoList(carts.ToList());
        return Response<List<CartResponseDto>>.Success(dtos, 200);
    }   

    public async Task<Response<CartResponseDto>> GetByIdAsync(Guid id)
    {
        var cart = await _unitOfWork.GetRepository<Cart>().GetByIdAsync(id);

        if (cart == null)
            return Response<CartResponseDto>.Fail("Sepet bulunamadı", 404);

        var dto = CartMapper.ToResponseDto(cart);
        return Response<CartResponseDto>.Success(dto, 200);
    }

    public async Task<Response<bool>> RemoveAsync(Guid id)
    {
        var cart = await _unitOfWork.GetRepository<Cart>().GetByIdAsync(id);

        if (cart == null)
            return Response<bool>.Fail("Sepet bulunamadı", 404);

        _unitOfWork.GetRepository<Cart>().Delete(cart);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }
}