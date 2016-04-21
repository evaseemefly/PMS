using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;   //添加EF的引用
using PMS.DALSQLSer;
using System.Data.Entity.Validation;

namespace PMS.DALFactory
{
    /// <summary>
    /// 数据仓储类——DBSession
    /// </summary>
    public partial class DBSession:IDAL.IDBSession
    {
        /// <summary>
        /// 获取当前线程中的EF上下文对象
        /// </summary>
        public DbContext Db
        {
            //通过属性的方式，使用单例模式取得EF上下文对象
            get { return DBContextFactory.GetDBContext(); }
        }

        /// <summary>
        /// 将本EF的所有更改更新至数据库
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            try
            {
                int index = Db.SaveChanges();
                return index > 0; 
            }
            //此处抛出异常使用DB.Save时的异常类
            catch (DbEntityValidationException dbEx)
            {

                return false;
            }
        }

    }
}
