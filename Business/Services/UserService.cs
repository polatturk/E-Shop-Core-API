using Core.Entities;
using Core.Interfaces;
using Core.Response;
using Core.DTOs;
using Core.Mappings;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class UserService(IUnitOfWork _unitOfWork) : IUserService
{

    public async Task<Response<List<UserResponseDto>>> GetAllAsync()
    {
        var users = await _unitOfWork.GetRepository<User>().GetAllAsync();

        var dtos = UserMapper.ToResponseDtoList(users.ToList());

        return Response<List<UserResponseDto>>.Success(dtos, 200);
    }
    public async Task<Response<UserResponseDto>> GetByIdAsync(Guid id)
    {
        var user = await _unitOfWork.GetRepository<User>().GetByIdAsync(id);

        if (user == null)
            return Response<UserResponseDto>.Fail("Kullanıcı bulunamadı", 404);

        var dto = UserMapper.ToResponseDto(user);

        return Response<UserResponseDto>.Success(dto, 200);
    }

    public async Task<Response<UserResponseDto>> CreateAsync(UserRegisterDto dto) 
    {
        var entity = UserMapper.ToEntity(dto);

        await _unitOfWork.GetRepository<User>().AddAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        var responseDto = UserMapper.ToResponseDto(entity);

        return Response<UserResponseDto>.Success(responseDto, 201);
    }

    public async Task<Response<bool>> UpdateAsync(UserUpdateDto dto)
    {
        var existingUser = await _unitOfWork.GetRepository<User>().GetByIdAsync(dto.Id);

        if (existingUser == null)
            return Response<bool>.Fail("Kullanıcı bulunamadı", 404);

        UserMapper.UpdateEntityFromDto(dto, existingUser);

        _unitOfWork.GetRepository<User>().Update(existingUser);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }

    public async Task<Response<bool>> RemoveAsync(Guid id)
    {
        var user = await _unitOfWork.GetRepository<User>().GetByIdAsync(id);

        if (user == null)
            return Response<bool>.Fail("Kullanıcı bulunamadı", 404);

        _unitOfWork.GetRepository<User>().Delete(user);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.Success(true, 204);
    }
}