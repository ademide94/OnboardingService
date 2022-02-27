using System;
using System.Collections.Generic;
using System.Text;
using OnboardingData;


namespace OnboardingBusinessLogic.Models
{
    public class GetAllCustomersResponse
    {
        public bool IsSuccesfull { get; set; }
        public List<CustomerResponse> Customers { get; set; }
    }

    public class CustomerResponse
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public string LGA { get; set; }
        public string State { get; set; }
    }
}
