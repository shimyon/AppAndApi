using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class GeneratePDF : AGenerateFile
    {
        public override object Generate()
        {
            var pdfBytes = (new NReco.PdfGenerator.HtmlToPdfConverter()).GeneratePdf(Data);
            return pdfBytes;
            //return base.Generate();
        }
    }
}
