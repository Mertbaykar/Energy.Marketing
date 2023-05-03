using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Models
{
    public class MarketStatistic
    {
        public decimal Average { get; set; }
        public DateTime Date { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public decimal WeightedAverage { get; set; }
        public decimal Summary { get; set; }


    }
}
