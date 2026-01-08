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

    public async Task<Response<UserResponseDto>> RegisterAsync(UserRegisterDto dto)
    {
        var existingUsers = await _unitOfWork.GetRepository<User>().GetAllAsync(x => x.Email == dto.Email);
        if (existingUsers.Any())
        {
            return Response<UserResponseDto>.Fail("Bu email adresi zaten kullanımda.", 400);
        }

        var entity = UserMapper.ToEntity(dto); 

        await _unitOfWork.GetRepository<User>().AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        var responseDto = UserMapper.ToResponseDto(entity);
        return Response<UserResponseDto>.Success(responseDto, 201);
    }

    public async Task<Response<TokenResponseDto>> LoginAsync(UserLoginDto dto)
    {
        var userList = await _unitOfWork.GetRepository<User>().GetAllAsync(x => x.Email == dto.Email);
        var user = userList.FirstOrDefault();

        if (user == null)
        {
            return Response<TokenResponseDto>.Fail("Email veya şifre hatalı.", 404);
        }

        // İleride BCrypt ile hashleyeceğim)
        if (user.Password != dto.Password)
        {
            return Response<TokenResponseDto>.Fail("Email veya şifre hatalı.", 400);
        }

        // JWT yazılacak
        var token = new TokenResponseDto("fake-jwt-token-buraya", DateTime.Now.AddHours(1));

        return Response<TokenResponseDto>.Success(token, 200);
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