using Marketing.Shared.JSONConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Marketing.Models
{
    public class McpSmpStatistic
    {
        [JsonConverter(typeof(DateTimeCustomConverter))]
        public DateTime Date { get; set; }
        public decimal? McpAvg { get; set; }
        public decimal? McpMax { get; set; }
        public decimal? McpMin { get; set; }
        public decimal? McpWeightedAverage { get; set; }
        public decimal? SmpAvg { get; set; }
        public decimal? SmpMax { get; set; }
        public decimal? SmpMin { get; set; }
        public decimal? SmpWeightedAverage { get; set; }
    }
}
