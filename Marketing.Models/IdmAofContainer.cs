using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Models
{
    public class IdmAofContainer
    {
        public List<IdmAofAverage> IdmAofList { get; set; } = new List<IdmAofAverage>();
        public List<MarketStatistic> Statistics { get; set; } = new List<MarketStatistic>();
    }
}
