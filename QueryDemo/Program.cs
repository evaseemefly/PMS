using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSFactory;

namespace QueryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始查询");
            SMSQuery query = new SMSQuery();
            PMS.Model.SMSModel.SMSModel_Query model = new PMS.Model.SMSModel.SMSModel_Query()
            {
                account = "dh74381",
                password = "uAvb3Qey",
                smsId = "54876ee66e74492bbfcf91656cbfa2bd"
            };
            List<PMS.Model.SMSModel.SMSModel_QueryReceive> list_out = new List<PMS.Model.SMSModel.SMSModel_QueryReceive>();
            query.QueryMsg(model, out list_out);

            var index = query.GetQueryState(list_out);

            var dic =PMS.Model.Dictionary.SMSQueryResultDictionary.GetResponseCode();          
            Console.WriteLine(dic[index]); 
            Console.ReadLine();
        }
    }
}
