using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace PMS.DALSQLSer
{
    public class UserInfoDAL
    {
        //1 创建实体上下文对象，并将继承自DbContext的EF实体对象PMS2016Entities赋给实体上下文对象
        DbContext Db = new PMS2016Entities();

        /*
         下面要操作数据
         主要的操作
         增删改查
         */

       //public void Test()
       // {
       //     this.Add()
       // }
        
        /// <summary>
        /// 根据实体为数据库中添加新的对象
        /// </summary>
        /// <param name="model">UserInfo实体对象</param>
        /// <returns></returns>
        public bool Create(UserInfo model)
        {
            //根据传入的UserInfo实体对象，向数据库中插入
            Db.Set<UserInfo>().Add(model);
            return true;
        }

        //从数据库中删除某个实体
        public bool Del(UserInfo model)
        {
            //去掉Attach尝试一下
            Db.Set<UserInfo>().Attach(model);
            //
            Db.Set<UserInfo>().Remove(model);
            return true;
        }

        public bool Update(UserInfo model)
        {
            //1 将UserInfo对象 加入 EF 容器中，并获取实体对象的管理状态
            DbEntityEntry<UserInfo> entry = Db.Entry<UserInfo>(model);
            //2 设置该对象为修改过的状态
            entry.State = System.Data.EntityState.Unchanged;

            return true;

        }

        public IQueryable<UserInfo> GetListBy(Expression<Func<UserInfo, bool>> whereLambda)
        {
            return Db.Set<UserInfo>().Where(whereLambda);
        }

        public IQueryable<UserInfo> GetListBy<Tkey>(Expression<Func<UserInfo, bool>> whereLambda,Expression<Func<UserInfo,Tkey>>orderLambda)
        {
            return Db.Set<UserInfo>().Where(whereLambda).OrderBy(orderLambda);
        }


    }
}
