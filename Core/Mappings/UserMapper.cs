using Core.DTOs;
using Core.Entities;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappings
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public partial class UserMapper
    {
        // RegisterDto -> User Entity
        public static partial User ToEntity(UserRegisterDto dto);

        // UpdateDto -> User Entity
        public static partial User ToEntity(UserUpdateDto dto);

        //  User Entity -> ResponseDto
        [MapProperty(nameof(User), nameof(UserResponseDto.FullName))]
        public static partial UserResponseDto ToResponseDto(User user);

        // FirstName ve LastName'i birleştiriyoruz
        private static string MapFullName(User user)
        {
            return $"{user.FirstName} {user.LastName}";
        }
    }
}
