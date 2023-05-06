using Marketing.Shared.HttpClients.Base;


namespace Marketing.Shared.HttpClients
{
    public class PtfSmpClient : HttpClientBase
    {
        public PtfSmpClient(HttpClient httpClient) : base(httpClient)
        {
            _httpClient.BaseAddress = new Uri(Constants.PTFAndSMFUrl);
        }
    }
}
