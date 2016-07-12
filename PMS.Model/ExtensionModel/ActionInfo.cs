using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace PMS.Model
{
    public partial class ActionInfo
    {
        private bool _checked = false;

        /// <summary>
        /// 选中
        /// </summary>
        public bool Checked
        {
            set { _checked = value; }
            get { return _checked; }
        }
        public bool byRole { get; set; }
        /// <summary>
        /// 1 
        /// </summary>
        /// <param name="list_action"></param>
        /// <returns></returns>
        public static List<EasyUIModel.EasyUITreeNode> ToEasyUITreeNode(List<ActionInfo> list_action)
        {
            List<EasyUIModel.EasyUITreeNode> list_nodes = new List<EasyUIModel.EasyUITreeNode>();

            LoadTreeNode(list_action, list_nodes, 0);
            return list_nodes;
        }

           
        /// <summary>
        /// 2 
        /// </summary>
        /// <param name="list_action"></param>
        /// <param name="list_node"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static void LoadTreeNode(List<ActionInfo> list_action, List<EasyUIModel.EasyUITreeNode> list_node, int pid)
        {
            //遍历权限集合
            /*
            1 
            */
            foreach (var item in list_action)
            {
                //如果权限父id=pid
                if(item.ParentID==pid)
                {
                    //根据当前的ActionInfo对象转换为Node节点
                    EasyUIModel.EasyUITreeNode node = item.ToNode();
                    //将该节点 加入到 树节点集合中
                    list_node.Add(node);

                    LoadTreeNode(list_action, node.children, node.id);
                }
            }
        }   

        /// <summary>
        /// 生成当前对象的url
        /// 为本实体中的url赋值，并将其返回
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            this.Url= GetUrlPart(this.AreaName) + GetUrlPart(this.ControllerName) + GetUrlPart(this.ActionMethodName);
            return this.Url;
        }
        
        /// <summary>
        /// 根据传入的字符串生成url节
        /// </summary>
        /// <param name="urlPart"></param>
        /// <returns></returns>
        public string GetUrlPart(string urlPart)
        {
            return string.IsNullOrEmpty(urlPart) ? "" : "/" + urlPart;
        }
        
        /// <summary>
        /// 3 将当前的ActionInfo对象中包含的信息转换成Node节点对象
        /// </summary>
        /// <returns></returns>
        public EasyUIModel.EasyUITreeNode ToNode()
        {
            EasyUIModel.EasyUITreeNode node = new EasyUIModel.EasyUITreeNode()
            {
                id = this.ID,
                text = this.ActionInfoName,
                state = "open",
                Checked = false,
                iconCls=this.MenuIcon,
                attributes = new { url = this.GetUrl() },
                children = new List<EasyUIModel.EasyUITreeNode>()
            };
            return node;
        }
        //public bool Checked
        //{
        //    set { _checked = value; }
        //    get { return _checked; }
        //}
    }
}
