using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Marketing.Helpers
{
    public class HttpClientHelper
    {
        public static string CreateUrl(string url, DateTime startDate, DateTime endDate)
        {
            var builder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["startDate"] = startDate.ToString("yyyy-MM-dd");
            query["endDate"] = endDate.ToString("yyyy-MM-dd");
            var decodedUrl = HttpUtility.UrlDecode(query.ToString());
            builder.Query = decodedUrl;
            return builder.ToString();
        }
    }
}
