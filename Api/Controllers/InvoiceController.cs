using Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Api.Controllers
{
    public class InvoiceController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GenereteFile(GeneratePDF GenFile)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);

            byte[] buffer = (byte[])GenFile.Generate();
            var contentLength = buffer.Length;
            var statuscode = HttpStatusCode.OK;
            response = Request.CreateResponse(statuscode);
            response.Content = new StreamContent(new MemoryStream(buffer));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentLength = contentLength;
            ContentDispositionHeaderValue contentDisposition = null;
            string RandomeFile = Guid.NewGuid().ToString();
            if (ContentDispositionHeaderValue.TryParse("inline; filename=" + RandomeFile + ".pdf", out contentDisposition))
            {
                response.Content.Headers.ContentDisposition = contentDisposition;
            }
            return response;
        }
    }
}
