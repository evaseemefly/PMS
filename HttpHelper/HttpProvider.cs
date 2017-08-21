using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpHelper
{
    public class HttpProvider: IHttpProvider
    {
        public HttpResponseParameter Excute(HttpRequestParameter requestParameter)
        {
            return HttpCore.Excute(requestParameter);
        }
    }
    
}
