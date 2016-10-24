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
                if (PersonIds.Length > 0&&PersonIds!= "undefined")
                {
                    //使用新的方法将string数组转成int数组
                    return Array.ConvertAll<string, int>(PersonIds.Split(','), s => int.Parse(s));
                }
                else
                {
                    return null;
                }
                
            }
        }

        public string PhoneNums { get; set; }

        public string[] PhoneNum_Str
        {
            get
            {
                if (PhoneNums == null)
                {
                    return null;
                }
                
                if (PhoneNums.Length > 0)
                {
                    //使用新的方法将string字符串改为数组
                    return PhoneNums.Split(',');
                }
                else
                {
                    return null;
                }

            }
        }

        public string Content { get; set; }
        public string SMSMissionID { get; set; }
    }
}