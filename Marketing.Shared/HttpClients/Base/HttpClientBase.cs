using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Marketing.Shared.HttpClients.Base
{
    public abstract class HttpClientBase
    {
        protected HttpClientBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        protected HttpClient _httpClient;
        protected JsonSerializerOptions JsonSerializerOptions => new JsonSerializerOptions { WriteIndented = true, ReferenceHandler = ReferenceHandler.IgnoreCycles, PropertyNameCaseInsensitive = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

        /// <summary>
        /// Base url ile <paramref name="queryString"/> birleşimi olan url'e Get request atar ve response'u <typeparamref name="TResult"/> tipinde cevap döner
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="queryString"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public virtual async Task<TResult> GetAsync<TResult>(string queryString) where TResult : class
        {
            try
            {
                //HttpClient client = new HttpClient();
                var responseMessage = await _httpClient.GetAsync(queryString);
                var result = await responseMessage.Content.ReadFromJsonAsync<TResult>(JsonSerializerOptions);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
