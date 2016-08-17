using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IDAL
{
    public interface IBaseDAL<T>
    {
        #region 1 根据实体为数据库中添加新的对象+bool Create(T model);
        /// <summary>
        /// 1 根据实体为数据库中添加新的对象
        /// </summary>
        /// <param name="model">T实体对象</param>
        /// <returns></returns>
        bool Create(T model);
        #endregion

        #region 2 从数据库中删除某个实体 +bool Del(T model);
        /// <summary>
        /// 2 从数据库中删除某个实体
        /// </summary>
        /// <param name="model">删除的实体对象</param>
        /// <returns></returns>
        bool Del(T model);
        #endregion

        #region 3 修改单独一个实体对象+ bool Update(T model);
        /// <summary>
        /// 3 修改单独一个实体对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(T model);
        #endregion

        #region 3 批量修改实体对象+ bool UpdateByList(List<T> list);
        /// <summary>
        ///  3 批量修改实体对象
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool UpdateByList(List<T> list);
        #endregion

        #region 4 查询用户信息+IQueryable<T> GetListBy
        /// <summary>
        /// 4 查询用户信息
        /// </summary>
        /// <param name="whereLambda">查询条件（lambda）</param>
        /// <returns></returns>
        IQueryable<T> GetListBy(Expression<Func<T, bool>> whereLambda);
        #endregion

        #region 4 根据条件 排序并查询+IQueryable<T> GetListBy<Tkey>
        /// <summary>
        ///  4 根据条件 排序并查询
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetListBy<Tkey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, Tkey>> orderLambda);
        #endregion

        #region 5 分页查询+IQueryable<T> GetPageList<TKey>
        /// <summary>
        /// 5 分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderByLambda">排序条件</param>
        /// <param name="isAsc">是否为升序，true为升序</param>
        /// <returns>查询结果序列</returns>
        IQueryable<T> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderByLambda, bool isAsc);
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
        IQueryable<T> GetPageList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderByLambda, bool isAsc);
        #endregion


        #region 6 从数据库中批量删除实体 +bool DelByList(List<T> list);
        /// <summary>
        /// 6 从数据库中批量删除实体
        /// </summary>
        /// <param name="model">删除的实体对象</param>
        /// <returns></returns>
        bool DelByList(List<T> list);
        #endregion
    }
}
