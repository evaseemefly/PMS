using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model.SMSModel;
using PMS.IBLL;
using DelegateSMS;

namespace ISMS
{
    /// <summary>
    /// 短信发送接口
    /// 本接口主要用于：根据xml格式发送短信，以及返回短信发送后的反馈信息
    /// </summary>
    public interface ISMSSend
    {
       

        /// <summary>
        /// 短信发送
        /// 返回是否成功bool
        /// 以及根据out参数输出短信发送接收实体对象
        /// </summary>
        /// <param name="smsdata"></param>
        /// <returns></returns>
        bool SendMsg(/*PMS.Model.CombineModel.SendAndMessage_Model*/  PMS.IModel.ISendAndMessage_Model model, out /*PMS.Model.Message.BaseResponse*/SMSModel_Receive receive);

        /// <summary>
        /// 获取添加的临时联系人
        /// 向数据库中写入这些临时联系人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="personBLL"></param>
        /// <param name="groupBLL"></param>
        /// <returns></returns>
        List<string> AddAndGetTempPersons(PMS.Model.ViewModel.ViewModel_Message model, IP_PersonInfoBLL personBLL, IP_GroupBLL groupBLL);

        /// <summary>
        /// 在发送短信之后执行
        ///  步骤五：
        ///  创建短信内容至数据库 
        ///  创建发送记录至数据库
        /// （此处应放在SMSFactory.SendMsg或写在JobInstance中的SendJob.Exceuted）
        /// </summary>
        /// <param name="model"></param>
        /// <param name="receive"></param>
        /// <param name="list_phones"></param>
        /// <param name="redis_list_id">redis中保存的list的key</param>
        /// <param name="redis_expirationDate">redis中保存集合的过期时间（默认72小时）</param>
        /// <returns></returns>
        bool AfterSend(PMS.Model.ViewModel.ViewModel_Message model, SMSModel_Receive receive, List<string> list_phones, string redis_list_id, int redis_expirationDate = 72);

        /// <summary>
        /// 获取短信内容
        /// 封装要提交至联通接口的发送对象（含联系人电话号码）
        /// </summary>
        /// <param name="model">短信对象</param>
        /// <param name="list_phones"></param>
        /// <returns></returns>
        SMSModel_Send ToSendModel(PMS.Model.ViewModel.ViewModel_Message model, List<string> list_phones);

        /// <summary>
        /// 获取传入的群组及部门获取对应联系人
        ///获取要删除的联系人id
        ///从联系人集合中去除要删除的联系人获得最终要发送的联系人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="delegateGetPersonList"></param>
        /// <returns></returns>
        List<string> GetFinalPersonPhoneList(PMS.Model.ViewModel.ViewModel_Message model, delegate_GetPersonListByGroupDepartment delegateGetPersonList);
    }
}
