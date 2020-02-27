using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntity;
using BAL.ViewModel;

namespace BAL
{
    public class TenentService : ICRUDS<DatabaseEntity.Tenent>
    {
        DatabaseEntity.dbs context = new DatabaseEntity.dbs();
        CRUD<DatabaseEntity.Tenent> crud = new CRUD<Tenent>();
        public ResultMsg Create(Tenent Tbl)
        {
            return crud.Create(Tbl);
        }

        public ResultMsg Delete(Guid TblId)
        {
            throw new NotImplementedException();
        }

        public ResultMsg Edit(Guid TblId, Tenent Tbl)
        {
            throw new NotImplementedException();
        }

        public Tenent Get(Guid TblId)
        {
            return crud.Get(w => w.Id == TblId);
        }

        public List<Tenent> GetAll()
        {
            return crud.GetAll();
        }

        public ResultMsgLogin LoginUser(TenentLogin login)
        {
            ResultMsgLogin result = new ResultMsgLogin();
            try
            {
                var tenent = context.Tenents.FirstOrDefault(f => f.ClientId == login.ClientId);
                if (tenent == null)
                {
                    result.IsOk = false;
                    result.DisplayMsg = "Client id is wrong!";
                    return result;
                }
                result.TenentId = tenent.Id;
                var user = context.Users.FirstOrDefault(f => f.UserName == login.UserName && f.Password == login.Password && f.TenentId == tenent.Id);
                if (user == null)
                {
                    result.IsOk = false;
                    result.DisplayMsg = "Userid or password not match!";
                    return result;
                }else
                {
                    result.IsOk = true;
                }
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
    }
}
