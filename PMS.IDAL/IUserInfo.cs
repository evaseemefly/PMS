using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PMS.IDAL
{
    /// <summary>
    /// 定义UserInfo实现类的接口
    /// 注意：
    /// 1 接口必须是是公开的，因为需要由实现类去继承（实现）
    /// 2 接口中的方法不需要添加访问修饰符（public），且没有方法体，只有方法签名
    /// </summary>
    public interface IUserInfo
    {
        #region 1 根据实体为数据库中添加新的对象+bool Create(UserInfo model);
        /// <summary>
        /// 1 根据实体为数据库中添加新的对象
        /// </summary>
        /// <param name="model">UserInfo实体对象</param>
        /// <returns></returns>
        bool Create(UserInfo model);
        #endregion

        #region 2 从数据库中删除某个实体 +bool Del(UserInfo model);
        /// <summary>
        /// 2 从数据库中删除某个实体
        /// </summary>
        /// <param name="model">删除的实体对象</param>
        /// <returns></returns>
        bool Del(UserInfo model);
        #endregion

        #region 3 修改单独一个实体对象+ bool Update(UserInfo model);
        /// <summary>
        /// 3 修改单独一个实体对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(UserInfo model);
        #endregion

        #region 3 批量修改实体对象+ bool UpdateByList(List<UserInfo> list);
        /// <summary>
        ///  3 批量修改实体对象
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool UpdateByList(List<UserInfo> list);
        #endregion

        #region 4 查询用户信息+IQueryable<UserInfo> GetListBy
        /// <summary>
        /// 4 查询用户信息
        /// </summary>
        /// <param name="whereLambda">查询条件（lambda）</param>
        /// <returns></returns>
        IQueryable<UserInfo> GetListBy(Expression<Func<UserInfo, bool>> whereLambda);
        #endregion

        #region 4 根据条件 排序并查询+IQueryable<UserInfo> GetListBy<Tkey>
        /// <summary>
        ///  4 根据条件 排序并查询
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        IQueryable<UserInfo> GetListBy<Tkey>(Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, Tkey>> orderLambda);
        #endregion

        #region 5 分页查询+IQueryable<UserInfo> GetPageList<TKey>
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
        IQueryable<UserInfo> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, TKey>> orderByLambda, bool isAsc);
        #endregion

        #region 保存EF上下文对象的修改+bool SaveChange();
        /// <summary>
        /// 保存EF上下文对象的修改
        /// </summary>
        /// <returns></returns>
        bool SaveChange();
        #endregion

    }
}
