﻿using crm_back_test.Models;
using static crm_back_test.Controllers.PaymentController;

namespace crm_back_test.Services.PaymentServices
{
    public interface IPaymentService
    {
        public Task<Payment?> getPayment(int paymentId);
        public Task<List<Payment>?> getPayments();
        public Task<Payment?> postPayment(Payment newPayment);
        //public Task<Project?> putProject(int projectId, Project newProject);
        //public Task<Project?> deleteProject(int projectId);

        int CalculateOrderAmount(Item[] items);
    }
}
