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
        public static List<EasyUIModel.EasyUITreeNode> ToEasyUITreeNode(List<ActionInfo> list_action,ActionInfo action_default=null)
        {
            List<EasyUIModel.EasyUITreeNode> list_nodes = new List<EasyUIModel.EasyUITreeNode>();

            LoadTreeNode(list_action, list_nodes, 0, action_default);
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
        /// 将权限集合转换为easyui使用的treenode集合
        /// 并根据传入的默认（选中）的权限设置指定节点为选中状态
        /// </summary>
        /// <param name="list_action"></param>
        /// <param name="list_node"></param>
        /// <param name="pid"></param>
        /// <param name="action_default"></param>
        public static void LoadTreeNode(List<ActionInfo> list_action, List<EasyUIModel.EasyUITreeNode> list_node, int pid,ActionInfo action_default=null)
        {
            //遍历权限集合
            /*
            1 
            */
            foreach (var item in list_action)
            {
                //如果权限父id=pid
                if (item.ParentID == pid)
                {
                    //根据当前的ActionInfo对象转换为Node节点
                    EasyUIModel.EasyUITreeNode node = item.ToNode();
                    //若默认权限（选中菜单）非空，且（当前id为默认权限的父节点或默认权限本身），则将当前节点的checked设置为true                    
                    if (action_default != null&&(action_default.ParentID == item.ID||action_default.ID==item.ID))
                    {
                        node.Checked = true;
                    }
                    //将该节点 加入到 树节点集合中
                    list_node.Add(node);

                    LoadTreeNode(list_action, node.children, node.id,action_default);
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
