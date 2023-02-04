﻿using crm_back_test.Models;

namespace crm_back_test.Services.CustomerServices
{
    public interface ICustomerService
    {
        public Task<Customer?> getCustomer(int customerId);
        public Task<List<Customer>?> getCustomers();
        public Task<List<Customer>?> postCustomer(Customer newCustomer);
        public Task<List<Customer>?> putCustomer(Customer newCustomer);
        public Task<List<Customer>?> deleteCustomer(int customerId);
    }
}