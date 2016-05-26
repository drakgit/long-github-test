using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CalendarDemo
{
    public class ItemInfo
    {
        public DateTime StartTime;
        public DateTime EndTime;
        public String LineId;
        public string Text;
        public int A;
        public int R;
        public int G;
        public int B;
        HatchStyle pattern;
        Color patternColor;

        public ItemInfo()
        { }

        public ItemInfo(DateTime startTime, DateTime endTime, String lineId, string text, Color color)
        {
            StartTime = startTime;
            EndTime = endTime;
            LineId = lineId;
            Text = text;
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
        }
    }
}
