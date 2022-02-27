using OnboardingData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingRepository.OtpLogRepo
{
    public interface IOtpLogRepository
    {
        Task<OtpLog> GetOtpLog(int otp, string phoneNumber);
        Task<bool> CreateOtpLog(OtpLog otpLog);
        Task<bool> UpdateOtpLog(OtpLog otpLog);
    }
}
