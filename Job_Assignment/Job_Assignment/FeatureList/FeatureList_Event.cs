using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MasterDatabase;


namespace Job_Assignment
{
    public partial class Form1 : SQL_APPL
    {

        private int SkillList_Index = 0;
        private int LineList_Index = 1;
        private int Line_DesciptionList_Index = 2;
        private int LineSkillRequestList_Index = 3;
        private int InputFromPlannerList_Index = 4;
        private int ProductionPlanByDate_Index = 5;
        private int ProductionPlanByWorkStation_Index = 6;
        private int WorkStationDescription_Index = 7;

        private void ListProductionLine_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SkillList_Init();
        }

        private void lbl_Empl_Skill_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Empl_Skill_List_Init();
        }

        private void lbl_LineDescription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Line_DesciptionList_Init();
        }

        private void lbl_LineSkillRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LineSkillRequestList_Init();
        }
        private void lbl_InputFromPlanner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InputFromPlannerList_Init();
        }
        private void lbl_ProductionPlanByDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KeHoachSanXuatTheoNgayList_Init();
        }

        private void lbl_ProductionPlanByWorkStation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KeHoachSanXuatTheoTramList_Init();
        }
        private void lbl_WorkStationDescription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LineWorkStationMapping_Init();
        }
    }
}
