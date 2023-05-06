using Marketing.Shared.HttpClients.Base;


namespace Marketing.Shared.HttpClients
{
    public class SmpClient : HttpClientBase
    {
        public SmpClient(HttpClient httpClient) : base(httpClient)
        {
            _httpClient.BaseAddress = new Uri(Constants.MarginalPriceUrl);
        }
    }
}
