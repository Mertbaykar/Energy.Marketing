using Marketing.Shared.HttpClients.Base;

namespace Marketing.Shared.HttpClients
{
    public class IDMClient : HttpClientBase
    {
        public IDMClient(HttpClient httpClient) : base(httpClient)
        {
            _httpClient.BaseAddress = new Uri(Constants.IDMIncome);
        }
    }
}
