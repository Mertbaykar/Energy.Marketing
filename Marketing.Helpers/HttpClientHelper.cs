using Marketing.Models;
using Marketing.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Marketing.Helpers
{
    public class HttpClientHelper
    {
        public static async Task<TResult> GetFromUrlAsync<TResult>(string url) where TResult : class
        {
            try
            {
                HttpClient client = new HttpClient();
                var responseMessage = await client.GetAsync(url);
                var result = await responseMessage.Content.ReadFromJsonAsync<TResult>();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
