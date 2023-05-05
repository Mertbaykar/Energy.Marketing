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
        public static string CreateUrl(string url, DateTime startDate, DateTime endDate, string? region = null)
        {
            var builder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["startDate"] = startDate.ToString("yyyy-MM-dd");
            query["endDate"] = endDate.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(region))
                query["region"] = region;
            var decodedUrl = HttpUtility.UrlDecode(query.ToString());
            builder.Query = decodedUrl;
            return builder.ToString();
        }

        public static string CreateUrl(string url, DateTime startDate, DateTime endDate, Period period)
        {
            var builder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["startDate"] = startDate.ToString("yyyy-MM-dd");
            query["endDate"] = endDate.ToString("yyyy-MM-dd");
            query["period"] = period.ToString();
            var decodedUrl = HttpUtility.UrlDecode(query.ToString());
            builder.Query = decodedUrl;
            return builder.ToString();
        }

        public static async Task<TResult> GetFromUrlAsync<TResult>(string url, DateTime startDate, DateTime endDate, string? region = null) where TResult : class
        {
            try
            {
                string finalUrl = CreateUrl(url, startDate, endDate, region);
                HttpClient client = new HttpClient();
                var responseMessage = await client.GetAsync(finalUrl);
                var result = await responseMessage.Content.ReadFromJsonAsync<TResult>();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<TResult> GetFromUrlAsync<TResult>(string url, DateTime startDate, DateTime endDate, Period period) where TResult : class
        {
            try
            {
                string finalUrl = CreateUrl(url, startDate, endDate, period);
                HttpClient client = new HttpClient();
                var responseMessage = await client.GetAsync(finalUrl);
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
