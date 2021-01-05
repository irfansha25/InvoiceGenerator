using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ViewInvoice;

namespace ViewModelInvoice
{
    public class VMSetting
    {
        public void SaveSetting(Setting setting)
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("Delete from Setting where UserId=" + Common.UserId + " And KeyString in ('PrintertName','CGSTLessThan1000','SGSTLessThan1000','CGSTGreaterThan1000','SGSTGreaterThan1000');");
            sbQuery.Append("Insert into Setting(KeyString,ValueString,UserId) Values('PrintertName','" + setting.PrinterName + "'," + Common.UserId + ");");
            sbQuery.Append("Insert into Setting(KeyString,ValueString,UserId) Values('CGSTLessThan1000','" + setting.CGSTLessThan1000 + "'," + Common.UserId + ");");
            sbQuery.Append("Insert into Setting(KeyString,ValueString,UserId) Values('SGSTLessThan1000','" + setting.SGSTLessThan1000 + "'," + Common.UserId + ");");
            sbQuery.Append("Insert into Setting(KeyString,ValueString,UserId) Values('CGSTGreaterThan1000','" + setting.CGSTGreaterThan1000 + "'," + Common.UserId + ");");
            sbQuery.Append("Insert into Setting(KeyString,ValueString,UserId) Values('SGSTGreaterThan1000','" + setting.SGSTGreaterThan1000 + "'," + Common.UserId + ");");
            Common.ExecuteNonQuery(sbQuery.ToString());
        }
        public void LoadCoordinates()
        {
            // Loading from a file, you can also load from a stream
            var xml = XDocument.Load(@"Coordinates.xml");

            Common.Coordinates = new Dictionary<string, System.Drawing.PointF>();

            // Query the data and write out a subset of contacts
            var query = from c in xml.Root.Descendants("Invoice")
                        select new
                        {
                            Property = (string)c.Attribute("property"),
                            PointX = c.Element("X").Value,
                            PointY = c.Element("Y").Value
                        };


            foreach (var elements in query)
            {
                Common.Coordinates.Add(elements.Property, new System.Drawing.PointF(Convert.ToSingle(elements.PointX), Convert.ToSingle(elements.PointY)));
            }
        }
        public Setting GetSetting()
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("Select KeyString,ValueString from Setting where userId=" + Common.UserId + "");
            DataSet ds = Common.GetDataSet(sbQuery.ToString());
            Setting setting = new Setting();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (var dr in ds.Tables[0].AsEnumerable())
                {
                    if (dr["KeyString"].ToString() == "PrintertName")
                        setting.PrinterName = dr["ValueString"].ToString();
                    else if (dr["KeyString"].ToString() == "CGSTLessThan1000")
                        setting.CGSTLessThan1000 = Convert.ToDouble(dr["ValueString"].ToString());
                    else if (dr["KeyString"].ToString() == "SGSTLessThan1000")
                        setting.SGSTLessThan1000 = Convert.ToDouble(dr["ValueString"].ToString());
                    else if (dr["KeyString"].ToString() == "CGSTGreaterThan1000")
                        setting.CGSTGreaterThan1000 = Convert.ToDouble( dr["ValueString"].ToString());
                    else if (dr["KeyString"].ToString() == "SGSTGreaterThan1000")
                        setting.SGSTGreaterThan1000 = Convert.ToDouble(dr["ValueString"].ToString());
                }
            }
            return setting;
        }
    }
}
