using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SMSFactory
{
    public class CTCWebClient: WebClient
    {
        private int _timeout;
        /// <summary>
        /// 超时时间(毫秒)
        /// </summary>
        public int Timeout
        {
            get
            {
                return _timeout;
            }
            set
            {
                _timeout = value;
            }
        }
        public CTCWebClient()
        {
            this._timeout = 60000;
        }

        public CTCWebClient(int timeout)
        {
            this._timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.Timeout = this._timeout;
            request.ReadWriteTimeout = this._timeout;
            return request;
        }
    }
}
