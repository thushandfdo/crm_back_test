using crm_back_test.Data;
using crm_back_test.Models;
using Microsoft.EntityFrameworkCore;

namespace crm_back_test.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context) 
        {
            _context = context;
        }

        public async Task<Customer?> getCustomer(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);

            return customer;
        }

        public async Task<List<Customer>?> getCustomers()
        {
            var notes = await _context.Customers.ToListAsync();

            return notes;
        }

        public async Task<List<Customer>?> postCustomer(Customer newCustomer)
        {
            var customer = await _context.Customers.Where(customer => customer.Company.Equals(newCustomer.Company)).FirstOrDefaultAsync();

            if (customer != null)
            {
                return null;
            }

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return await _context.Customers.ToListAsync();
        }

        public async Task<List<Customer>?> putCustomer(int customerId, Customer newCustomer)
        {
            var customer = await _context.Customers.FindAsync(customerId);

            if (customer == null)
            {
                return null;
            }

            customer.Company = (newCustomer.Company == "") ? customer.Company : newCustomer.Company;

            await _context.SaveChangesAsync();

            return await _context.Customers.ToListAsync();
        }

        public async Task<List<Customer>?> deleteCustomer(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);

            if (customer == null)
            {
                return null;
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return await _context.Customers.ToListAsync();
        }
    }
}
