using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using PMS.IDAL;

namespace PMS.DALSQLSer
{
    /// <summary>
    /// 用户数据访问层继承自IUserInfo接口
    /// </summary>
    public class UserInfoDAL: IUserInfo
    {
        //1 创建实体上下文对象，并将继承自DbContext的EF实体对象PMS2016Entities赋给实体上下文对象
        DbContext Db = new PMS2016Entities();

        /*
         下面要操作数据
         主要的操作
         增删改查
         */

        #region 1 根据实体为数据库中添加新的对象+public bool Create(UserInfo model)
        /// <summary>
        /// 1 根据实体为数据库中添加新的对象
        /// </summary>
        /// <param name="model">UserInfo实体对象</param>
        /// <returns></returns>
        public bool Create(UserInfo model)
        {
            //根据传入的UserInfo实体对象，向数据库中插入
            Db.Set<UserInfo>().Add(model);
            return true;
        }
        #endregion

        #region 2 从数据库中删除某个实体+public bool Del(UserInfo model)
        /// <summary>
        /// 2 从数据库中删除某个实体
        /// </summary>
        /// <param name="model">删除的实体对象</param>
        /// <returns></returns>
        public bool Del(UserInfo model)
        {
            //1 将实体对象添加到上下文中
            Db.Set<UserInfo>().Attach(model);
            //2 将该实体对象标记为删除
            Db.Set<UserInfo>().Remove(model);
            return true;
        }
        #endregion

        #region 对于委托的示例
        //public void Test()
        // {
        //     this.Add()
        // }

        //public delegate void Dg_Test(string str);

        //public void Test(string str)
        //{
        //    Console.WriteLine("测试"+str);
        //}

        //public void Delete(Dg_Test dg)
        //{
        //    dg("我是通过委托传递的参数");
        //    //Test("");
        //}
        #endregion

        #region 3 修改单独一个实体对象+public bool Update(UserInfo model)
        /// <summary>
        /// 3 修改单独一个实体对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(UserInfo model)
        {
            //Dg_Test dg_test = new Dg_Test(Test);
            ////dg_test("我是通过委托传递的参数");

            //Delete(dg_test);
            //1 将UserInfo对象 加入 EF 容器中，并获取实体对象的管理状态
            DbEntityEntry<UserInfo> entry = Db.Entry<UserInfo>(model);
            //2 设置该对象为修改过的状态
            entry.State = System.Data.EntityState.Modified;

            return true;

        }
        #endregion

        #region 3 批量修改实体对象+public bool UpdateByList(List<UserInfo> list)
        /// <summary>
        ///  3 批量修改实体对象
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateByList(List<UserInfo> list)
        {
            //遍历传入的要修改的集合，将每个对象的状态均设置为修改状态
            foreach (var item in list)
            {
                DbEntityEntry<UserInfo> entry = Db.Entry<UserInfo>(item);
                entry.State = System.Data.EntityState.Modified;
            }
            return true;
        }
        #endregion

        #region 4 查询用户信息+ public IQueryable<UserInfo> GetListBy
        /// <summary>
        /// 4 查询用户信息
        /// </summary>
        /// <param name="whereLambda">查询条件（lambda）</param>
        /// <returns></returns>
        public IQueryable<UserInfo> GetListBy(Expression<Func<UserInfo, bool>> whereLambda)
        {
            //Db.Set<int>().Where()
            return Db.Set<UserInfo>().Where(whereLambda);
        }
        #endregion

        #region 4 根据条件 排序并查询+IQueryable<UserInfo> GetListBy<Tkey>
        /// <summary>
        ///  4 根据条件 排序并查询
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        public IQueryable<UserInfo> GetListBy<Tkey>(Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, Tkey>> orderLambda)
        {
            return Db.Set<UserInfo>().Where(whereLambda).OrderBy(orderLambda);
        }
        #endregion

        #region 5 分页查询+public IQueryable<UserInfo> GetPageList<TKey>
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
        public IQueryable<UserInfo> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, TKey>> orderByLambda, bool isAsc)
        {
            //5.1 根据查询条件(whereLambda)返回查询 序列
            var query = Db.Set<UserInfo>().Where(whereLambda);

            //5.2 根据升降序标记判断升序降序排列
            if (isAsc)
            {
                //根据键按升序排序
                query = query.OrderBy(orderByLambda);
            }
            else
            {
                //根据键按降序排列
                query = query.OrderByDescending(orderByLambda);
            }

            /*5.3
                .Skip 跳过一定数量的元素，返回剩余元素
                .Take 从序列的开头返回指定数量的连续元素
             */
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

        }
        #endregion

        #region 6 对EF上下文对象保存所有修改并提交至数据库+public bool SaveChange()
        /// <summary>
        /// 6 对EF上下文对象保存所有修改并提交至数据库
        /// </summary>
        /// <returns></returns>
        public bool SaveChange()
        {
            return Db.SaveChanges() > 0;
        }
        #endregion



    }
}
