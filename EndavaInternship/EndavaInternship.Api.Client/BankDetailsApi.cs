using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EndavaInternship.Api.Contracts;
using Newtonsoft.Json;

namespace EndavaInternship.Api.Client
{
    public class BankDetailsApi
    {
        private const string ApiPath = "http://localhost:8890/endavainternship-api/bankdetails/";

        public async Task Create(CreateUserBankDetailsRequest request)
        {
            var uri = new Uri(ApiPath);
            var content = request.GetJsonDataStream();

            using (var client = new HttpClient())
            {
                await client.PostAsync(uri, content);
            }
        }

        public async Task<BankDetailsResponse> Get(string id)
        {
            var uri = new Uri(ApiPath + id);

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uri);
                var content = await result.Content.ReadAsStringAsync();
                return content.To<BankDetailsResponse>();
            }
        }
    }

    internal static class Extensions
    {
        internal static StringContent GetJsonDataStream<T>(this T request)
        {
            return new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        }

        internal static T To<T>(this string request)
        {
            return JsonConvert.DeserializeObject<T>(request);
        }
    }
}