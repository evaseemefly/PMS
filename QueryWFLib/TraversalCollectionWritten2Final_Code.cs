using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using PMS.Model.Enum;

namespace QueryWFLib
{

    public sealed class TraversalCollectionWritten2Final_Code : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Text { get; set; }

        /// <summary>
        /// 输入的查询状态
        /// </summary>
        public InArgument<QueryState_Enum> State_Query { get; set; }

        /// <summary>
        /// 输入的在步骤二进行的查询结果集合
        /// </summary>
        public InArgument<List<PMS.Model.SMSModel.SMSModel_QueryReceive>> List_QueryModel { get; set; }

        /// <summary>
        /// 输出的符合条件的查询对象集合
        /// </summary>
        public OutArgument<List<PMS.Model.SMSModel.SMSModel_QueryReceive>> List_QueryReceive { get; set; }

        /// <summary>
        /// 返回最终的匹配结果（枚举）
        /// </summary>
        public OutArgument<MatchCondition_Enum> Enum_MatchCondition { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            string text = context.GetValue(this.Text);

            List<PMS.Model.SMSModel.SMSModel_QueryReceive> list_ordQuery = context.GetValue(this.List_QueryModel);

            List<PMS.Model.SMSModel.SMSModel_QueryReceive> list_newQuery = new List<PMS.Model.SMSModel.SMSModel_QueryReceive>();

            var state_query = context.GetValue(this.State_Query);

            MatchCondition_Enum state_match= MatchCondition_Enum.other;

            //var state = context.GetValue(this.State_Query);
            ExistEnum exist_enum = ExistEnum.isNotExist;
            int index = 0;
            
            if (list_ordQuery.Count() > 0&&state_query== QueryState_Enum.remnant)
            {
                //遍历当前集合
                list_ordQuery.ForEach(r => 
                {
                    index++;
                    Common.LogHelper.WriteWarn(string.Format("查询第{0}个对象", index));
                    //为当前集合中的每个对象创建查询实例
                    var queryReceive = new QueryRecive(r);
                    //判断当前查询结果是否满足条件
                    var exist_temp = queryReceive.Execute();
                    exist_enum=(exist_temp == ExistEnum.isExist)? ExistEnum.isExist:ExistEnum.isNotExist;
                    if (exist_enum == ExistEnum.isExist)
                    {
                        list_newQuery.Add(r);
                        state_match = MatchCondition_Enum.conform;
                    }
                });
                
            }

            context.SetValue(List_QueryReceive, list_newQuery);

            context.SetValue(Enum_MatchCondition, state_match);
        }
    }
}
