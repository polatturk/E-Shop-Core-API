using Core.Entities;
using Core.Interfaces;
using Core.Response;
using Core.DTOs;
using Core.Mappings;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class AddressService(IUnitOfWork _unitOfWork) : IAddressService
{
    public async Task<Response<List<AddressResponseDto>>> GetAllAsync()
    {
        var addresses = await _unitOfWork.GetRepository<Address>().GetAllAsync();

        var dtos = AddressMapper.ToResponseDtoList(addresses.ToList());

        return Response<List<AddressResponseDto>>.Success(dtos, 200);
    }

    public async Task<Response<AddressResponseDto>> GetByIdAsync(Guid id)
    {
        var address = await _unitOfWork.GetRepository<Address>().GetByIdAsync(id);

        if (address == null)
            return Response<AddressResponseDto>.Fail("Adres bulunamadı", 404);

        var dto = AddressMapper.ToResponseDto(address);
        return Response<AddressResponseDto>.Success(dto, 200);
    }

    public async Task<Response<AddressResponseDto>> CreateAsync(AddressCreateDto dto)
    {
        var entity = AddressMapper.ToEntity(dto);

        await _unitOfWork.GetRepository<Address>().AddAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        var responseDto = AddressMapper.ToResponseDto(entity);
        return Response<AddressResponseDto>.Success(responseDto, 201);
    }

    public async Task<Response<bool>> UpdateAsync(AddressUpdateDto dto)
    {
        var existingAddress = await _unitOfWork.GetRepository<Address>().GetByIdAsync(dto.Id);

        if (existingAddress == null)
            return Response<bool>.Fail("Adres bulunamadı", 404);

        AddressMapper.UpdateEntityFromDto(dto, existingAddress);

        _unitOfWork.GetRepository<Address>().Update(existingAddress);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }

    public async Task<Response<bool>> RemoveAsync(Guid id)
    {
        var address = await _unitOfWork.GetRepository<Address>().GetByIdAsync(id);

        if (address == null)
            return Response<bool>.Fail("Adres bulunamadı", 404);

        _unitOfWork.GetRepository<Address>().Delete(address);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }
}