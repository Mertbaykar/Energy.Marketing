using Marketing.Shared.Enums;
using Marketing.Shared.JSONConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Marketing.Models
{
    public class IdmAofAverage
    {
        [JsonConverter(typeof(DateTimeCustomConverter))]
        public DateTime Date { get; set; }
        public decimal? Aof { get; set; }
        public long Period { get; set; }
        public PeriodType PeriodType { get; set; }
    }
}
