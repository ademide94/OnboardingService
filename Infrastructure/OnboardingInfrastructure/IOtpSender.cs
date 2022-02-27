using System;
using System.Threading.Tasks;

namespace OnboardingInfrastructure
{
    public interface IOtpSender
    {
        Task<bool> SendOtp(string PhoneNumber, int Code);
    }
}
