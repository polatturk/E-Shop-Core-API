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
    public partial class AddressMapper
    {
        // CreateDto -> Entity
        public static partial Address ToEntity(AddressCreateDto dto);

        // UpdateDto -> Entity
        public static partial Address ToEntity(AddressUpdateDto dto);

        // Entity -> ResponseDto
        public static partial AddressResponseDto ToResponseDto(Address address);

        // Kullanıcın tüm adreslerini listelemek için
        public static partial List<AddressResponseDto> ToResponseDtoList(List<Address> addresses);
    }
}
