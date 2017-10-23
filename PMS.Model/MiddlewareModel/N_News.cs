using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace PMS.Model
{
   public partial class N_News
    {
        public N_News ToMiddleModel()
        {
            return new N_News()
            {
                SNID = this.SNID,
                isDel = this.isDel,
                NewsType = this.NewsType,
                SubDateTime = this.SubDateTime,
                Title = this.Title,
                UID = this.UID,
                NewsContent = this.NewsContent
            };
        }
    }
}
