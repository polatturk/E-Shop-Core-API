using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record ProductCreateDto(string Name, string Description, decimal Price, int Stock, int CategoryId);

    public record ProductUpdateDto(int Id, string Name, string Description, decimal Price, int Stock, int CategoryId);

    public record ProductResponseDto(int Id, string Name, string Description, decimal Price, int Stock, string CategoryName);
}
