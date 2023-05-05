using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Models
{
    public class McpSmpContainer
    {
        public List<McpSmp> McpSmps { get; set; } = new List<McpSmp>();
        public List<McpSmpStatistic> Statistics { get; set; } = new List<McpSmpStatistic>();
    }
}
