using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSOA.Areas.SMS.Models
{
    public class ViewModel_GroupMission
    {
        public string group_Ids { get; set; }

        public string mission_Ids { get; set; }

        public int[] GroupId_Int
        {
            get
            {
                return Array.ConvertAll<string, int>(group_Ids.Split(','), s => int.Parse(s));
            }
        }
        public int[] MissionId_Int
        {
            get
            {
                return Array.ConvertAll<string, int>(mission_Ids.Split(','), s => int.Parse(s));
            }
        }
    }
}