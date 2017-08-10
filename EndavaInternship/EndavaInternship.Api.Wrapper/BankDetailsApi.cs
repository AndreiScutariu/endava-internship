using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EndavaInternship.Api.Contract;
using Newtonsoft.Json;

namespace EndavaInternship.Api.Wrapper
{
    public class BankDetailsApi
    {
        private const string ApiKey = "http://localhost:8890/endavainternship-api/bankdetails/";

        public async Task AddAsync(CreateUserBankDetailsRequest request)
        {
            var uri = new Uri(ApiKey);
            var serializedRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(uri, content);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    
                }
            }
        }

        public async Task<UserBankDetailsResponse> GetAsync(string userId)
        {
            var uri = new Uri(ApiKey + userId);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<UserBankDetailsResponse>(content);
            }
        }
    }
}