using System;
using OnboardingRepository.CustomerRepo;
using OnboardingBusinessLogic.Models;
using System.Threading.Tasks;
using OnboardingData;
using System.Collections.Generic;
using OnboardingInfrastructure;
using OnboardingRepository.OtpLogRepo;
using System.Linq;

namespace OnboardingBusinessLogic
{
    public class CustomerInfoService : ICustomerInfoService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOtpLogRepository   _otpLogRepository;
        private readonly IOtpSender _otpSender;
        public CustomerInfoService(ICustomerRepository customerRepository , IOtpLogRepository  otpLogRepository, IOtpSender otpSender)
        {
            _customerRepository = customerRepository;
            _otpLogRepository = otpLogRepository;
            _otpSender = otpSender;
        }

        public async Task<CreateCustomerResponse> CreateCustomer (CreateCustomerRequest customerRequest )
        {
            var customer = new Customer
            {
                Email = customerRequest.Email,
                Password = customerRequest.Password,
                PhoneNumber = customerRequest.PhoneNumber,
                LGAId = customerRequest.LgaId,
                StateId = customerRequest.StateId
            };   
            var res = new CreateCustomerResponse();

            var otpRes = await _otpLogRepository.GetOtpLog(customerRequest.Otp, customerRequest.PhoneNumber).ConfigureAwait(false);
            if(otpRes ==  null)
            {
                res.IsSuccessful = false;
                res.Message = "Invalid Otp";
                return res;
            }

            if (otpRes.IsUsed)
            {
                res.IsSuccessful = false;
                res.Message = "Otp already used!";
                return res;
            }

            otpRes.IsUsed = true;
            var updateOtpRes = await _otpLogRepository.UpdateOtpLog(otpRes).ConfigureAwait(false);
            if (!updateOtpRes)
            {
                res.IsSuccessful = false;
                res.Message = "Error!";
                return res;
            }

            var status = await _customerRepository.CreateCustomer(customer).ConfigureAwait(false);

            if (!status)
            {
                res.IsSuccessful = false;
                res.Message = "Error occurred while saving.";
                return res;
            }

            res.IsSuccessful = true;
            res.Message = "Done!";
            return res;
        }

        public async Task<GetAllCustomersResponse> GetAllCustomers()
        {  
            var res = new GetAllCustomersResponse();
            var customerRes = new List<CustomerResponse>();


            var customers =await _customerRepository.GetAllCustomers().ConfigureAwait(false);
            if (customers.Count == 0)
            {
                res.IsSuccesfull = false;
                res.Customers = null;
                return res;
            }

            var lgas = await _customerRepository.GetLGAs().ConfigureAwait(false);
            var states = await _customerRepository.GeStates().ConfigureAwait(false);

            foreach (var customer in customers)
            {

                customerRes.Add(new CustomerResponse
                {
                     DateCreated = customer.DateCreated,
                     Email = customer.Email,
                     LGA = lgas.Where(s => s.Id == customer.LGAId).FirstOrDefault()?.Name ,
                     Password = customer.Password,
                     PhoneNumber = customer.PhoneNumber,
                     State = states.Where(s=>s.Id == customer.StateId).FirstOrDefault()?.Name
                });
            }

          

           
          
            res.IsSuccesfull = true;
            res.Customers = customerRes;
             

            return res;
        }

        public async Task<GenerateOtpResponse> GenerateOtp(string phoneNumber)
        {
            var res = new GenerateOtpResponse();
            if (string.IsNullOrEmpty(phoneNumber))
            {
                res.Isuccessfull = false;
                res.Message = "Invalid Phone Number.";
                return res;
            }

            var otpRequest = new OtpLog { PhoneNumber = phoneNumber };

            var OtpSender = await _otpSender.SendOtp(phoneNumber, otpRequest.OtpCode).ConfigureAwait(false);

            if(!OtpSender)
            {
                res.Isuccessfull = false;
                res.Message = "Failed to send Otp!";
                return res;
            }

            var otpRes = await _otpLogRepository.CreateOtpLog(otpRequest).ConfigureAwait(false);

            if(!otpRes)
            {
                res.Isuccessfull = false;
                res.Message = "Error!";
                return res;
            }

            res.Isuccessfull = true;
            res.Message = "An Otp has been sent to "+phoneNumber+" !";
            return res;

        }

        public async Task<GetAllLgaAndStateRes> GetAllLgaAndState()
        {
            var lgas = await _customerRepository.GetLGAs().ConfigureAwait(false);
            var states = await  _customerRepository.GeStates().ConfigureAwait(false);
            var res = new GetAllLgaAndStateRes();
            
            if (lgas.Count == 0 || states.Count == 0 )
            {
                res.IsSuccessful = false;
                return res;
            }

            res.LGAs = lgas;
            res.States = states;
            res.IsSuccessful = true;
           
            return res;

        }
    }
}
