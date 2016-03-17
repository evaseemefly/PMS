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
    public interface IUserInfoDAL:IBaseDAL<UserInfo>
    {
        
    }
}
