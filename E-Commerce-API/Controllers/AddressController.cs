using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController(IAddressService _addressService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _addressService.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _addressService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AddressCreateDto dto)
        {
            var response = await _addressService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(AddressUpdateDto dto)
        {
            var response = await _addressService.UpdateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _addressService.RemoveAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}