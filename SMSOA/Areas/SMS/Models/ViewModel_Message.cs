using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.SMS.Models
{
    public class ViewModel_Message
    {
        public string PersonIds { get; set; }

        public int[] PersonId_Int
        {
            get
            {
                //使用新的方法将string数组转成int数组
                return Array.ConvertAll<string,int>(PersonIds.Split(','),s=>int.Parse(s));
            }
        }

        public string Content { get; set; }
    }
}