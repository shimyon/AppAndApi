using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class ResultMsg
    {
        public bool IsOk { get; set; }
        public string DisplayMsg { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public string InnInnerException { get; set; }
    }
}
