using ISMS;
using PMS.Model.SMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISMS
{
    public interface IMMSSend:ISMSSend
    {
        string CreateZip(System.IO.Stream picture_stream, string fileDirectory);
        //MMSModel_Send ToSendModel(PMS.Model.ViewModel.ViewModel_MMSMessage model, List<string> list_phones);
        MMSModel_Send ToSendModel(PMS.Model.SMSModel.MMSModel_Send model, List<string> list_phones);

        bool AfterSend(PMS.Model.ViewModel.ViewModel_MMSMessage model, MMSModel_Receive receive, List<string> list_phones, string redis_list_id, int redis_expirationDate = 72);


    }
}
