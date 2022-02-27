using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingInfrastructure
{
    public class OtpSender : IOtpSender
    {
        public async Task<bool> SendOtp(string PhoneNumber, int Code)
        {
            return true;
        }
    }
}
