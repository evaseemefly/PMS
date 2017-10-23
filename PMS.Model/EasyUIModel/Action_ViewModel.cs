using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMS.Model;

namespace PMS.Model.EasyUIModel
{
    public class Action_ViewModel
    {
        /// <summary>
        /// 将P_DepartmentInfo转成TreeGrid
        /// </summary>
        /// <param name="list_action">部门实体对象集合</param>
        /// <param name="checkedIds">选中的部门id数组</param>
        /// <returns></returns>
        public static List<EasyUITreeGrid_Action> ToEasyUITreeGrid(List<ActionInfo> list_action,params int[] checkedIds)
        {
            List<EasyUITreeGrid_Action> list_treeGrid = new List<EasyUITreeGrid_Action>();

            LoadTreeGrid(list_action, list_treeGrid, 0, checkedIds);
            return list_treeGrid;
        }

        public static List<EasyUIComboTree_Action> ToEasyUIComboTree(List<ActionInfo> list_action, params int[] checkedIds)
        {
            List<EasyUIComboTree_Action> list_comboTree = new List<EasyUIComboTree_Action>();

            LoadComboTree(list_action, list_comboTree, 0, checkedIds);
            return list_comboTree;
        }

        /// <summary>
        ///  将P_DepartmentInfo 对象转成treegrid节点
        /// </summary>
        /// <param name="item">部门实体对象</param>
        /// <param name="isChecked">该节点是否选中</param>
        /// <returns></returns>
        public EasyUITreeGrid_Action ToTreeGridNode(ActionInfo item,bool isChecked=false)
        {
            EasyUITreeGrid_Action node = new EasyUITreeGrid_Action()
            {
                Checked=isChecked,
                selected=isChecked,
                 ID = item.ID,
                  ActionName=item.ActionInfoName,
                Remark = item.Remark,
                children = new List<EasyUITreeGrid_Action>()
            };
            return node;
        }

        public EasyUIComboTree_Action ToComboTreeNode(ActionInfo item, bool isChecked = false)
        {
            EasyUIComboTree_Action node;
            
                node = new EasyUIComboTree_Action()
                {
                    Checked = isChecked,
                    selected = isChecked,
                    id = item.ID,
                    text = item.ActionInfoName,
                    children = new List<EasyUIComboTree_Action>()
                };
            
            return node;
        }

       /// <summary>
       /// 将部门实体对象集合转换为TreeGrid
       /// </summary>
       /// <param name="list_action"></param>
       /// <param name="list_treeGrid"></param>
       /// <param name="pid"></param>
       /// <param name="checkedIds">选中的部门实体对象的id数组</param>
        private static void LoadTreeGrid(List<ActionInfo> list_action, List<EasyUITreeGrid_Action> list_treeGrid, int pid,params int[] checkedIds)
        {
            
            foreach (var item in list_action)
            {
                //如果权限父id=PDID
                if (item.ID == pid)
                {
                    Action_ViewModel model = new Action_ViewModel();
                    //根据当前的ActionInfo对象转换为Node节点
                    EasyUITreeGrid_Action node;
                    if (checkedIds != null && checkedIds.Length > 0)
                    {
                        node = model.ToTreeGridNode(item,checkedIds.Contains(item.ID));
                    }
                    else
                    {
                        node = model.ToTreeGridNode(item);
                    }
                    //将该节点 加入到 树节点集合中
                    list_treeGrid.Add(node);

                    LoadTreeGrid(list_action, node.children, node.ID, checkedIds);
                    
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list_department"></param>
        /// <param name="list_treeGrid"></param>
        /// <param name="pid"></param>
        private static void LoadComboTree(List<ActionInfo> list_action, List<EasyUIComboTree_Action> list_comboTree, int pid, params int[] checkedIds)
        {
            foreach (var item in list_action)
            {
                //如果权限父id=PDID
                if (item.ParentID == pid)
                {
                    Action_ViewModel model = new Action_ViewModel();
                    //根据当前的ActionInfo对象转换为Node节点
                    EasyUIComboTree_Action node;
                    if (checkedIds != null && checkedIds.Length > 0)
                    {
                        node = model.ToComboTreeNode(item,checkedIds.Contains(item.ID));
                    }
                    else
                    {
                        node = model.ToComboTreeNode(item);
                    }


                    //将该节点 加入到 树节点集合中
                    list_comboTree.Add(node);

                    LoadComboTree(list_action, node.children, node.id, checkedIds);

                }
            }
        }
    }
}