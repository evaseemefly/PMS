using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PMS.Model.EasyUIModel
{
   public class EasyUITreeNode
    {
        /*
        id：节点ID，对加载远程数据很重要。
        text：显示节点文本。
        state：节点状态，'open' 或 'closed'，默认：'open'。在设置为'closed'的时候，当前节点的子节点将会从远程服务器加载他们。
        checked：表示该节点是否被选中。
        attributes: 被添加到节点的自定义属性。
        children: 一个节点数组声明了若干节点。
        */
        /// <summary>
        /// 节点ID，对加载远程数据很重要。
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 显示节点文本。
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 节点状态，'open' 或 'closed'，默认：'open'。在设置为'closed'的时候，当前节点的子节点将会从远程服务器加载他们。
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// 表示该节点是否被选中。
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// 被添加到节点的自定义属性。
        /// </summary>
        public object attributes { get; set; }

        public string iconCls { get; set; }

        /// <summary>
        /// 一个节点数组声明了若干节点。
        /// </summary>
        public List<EasyUITreeNode> children { get; set; }
    }
}
