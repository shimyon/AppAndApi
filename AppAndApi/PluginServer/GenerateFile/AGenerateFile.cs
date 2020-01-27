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

    public abstract class AGenerateFile
    {
        public FileType Type { get; set; }
        public object Data { get; set; }
        public virtual void Generate()
        {

        }
    }
}