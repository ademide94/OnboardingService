using OnboardingData;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingBusinessLogic.Models
{
    public class GetAllLgaAndStateRes
    {
        public bool IsSuccessful { get; set; }
        public List<LGA> LGAs { get; set; }
        public List<State>  States { get; set; }
    }
}
