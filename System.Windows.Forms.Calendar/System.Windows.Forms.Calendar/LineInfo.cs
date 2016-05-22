using System;
using System.Collections.Generic;
using System.Text;

namespace System.Windows.Forms.Calendar
{
    public class LineInfo
    {
        public string LineId;
        public string LineName;

        public LineInfo(string lineId, string lineName)
        {
            LineId = lineId;
            LineName = lineName;
        }
    }
}
