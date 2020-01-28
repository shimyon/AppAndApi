using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAndApi.PluginServer.GenerateFile
{
    public enum FileType
    {
        PDF,
        TXT,
        HTML
    }

    public class AGenerateFile
    {
        public FileType Type { get; set; }
        public string Data { get; set; }
        public virtual object Generate()
        {
            return null;
        }
    }
}