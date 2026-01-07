using Core.Entities;
using Core.Interfaces;
using Core.Response;
using Core.DTOs;
using Core.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class ProductService(IUnitOfWork _unitOfWork) : IProductService
{

    public async Task<Response<List<ProductResponseDto>>> GetAllAsync()
    {
        var products = await _unitOfWork.GetRepository<Product>()
            .GetAllAsync(include: q => q.Include(p => p.Category));

        var dtos = ProductMapper.ToResponseDtoList(products.ToList());

        return Response<List<ProductResponseDto>>.Success(dtos, 200);
    }

    public async Task<Response<ProductResponseDto>> GetByIdAsync(Guid id)
    {
        var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(id);

        if (product == null)
            return Response<ProductResponseDto>.Fail("Ürün bulunamadı", 404);

        var dto = ProductMapper.ToResponseDto(product);
        return Response<ProductResponseDto>.Success(dto, 200);
    }

    public async Task<Response<ProductResponseDto>> CreateAsync(ProductCreateDto dto)
    {
        var entity = ProductMapper.ToEntity(dto);

        await _unitOfWork.GetRepository<Product>().AddAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        var responseDto = ProductMapper.ToResponseDto(entity);
        return Response<ProductResponseDto>.Success(responseDto, 201);
    }

    public async Task<Response<bool>> UpdateAsync(ProductUpdateDto dto) 
    {
        var existingProduct = await _unitOfWork.GetRepository<Product>().GetByIdAsync(dto.Id);
        if (existingProduct == null) return Response<bool>.Fail("Ürün bulunamadı", 404);

        ProductMapper.UpdateEntityFromDto(dto, existingProduct);
        _unitOfWork.GetRepository<Product>().Update(existingProduct);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }

    public async Task<Response<bool>> RemoveAsync(Guid id) 
    {
        var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(id);
        if (product == null) return Response<bool>.Fail("Ürün bulunamadı", 404);

        _unitOfWork.GetRepository<Product>().Delete(product);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }
}