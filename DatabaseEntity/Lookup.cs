using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEntity
{
    public class Lookup : _BaseEntity
    {
        public string DisplayValue { get; set; }
        public string Key { get; set; }
        public string GroupName { get; set; }
    }
}
