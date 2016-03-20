using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PMS.Model.ViewModel
{
    public class LoginUser
    {
        /// <summary>
        /// 登录名——必填
        /// </summary>
        [Required]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码——必填
        /// </summary>
        [Required]
        public string Pwd { get; set; }

        public bool IsAlways { get; set; }
    }
}
