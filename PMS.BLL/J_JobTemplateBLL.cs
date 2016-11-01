using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IBLL;
using PMS.Model.ViewModel;

namespace PMS.BLL
{
    public partial class J_JobTemplateBLL : IBaseDelBLL
    {
        /// <summary>
        /// 获取全部的模板
        /// </summary>
        /// <returns></returns>
        public List<J_JobTemplate> GetAllJobTemplate()
        {
            List<J_JobTemplate> list_jobTemplate = new List<J_JobTemplate>();
            list_jobTemplate = this.GetListBy(p => p.isDel == false).ToList();
            return list_jobTemplate;
        }

        /// <summary>
        /// 根据角色查询该角色拥有的模板
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<J_JobTemplate> GetJobTemplateByRole(int rid)
        {
            //1.得到指定id的角色对象
            var roleInfo = this.CurrentDBSession.RoleInfoDAL.GetListBy(r => r.ID == rid).FirstOrDefault();
            if(roleInfo == null) { return null; }
            //2.得到该角色的全部模板
            return roleInfo.J_JobTemplate.ToList();
            
        }

        /// <summary>
        /// 根据用户查询该用户拥有的模板
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<J_JobTemplate> GetJobTemplateByUser(int uid)
        {
            //1.得到指定id的角色对象
            var userInfo = this.CurrentDBSession.UserInfoDAL.GetListBy(r => r.ID == uid).FirstOrDefault();
            if (userInfo == null) { return null; }
            //2.得到该角色的全部模板
            return userInfo.J_JobTemplate.ToList();
        }

        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddJobTemplate(PMS.Model.ViewModel.ViewModel_JobTemplate model)
        {
            if (model != null)
            {
                J_JobTemplate jobTemplate = new J_JobTemplate()
                {
                    JobClassName = model.JobClassName,
                    JobType = model.JobType,
                    CronStr = model.CronStr,
                    Remark =model.Remark
                };
                try
                {
                    this.Create(jobTemplate);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditJobTemplate(PMS.Model.ViewModel.ViewModel_JobTemplate model)
        {

            if(model != null)
            {
                var jobTemplate = this.GetListBy(p => p.JTID == model.JTID).FirstOrDefault();
                jobTemplate.JobClassName = model.JobClassName;
                jobTemplate.JobType = model.JobType;
                jobTemplate.CronStr = model.CronStr;
                jobTemplate.Remark = model.Remark;
               
                try
                {
                    this.Update(jobTemplate);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// 通过ID批量获取模板对象
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public List<J_JobTemplate> GetListByIds(List<int> list_ids)
        {
            return GetListBy(t => list_ids.Contains(t.JTID)).ToList();
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="JTID"></param>
        /// <returns></returns>
        public bool DelJobTemplate(List<int> list_JTID)
        {
            List<J_JobTemplate> list_jobTemplate = new List<J_JobTemplate>();
            foreach(var item in this.GetListByIds(list_JTID))
            {
                item.isDel = true;
                list_jobTemplate.Add(item);
            }
            //var jobTemplate = this.CurrentDAL.GetListBy(p => p.JTID.Equals(JTID)).FirstOrDefault();
            try
            {
                this.UpdateByList(list_jobTemplate);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool PhysicsDel(List<int> list_ids)
        {
            var list_model = this.GetListByIds(list_ids);
            if(list_model == null){ return false; }
            try
            {
                this.CurrentDAL.DelByList(list_model);
                this.CurrentDBSession.SaveChanges();
                return false;
            }
            catch (Exception)
            {

                return true;
            }
        }

        /// <summary>
        /// 还原
        /// </summary>
        /// <param name="list_id"></param>
        /// <returns></returns>
        public bool Recovery(List<int> list_id)
        {
            var list_model = this.GetListByIds(list_id);
            list_model.ForEach(p => p.isDel = false);
            try
            {
                this.UpdateByList(list_model);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ViewModel_Recycle_Common> GetIsDelList()
        {
            return null;
        }

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        public bool AddValidation(String name)
        {
            var list_model = this.GetListBy(r => r.isDel == false).ToList();
            return list_model.Exists(r => r.JobClassName.Equals(name));
        }
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        public bool EditValidation(int id, String name)
        {
            var list_model = this.GetListBy(r => r.JTID != id && r.isDel == false).ToList();
            return list_model.Exists(r => r.JobClassName.Equals(name));


        }
    }
}
