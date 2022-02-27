using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnboardingInfrastructure.Models;
using OnboardingUtilites;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingInfrastructure.NewFolder
{
    public class AlatService : IAlatService
    {
        private readonly AppSettings _appSettings;
        public AlatService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public async Task<GetBanksResponse> GetBanks ()
        {
            string url = $"{_appSettings.OnboardingGetBanksUrl}";

            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            string result = response.Content.ReadAsStringAsync().Result;


            var res = new GetBanksResponse { AlatResponse = new AlatResponse() };
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var resData = JsonConvert.DeserializeObject<AlatResponse>(result);
                res.AlatResponse.result = resData.result;
                res.IsScuccessfull = true;
            }
            else
            {
                var resData = JsonConvert.DeserializeObject<AlatResponse>(result); 
                res.IsScuccessfull = false;
            }

            return res;
        }
    }
}
