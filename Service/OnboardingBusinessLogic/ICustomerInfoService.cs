using OnboardingBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingBusinessLogic
{
    public interface ICustomerInfoService
    {
        Task<GetAllCustomersResponse> GetAllCustomers();
        Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest customerRequest);
        Task<GenerateOtpResponse> GenerateOtp(string phoneNumber);
        Task<GetAllLgaAndStateRes> GetAllLgaAndState();
    }
}
