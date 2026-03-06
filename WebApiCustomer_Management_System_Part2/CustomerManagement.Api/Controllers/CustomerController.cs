using CustomerManagement.Core.Application.DTOs;
using CustomerManagement.Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard() =>
            Ok(await _service.GetCustomerDashboardAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var data = await _service.GetCustomerDetailAsync(id);
            return data == null ? NotFound() : Ok(data);
        }

        [HttpGet("{id}/interactions")]
        public async Task<IActionResult> GetInteractions(int id) =>
            Ok(await _service.GetCustomerInteractionsAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
        {
            var id = await _service.CreateCustomerAsync(dto);
            return CreatedAtAction(nameof(GetDetail), new { id = id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateCustomerDto dto)
        {
            var result = await _service.UpdateCustomerAsync(id, dto);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteCustomerAsync(id);
            return result ? Ok() : NotFound();
        }
    }
}