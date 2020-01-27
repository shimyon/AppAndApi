using AppAndApi.PluginServer.GenerateFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppAndApi.Controllers
{
    public class InvoiceController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GenereteFile(AGenerateFile GenFile)
        {
            
            return Ok();
        }
    }
}
