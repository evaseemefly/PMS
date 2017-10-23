using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public abstract class BaseImageProcessing
    {
        protected System.IO.Stream picture_stream { get; set; }
        protected string fileDirectory { get; set; }


        public abstract string Excute(string content, out string fileNameIncludeExt);
    }
}
