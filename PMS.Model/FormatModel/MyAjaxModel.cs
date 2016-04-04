using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model.FormatModel
{
    public class MyAjaxModel
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// ok,error,noLogin,noPermission
        /// </summary>
        public string Statu { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
    }
}
