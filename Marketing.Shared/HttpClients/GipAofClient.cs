using Marketing.Shared.HttpClients.Base;

namespace Marketing.Shared.HttpClients
{
    public class GipAofClient : HttpClientBase
    {
        public GipAofClient(HttpClient httpClient) : base(httpClient)
        {
            _httpClient.BaseAddress = new Uri(Constants.GIPAOFUrl);
        }
    }
}
