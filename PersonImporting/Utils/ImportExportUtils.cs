using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonImporting.Utils
{
    public static class ImportExportUtils
    {
        /// <summary>
        /// 数据约束:文件名格式
        /// </summary>
        /// <returns></returns>
        public static bool FileFormateValidation(string fullPath)
        {
            //1.判断后缀名
            string extention = Path.GetExtension(fullPath);
            if (!(extention.Equals(".txt"))){ return false; }
            //2.判断群组的优先级是否为3位数字
            string fullNameWithOutExtension = Path.GetFileNameWithoutExtension(fullPath);

            if(fullNameWithOutExtension.Length <= 3) { return false; }

            //3.判断前三位是否为数字
            for (int i = 0; i < 3; i++)
            {
                if (fullNameWithOutExtension[i] <= '9' & fullNameWithOutExtension[i] >= '0')
                {

                }
                else
                {
                    return false;
                }    
            }
            return true;
        }
        /// <summary>
        /// 数据约束:文件内容格式(用于导入群组联系人）
        /// </summary>
        /// <returns></returns>
        public static bool ContactsValidation(string txtLine)
        {
            var array = txtLine.Split(',');
            //格式错误
            if (array.Length != 3) {
                return false;}
            //电话号码不为11位
            if(array[2].Length != 11) {
                return false; }
            return true;
        }

        /// <summary>
        /// 数据约束:文件内容格式(用于导入任务）
        /// </summary>
        /// <param name="txtLine"></param>
        /// <returns></returns>
        public static bool ContactsValidationM(string txtLine)
        {
            var array = txtLine.Split(',');
            //格式错误
            if (array.Length != 4)
            {
                return false;
            }
            if (!(array[1].Equals("g") | array[1].Equals("d")))
            {
                return false;
            }
            //
            if (!(array[2].Equals("sms")| array[2].Equals("mms")))
            {
                return false;
            }
            if (!(array[3].Equals("1") | array[3].Equals("0")))
            {
                return false;
            }
            return true;
        }
    }
}
