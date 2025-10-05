using GrainBroker.API.Services;
using GrainBroker.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GrainBroker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(Guid id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            var createdCustomer = await _customerService.CreateCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            var updatedCustomer = await _customerService.UpdateCustomerAsync(customer);
            if (updatedCustomer == null)
            {
                return NotFound();
            }

            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var result = await _customerService.DeleteCustomerAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}