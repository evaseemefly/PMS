using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;


namespace PMS.BLL
{
    public partial class J_JobInfoBLL
    {

        //使用WCF中的方法
        ServiceReference_Quartz.IJobService ijobService= new ServiceReference_Quartz.JobServiceClient();

        /// <summary>
        /// 获取全部的模板
        /// </summary>
        /// <returns></returns>
        public List<J_JobInfo> GetAllJobInfo()
        {
            return null;
        }

        /// <summary>
        /// 根据角色查询该角色拥有的模板
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<J_JobInfo> GetJobInfoByUser(int uid)
        {
            return null;
        }

        /// <summary>
        /// 创建作业实例
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddJobInfo(PMS.Model.J_JobInfo model)
        {
            //根据传入的JobInfo创建指定的作业
            
            //iJobService = new ServiceReference_Quartz.JobServiceClient();
            //添加作业至调度池中
            ijobService.AddScheduleJob(model);
            return false;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditJobInfo()
        {
            return false;
        }

        /// <summary>
        /// 根据指定id暂停某作业
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool PauseJob(int id)
        {
            //1 根据id查询实体
            var job_temp= this.GetListBy(j => j.JID == id).FirstOrDefault();
            //
            if (job_temp != null)
            {
                //2 暂停
                ijobService.PauseJob(job_temp.JobName, job_temp.JobGroup);
                return true;
            }            
            return false;
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="JTID"></param>
        /// <returns></returns>
        public bool DelJobInfo(int JID)
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
