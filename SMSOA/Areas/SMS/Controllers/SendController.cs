﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.IBLL;
using PMS.Model;
using Common;
using Common.EasyUIFormat;
using PMS.Model.EqualCompare;
using ISMS;

namespace SMSOA.Areas.SMS.Controllers
{
    public class SendController : Controller
    {
        IS_SMSMissionBLL smsMissionBLL { get; set; }
        IP_GroupBLL groupBLL { get; set; }
        IP_DepartmentInfoBLL departmentBLL { get; set; }
        IP_PersonInfoBLL personBLL { get; set; }
        ISMSSend smsSendBLL { get; set; }
        //IUserInfoBLL userInfoBLL { get; set; }
        // GET: SMS/Send


        public ActionResult Index()
        {
            ViewBag.GetAllMission_combogrid = "/SMS/Send/GetAllMissionByPID";
            ViewBag.GetGroupByMID_combogrid = "/SMS/Send/GetGroupByMID";
            ViewBag.GetDepartment_combotree = "/SMS/Send/GetDepartmentInfo4ComboTree";
            ViewBag.GetPersonByMission = "/SMS/Send/GetPersonByMission";
            ViewBag.GetPersonByGroupDepartment = "/SMS/Send/GetPersonByGroupDepartment";
            ViewBag.DoSend = "/SMS/Send/DoSend";
            return View();
        }

        /// <summary>
        /// 根据短信任务id查询该短信任务所拥有的联系人并返回
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public ActionResult GetPersonByMission(int mid)
        {
            //1 根据mid获取指定任务对象
            var mission = smsMissionBLL.GetListBy(s => s.SMID == mid).FirstOrDefault();
            //2 根据短信任务查找对应的群组
            var group = mission.R_Group_Mission.ToList();
            //2.1 创建该任务所拥有的群组对象集合
            List<P_Group> list_group = new List<P_Group>();
            //2.2 添加至群组对象集合中
            group.ForEach(g => list_group.Add(g.P_Group));
            //2.3 根据群组对象集合获取该群组集合中所共有的联系人
            List<P_PersonInfo> list_person = new List<P_PersonInfo>();
            list_group.ForEach(g => list_person.AddRange(g.P_PersonInfo));

            //3 根据短信任务查找对应的部门
            var department = mission.R_Department_Mission.ToList();
            //3.1 创建该任务所拥有的部门对象集合
            List<P_DepartmentInfo> list_department = new List<P_DepartmentInfo>();
            //3.2 添加至部门对象集合中
            department.ForEach(d => list_department.Add(d.P_DepartmentInfo));
            //3.3 根据部门对象集合获取该群组集合中所共有的联系人
            list_department.ForEach(d => list_person.AddRange(d.P_PersonInfo));

            //4 将联系人集合去重
            list_person= list_person.Distinct(new P_PersonEqualCompare()).ToList();

            return Content(Common.SerializerHelper.SerializerToString(list_person));
        }

        /// <summary>
        /// 根据请求中的 部门id 以及 群组id 查询对应的联系人
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPersonByGroupDepartment()
        {
            string dids= Request.QueryString["dids"];
            string gids = Request.QueryString["gids"];
            List<int> list_dids = new List<int>();
            List<int> list_gids = new List<int>();
            if(dids!="")
            {
                dids.Split(',').ToList().ForEach(d => list_dids.Add(int.Parse(d)));
            }
            if(gids!="")
            {
                gids.Split(',').ToList().ForEach(g => list_gids.Add(int.Parse(g)));
            }
           

            //2 根据department以及group的id查询其对应的Person对象集合
            List<P_PersonInfo> list_person = new List<P_PersonInfo>();
            var list_department= departmentBLL.GetListByIds(list_dids);
            list_department.ForEach(d => list_person.AddRange(d.P_PersonInfo));
            var list_group = groupBLL.GetListByIds(list_gids);
            list_group.ForEach(g => list_person.AddRange(g.P_PersonInfo));

            //3 将联系人集合去重
            list_person = list_person.Distinct(new P_PersonEqualCompare()).ToList();

            //4 序列化后返回
            return Content(Common.SerializerHelper.SerializerToString(list_person));
        }

        /// <summary>
        /// 根据 短信任务id 查询对应的群组列表
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public ActionResult GetGroupByMID(int mid)
        {
            //1获取传入的任务id
            //1.1根据任务id查找对应的任务对象并查找对应的群组集合
            List<PMS.Model.P_Group> list_owned_group = new List<PMS.Model.P_Group>();
           
            //根据短信任务查找短信任务所拥有的群组（在R_Group_Mission表中），并只拿取isPass为true的所对应的群组
            smsMissionBLL.GetListBy(m => m.SMID == mid).FirstOrDefault().R_Group_Mission.Where(r=>r.isPass==true).ToList().ForEach(r=>list_owned_group.Add(r.P_Group));

            var list = ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_owned_group, true);
            //2 从所有的群组中删除该任务所拥有的群组集合
            var list_excludeOwned_group = groupBLL.GetListBy(g => g.isDel == false).ToList().Where(g => !list_owned_group.Contains(g)).ToList();
            list.AddRange(ToEasyUICombogrid_Group.ToEasyUIDataGrid(list_excludeOwned_group, false));
            //将该任务拥有的群组设置为选中状态
            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list,
                footer = null
            };
            var temp = Common.SerializerHelper.SerializerToString(model);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);
        }

        /// <summary>
        /// 根据传入的 联系人id数组 以及 短信内容进行短信发送
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DoSend(Models.ViewModel_Message model)
        {
            //1 获取联系人id 数组
           var ids= model.PersonId_Int;
            //1.1 根据联系人id数组获取指定的联系人
           var list_person= personBLL.GetListByIds(ids.ToList());
            //1.2 获取
            List<string> list_phones = new List<string>(); ;
            list_person.ForEach(p => list_phones.Add(p.PhoneNum.ToString()));
            //2 获取短信内容
            var content = model.Content;
            //2.1 设置发送对象相关参数
            string account= "dh74381"; //账号"dh74381";
            string passWord= "uAvb3Qey";//密码 = "uAvb3Qey";
            string subCode="";//短信子码"74431"，接收回馈信息用
            string sign= "【国家海洋预报台】"; //短信签名，！仅在！发送短信时用= "【国家海洋预报台】";
                         //短信发送与查询所需参数
            string phones;//电话号码
            string smsContent= content;//短信内容
            string sendTime;//计划发送时间，为空则立即发送
                            //3 对短信内容进行校验——先暂时不做
            PMS.Model.SMSModel.SMSModel_Send sendMsg = new PMS.Model.SMSModel.SMSModel_Send()
            {
                account = account,
                password = passWord,
                content = smsContent,
                phones= list_phones.ToArray()
            };
            //4 短信发送
            PMS.Model.SMSModel.SMSModel_Receive receive;
            smsSendBLL.SendMsg(sendMsg, out receive);
            return Content("ok");
        }

        /// <summary>
        /// 根据 短信任务id 查询对应的部门实体，并转成ComboTree对象
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public ActionResult GetDepartmentInfo4ComboTree(int mid)
        {
            //根据短信任务找到与该任务对应的所属部门
           var mission= smsMissionBLL.GetListBy(m => m.SMID == mid).FirstOrDefault();
            List<int> list_id = new List<int>();
            mission.R_Department_Mission.ToList().ForEach(r => list_id.Add(r.DepartmentID));
           var list_alldepartment= departmentBLL.GetListBy(d => d.isDel == false).ToList();
            List<PMS.Model.EasyUIModel.EasyUIComboTree_Department> list_combotree = PMS.Model.EasyUIModel.Department_ViewModel.ToEasyUIComboTree(list_alldepartment, list_id.ToArray());

            var temp= Common.SerializerHelper.SerializerToString(list_combotree);
            temp = temp.Replace("Checked", "checked");
            return Content(temp);
        }

        /// <summary>
        /// 查询所有 短信任务对象集合
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllMissionByPID()
        {
            //int userId=3;
            //userInfoBLL.GetListBy(p=>p.ID==userId).FirstOrDefault().R_UserInfo_SMSMission.
            //获取全部的短信种类集合
            var list_allmission= smsMissionBLL.GetAllList();
            
            PMS.Model.EasyUIModel.EasyUIDataGrid model = new PMS.Model.EasyUIModel.EasyUIDataGrid()
            {
                total = 0,
                rows = list_allmission,
                footer = null
            };
            //将权限转换为对应的
            return Content(Common.SerializerHelper.SerializerToString(model));
        }
    }
}