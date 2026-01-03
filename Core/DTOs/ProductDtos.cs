using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record ProductCreateDto(string Name, string? Description, decimal Price, int StockQuantity, string ImageUrl, Guid CategoryId);

    public record ProductUpdateDto(Guid Id, string Name, string? Description, decimal Price, int StockQuantity, string ImageUrl, Guid CategoryId);

    public record ProductResponseDto(Guid Id, string Name, string? Description, decimal Price, int StockQuantity, string ImageUrl, string CategoryName);
}
