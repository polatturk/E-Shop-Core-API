using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_API.Controllers
{
    [Authorize(Roles = "Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController(ICartItemService _cartItemService) : ControllerBase
    {
        private Guid UserId => Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                                   ?? throw new UnauthorizedAccessException());

        [HttpGet("MyItems")]
        public async Task<IActionResult> GetMyCartItems()
        {
            var response = await _cartItemService.GetAllByUserIdAsync(UserId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _cartItemService.GetByIdAsync(id, UserId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart(AddToCartDto dto)
        {
            var response = await _cartItemService.CreateAsync(dto, UserId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CartItemUpdateDto dto)
        {
            var response = await _cartItemService.UpdateAsync(dto, UserId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("RemoveFromCart/{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var response = await _cartItemService.RemoveAsync(id, UserId);
            return StatusCode(response.StatusCode, response);
        }
    }
}
