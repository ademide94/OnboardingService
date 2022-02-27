using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingInfrastructure.Models
{
    public class GetBanksResponse
    {
        public bool IsScuccessfull {get; set;}
        public AlatResponse AlatResponse { get; set; }
    }

    public class Result
    {
        public string bankName { get; set; }
        public string bankCode { get; set; }
    }

    public class AlatResponse
    {
        public Result result { get; set; }
        public string errorMessage { get; set; }
        public List<string> errorMessages { get; set; }
        public bool hasError { get; set; }
        public DateTime timeGenerated { get; set; }
    }
}
