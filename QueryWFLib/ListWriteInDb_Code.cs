using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using PMS.Model.SMSModel;
using PMS.Model;
using PMS.IBLL;
using Common.Ioc;

namespace QueryWFLib
{

    public sealed class ListWriteInDb_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        public InArgument<List<SMSModel_QueryReceive>> List_Final { get; set; }

        public OutArgument<PMS.Model.Enum.WriteInDb_Enum> Write_Enum { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            string text = context.GetValue(this.Text);
            var list = context.GetValue(this.List_Final);
            //遍历写入数据库
            PMS.Model.Enum.WriteInDb_Enum write_enum = PMS.Model.Enum.WriteInDb_Enum.unknown;

            if (list == null)
            {                
                return;
            }
            WriteInDB(list,ref write_enum);

            context.SetValue(this.Write_Enum, write_enum);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="write_enum"></param>
        private void WriteInDB(List<SMSModel_QueryReceive> list,ref PMS.Model.Enum.WriteInDb_Enum write_enum)
        {
            IS_SMSRecord_CurrentBLL smsRecord_CurrentBLL = UnityServiceLocator.Instance.GetService<IS_SMSRecord_CurrentBLL>();/* new PMS.BLL.S_SMSRecord_CurrentBLL();*/
            //思路
            /*尽量减少反复连接数据库的操作
              先从list中提取msgid不同的对象
             */

            //1 查出不同的msgid集合（IEnmuerable）
            var list_distinct_msgid = from s in list.Distinct(new PMS.Model.EqualCompare.SMSModel_QueryReceive_Compare())
                                      select s.msgId;
            write_enum = PMS.Model.Enum.WriteInDb_Enum.ok;
            //2 遍历
            foreach (var msgid in list_distinct_msgid)
            {
                //2.1 取出对应msgid对应的集合
                var list_temp = (from s in list
                                where s.msgId == msgid
                                select s).ToList();
                //2.2批量写入
                try
                {
                    smsRecord_CurrentBLL.SaveReceieveMsg(list_temp,msgid);

                    Console.WriteLine("写入成功{0}个人其对应msgid为{1}",list_temp.Count(),msgid);
                }
                catch (Exception ex)
                {
                    write_enum =PMS.Model.Enum.WriteInDb_Enum.error;
                }
            }
            
        }
    }
}
