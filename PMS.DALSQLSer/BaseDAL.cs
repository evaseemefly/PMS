using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DALSQLSer
{
    public class BaseDAL<T>where T: class, new()
    {
        //1 创建实体上下文对象，并将继承自DbContext的EF实体对象PMS2016Entities赋给实体上下文对象
        //3月15日修改——通过线程中唯一的方法 创建在一个线程中职能创建一次的数据上下文对象
        DbContext Db = DBContextFactory.GetDBContext();

        //DbContext db2 = new PMS2016Entities();
        //public void Test()
        // {
        //     Db = new PMS2016Entities();
        // }

        /*
         下面要操作数据
         主要的操作
         增删改查
         */

        #region 1-1 根据实体为数据库中添加新的对象+public bool Create(T model)
        /// <summary>
        /// 1 根据实体为数据库中添加新的对象
        /// </summary>
        /// <param name="model">T实体对象</param>
        /// <returns></returns>
        public bool Create(T model)
        {
            //根据传入的T实体对象，向数据库中插入
            Db.Set<T>().Add(model);

            //DbEntityEntry<T> entry = Db.Entry<T>(model);
            ////2 设置该对象为修改过的状态
            //entry.State = System.Data.EntityState.Added;
            return true;
        }
        #endregion

        #region 1-2 根据实体集合为数据库中批量添加新的对象+public bool CreateByList(List<T> list)
        /// <summary>
        /// 1 根据实体为数据库中添加新的对象
        /// </summary>
        /// <param name="model">T实体对象</param>
        /// <returns></returns>
        public bool CreateByList(List<T> list)
        {
            foreach (var item in list)
            {
                this.Create(item);
                //DbEntityEntry<T> entry = Db.Entry<T>(item);
                //entry.State = System.Data.Entity.EntityState.Added;
            }
            return true;
            //根据传入的T实体对象，向数据库中插入
            //DbEntityEntry<T> entry = Db.Entry<T>(model);
            ////2 设置该对象为修改过的状态
            //entry.State = System.Data.EntityState.Added;
        }
        #endregion

        #region 2 从数据库中删除某个实体+public bool Del(T model)
        /// <summary>
        /// 2 从数据库中删除某个实体
        /// </summary>
        /// <param name="model">删除的实体对象</param>
        /// <returns></returns>
        public bool Del(T model)
        {
            //1 将实体对象添加到上下文中
            Db.Set<T>().Attach(model);
            //2 将该实体对象标记为删除            
            //Db.Entry<T>(model).State = System.Data.EntityState.Deleted;
            Db.Set<T>().Remove(model);
            return Db.SaveChanges()>0;
            //return true;
        }

        //public bool PhysicsDel(T model)
        //{
            
        //}

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

        #region 3 修改单独一个实体对象+public bool Update(T model)
        /// <summary>
        /// 3 修改单独一个实体对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T model)
        {
            //1 将T对象 加入 EF 容器中，并获取实体对象的管理状态
            DbEntityEntry<T> entry = Db.Entry<T>(model);
            //2 设置该对象为修改过的状态
            entry.State = System.Data.Entity.EntityState.Modified;  //EF5.0与EF 6.0有区别
            return true;

        }
        #endregion

        #region 3 批量修改实体对象+public bool UpdateByList(List<T> list)
        /// <summary>
        ///  3 批量修改实体对象
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateByList(List<T> list)
        {
            //遍历传入的要修改的集合，将每个对象的状态均设置为修改状态
            foreach (var item in list)
            {
                DbEntityEntry<T> entry = Db.Entry<T>(item);
                entry.State =System.Data.Entity.EntityState.Modified;
            }
            return true;
        }
        #endregion

        #region 4 查询用户信息+ public IQueryable<T> GetListBy
        /// <summary>
        /// 4 查询用户信息
	    /// isNotTrack默认值为false，只有为true时才进行AsNoTracking操作，查询对象不加载至DBContext中
        /// </summary>
        /// <param name="whereLambda">查询条件（lambda）</param>
        /// <returns></returns>
        public IQueryable<T> GetListBy(Expression<Func<T, bool>> whereLambda, bool isNotTrack = false)
        {
            //Db.Set<int>().Where()
            var item = Db.Set<T>().Where(whereLambda);
            //ToNoTracking(ref item, isNotTrack);
            if (isNotTrack)
            {
                return item.AsNoTracking();
            }
            return item;
        }
        #endregion

        /// <summary>
        /// 是否将查询对象放入数据上下文中（默认为不放置在缓存中）；
        /// true不放在数据上下文中，false放在数据上下文中。
        /// </summary>
        /// <param name="query"></param>
        /// <param name="isNotTrack">true不放在数据上下文中，false放在数据上下文中</param>
        protected void ToNoTracking(ref IQueryable<T> query,bool isNotTrack = true)
        {
            if (isNotTrack)
            {
              query= query.AsNoTracking();
            }
        }

        #region 4 根据条件 排序并查询+IQueryable<T> GetListBy<Tkey>
        /// <summary>
        ///  4 根据条件 排序并查询
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetListBy<Tkey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, Tkey>> orderLambda, bool isNotTrack = false)
        {
            //11月25日 修改
            //return Db.Set<T>().Where(whereLambda).OrderBy(orderLambda);
            //新增
            var query = Db.Set<T>().Where(whereLambda).OrderBy(orderLambda).AsQueryable();
            //ToNoTracking(ref query, true);
            ToNoTracking(ref query, isNotTrack);
            return query;
        }
        #endregion

        #region 5 分页查询+public IQueryable<T> GetPageList<TKey>
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
        public IQueryable<T> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderByLambda, bool isAsc)
        {
            //5.1 根据查询条件(whereLambda)返回查询 序列
            var query = Db.Set<T>().Where(whereLambda);

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

        /// <summary>
        /// 5.1 分页查询
        /// </summary>
        /// <typeparam name="TKey">排序的约束</typeparam>
        /// <param name="pageIndex">当前的页码</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="rowCount">总条数</param>
        /// <param name="whereLambda">过滤条件</param>
        /// <param name="orderByLambda">排序条件</param>
        /// <param name="isAsc">排序方式：true—升序排列;false—降序排列</param>
        /// <returns></returns>
        public IQueryable<T> GetPageList<TKey>(int pageIndex, int pageSize,ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderByLambda, bool isAsc)
        {
            //5.1 根据查询条件(whereLambda)返回查询 序列
            var query = Db.Set<T>().Where(whereLambda);
            //获取总条数
            rowCount = query.Count();
            //5.2 根据升降序标记判断升序降序排列
            if (isAsc)
            {
                //根据键按升序排序
                //注意此处需要根据当前页码以及也容量跳过指定条数的数据，实现分页查询
                //query = query.OrderBy(orderByLambda);
                query = query.OrderBy<T,TKey>(orderByLambda).Skip<T>((pageIndex-1)*pageSize).Take<T>(pageSize); //修改后为：跳过当前（页码-1）*页容量个条数，取之后的页容量 个记录
            }
            else
            {
                //根据键按降序排列
                query = query.OrderByDescending(orderByLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize); 
            }

            /*5.3
                .Skip 跳过一定数量的元素，返回剩余元素
                .Take 从序列的开头返回指定数量的连续元素
             */
            return query/*.Skip((pageIndex - 1) * pageSize).Take(pageSize)*/;

        }

        #region 6 对EF上下文对象保存所有修改并提交至数据库+public bool SaveChange()
        /// <summary>
        /// 6 对EF上下文对象保存所有修改并提交至数据库
        /// </summary>
        /// <returns></returns>
        public bool SaveChange()
        {
            try
            {
                var i = Db.SaveChanges();
                return i > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }
        #endregion


        #region 7 批量删除实体对象+public bool UpdateByList(List<T> list)
        /// <summary>
        ///  7 批量删除实体对象
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DelByList(List<T> list)
        {
            //遍历传入的要修改的集合，将每个对象的状态均设置为修改状态
            foreach (var item in list)
            {
                //if (!Db.Set<T>().Find(item))
                //1 将实体对象添加到上下文中
                Db.Set<T>().Attach(item);
                //2 将该实体对象标记为删除
                Db.Set<T>().Remove(item);
            }

            return Db.SaveChanges()>0;
            //return true;
        }
        #endregion
    }
}
