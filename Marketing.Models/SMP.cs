using JSONConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Marketing.Models
{
    public class SMP
    {
        [JsonConverter(typeof(DateTimeCustomConverter))]
        public DateTime Date { get; set; }
        [JsonIgnore]
        public DateTime NextHour => Date.AddHours(1);
        //public DateTime NextHour { get; set; }
        public decimal Price { get; set; }
        public string SmpDirection { get; set; }
        public long SmpDirectionId { get; set; }
    }
}
