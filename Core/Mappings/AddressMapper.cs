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

    public static partial class AddressMapper
    {
        public static partial Address ToEntity(AddressCreateDto dto);

        public static partial AddressResponseDto ToResponseDto(Address address);

        public static partial List<AddressResponseDto> ToResponseDtoList(List<Address> addresses);

        public static partial void UpdateEntityFromDto(AddressUpdateDto dto, Address entity);

    }

}