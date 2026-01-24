using Business.Services;
using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService _orderService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _orderService.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _orderService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [Authorize] 
        [HttpPost("Create")]
        public async Task<IActionResult> Create(OrderCreateDto dto)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized("Sipariş vermek için önce giriş yapmalısınız.");
            }

            var response = await _orderService.CreateAsync(dto, Guid.Parse(userIdClaim));
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(OrderUpdateDto dto)
        {
            var response = await _orderService.UpdateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _orderService.RemoveAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
