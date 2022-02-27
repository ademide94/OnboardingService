using OnboardingData;
using OnboardingRepository.BaseRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingRepository.OtpLogRepo
{
    public class OtpLogRepository : IOtpLogRepository
    {
        private readonly IRepository<OtpLog> _repository;
        public OtpLogRepository(IRepository<OtpLog> repository)
        {
            _repository = repository;
        }

        public async Task<OtpLog> GetOtpLog(int otp,string phoneNumber )
        {
            var res = await _repository.GetAsync(s => s.OtpCode == otp && s.PhoneNumber == phoneNumber);
            return res;
        }

        public async Task<bool> CreateOtpLog(OtpLog otpLog)
        {
            var res = await _repository.AddAsync(otpLog).ConfigureAwait(false);
            return res;
        }

        public async Task<bool> UpdateOtpLog(OtpLog otpLog)
        {
            var res = await _repository.Update(otpLog).ConfigureAwait(false);
            return res;
        }

    }
}
