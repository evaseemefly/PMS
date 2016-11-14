using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IBLL
{
   public interface IBaseBLL<T>
    {
        #region 1-1 新增实体- void Create(T model);
        bool Create(T model);
        #endregion

        #region 1-2 批量新增实体+public void Create(UserInfo model)
        /// <summary>
        /// 1- 新增实体
        /// </summary>
        /// <param name="model"></param>
        bool CreateByList(List<T> list);
        #endregion

        #region 2- 根据用户id删除数据库中记录
        /// <summary>
        /// 2- 根据用户id删除数据库中记录 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Del(T model);
        #endregion

        #region 3- 修改实体
        /// <summary>
        /// 3- 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(T model);
        #endregion

        #region 3- 批量修改
        /// <summary>
        /// 3- 批量修改
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool UpdateByList(List<T> list);
        #endregion

        #region 4- 根据条件查询
        /// <summary>
        /// 4- 根据条件查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetListBy(Expression<Func<T, bool>> whereLambda);
        #endregion

        #region 4- 根据条件查询，并排序
        /// <summary>
        /// 4- 根据条件查询，并排序
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetListBy<Tkey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, Tkey>> orderLambda);
        #endregion

        #region 5- 分页查询
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
    }
}
