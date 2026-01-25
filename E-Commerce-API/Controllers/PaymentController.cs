using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Authorize] // Tüm ödeme işlemleri yetki gerektirsin
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentService _paymentService) : ControllerBase
    {
        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin")] // Sadece admin tüm ödemeleri görebilsin
        public async Task<IActionResult> GetAll()
        {
            var response = await _paymentService.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _paymentService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(PaymentCreateDto dto)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("Ödeme yapmak için giriş yapmalısınız.");

            var response = await _paymentService.CreateAsync(dto, Guid.Parse(userIdClaim));
            return StatusCode(response.StatusCode, response);
        }
    }
}
