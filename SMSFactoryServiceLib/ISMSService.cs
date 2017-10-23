﻿using PMS.Model.SMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SMSFactoryServiceLib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface ISMSService
    {
        /// <summary>
        /// 短信发送
        /// 返回是否成功bool
        /// 以及根据out参数输出短信发送接收实体对象
        /// </summary>
        /// <param name="smsdata"></param>
        /// <returns></returns>
        [OperationContract]
        bool SendMsg(SMSModel_Send smsdata, out SMSModel_Receive receiveModel);
    }

    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    // 可以将 XSD 文件添加到项目中。在生成项目后，可以通过命名空间“SMSFactoryServiceLib.ContractType”直接使用其中定义的数据类型。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
