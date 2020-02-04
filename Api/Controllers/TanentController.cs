using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL;
using DatabaseEntity;

namespace Api.Controllers
{
    public class TanentController : ApiController, BAL.ICRUD<DatabaseEntity.Tenent>
    {
        TenentService tenentService = new TenentService();
        [HttpPost]
        public ResultMsg Create(Tenent Tbl)
        {
            ResultMsg resultmsg = tenentService.Create(Tbl);
            if (resultmsg.IsOk)
            {
                resultmsg.DisplayMsg = "Saved successfully";
            }
            return resultmsg;
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

        [HttpPost]
        public List<Tenent> GetAll()
        {
            return tenentService.GetAll();
        }
    }
}