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
    public class UserController : ApiController, BAL.ICRUDS<DatabaseEntity.User>
    {
        BAL.UserService userService = new BAL.UserService();
        [HttpPost]
        public ResultMsg Create(User Tbl)
        {
            Tbl.TenentId = App.TenentID;
            ResultMsg resultmsg = userService.Create(Tbl);
            if (resultmsg.IsOk)
            {
                resultmsg.DisplayMsg = "Saved successfully";
            }
            else
            {
                resultmsg.DisplayMsg = "Error in saved data";
            }
            return resultmsg;
        }

        public ResultMsg Delete(Guid TblId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ResultMsg Edit(Guid TblId, User Tbl)
        {
            ResultMsg resultmsg = userService.Edit(TblId, Tbl);
            if (resultmsg.IsOk)
            {
                resultmsg.DisplayMsg = "Saved successfully";
            }
            else
            {
                resultmsg.DisplayMsg = "Error in saved data";
            }
            return resultmsg;
        }

        [HttpPost]
        public User Get(Guid TblId)
        {
            return userService.Get(TblId);
        }

        [HttpPost]
        public List<User> GetAll()
        {
            return userService.GetAll();
        }
    }
}
 