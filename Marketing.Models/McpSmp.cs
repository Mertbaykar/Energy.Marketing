using Marketing.Shared.JSONConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Marketing.Models
{
    public class McpSmp
    {
        [JsonConverter(typeof(DateTimeCustomConverter))]
        public DateTime Date { get; set; }
        public decimal? Mcp { get; set; }
        public decimal? Smp { get; set; }
        public McpState? McpState { get; set; }
        public SmpDirection? SmpDirection { get; set; }
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum McpState
    {
        INTERIM,
        FINAL
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SmpDirection
    {
        ENERGY_DEFICIT,
        IN_BALANCE,
        ENERGY_SURPLUS
    }
}
