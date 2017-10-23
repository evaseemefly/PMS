using PMS.IBLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL
{
    public partial class UserInfoBLL : BaseBLL<UserInfo>, IUserInfoBLL, IBaseDelBLL
    {
        
        /// <summary>
        /// 根据用户id查询对应的作业
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<J_JobInfo> GetJobListByUser(int uid)
        {
            //1 根据uid查找对应的用户对象
            var user = base.GetListBy(u => u.ID == uid).FirstOrDefault();
            
            List<J_JobInfo> list_jobInfo = new List<J_JobInfo>();
            list_jobInfo.AddRange(GetJobByUser(user));

            //2 根据用户查找对应的模板集合
            var list = GetJobTemplateByUser(user);
            foreach (var item in list)
            {
                list_jobInfo.AddRange(GetJobByTemplate(item));
            }
            
            return list_jobInfo;
        }

        /// <summary>
        /// 获取用户所拥有的作业模板集合
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<J_JobTemplate> GetJobTemplateByUser(UserInfo user)
        {
            return NullDelTemplate(user.J_JobTemplate);
        }
        /// <summary>
        /// 获取与用户直接关联的作业集合
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected List<J_JobInfo> GetJobByUser(UserInfo user)
        {
           return NullDelJob(user.J_JobInfo).ToList();
        }

        /// <summary>
        /// 获取与作业模板相连的作业集合
        /// </summary>
        /// <param name="jobTemplate"></param>
        /// <returns></returns>
        protected List<J_JobInfo> GetJobByTemplate(J_JobTemplate jobTemplate)
        {
           return NullDelJob(jobTemplate.J_JobInfo).ToList();
            
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

        /// <summary>
        /// 过滤作业集合中未删除的集合
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private IEnumerable<J_JobTemplate> NullDelTemplate(ICollection<J_JobTemplate> array)
        {
            return array.Where(j => j.isDel == false);
        }
    }
}
