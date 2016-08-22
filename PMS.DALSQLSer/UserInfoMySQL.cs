using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;

namespace PMS.DALSQLSer
{
    public class UserInfoMySQL : PMS.IDAL.IUserInfoDAL
    {
        public bool Create(UserInfo model)
        {
            throw new NotImplementedException();
        }

        public bool Del(UserInfo model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserInfo> GetListBy(Expression<Func<UserInfo, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserInfo> GetListBy<Tkey>(Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, Tkey>> orderLambda)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserInfo> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, TKey>> orderByLambda, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserInfo> GetPageList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, TKey>> orderByLambda, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }

        public bool Update(UserInfo model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateByList(List<UserInfo> list)
        {
            throw new NotImplementedException();
        }

        public bool DelByList(List<UserInfo> list)
        {
            throw new NotImplementedException();
        }
    }
}
