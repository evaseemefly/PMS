using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL
{
   public abstract class BaseBLL<T>/*:BaseDelBLL<T>*/
    {

        /// <summary>
        /// 数据层的访问接口
        /// </summary>
        //protected IDAL.IUserInfoDAL idal;
        /// <summary>
        /// 目前的数据仓储对象
        /// </summary>
        public IDAL.IDBSession CurrentDBSession
        {
            get
            {
                return DALFactory.DBSessionFactory.CreateDbSession();
            }
        }
        
        public IDAL.IBaseDAL<T> CurrentDAL { get; set; }

        /// <summary>
        /// 需要由子类重写的为CurrentDAL赋值的方法
        /// </summary>
        public abstract void SetCurrentDAL();

        /// <summary>
        /// 构造函数，执行由子类重写后的SetCurrentDAL方法
        /// </summary>
        public BaseBLL()
        {
            SetCurrentDAL();
        }

        /// <summary>
        /// 自定义无参的构造函数，每次New本类时，会执行SetDAL方法，为idal赋具体的实现类
        /// </summary>
        //public UserInfoBLL()
        //{
        //    SetDAL();
        //}

        /// <summary>
        /// 定义私有的方法，为对数据层的操作接口赋一个具体的数据操作层实现类
        /// </summary>
        //private void SetDAL()
        //{
        //    CurrentDAL = new DALSQLSer.UserInfoDAL();
        //}

        #region 1- 新增实体+public void Create(UserInfo model)
        /// <summary>
        /// 1- 新增实体
        /// </summary>
        /// <param name="model"></param>
        public bool Create(T model)
        {
            //1.1 执行添加操作只是将要修改的对象标记为添加标记
            //UserInfoDAL.Create(model);
            CurrentDAL.Create(model);
            //1.2 执行保存操作
           return CurrentDBSession.SaveChanges();
            
        }
        #endregion

        #region 1-2 批量新增实体+public void Create(UserInfo model)
        /// <summary>
        /// 1- 新增实体
        /// </summary>
        /// <param name="model"></param>
        public bool CreateByList(List<T> list)
        {
            //1.1 执行添加操作只是将要修改的对象标记为添加标记
            //UserInfoDAL.Create(model);
            CurrentDAL.CreateByList(list);
            //1.2 执行保存操作
            return CurrentDBSession.SaveChanges();

        }
        #endregion

        #region 2- 根据用户id删除数据库中记录 +public bool Del(UserInfo model)
        /// <summary>
        /// 2- 根据用户id删除数据库中记录 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Del(T model)
        {
            //2.1 调用数据访问层的Del方法，只是向EF上下文中添加了要删除的实体对象的修改标记，需要执行保存方法
            CurrentDAL.Del(model);
            //
           return CurrentDBSession.SaveChanges();
        }
        #endregion

        #region 3- 修改实体+public bool Update(UserInfo model)
        /// <summary>
        /// 3- 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T model)
        {
            //同删除
            CurrentDAL.Update(model);
            //return idal.SaveChange();
           return CurrentDBSession.SaveChanges();
        }
        #endregion

        #region 3- 批量修改
        /// <summary>
        /// 3- 批量修改
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateByList(List<T> list)
        {
            CurrentDAL.UpdateByList(list);
            //return idal.SaveChange();
            return CurrentDBSession.SaveChanges();
        }
        #endregion

        #region 4- 根据条件查询
        /// <summary>
        /// 4- 根据条件查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetListBy(Expression<Func<T, bool>> whereLambda, bool isNotTracking = false)
        {
            return CurrentDAL.GetListBy(whereLambda, isNotTracking);
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
        public IQueryable<T> GetListBy<Tkey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, Tkey>> orderLambda, bool isNotTracking = false)
        {
            return CurrentDAL.GetListBy<Tkey>(whereLambda, orderLambda, isNotTracking);
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
        public IQueryable<T> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderByLambda, bool isAsc)
        {
            return CurrentDAL.GetPageList<TKey>(pageIndex, pageSize, whereLambda, orderByLambda, isAsc);
        }
        #endregion

        #region 5.1 分页查询+public IQueryable<T> GetPageList<TKey>
        /// <summary>
        /// 5.1 分页查询
        /// </summary>
        /// <typeparam name="TKey">排序的约束</typeparam>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderByLambda">排序条件</param>
        /// <param name="isAsc">是否为升序，true为升序</param>
        /// <returns>查询结果序列</returns>
        public IQueryable<T> GetPageList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderByLambda, bool isAsc)
        {
            return CurrentDAL.GetPageList<TKey>(pageIndex, pageSize,ref rowCount, whereLambda, orderByLambda, isAsc);
        }
        #endregion


        #region 6- 批量删除
        /// <summary>
        /// 3- 批量修改
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DelByList(List<T> list)
        {
            CurrentDAL.DelByList(list);
            //return idal.SaveChange();
            return CurrentDBSession.SaveChanges();
        }
        #endregion


    }
}
