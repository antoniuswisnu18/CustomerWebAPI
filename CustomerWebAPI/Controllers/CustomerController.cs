using CustomerWebAPI.BusinessLogicLayer;
using CustomerWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetCustomers()
        {
            try
            {
                var customers = await _customerService.GetCustomerAsync();
                return new
                {
                    message = "Success",
                    transactionId = Guid.NewGuid(),
                    data = customers
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Finish with error.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<object>> GetCustomerById(int customerId)
        {
            try
            {

                var customer = await _customerService.GetCustomerByIdAsync(customerId);
                return new
                {
                    message = "Success",
                    transactionId = Guid.NewGuid(),
                    data = customer
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Finish with error.",
                    error = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateCustomer(Customer customer)
        {
            try
            {
                var createdCustomer = await _customerService.CreateCustomerAsync(customer);
                return new
                {
                    message = "Customer Successfully created",
                    transactionId = Guid.NewGuid(),
                    data = createdCustomer
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Finish with error.",
                    error = ex.Message
                });
            }
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            try
            {
                await _customerService.UpdateCustomerAsync(id, customer);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Finish with error.",
                    error = ex.Message
                });
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Finish with error.",
                    error = ex.Message
                });
            }
        }
    }
}
