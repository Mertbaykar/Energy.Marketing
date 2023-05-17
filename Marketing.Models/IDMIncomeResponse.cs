using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Models
{
    public class IDMIncomeResponse
    {
        public IDMIncomeContainer Body { get; set; }
        public string ResultCode { get; set; }
        public string ResultDescription { get; set; }
    }
}
