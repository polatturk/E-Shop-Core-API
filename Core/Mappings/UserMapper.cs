using Core.DTOs;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappings
{

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public static partial class UserMapper 
    {
        public static partial User ToEntity(UserRegisterDto dto);

        public static partial void UpdateEntityFromDto(UserUpdateDto dto, User entity);

        [MapProperty(nameof(User.FirstName), nameof(UserResponseDto.FullName))] 
        public static partial UserResponseDto ToResponseDto(User user);

        public static partial List<UserResponseDto> ToResponseDtoList(List<User> users);

        private static string MapFullName(User user)
        {
            return $"{user.FirstName} {user.LastName}";
        }
    }
}