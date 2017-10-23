using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Model.ViewModel;

namespace SMSOA.Areas.SMS.Controllers
{
    public class SMSBaseController : Admin.Controllers.BaseController
    {
        public override ViewModel_MyHttpContext GetHttpContext()
        {
            throw new NotImplementedException();
        }

        protected bool CheckPhonesIsEmpty(List<string> list)
        {
            return list.Count() == 0 ? true : false;
        }
    }
}