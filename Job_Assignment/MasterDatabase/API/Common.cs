using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;

namespace MasterDatabase
{
    public class UserInfo_struct
    {
        public string UserName;
        public string Password;
        public string Empl_ID;
        public string Department;
        public string MailAddr;
        public string Permission;
        public string Group;
    }

    public class EmplInfo_struct
    {
        public string Empl_ID;
        public string Last_Name;
        public string First_Name;
        public string Department;
        public string Password;
        public string Office;
    }

    public class PosSize
    {
        public int pos_x, pos_y;
        public int width, height;
    }

    public enum TextBox_Type
    {
        TEXT,
        NUMBER
    }

    public enum AnchorType
    {
        LEFT,
        RIGHT,
        LEFT_RIGHT,
        ALL,
        NONE
    }
    public enum DateStringType
    {
        DDMMYY,
        MMDDYY,
        YYMMDD
    }

}
