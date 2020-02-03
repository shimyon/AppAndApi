using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface ICRUD<T> where T : class
    {
        ResultMsg Create(T Tbl);
        ResultMsg Delete(Guid TblId);
        ResultMsg Edit(Guid TblId, T Tbl);
        T Get(Guid TblId);
        List<T> GetAll();
    }
}
