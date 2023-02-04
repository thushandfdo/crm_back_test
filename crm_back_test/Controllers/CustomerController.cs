using crm_back_test.Models;
using crm_back_test.Services.CustomerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crm_back_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer?>> getCustomer(int customerId)
        {
            var customer = await _customerService.getCustomer(customerId);

            if (customer == null)
            {
                return NotFound("Customer does not exist");
            }

            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>?>> getCustomers()
        {
            var customers = await _customerService.getCustomers();

            if (customers == null)
            {
                return NotFound("Customers list is Empty..!");
            }

            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>?>> postCustomer(Customer newCustomer)
        {
            var customers = await _customerService.postCustomer(newCustomer);

            if (customers == null)
            {
                return NotFound("Customer is already exist..!");
            }

            return Ok(customers);
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>?>> putCustomer(Customer newCustomer)
        {
            var customers = await _customerService.putCustomer(newCustomer);

            if (customers == null)
            {
                return NotFound("Customer is not found..!");
            }

            return Ok(customers);
        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult<List<Customer>?>> deleteCustomer(int customerId)
        {
            var customers = await _customerService.deleteCustomer(customerId);

            if (customers == null)
            {
                return NotFound("Customer is not found..!");
            }

            return Ok(customers);
        }
    }
}
