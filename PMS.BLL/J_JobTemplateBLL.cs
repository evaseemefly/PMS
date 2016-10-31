using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace PMS.BLL
{
    public partial class J_JobTemplateBLL
    {
        /// <summary>
        /// 获取全部的模板
        /// </summary>
        /// <returns></returns>
        public List<J_JobTemplate> GetAllJobTemplate()
        {
            return null;
        }

        /// <summary>
        /// 根据角色查询该角色拥有的模板
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<J_JobTemplate> GetJobTemplateByUser(int uid)
        {
            return null;
        }

        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddJobTemplate(PMS.Model.ViewModel.ViewModel_JobTemplate model)
        {
            return false;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditJobTemplate(PMS.Model.ViewModel.ViewModel_JobTemplate model)
        {
            return false;
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="JTID"></param>
        /// <returns></returns>
        public bool DelJobTemplate(int JTID)
        {
            return false;
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool PhysicsDel(List<int> list_ids)
        {
            return false;
        }

        /// <summary>
        /// 还原
        /// </summary>
        /// <param name="list_id"></param>
        /// <returns></returns>
        public bool Recovery(List<int> list_id)
        {
            return false;
        }
    }
}
