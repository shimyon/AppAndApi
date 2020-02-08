using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface ICRUD<T> where T : class
    {
        ResultMsg Create(T Tbl);
        ResultMsg Delete(Guid TblId);
        ResultMsg Edit(Guid TblId, T Tbl);
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll();
    }

    public interface ICRUDS<T> where T : class
    {
        ResultMsg Create(T Tbl);
        ResultMsg Delete(Guid TblId);
        ResultMsg Edit(Guid TblId, T Tbl);
        T Get(Guid TblId);
        List<T> GetAll();
    }


}
