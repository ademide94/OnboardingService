using OnboardingInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingInfrastructure.NewFolder
{
    public interface IAlatService
    {
       Task<GetBanksResponse> GetBanks();
    }
}
