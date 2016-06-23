using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMS.Model;

namespace SMSOA.Areas.Contacts.Models
{
    public class Department_ViewModel
    {
        /// <summary>
        /// 将P_DepartmentInfo转成TreeGrid
        /// </summary>
        /// <param name="list_department">部门实体对象集合</param>
        /// <param name="checkedIds">选中的部门id数组</param>
        /// <returns></returns>
        public static List<EasyUITreeGrid_Department> ToEasyUITreeGrid(List<P_DepartmentInfo> list_department,bool hasisPass,params int[] checkedIds)
        {
            List<EasyUITreeGrid_Department> list_treeGrid = new List<EasyUITreeGrid_Department>();

            LoadTreeGrid(list_department, list_treeGrid, 0, hasisPass, checkedIds);
            return list_treeGrid;
        }


        public static List<EasyUIComboTree_Department> ToEasyUIComboTree(List<P_DepartmentInfo> list_department)
        {
            List<EasyUIComboTree_Department> list_comboTree = new List<EasyUIComboTree_Department>();

            LoadComboTree(list_department, list_comboTree, 0);
            return list_comboTree;
        }

       

        public EasyUIComboTree_Department ToComboTreeNode(P_DepartmentInfo item)
        {
            EasyUIComboTree_Department node = new EasyUIComboTree_Department()
            {
                id = item.DID,
                text = item.DepartmentName,
                children = new List<EasyUIComboTree_Department>()
            };
            return node;
        }

        /// <summary>
        /// 将P_DepartmentInfo 对象转成treegrid节点
        /// 传入参数含isPass标签，若isPass为true则对checked，selected，以及isPass添加判断
        /// </summary>
        /// <param name="item">部门实体对象</param>
        /// <param name="hasisPass">是否包含isPass标签</param>
        /// <param name="isChecked">该节点是否选中</param>
        /// <returns></returns>
        public EasyUITreeGrid_Department ToNode(P_DepartmentInfo item, bool hasisPass, bool isChecked = false)
        {
            EasyUITreeGrid_Department node = new EasyUITreeGrid_Department()
            {
                Checked = hasisPass ? item.Checked : isChecked,
                selected = hasisPass ? item.selected : isChecked,
                IsPass = hasisPass ? item.IsPass : isChecked,
                DID = item.DID,
                Area = item.Area,
                DepartmentName = item.DepartmentName,
                Remark = item.Remark,
                children = new List<EasyUITreeGrid_Department>()
            };
            return node;
        }

       
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list_department"></param>
        /// <param name="list_treeGrid"></param>
        /// <param name="pid"></param>
        private static void LoadComboTree(List<P_DepartmentInfo> list_department, List<EasyUIComboTree_Department> list_comboTree, int pid)
        {
            foreach (var item in list_department)
            {
                //如果权限父id=PDID
                if (item.PDID == pid)
                {
                    Department_ViewModel model = new Department_ViewModel();
                    //根据当前的ActionInfo对象转换为Node节点
                    EasyUIComboTree_Department node = model.ToComboTreeNode(item);
                    //将该节点 加入到 树节点集合中
                    list_comboTree.Add(node);

                    LoadComboTree(list_department, node.children, node.id);

                }
            }
        }


        /// <summary>
        /// 将部门实体对象集合转换为TreeGrid
        /// </summary>
        /// <param name="list_department"></param>
        /// <param name="list_treeGrid"></param>
        /// <param name="pid"></param>
        /// <param name="hasisPass">是否包含isPass标签</param>
        /// <param name="checkedIds">选中的部门实体对象的id数组</param>
        private static void LoadTreeGrid(List<P_DepartmentInfo> list_department, List<EasyUITreeGrid_Department> list_treeGrid, int pid, bool hasisPass, params int[] checkedIds)
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
                        node = model.ToNode(item, hasisPass, checkedIds.Contains(item.DID));
                    }
                    else
                    {
                        if (hasisPass)
                            node = model.ToNode(item, hasisPass);
                        else
                        {
                            node = model.ToNode(item, hasisPass);
                        }
                    }
                    //将该节点 加入到 树节点集合中
                    list_treeGrid.Add(node);

                    LoadTreeGrid(list_department, node.children, node.DID, hasisPass, checkedIds);

                }
            }
        }
    }
}