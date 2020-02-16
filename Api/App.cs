using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api
{
    public static class App
    {
        public static Guid TenentID
        {
            get
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.Headers["tenentid"]))
                {
                    return new Guid(HttpContext.Current.Request.Headers["tenentid"]);
                }
                return Guid.Empty;
            }
        }
    }
}