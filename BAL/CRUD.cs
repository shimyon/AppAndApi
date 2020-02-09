using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class CRUD<T> : ICRUD<T> where T : class
    {
        DatabaseEntity.dbs context = new DatabaseEntity.dbs();
        public ResultMsg Create(T entity)
        {
            ResultMsg result = new ResultMsg();
            try
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
                result.IsOk = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex.Message;
                if (ex.InnerException != null)
                {
                    result.InnerException = ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                    {
                        result.InnInnerException = ex.InnerException.InnerException.Message;
                    }
                }
                result.StackTrace = ex.StackTrace;
                result.IsOk = false;
            }
            return result;
        }

        public ResultMsg Delete(Guid TblId)
        {
            throw new NotImplementedException();
        }

        public ResultMsg Edit(Guid TblId, T Tbl)
        {
            ResultMsg result = new ResultMsg();
            try
            {

                if (Tbl == null)
                    return null;

                T existing = context.Set<T>().Find(TblId);

                if (existing != null)
                {
                    context.Entry(existing).CurrentValues.SetValues(Tbl);
                    context.SaveChanges();
                }
                result.IsOk = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex.Message;
                if (ex.InnerException != null)
                {
                    result.InnerException = ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                    {
                        result.InnInnerException = ex.InnerException.InnerException.Message;
                    }
                }
                result.StackTrace = ex.StackTrace;
                result.IsOk = false;
            }
            return result;
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            var rec = context.Set<T>().FirstOrDefault(filter);
            return rec;
        }

        public List<T> GetAll()
        {
            var list = context.Set<T>().ToList();
            return list;
        }
    }
}
