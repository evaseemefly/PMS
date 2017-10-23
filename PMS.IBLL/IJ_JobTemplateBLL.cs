using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
    public partial interface IJ_JobTemplateBLL
    {
        List<J_JobTemplate> GetAllJobTemplate();
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        bool AddJobTemplate(PMS.Model.ViewModel.ViewModel_JobTemplate model);
        /// <summary>
        /// 编辑用户 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool EditJobTemplate(PMS.Model.ViewModel.ViewModel_JobTemplate model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="JTID"></param>
        /// <returns></returns>

        bool DelJobTemplate(List<int> JTID);


        ///<summary>
        ///数据验证
        ///</summary>
        ///<param name="name"></param>
        bool AddValidation(string name);

        ///<summary>
        ///数据验证
        ///</summary>
        ///<param name="name"></param>
        ///<returns></returns>
        bool EditValidation(int id, string name);

        /// <summary>
        /// 根据角色ID得到模板
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        List<J_JobTemplate> GetJobTemplateByRole(int rid);
        /// <summary>
        /// 根据用户ID得到模板
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        List<J_JobTemplate> GetJobTemplateByUser(int rid);

        /// <summary>
        /// 执行为用户分配模板
        /// </summary>
        /// <param name="JTID"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool SetTemplate4UserInfo(int JTID, List<int> ids);
    }
}
