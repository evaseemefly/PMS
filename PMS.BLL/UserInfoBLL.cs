using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using PMS.IBLL;
using System.Linq.Expressions;

namespace PMS.BLL
{
    public class UserInfoBLL:IUserInfo
    {

        /// <summary>
        /// 数据层的访问接口
        /// </summary>
        protected IDAL.IUserInfoDAL idal;

        /// <summary>
        /// 自定义无参的构造函数，每次New本类时，会执行SetDAL方法，为idal赋具体的实现类
        /// </summary>
        public UserInfoBLL()
        {
            SetDAL();
        }

        /// <summary>
        /// 定义私有的方法，为对数据层的操作接口赋一个具体的数据操作层实现类
        /// </summary>
        private void SetDAL()
        {
            idal =new DALSQLSer.UserInfoDAL();
        }

        #region 1- 新增实体+public void Create(UserInfo model)
        /// <summary>
        /// 1- 新增实体
        /// </summary>
        /// <param name="model"></param>
        public void Create(UserInfo model)
        {
            //1.1 执行添加操作只是将要修改的对象标记为添加标记
            idal.Create(model);
            //1.2 执行保存操作
            idal.SaveChange();
        }
        #endregion

        #region 2- 根据用户id删除数据库中记录 +public bool Del(UserInfo model)
        /// <summary>
        /// 2- 根据用户id删除数据库中记录 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Del(UserInfo model)
        {
            //2.1 调用数据访问层的Del方法，只是向EF上下文中添加了要删除的实体对象的修改标记，需要执行保存方法
            idal.Del(model);
            //
            return idal.SaveChange();
        }
        #endregion

        #region 3- 修改实体+public bool Update(UserInfo model)
        /// <summary>
        /// 3- 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(UserInfo model)
        {
            //同删除
            idal.Update(model);
            return idal.SaveChange();
        }
        #endregion

        #region 3- 批量修改
        /// <summary>
        /// 3- 批量修改
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateByList(List<UserInfo> list)
        {
            idal.UpdateByList(list);
            return idal.SaveChange();
        }
        #endregion

        #region 4- 根据条件查询
        /// <summary>
        /// 4- 根据条件查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<UserInfo> GetListBy(Expression<Func<UserInfo, bool>> whereLambda)
        {
            return idal.GetListBy(whereLambda);
        }
        #endregion

        #region 4- 根据条件查询，并排序+public IQueryable<UserInfo> GetListBy<Tkey>
        /// <summary>
        /// 4- 根据条件查询，并排序
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        public IQueryable<UserInfo> GetListBy<Tkey>(Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, Tkey>> orderLambda)
        {
            return idal.GetListBy<Tkey>(whereLambda, orderLambda);
        }
        #endregion

        #region 5- 分页查询+public IQueryable<UserInfo> GetPageList<TKey>
        /// <summary>
        /// 5- 分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderByLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<UserInfo> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, TKey>> orderByLambda, bool isAsc)
        {
            return idal.GetPageList<TKey>(pageIndex, pageSize, whereLambda, orderByLambda, isAsc);
        }
        #endregion

    }
}
