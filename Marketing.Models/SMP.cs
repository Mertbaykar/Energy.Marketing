using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Models
{
    public class SMP
    {
        public DateTime Date { get; set; }
        public DateTime NextHour => Date.AddHours(1);
        //public DateTime NextHour { get; set; }
        public decimal Price { get; set; }
        public string SmpDirection { get; set; }
        public long SmpDirectionId { get; set; }
    }
}
