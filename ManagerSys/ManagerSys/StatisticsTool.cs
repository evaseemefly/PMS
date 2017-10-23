using ManagerSys.BLL;
using ManagerSys.ViewModel;
using PersonImporting.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerSys
{
    public partial class StatisticsTool : Form
    {
        public StatisticsTool()
        {
            InitializeComponent();
        }
        static DateTime timeStart;
        static DateTime timeStop;
        static MissionBLL missionBLL = new MissionBLL();
        static MsgContentRecordBLL mcrBLL = new MsgContentRecordBLL();
        static List<StatisticsModel> statisticResults;
        static List<StatisticsResultModel> statisticResults2;

        private void StatisticsTool_Load(object sender, EventArgs e)
        {
            timeStart = monthCalendar1.SelectionStart;
            timeStop = monthCalendar2.SelectionStart;
            var missionList = missionBLL.getMissionList().ToList();
            dataGridView1.DataSource = missionList;
            MissionTest();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int SMID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //看哪个被选中了，把任务名导进去
            for (int i = 1; i <= 20; i++)
            {
                //看有没有被选中
                if (((RadioButton)(groupBox2.Controls.Find("radioButton" + i.ToString(), false)[0])).Checked==true)
                {
                    ((TextBox)(groupBox2.Controls.Find("textBox" + i.ToString(), false)[0])).Text = missionBLL.getMissionName(SMID);
                    MissionTest();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 20; i++)
            {
                ((RadioButton)(groupBox2.Controls.Find("radioButton" + i.ToString(), false)[0])).Checked = false;
                ((TextBox)(groupBox2.Controls.Find("textBox" + i.ToString(), false)[0])).Text = "";
            }
            MissionTest();
        }

        private void buttonDo_Click(object sender, EventArgs e)
        {

            statisticResults = new List<StatisticsModel>();
            statisticResults2 = new List<StatisticsResultModel>();
            GetRecordList();
            Statisticsing();
            resultsOutput();
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            timeStart = monthCalendar1.SelectionStart;
            if (DateTime.Compare(timeStart, timeStop) > 0)
            {
                monthCalendar2.SelectionStart = timeStart;
                monthCalendar2.SelectionEnd = timeStart;
                timeStop = timeStart;
            }

        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            timeStop = monthCalendar2.SelectionStart;
            if (DateTime.Compare(timeStart, timeStop) > 0)
            {
                monthCalendar1.SelectionStart = timeStop;
                monthCalendar1.SelectionEnd = timeStop;
                timeStart = timeStop;
            }

        }


        private void MissionTest()
        {
            for(int i=1;i<=20;i++)
            {
                //任务名不是空
                if (!((TextBox)(groupBox2.Controls.Find("textBox"+i.ToString(), false)[0])).Text.Equals(""))
                {
                    //检查任务名是否存在
                    if (missionBLL.CheckMissionExist(((TextBox)(groupBox2.Controls.Find("textBox" + i.ToString(), false)[0])).Text))
                    {
                        //存在则正常
                        ((RadioButton)(groupBox2.Controls.Find("radioButton" + i.ToString(), false)[0])).Text = "载入正常";
                        ((RadioButton)(groupBox2.Controls.Find("radioButton" + i.ToString(), false)[0])).ForeColor = Color.Green;
                    }
                    //不存在则失败
                    else
                    {
                        ((RadioButton)(groupBox2.Controls.Find("radioButton" + i.ToString(), false)[0])).Text = "载入失败";
                        ((RadioButton)(groupBox2.Controls.Find("radioButton" + i.ToString(), false)[0])).ForeColor = Color.Red;
                    }
                }
                else
                {
                    ((RadioButton)(groupBox2.Controls.Find("radioButton" + i.ToString(), false)[0])).Text = "选择载入";
                    ((RadioButton)(groupBox2.Controls.Find("radioButton" + i.ToString(), false)[0])).ForeColor = Color.Black;
                }
            }
        }

        private void GetRecordList()
        {
            for (int i = 1; i <= 20; i++)
            {
                string missionName = ((TextBox)(groupBox2.Controls.Find("textBox" + i.ToString(), false)[0])).Text;
                //任务名不是空
                if (!missionName.Equals(""))
                {
                    
                    //检查任务名是否存在
                    if (missionBLL.CheckMissionExist(missionName))
                    {
                        //存在则获取该任务的发送记录
                        int SMID = missionBLL.GetMissionId(missionName);
                        var mrcList = mcrBLL.GetMsgRecord(SMID, timeStart, timeStop);
                        //存在记录时
                        if (mrcList.Count>0)
                        {
                            //将每条记录转换成输出格式
                            foreach(var temp in mrcList)
                            {
                                var temp1 = Record2Statistics(temp,missionName);
                                statisticResults.Add(temp1);
                            }
                        }
                    }
                    //不存在则标记失败
                    else
                    {
                        ((RadioButton)(groupBox2.Controls.Find("radioButton" + i.ToString(), false)[0])).Text = "获取失败";
                        ((RadioButton)(groupBox2.Controls.Find("radioButton" + i.ToString(), false)[0])).ForeColor = Color.Red;
                    }
                }
            }
        }

        /// <summary>
        /// 将短信记录转换为统计格式
        /// </summary>
        /// <param name="MRC"></param>
        /// <param name="missionName"></param>
        /// <returns></returns>
        private StatisticsModel Record2Statistics(PMS.Model.S_SMSContent MRC,string missionName)
        {
            StatisticsModel sm = new StatisticsModel();
            sm.missionName = missionName;
            sm.msgContent = MRC.SMSContent.Replace("\n","");
            sm.sendTime = MRC.SendDateTime;
            if(MRC.isMMS==false)
            {
            sm.smsPersonNumber = mcrBLL.GetMsgPersonNumber(MRC.ID);
            sm.smsMsgNumber = sm.smsPersonNumber*MRC.smsCount;
            }
            else
            {
            sm.mmsPersonNumber = mcrBLL.GetMsgPersonNumber(MRC.ID);
            sm.mmsMsgNumber = sm.mmsPersonNumber*MRC.smsCount;
            }


            return sm;
        }
        /// <summary>
        /// 统计各任务的发送量
        /// </summary>
        private void Statisticsing()
        {
            for (int i = 1; i <= 20; i++)
            {
                string missionName = ((TextBox)(groupBox2.Controls.Find("textBox" + i.ToString(), false)[0])).Text;
                //任务名不是空
                if (!missionName.Equals(""))
                {
                    //找到当前任务的短信记录
                    var missionMsg = statisticResults.FindAll(s => s.missionName.Equals(missionName)).ToList();
                    if(missionMsg.Count>0)
                    {
                        StatisticsResultModel tempS = new StatisticsResultModel();
                        tempS.missionName = missionName;
                        foreach (var temp in missionMsg)
                        {
                            tempS.smsMsgNumber = tempS.smsMsgNumber + temp.smsMsgNumber;
                            tempS.smsPersonNumber = tempS.smsPersonNumber + temp.smsPersonNumber;
                            tempS.mmsMsgNumber = tempS.mmsMsgNumber + temp.mmsMsgNumber;
                            tempS.mmsPersonNumber = tempS.mmsPersonNumber + temp.mmsPersonNumber;
                        }
                        statisticResults2.Add(tempS);

                    }
                    
                }
            }
        } 


        /// <summary>
        /// 输出结果
        /// </summary>
        private void resultsOutput()
        {
            TS1.Text = "";
            TS2.Text = "";
            StreamWriter sw = new StreamWriter(TOutput.Text+"相关记录.xls", false, Encoding.Default);
            sw.WriteLine("发送时间\t任务名称\t短信发送量\t彩信发送量\t短信发送人数\t彩信发送人数\t信息内容");
            TS1.Text = TS1.Text + "发送时间\t\t任务名称\t\t短信量\t彩信量\t短信人数\t彩信人数\t信息内容\n";
            foreach (var temp in statisticResults)
            {
                sw.WriteLine(temp.sendTime.ToString() + "\t" + temp.missionName + "\t" + temp.smsMsgNumber + "\t" + temp.mmsMsgNumber + "\t" + temp.smsPersonNumber + "\t" + temp.mmsPersonNumber + "\t" + temp.msgContent);
                TS1.Text = TS1.Text + temp.sendTime.ToString() + "\t" + temp.missionName + "\t" + temp.smsMsgNumber + "\t" + temp.mmsMsgNumber + "\t" + temp.smsPersonNumber + "\t\t" + temp.mmsPersonNumber + "\t" + temp.msgContent + "\n";
            }
            sw.Close();
            sw = new StreamWriter(TOutput.Text + "统计结果.xls", false, Encoding.Default);
            sw.WriteLine("任务名称\t短信发送总量\t彩信发送总量\t短信总人数\t彩信总人数");
            TS2.Text = TS2.Text + "任务名称\t\t短信总量\t彩信总量\t短信总人数\t彩信总人数\n";
            foreach (var temp in statisticResults2)
            {
                sw.WriteLine(temp.missionName + "\t" + temp.smsMsgNumber + "\t" + temp.mmsMsgNumber + "\t" + temp.smsPersonNumber + "\t" + temp.mmsPersonNumber);
                TS2.Text = TS2.Text + temp.missionName + "\t" + temp.smsMsgNumber + "\t\t" + temp.mmsMsgNumber + "\t\t" + temp.smsPersonNumber + "\t\t" + temp.mmsPersonNumber + "\n";
            }
            sw.Close();
        }


    }
}
