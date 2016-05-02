using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMS.Model;

namespace PMS.Model.EasyUIModel
{
    public class Department_ViewModel
    {
        /// <summary>
        /// 将P_DepartmentInfo转成TreeGrid
        /// </summary>
        /// <param name="list_department">部门实体对象集合</param>
        /// <param name="checkedIds">选中的部门id数组</param>
        /// <returns></returns>
        public static List<EasyUITreeGrid_Department> ToEasyUITreeGrid(List<P_DepartmentInfo> list_department,params int[] checkedIds)
        {
            List<EasyUITreeGrid_Department> list_treeGrid = new List<EasyUITreeGrid_Department>();

            LoadTreeGrid(list_department, list_treeGrid, 0, checkedIds);
            return list_treeGrid;
        }

        public static List<EasyUIComboTree_Department> ToEasyUIComboTree(List<P_DepartmentInfo> list_department, params int[] checkedIds)
        {
            List<EasyUIComboTree_Department> list_comboTree = new List<EasyUIComboTree_Department>();

            LoadComboTree(list_department, list_comboTree, 0, checkedIds);
            return list_comboTree;
        }

        /// <summary>
        ///  将P_DepartmentInfo 对象转成treegrid节点
        /// </summary>
        /// <param name="item">部门实体对象</param>
        /// <param name="isChecked">该节点是否选中</param>
        /// <returns></returns>
        public EasyUITreeGrid_Department ToTreeGridNode(P_DepartmentInfo item,bool isChecked=false)
        {
            EasyUITreeGrid_Department node = new EasyUITreeGrid_Department()
            {
                Checked=isChecked,
                selected=isChecked,
                DID = item.DID,
                Area = item.Area,
                DepartmentName = item.DepartmentName,
                Remark = item.Remark,
                children = new List<EasyUITreeGrid_Department>()
            };
            return node;
        }

        public EasyUIComboTree_Department ToComboTreeNode(P_DepartmentInfo item, bool isChecked = false)
        {
            EasyUIComboTree_Department node;
            
                node = new EasyUIComboTree_Department()
                {
                    Checked = isChecked,
                    selected = isChecked,
                    id = item.DID,
                    text = item.DepartmentName,
                    children = new List<EasyUIComboTree_Department>()
                };
            
            return node;
        }

       /// <summary>
       /// 将部门实体对象集合转换为TreeGrid
       /// </summary>
       /// <param name="list_department"></param>
       /// <param name="list_treeGrid"></param>
       /// <param name="pid"></param>
       /// <param name="checkedIds">选中的部门实体对象的id数组</param>
        private static void LoadTreeGrid(List<P_DepartmentInfo> list_department, List<EasyUITreeGrid_Department> list_treeGrid, int pid,params int[] checkedIds)
        {
            
            foreach (var item in list_department)
            {
                //如果权限父id=PDID
                if (item.PDID == pid)
                {
                    Department_ViewModel model = new Department_ViewModel();
                    //根据当前的ActionInfo对象转换为Node节点
                    EasyUITreeGrid_Department node;
                    if (checkedIds != null && checkedIds.Length > 0)
                    {
                        node = model.ToTreeGridNode(item,checkedIds.Contains(item.DID));
                    }
                    else
                    {
                        node = model.ToTreeGridNode(item);
                    }
                    //将该节点 加入到 树节点集合中
                    list_treeGrid.Add(node);

                    LoadTreeGrid(list_department, node.children, node.DID, checkedIds);
                    
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list_department"></param>
        /// <param name="list_treeGrid"></param>
        /// <param name="pid"></param>
        private static void LoadComboTree(List<P_DepartmentInfo> list_department, List<EasyUIComboTree_Department> list_comboTree, int pid, params int[] checkedIds)
        {
            foreach (var item in list_department)
            {
                //如果权限父id=PDID
                if (item.PDID == pid)
                {
                    Department_ViewModel model = new Department_ViewModel();
                    //根据当前的ActionInfo对象转换为Node节点
                    EasyUIComboTree_Department node;
                    if (checkedIds != null && checkedIds.Length > 0)
                    {
                        node = model.ToComboTreeNode(item,checkedIds.Contains(item.DID));
                    }
                    else
                    {
                        node = model.ToComboTreeNode(item);
                    }


                    //将该节点 加入到 树节点集合中
                    list_comboTree.Add(node);

                    LoadComboTree(list_department, node.children, node.id, checkedIds);

                }
            }
        }
    }
}