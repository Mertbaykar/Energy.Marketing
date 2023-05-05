using Marketing.Shared.JSONConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Marketing.Models
{
    public class IdmAof
    {
        [JsonConverter(typeof(DateTimeCustomConverter))]
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

    }
}
