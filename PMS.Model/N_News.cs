//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMS.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class N_News
    {
        public N_News()
        {
            this.R_UserInfo_News = new HashSet<R_UserInfo_News>();
        }
    
        public int SNID { get; set; }
        public int UID { get; set; }
        public string Title { get; set; }
        public int NewsType { get; set; }
        public string NewsContent { get; set; }
        public System.DateTime SubDateTime { get; set; }
        public bool isDel { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
        public virtual ICollection<R_UserInfo_News> R_UserInfo_News { get; set; }
    }
}
