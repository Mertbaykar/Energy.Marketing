using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Models
{
    public class McpSmpResponse
    {
        public McpSmpContainer Body { get; set; }
        public string ResultCode { get; set; }
        public string ResultDescription { get; set; }
    }
}
