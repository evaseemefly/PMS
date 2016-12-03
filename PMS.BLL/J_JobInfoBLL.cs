using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IBLL;
using PMS.BLL;
using PMS.IModel;


namespace PMS.BLL
{
    public partial class J_JobInfoBLL
    {

        //使用WCF中的方法
        //ServiceReference_Quartz.IJobService ijobService = new ServiceReference_Quartz.JobServiceClient();
        //ServiceReference_QuartzService.IJobService iobService = new ServiceReference_QuartzService.JobServiceClient();
        //ServiceReference_Quartz.JobServiceClient jobServiceClient = new ServiceReference_Quartz.JobServiceClient();
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        QuartzJobFactory.IJobService ijobService = new QuartzJobFactory.JobService();
        IUserInfoBLL userInfoBLL = new UserInfoBLL();

        /// <summary>
        /// 获取全部的正在运行的作业
        /// </summary>
        /// <returns></returns>
        public IEnumerable<J_JobInfo> GetAllNullDelJobInfo()
        {
           return from j in base.GetListBy(j => j.isDel == false)
                  where j.JobState!=(int)Model.Enum.JobState_Enum.STOP
                  select j;
        }

        /// <summary>
        /// 分页查询指定用户或全部用户的
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="rowCount">返回的总页数</param>
        /// <param name="isAsc">是否降序</param>
        /// <param name="isMiddle">是否转成中间变量</param>
        /// <param name="uid">若不填则默认为-1，查询所有的用户</param>
        /// <returns></returns>
        public List<J_JobInfo> GetJobInfoByPage(int pageIndex,int pageSize,ref int rowCount,bool isAsc,bool isMiddle,int uid=-1)
        {
            
            IEnumerable<J_JobInfo> query;
            //List<J_JobInfo> query = base.GetListBy(j => j.UID == uid).ToList();
            if (uid != -1)
            {
                //获取指定uid的所有非终止作业
                query = GetNullFinishJobInfo(uid);
                //过滤掉软删除的作业
                query = NullDelJob(query);
            }
            else
            {
                //获取所有用户的全部作业集合
                query = this.GetAllNullDelJobInfo();
            }
            
           return this.ToListByPage(query, pageIndex, pageSize, ref rowCount, true, true);
        }

        /// <summary>
        /// 根据指定的用户id
        /// 获取该用户id的非终止作业
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        protected IEnumerable<J_JobInfo> GetNullFinishJobInfo(int uid)
        {
            int jobState = (int)Model.Enum.JobState_Enum.STOP;
            var array = from j in userInfoBLL.GetListBy(u => u.ID == uid).FirstOrDefault().J_JobInfo
                              where j.JobState != jobState
                              select j;
            return array;
        }

        /// <summary>
        /// 分页返回
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="isAsc"></param>
        /// <param name="isMiddle"></param>
        /// <returns></returns>
        private List<J_JobInfo> ToListByPage(IEnumerable<J_JobInfo> query, int pageIndex, int pageSize, ref int rowCount, bool isAsc, bool isMiddle)
        {
            rowCount = query.ToList().Count();
            if (isAsc)
            {
                //query = query.OrderBy(j => j.JID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                query = query.OrderByDescending(j => j.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                //query = query.OrderByDescending(j => j.JID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                query = query.OrderByDescending(j => j.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            if (isMiddle)
            {
                return query.Select(s => s.ToMiddleModel()).ToList();
            }
            else
            {
                //按照时间倒叙
                return query.ToList();
            }

        }


        /// <summary>
        /// 根据角色查询该角色拥有的模板（暂未实现）
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<J_JobInfo> GetJobInfoByUser(int uid)
        {
            // var user= userInfoBLL.GetListBy(u => u.ID == uid).FirstOrDefault();
            // //获取用户所拥有的作业模板
            //var list_jobTemplate= userInfoBLL.GetJobTemplateByUser(user).ToList();
            // base.GetListBy(j=>j)
            //return list_jobTemplate.Select(t=>t.ToMiddleModel()).ToList();
            return null;
        }

        /// <summary>
        /// 创建作业实例
        /// (写入数据库及添加至作业调度池中)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PMS.Model.Message.IBaseResponse AddJobInfo(J_JobInfo model, IJobData jobData=null)
        {
            
            //1 创建与UserInfo的关系
           var user= this.CurrentDBSession.UserInfoDAL.GetListBy(u => u.ID == model.UID).FirstOrDefault();
            model.UserInfoes.Add(user.ToMiddleModel());
            //2 创建J_JobInfo对象
            // 1 添加作业至调度池中
            if(jobData==null) jobData = new PMS.Model.JobDataModel.SendJobDataModel();
            model.JobState = (int)(PMS.Model.Enum.JobState_Enum.WAITING);
            base.Create(model);
            // var response = ijobService.AddScheduleJob(model, jobData);
            //object response_wcf= jobServiceClient.AddScheduleJob(model.ToMiddleModel(), jobData);
            //var response= response_wcf as Model.Message.IBaseResponse;
            //client.AddScheduleJob(model.ToMiddleModel(), jobData);
            //2 写入jobInfo表作业的状态
            if (response.Success)
            {
                model.JobState = (int)(PMS.Model.Enum.JobState_Enum.WAITING);
                base.Update(model);
            }
            //2 根据传入的JobInfo创建指定的作业
            //if (response.Success == true)
            //{
            //    base.Create(model);
            //}
            //if (base.Create(model))
            //{
            //    return true;
            //}
            return response;
           

        }

        /// <summary>
        /// 根据指定id暂停某作业
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PMS.Model.Message.IBaseResponse PauseJob(int id)
        {
            //1 根据id查询实体
            var job_temp = this.GetListBy(j => j.JID == id).FirstOrDefault();
            //
            Model.Message.IBaseResponse response = new Model.Message.BaseResponse(); 
            if (job_temp != null)
            {
                //2 暂停
                response = ijobService.PauseJob(job_temp);
                // return response.Success;
            }
            if (response.Success)
            {
                job_temp.JobState = (int)(PMS.Model.Enum.JobState_Enum.PAUSED);
                base.Update(job_temp);
                return response;
            }
            return new PMS.Model.Message.BaseResponse() { Success = false, Message = "执行暂停作业操作失败" };
        }

        /// <summary>
        /// 恢复指定作业
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PMS.Model.Message.IBaseResponse ResumeJob(int id)
        {
            //1 根据id查询实体
            var job_temp = this.GetListBy(j => j.JID == id).FirstOrDefault();
            //
            Model.Message.IBaseResponse response = new Model.Message.BaseResponse();
            if (job_temp != null)
            {
                //2 暂停
                response = ijobService.ResumeTargetJob(job_temp);
                //return response;
                // return response.Success;
            }
            if (response.Success)
            {
                job_temp.JobState = (int)(PMS.Model.Enum.JobState_Enum.running);
                base.Update(job_temp);
                return response;
            }
            return new PMS.Model.Message.BaseResponse() { Success = false, Message = "执行恢复作业操作失败" };
        }

        /// <summary>
        /// 终止指定作业
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PMS.Model.Message.IBaseResponse RemoveJob(int id)
        {
            //1 根据id查询实体
            var job_temp = this.GetListBy(j => j.JID == id).FirstOrDefault();
            //
            Model.Message.IBaseResponse response = new Model.Message.BaseResponse();
            if (job_temp != null)
            {
                //2 暂停
                response = ijobService.RemovceJob(job_temp);
                //软删除
                this.DelJobInfo(id);
                //return response;
            }
            if (response.Success)
            {
                job_temp.JobState = (int)(PMS.Model.Enum.JobState_Enum.STOP);
                base.Update(job_temp);
                return response;
            }
            return new PMS.Model.Message.BaseResponse() { Success = false, Message = "不存在指定作业" };
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

        public bool EditValidation(int id, String name)
        {
            var list_model = this.GetListBy(r => r.JID != id && r.isDel == false).ToList();
            return list_model.Exists(r => r.JobName==name);
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
                //var response = ijobService.RemovceJob(job_temp);
               return DelSoftJobInfos(new int[] { JID });
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

            return false;
        }

        /// <summary>
        /// 过滤作业集合中未删除的集合
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private IEnumerable<J_JobInfo> NullDelJob(IEnumerable<J_JobInfo> array)
        {
            return array.Where(j => j.isDel == false);
        }
    }
}
