using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnboardingData;

namespace OnboardingRepository.CustomerRepo
{
    public interface ICustomerRepository
    {
        System.Threading.Tasks.Task<List<Customer>> GetAllCustomers();
        Task<bool> CreateCustomer(Customer customer);
        Task<Customer> GetCustomerByEmail(string email);
        Task<List<LGA>> GetLGAs();
        Task<List<State>> GeStates();
    }
}
