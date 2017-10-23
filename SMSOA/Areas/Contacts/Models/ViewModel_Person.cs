using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.Contacts.Models
{
    public class ViewModel_Person
    {
        public int PID { get; set; }

        public string PName { get; set; }

        public string PhoneNum { get; set; }

        public string Remark { get; set; }

        public short isVIP { get; set; }

        /// <summary>
        /// 群组id数组
        /// </summary>
        public int[] GID { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public int DID { get; set; }
    }
}