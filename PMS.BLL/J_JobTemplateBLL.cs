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
    public partial class J_JobTemplateBLL : IBaseDelBLL,ICanBeDel
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
        public bool AddJobTemplate(ViewModel_JobTemplate model)
        {
            if (model != null)
            {
                J_JobTemplate jobTemplate = new J_JobTemplate()
                {
                
                    JTName = model.JTName,
                    JobClassName = model.JobClassName,
                    JobType = model.JobType,
                    CronStr = model.CronStr,
                    Remark =model.Remark,
                    JobGroup = model.JobGroup
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
                jobTemplate.JobGroup = model.JobGroup;
               
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
        public bool PhysicsDel(List<int> list_ids, bool isCheckCanBeDel = false)
        {
            var list_model = this.GetListByIds(list_ids);
            if(list_model == null){ return false; }
            if (CanBeDel(list_ids) || !isCheckCanBeDel)
            {
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
            return false;
            
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
        /// 分页获取已经软删除的集合
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public List<ViewModel_Recycle_Common> GetIsDelbyPageList(int pageIndex, int pageSize, ref int rowCount)
        {
            var query = base.GetPageList<int>(pageIndex, pageSize, a => a.isDel == true, a => a.JTID, true);
            rowCount = query.Count();
            return query.ToList().Select(a => a.ToRecycleModel()).ToList();
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
        /// <summary>
        /// 执行分配模板给用户的操作
        /// </summary>
        /// <param name="JTID">选中的作业模板</param>
        /// <param name="ids">选中的用户ID集合</param>
        /// <returns></returns>
        public bool SetTemplate4UserInfo(int JTID, List<int> ids)
        {
            if(JTID != 0)
            {
                //1. 获取选中的作业模板
                var jobTemplate = this.GetListBy(j => j.isDel == false && j.JTID == JTID).FirstOrDefault();
                //2.清空所有关系
                jobTemplate.UserInfoes.Clear();
                foreach(var item in ids)
                {
                    //3.得到用户对象
                    var userInfo = this.CurrentDBSession.UserInfoDAL.GetListBy(u => u.DelFlag == false && u.ID == item).FirstOrDefault();
                    //4. 加入关系表
                    jobTemplate.UserInfoes.Add(userInfo);
                }
                return this.CurrentDBSession.SaveChanges();
            }

            
            return false;
        }

        public bool CanBeDel(List<int> list_ids)
        {
            throw new NotImplementedException();
        }
    }
}
