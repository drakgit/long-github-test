using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MasterDatabase;
using System.Collections;

namespace Job_Assignment
{
    public class PlanByDateController
    {
        const int MAX_SHIFT_ON_LINE = 3;
        MaterDatabase masterDb;
        public PlanByDateController(MaterDatabase _masterDb)
        {
            masterDb = _masterDb;
        }
        private String ValidateRow(DataRow row)
        {
            if (row["PartNumber"] == DBNull.Value || String.IsNullOrEmpty(row["PartNumber"].ToString()))
                return "PartNumber is not empty";
            if (row["Date"] == DBNull.Value)
                return "Date is not empty";
            if (row["Qty"] == DBNull.Value)
                return "Qty is not empty";
            else
            {
                int qty = 0;
                bool b = int.TryParse(row["Qty"].ToString(), out qty);
                if (!b)
                    return "Qty is must number";
            }

            return "";
        }
        public String Calculate(DataTable inputPlan)
        {
            SqlDataAdapter sqlAdapterLineDescription = null;
            DataSet dsLineDescription = new DataSet();
            try
            {
                DataTable tbLineDescription = masterDb.Get_SQL_Data(Form1.MasterDatabase_Connection_Str, "select * from MDB_003_Line_Desciption", ref sqlAdapterLineDescription, ref dsLineDescription);
                Dictionary<String, decimal> totalShiftOnLine = new Dictionary<string, decimal>();
                for (int i = 0; i < inputPlan.Rows.Count; i++)
                {
                    String errMessage = ValidateRow(inputPlan.Rows[i]);

                    if (!String.IsNullOrEmpty(errMessage))
                        return errMessage;

                    String partNumber = inputPlan.Rows[i]["PartNumber"] as String;
                    DataRow[] lines = tbLineDescription.Select("PartNumber='" + partNumber + "'");
                    if (lines.Length > 0)
                    {
                        DataRow line = lines[0];
                        String lineId = (String)line["LineId"];
                        
                        inputPlan.Rows[i]["LineId"] = lineId;
                        inputPlan.Rows[i]["LineName"] = line["LineName"];
                        inputPlan.Rows[i]["GroupID"] = line["GroupID"];
                        inputPlan.Rows[i]["Capacity"] = line["MaxCapacity"];
                        inputPlan.Rows[i]["NumOfShift"] = Math.Round(1.0 * (int)inputPlan.Rows[i]["Qty"] / (int)line["MaxCapacity"], 1);
                        inputPlan.Rows[i]["NumOfPerson_Per_Day"] = (decimal)inputPlan.Rows[i]["NumOfShift"] * (int)line["MaxResource"];
                        if (!totalShiftOnLine.ContainsKey(lineId))
                        {
                            totalShiftOnLine.Add(lineId, 0);
                        }
                        totalShiftOnLine[lineId] += (decimal)inputPlan.Rows[i]["NumOfShift"];
                    }
                }
                //update totalShiftOnline
                for (int i = 0; i < inputPlan.Rows.Count; i++)
                {
                    String lineId = (String)inputPlan.Rows[i]["LineId"];
                    inputPlan.Rows[i]["TotalShiftPerLine"] = totalShiftOnLine[lineId];
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
 
            return "";
        }
        public String GetLineRule(DataTable inputPlan, ref Dictionary<String, bool> result)
        {
            result = new Dictionary<string, bool>();
            try
            {
                for (int i = 0; i < inputPlan.Rows.Count; i++)
                {
                    DateTime dt;
                    bool b = DateTime.TryParse(inputPlan.Rows[i]["Date"].ToString(), out dt);
                    String partNumber = inputPlan.Rows[i]["PartNumber"] as String;

                    if (b)
                    {
                        String key = String.Format("{0}_{1}", dt.ToString("dd/MM/yyyy"), partNumber);
                        if (!result.ContainsKey(key))
                        {
                            result.Add(key, false);
                        }
                        if ((decimal)inputPlan.Rows[i]["TotalShiftPerLine"] > MAX_SHIFT_ON_LINE)
                        {
                            result[key] = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        public String GetTotalResource(DataTable inputPlan, ref decimal totalResource)
        {
            //inputPlan.Compute("sum(NumOfPerson_Per_Day)", "");
            try
            {
                totalResource = 0;
                for (int i = 0; i < inputPlan.Rows.Count; i++)
                {
                    totalResource += (decimal)inputPlan.Rows[i]["NumOfPerson_Per_Day"];
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

    }
}