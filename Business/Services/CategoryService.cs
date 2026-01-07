using Core.Entities;
using Core.Interfaces;
using Core.Response;
using Core.DTOs;
using Core.Mappings;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class CategoryService(IUnitOfWork _unitOfWork) : ICategoryService
{
    public async Task<Response<List<CategoryResponseDto>>> GetAllAsync()
    {
        var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync();

        var dtos = CategoryMapper.ToResponseDtoList(categories.ToList());

        return Response<List<CategoryResponseDto>>.Success(dtos, 200);
    }

    public async Task<Response<CategoryResponseDto>> GetByIdAsync(Guid id)
    {
        var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);

        if (category == null)
            return Response<CategoryResponseDto>.Fail("Kategori bulunamadı", 404);

        var dto = CategoryMapper.ToResponseDto(category);
        return Response<CategoryResponseDto>.Success(dto, 200);
    }

    public async Task<Response<CategoryResponseDto>> CreateAsync(CategoryCreateDto dto)
    {
        var entity = CategoryMapper.ToEntity(dto);

        await _unitOfWork.GetRepository<Category>().AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(); 

        var responseDto = CategoryMapper.ToResponseDto(entity);
        return Response<CategoryResponseDto>.Success(responseDto, 201);
    }

    public async Task<Response<bool>> UpdateAsync(CategoryUpdateDto dto)
    {
        var existingCategory = await _unitOfWork.GetRepository<Category>().GetByIdAsync(dto.Id);

        if (existingCategory == null)
            return Response<bool>.Fail("Kategori bulunamadı", 404);

        CategoryMapper.UpdateEntityFromDto(dto, existingCategory);

        _unitOfWork.GetRepository<Category>().Update(existingCategory);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }

    public async Task<Response<bool>> RemoveAsync(Guid id)
    {
        var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);

        if (category == null)
            return Response<bool>.Fail("Kategori bulunamadı", 404);

        _unitOfWork.GetRepository<Category>().Delete(category);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }
}