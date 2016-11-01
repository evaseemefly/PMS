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
        //ServiceReference_Quartz.IJobService ijobService= new ServiceReference_Quartz.JobServiceClient();
        QuartzJobFactory.IJobService ijobService = new QuartzJobFactory.JobService();


        /// <summary>
        /// 获取全部的作业
        /// </summary>
        /// <returns></returns>
        public List<J_JobInfo> GetAllNullDelJobInfo()
        {
            base.GetListBy(j => j.isDel == false).ToList();
            return null;
        }

        /// <summary>
        /// 根据角色查询该角色拥有的模板（暂未实现）
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<J_JobInfo> GetJobInfoByUser(int uid)
        {
           // base.GetListBy(j=>j)
            return null;
        }

        /// <summary>
        /// 创建作业实例
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddJobInfo(J_JobInfo model)
        {
            //1 添加作业至调度池中
           var response= ijobService.AddScheduleJob(model);
            //2 根据传入的JobInfo创建指定的作业
            if (response.Success == true)
            {
                base.Create(model);
            }
            return false;
        }

        /// <summary>
        /// 编辑（暂未实现）
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
               var response= ijobService.PauseJob(job_temp);
                return response.Success;
            }            
            return false;
        }

        /// <summary>
        /// 根据id集合批量获取作业集合
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public List<J_JobInfo> GetListByIds(List<int> list_ids)
        {

            return GetListBy(a => list_ids.Contains(a.JID)).ToList();

        }

        /// <summary>
        /// 修改指定的id的对象集合的删除标记为删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        protected bool DelSoftJobInfos(int[] list_ids)
        {
            List<J_JobInfo> list = new List<J_JobInfo>();
            //遍历需要查找的Action集合
            foreach (var item in this.GetListByIds(list_ids.ToList()))
            {
                //修改其中的删除标记
                item.isDel = true;
                //并添加至新创建的集合中
                list.Add(item);
            }
            try
            {
                this.UpdateByList(list);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="JTID"></param>
        /// <returns></returns>
        public bool DelJobInfo(int JID)
        {
            //1 根据id查询实体
            var job_temp = this.GetListBy(j => j.JID == JID).FirstOrDefault(); 
            //
            if (job_temp != null)
            {
                //2 删除该作业
                var response = ijobService.RemovceJob(job_temp);
                if (response.Success == true)
                {
                    DelSoftJobInfos(new int[]{ JID});
                }
                return response.Success;
            }
            return false;
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="list_ids"></param>
        /// <returns></returns>
        public bool PhysicsDel(List<int> list_ids)
        {
            //只需要清除数据库中JobInfo表中的对应记录即可
            return false;
        }

        /// <summary>
        /// 还原（不使用此功能）
        /// </summary>
        /// <param name="list_id"></param>
        /// <returns></returns>
        public bool Recovery(List<int> list_id)
        {
            //
            return false;
        }

        /// <summary>
        /// 过滤作业集合中未删除的集合
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private IEnumerable<J_JobInfo> NullDelJob(ICollection<J_JobInfo> array)
        {
            return array.Where(j => j.isDel == false);
        }
    }
}
