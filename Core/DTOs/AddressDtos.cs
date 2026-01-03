using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record AddressCreateDto(string Street, string City, string State, string Country, string ZipCode, AddressType Type, Guid UserId);

    public record AddressUpdateDto(Guid Id, string Street, string City, string State, string Country, string ZipCode, AddressType Type);

    public record AddressResponseDto(Guid Id, string Street, string City, string State, string Country, string ZipCode, AddressType Type);
}
