using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.ViewModel
{
   public class ViewModel_News
    {
        public int SNID { get; set; }

        public int NewsType { get; set; }

        public string Title { get; set; }

        public string NewsContent { get; set; }

        public DateTime SubDateTime { get; set; }

        public List<UserInfo> list_User { get; set; }

    }
}
