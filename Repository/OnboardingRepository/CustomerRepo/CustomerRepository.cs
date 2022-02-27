using System;
using System.Collections.Generic;
using System.Text;
using OnboardingRepository.BaseRepo;
using OnboardingData;using System.Threading.Tasks;
using System.Linq;

namespace OnboardingRepository.CustomerRepo
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IRepository<Customer> _repository;
        private readonly IRepository<LGA> _lgaRespository;
        private readonly IRepository<State> _stateRespository;

        public CustomerRepository(IRepository<Customer> repository, IRepository<LGA> lgaRespository , IRepository<State> stateRespository)
        {
            _repository = repository;
            _lgaRespository = lgaRespository;
            _stateRespository = stateRespository;
        }

        public async Task<bool> CreateCustomer(Customer customer)
        {
            var res = await _repository.AddAsync(customer).ConfigureAwait(false);
            return res;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var res = await _repository.GetAllAsync(s => s.Id != null).ConfigureAwait(false);
            return res.ToList();
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            var res = await _repository.GetAsync(s => s.Email == email).ConfigureAwait(false);
            return res;
        }

        public async Task<List<LGA>> GetLGAs ()
        {
            var res = await _lgaRespository.GetAllAsync(s => s.Id != 0).ConfigureAwait(false);
            return res.ToList();
        }

        public async Task<List<State>> GeStates()
        {
            var res = await _stateRespository.GetAllAsync(s => s.Id != 0).ConfigureAwait(false);
            return res.ToList();
        }




    }
}
