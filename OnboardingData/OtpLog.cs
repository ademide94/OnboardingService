using OnboardingUtilites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnboardingData
{
    public class OtpLog
    {
        [Key]
        public Guid Id { get; set; }
        public int OtpCode { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsUsed { get; set; }
        public string PhoneNumber {get;set;}

        public OtpLog()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
            OtpCode = 1234;  /// UtilitiesCode.GenerateOtp();
        }
    }
}
