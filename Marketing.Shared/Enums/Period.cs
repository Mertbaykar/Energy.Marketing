using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Marketing.Shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Period
    {
        DAILY,
        WEEKLY,
        MONTHLY,
        PERIODIC
    }
}
