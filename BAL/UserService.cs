using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntity;

namespace BAL
{
    public class UserService : ICRUDS<DatabaseEntity.User>
    {
        CRUD<DatabaseEntity.User> crud = new CRUD<User>();
        public ResultMsg Create(User Tbl)
        {
            return crud.Create(Tbl);
        }

        public ResultMsg Delete(Guid TblId)
        {
            throw new NotImplementedException();
        }

        public ResultMsg Edit(Guid TblId, User Tbl)
        {
            return crud.Edit(TblId, Tbl);
        }

        public User Get(Guid TblId)
        {
            return crud.Get(w => w.Id == TblId);
        }

        public List<User> GetAll()
        {
            return crud.GetAll();
        }
    }
}
