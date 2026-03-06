using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Api.Services;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/v1/customer
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        // GET: api/v1/customer/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
                return NotFound($"Customer with id {id} not found.");

            return Ok(customer);
        }

        // POST: api/v1/customer
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _customerService.CreateCustomerAsync(dto);

            // returns 201 Created with Location header
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/v1/customer/3
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _customerService.UpdateCustomerAsync(id, dto);

            if (!success)
                return NotFound($"Customer with id {id} not found.");

            return NoContent(); // 204
        }

        // DELETE: api/v1/customer/3
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _customerService.DeleteCustomerAsync(id);

            if (!success)
                return NotFound($"Customer with id {id} not found.");

            return NoContent(); // 204
        }
    }
}