namespace CommuteUpdater
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class TflClient : ITflClient
    {
        private readonly string _baseUrl;

        public TflClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<List<DisruptionResponse>> GetDisruptionsForLineAsync(string lineId)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_baseUrl + "/line/" + lineId + "/disruption");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DisruptionResponse>>(responseBody);
            }
        }
    }
}