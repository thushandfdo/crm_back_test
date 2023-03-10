using crm_back_test.Models;

namespace crm_back_test.Services.CustomerServices
{
    public interface ICustomerService
    {
        public Task<Customer?> getCustomer(int customerId);
        public Task<List<Customer>?> getCustomers();
        public Task<Customer?> postCustomer(Customer newCustomer);
        public Task<Customer?> putCustomer(int customerId, Customer newCustomer);
        public Task<Customer?> deleteCustomer(int customerId);
    }
}
