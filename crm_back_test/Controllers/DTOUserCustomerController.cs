using crm_back_test.DTOs;
using crm_back_test.Models;
using crm_back_test.Services.CustomerServices;
using crm_back_test.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crm_back_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DTOUserCustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;

        public DTOUserCustomerController(ICustomerService customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<DTOUserCustomer?>> getCustomer(int customerId)
        {
            var customer = await _customerService.getCustomer(customerId);
            var user = await _userService.getUser(customerId);

            if (customer == null || user == null || user.Type != "Customer")
            {
                return NotFound("Customer does not exist");
            }

            var userCustomer = new DTOUserCustomer()
            {
                UserId = customerId,
                Type = user.Type,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ContactNo = user.ContactNo,
                Email = user.Email,
                ProfilePic = user.ProfilePic,
                Company = customer.Company
            };

            return Ok(userCustomer);
        }

        [HttpGet]
        public async Task<ActionResult<List<DTOUserCustomer>?>> getCustomers()
        {
            var customers = await _customerService.getCustomers();
            var users = await _userService.getUsers();

            if (customers == null || users == null)
            {
                return NotFound("Customers list is Empty..!");
            }

            users = users.Where(user => user.Type == "Customer").ToList();

            var userCustomers = new List<DTOUserCustomer>();
            
            foreach(var user in users) 
            {
                var userCustomer = new DTOUserCustomer();

                userCustomer.UserId = user.UserId;
                userCustomer.Type = user.Type;
                userCustomer.Username = user.Username;
                userCustomer.Password = user.Password;
                userCustomer.FirstName = user.FirstName;
                userCustomer.LastName = user.LastName;
                userCustomer.ContactNo = user.ContactNo;
                userCustomer.Email = user.Email;
                userCustomer.ProfilePic = user.ProfilePic;

                var cus = customers.Find(customer => customer.UserId == user.UserId);
                userCustomer.Company = (cus == null) ? "" : cus.Company;

                userCustomers.Add(userCustomer);
            }

            return Ok(userCustomers);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>?>> postCustomer(DTOUserCustomer newCustomer)
        {
            var user = new User()
            {
                Type = newCustomer.Type,
                Username = newCustomer.Username,
                Password = newCustomer.Password,
                FirstName = newCustomer.FirstName,
                LastName = newCustomer.LastName,
                ContactNo = newCustomer.ContactNo,
                Email = newCustomer.Email,
                ProfilePic = newCustomer.ProfilePic
            };

            var users = await _userService.postUser(user);

            if (users == null)
                return NotFound("Customers list is Empty..!");

            var customer = new Customer()
            {
                UserId = users.Find(x => x.Email == user.Email).UserId,
                Company = newCustomer.Company
            };

            var customers = await _customerService.postCustomer(customer);
            
            return Ok(users);
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult<List<User>?>> putCustomer(int customerId, DTOUserCustomer newCustomer)
        {
            var user = new User()
            {
                Type = newCustomer.Type,
                Username = newCustomer.Username,
                Password = newCustomer.Password,
                FirstName = newCustomer.FirstName,
                LastName = newCustomer.LastName,
                ContactNo = newCustomer.ContactNo,
                Email = newCustomer.Email,
                ProfilePic = newCustomer.ProfilePic
            };

            var users = await _userService.putUser(customerId, user);

            if (users == null)
                return NotFound("Customers list is Empty..!");

            var customer = new Customer()
            {
                UserId = customerId,
                Company = newCustomer.Company
            };

            var customers = await _customerService.putCustomer(customerId, customer);
            
            return Ok(users);
        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult<List<User>?>> deleteCustomer(int customerId)
        {
            var customers = await _customerService.deleteCustomer(customerId);

            if (customers == null)
                return NotFound("Customer not Found...!");

            var users = await _userService.deleteUser(customerId);

            return Ok(users);
        }
    }
}
