using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingBusinessLogic.Models
{
    public class CreateCustomerRequest
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int LgaId { get; set; }
        public int StateId { get; set; }
        public int Otp { get; set; }
    }
}
