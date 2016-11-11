using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.ViewModel
{
    /// <summary>
    /// 1 提交的短信的相关信息[
    /// 1）联系人id
    /// 2）群组id
    /// 3）电话号码
    /// 4）内务id
    /// 5）短息内容]
    /// 2 作业相关信息
    /// </summary>
   public class ViewModel_Message : ViewModel_BaseJob
    {
        /// <summary>
        /// 此处修改
        /// 此处的id是不发送的人员id
        /// </summary>
        public string PersonIds { get; set; }

        public int[] PersonId_Int
        {
            get
            {
                if (PersonIds.Length > 0 && PersonIds != "undefined")
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

        public int[] GroupIds
        {
            get; set;
        }

        public int[] DepartmentIds
        {
            get; set;
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
