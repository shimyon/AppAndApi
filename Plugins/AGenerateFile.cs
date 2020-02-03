using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class AGenerateFile
    {
        public FileType Type { get; set; }
        public string Data { get; set; }
        public virtual object Generate()
        {
            return null;
        }
    }
}
