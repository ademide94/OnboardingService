using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardingBusinessLogic;
using OnboardingBusinessLogic.Models;

namespace OnboardingApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerInfoController : ControllerBase
    {
        private readonly ICustomerInfoService _customerInfoService;
        public CustomerInfoController(ICustomerInfoService customerInfoService)
        {
            _customerInfoService = customerInfoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer (CreateCustomerRequest customerRequest)
        {
            if(customerRequest == null)
            {
                return BadRequest("Invalid request.");
            }
            var res = await _customerInfoService.CreateCustomer(customerRequest).ConfigureAwait(false);

            if(!res.IsSuccessful)
            {
                return StatusCode(500, res.Message);
            }
            return Ok(res.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
           
            var res = await _customerInfoService.GetAllCustomers().ConfigureAwait(false);

            if (res.Customers == null)
            {
                return StatusCode(500, "No records found!");
            }
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateOtp(string phoneNumber)
        {
            if( string.IsNullOrEmpty(phoneNumber))
            {
                return BadRequest("Invalid request.");
            }

            if (phoneNumber.Length > 11)
            {
                return BadRequest("Invalid request.");
            }

            var res = await _customerInfoService.GenerateOtp(phoneNumber).ConfigureAwait(false);

            if (!res.Isuccessfull)
            {
                return StatusCode(500, res.Message);
            }
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLgaAndState()
        {
           
            var res = await _customerInfoService.GetAllLgaAndState().ConfigureAwait(false);

            if (res == null)
            {
                return StatusCode(500, "No records found!");
            }
            return Ok(res);
        }
    }
}
