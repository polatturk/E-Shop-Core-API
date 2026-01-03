using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record CategoryCreateDto(string Name, string? Description);

    public record CategoryUpdateDto(Guid Id, string Name, string? Description);

    public record CategoryResponseDto(Guid Id, string Name, string? Description);

}
