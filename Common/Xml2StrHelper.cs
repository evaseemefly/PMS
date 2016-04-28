using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Common
{
   public static class Xml2StrHelper
    {
        public static String Xml2Str(String _returnMsg, String treeNode)//单一模式
        {
            XmlDocument xx = new XmlDocument();
            xx.LoadXml(_returnMsg);
            XmlNode nodes = xx.SelectSingleNode(treeNode);
            if (nodes == null)
            {
                //returnValue = false;
                //return treeNode + "未检测到该标签";
                return "";
            }
            return nodes.InnerText;
        }
    }
}
