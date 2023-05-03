using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Models
{
    public class SMPContainer
    {
        public List<SMP> SmpList { get; set; } = new List<SMP>();
        public List<MarketStatistic> Statistics { get; set; } = new List<MarketStatistic>();
    }
}
