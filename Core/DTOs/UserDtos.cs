using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record UserRegisterDto(string FirstName, string LastName, string Email, string Password, Gender Gender);

    public record UserLoginDto(string Email, string Password);

    public record UserResponseDto(Guid Id, string FullName, string Email, UserRole Role, Gender Gender);

    public record UserUpdateDto(Guid Id, string FirstName, string LastName, string Email, Gender Gender);
}
