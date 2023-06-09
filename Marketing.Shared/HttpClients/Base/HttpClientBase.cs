﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Web;
using System.Runtime.CompilerServices;
using Marketing.Shared.Enums;

namespace Marketing.Shared.HttpClients.Base
{
    public abstract class HttpClientBase
    {
        protected HttpClientBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        protected HttpClient _httpClient;

        private JsonSerializerOptions _jsonSerializerOptions = null;
        protected JsonSerializerOptions JsonSerializerOptions
        {
            get
            {
                if (_jsonSerializerOptions == null)
                {
                    _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true, ReferenceHandler = ReferenceHandler.IgnoreCycles, PropertyNameCaseInsensitive = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
                }
                return _jsonSerializerOptions;
            }
        }


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
                var responseMessage = await _httpClient.GetAsync(queryString);
                var result = await responseMessage.Content.ReadFromJsonAsync<TResult>(JsonSerializerOptions);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Base Url'e Get request atar ve response'u <typeparamref name="TResult"/> tipinde cevap döner. Fonksiyon çağrılırken kullanılan parametre adları request esnasında kullanılır
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="period"></param>
        /// <param name="region"></param>
        /// <param name="startDateExpression"></param>
        /// <param name="endDateExpression"></param>
        /// <param name="periodExpression"></param>
        /// <param name="regionExpression"></param>
        /// <returns></returns>
        public virtual async Task<TResult> GetAsync<TResult>(DateTime startDate, DateTime endDate, Period? period = null, string? region = null) where TResult : class
        {
            var builder = new UriBuilder(_httpClient.BaseAddress.ToString());
            var query = HttpUtility.ParseQueryString(builder.Query);

            query["startDate"] = startDate.ToString("yyyy-MM-dd");
            query["endDate"] = endDate.ToString("yyyy-MM-dd");
            if (period.HasValue)
                query["period"] = period.Value.ToString();
            if (!string.IsNullOrEmpty(region))
                query["region"] = region;

            var decodedUrl = HttpUtility.UrlDecode(query.ToString());
            builder.Query = decodedUrl;
            var responseMessage = await _httpClient.GetAsync(builder.ToString());
            var result = await responseMessage.Content.ReadFromJsonAsync<TResult>(JsonSerializerOptions);
            return result;
        }
    }
}
