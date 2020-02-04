using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntity;

namespace BAL
{
    public class TenentService : ICRUD<DatabaseEntity.Tenent>
    {
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
            throw new NotImplementedException();
        }

        public List<Tenent> GetAll()
        {
            return crud.GetAll();
        }
    }
}
