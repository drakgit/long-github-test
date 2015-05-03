using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterDatabase
{
    public class ExcelImportStruct
    {
        public string Col_str;
        public string DB_str;
        public int Col;
        public int CSV_Col;
        public Excel_Col_Type Col_type;
        public int Data_Max_len;
        public bool Is_Primary_Key;
        public int My_index;

        public ExcelImportStruct(int index, string name, string col_str, Excel_Col_Type type, int data_max_len, bool pri_key)
        {
            My_index = index;
            //Name = name;
            Col_str = col_str;
            DB_str = name;
            Col_type = type;
            Data_Max_len = data_max_len;
            Col = 0;
            Is_Primary_Key = pri_key;
        }
    }
}
