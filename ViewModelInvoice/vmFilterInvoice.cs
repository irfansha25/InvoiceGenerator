using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using ViewInvoice;

namespace ViewModelInvoice
{
    public class VMFilterInvoice
    {
        public List<TaxInvoice> GetFilterInvoice(int clientId)
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("Select inv.InvoiceId, cm.ClientId,cm.ClientName,cm.Address,cm.GSTNo,inv.InvoiceNumber,inv.InvoiceDate,inv.Discount,inv.CGST,inv.SGST,inv.IGST,inv.Freight from InvoiceMaster inv ");
            sbQuery.Append("inner join ClientMaster cm on inv.ClientId=cm.ClientId where cm.ClientId=" + clientId + " order by inv.InvoiceId");
            return GetAllInvoice(sbQuery.ToString());

        }
        public List<TaxInvoice> GetFilterInvoice(DateTime dtFromDate, DateTime dtEndDate)
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("Select inv.InvoiceId, cm.ClientId,cm.ClientName,cm.Address,cm.GSTNo,inv.InvoiceNumber,inv.InvoiceDate,inv.Discount,inv.CGST,inv.SGST,inv.IGST,inv.Freight from InvoiceMaster inv ");
            sbQuery.Append("inner join ClientMaster cm on inv.ClientId=cm.ClientId where inv.InvoiceDate between '" + dtFromDate.ToString("dd-MMM-yyyy") + "' And '" + dtEndDate.ToString("dd-MMM-yyyy") + "' order by inv.InvoiceId");
            return GetAllInvoice(sbQuery.ToString());
        }
        public List<TaxInvoice> GetFilterInvoice(int clientId, DateTime dtFromDate, DateTime dtEndDate)
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("Select inv.InvoiceId, cm.ClientId,cm.ClientName,cm.Address,cm.GSTNo,inv.InvoiceNumber,inv.InvoiceDate,inv.Discount,inv.CGST,inv.SGST,inv.IGST,inv.Freight from InvoiceMaster inv ");
            sbQuery.Append("inner join ClientMaster cm on inv.ClientId=cm.ClientId where cm.ClientId=" + clientId + " And  inv.InvoiceDate between  '" + dtFromDate.ToString("dd-MMM-yyyy") + "' And '" + dtEndDate.ToString("dd-MMM-yyyy") + "' order by inv.InvoiceId");
            return GetAllInvoice(sbQuery.ToString());
        }
        private List<TaxInvoice> GetAllInvoice(string query)
        {
            List<TaxInvoice> InvoiceList = new List<TaxInvoice>();
            DataSet ds = Common.GetDataSet(query);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (var dr in ds.Tables[0].AsEnumerable())
                {
                    TaxInvoice objInvoice = new TaxInvoice();
                    objInvoice.InvoiceId = Convert.ToInt32(dr["InvoiceId"]);
                    objInvoice.ClientId = Convert.ToInt32(dr["ClientId"]);
                    objInvoice.ClientName = Convert.ToString(dr["ClientName"]);
                    objInvoice.Address = Convert.ToString(dr["Address"]);
                    objInvoice.GstNo = Convert.ToString(dr["GSTNo"]);
                    objInvoice.InvoiceNo = Convert.ToString(dr["InvoiceNumber"]);
                    objInvoice.InvoiceDate = Convert.ToDateTime(dr["InvoiceDate"]);
                    objInvoice.Discount = dr["Discount"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Discount"]);
                    objInvoice.CGST = dr["CGST"] == DBNull.Value ? 0 : Convert.ToDouble(dr["CGST"]);
                    objInvoice.SGST = dr["SGST"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SGST"]);
                    objInvoice.IGST = dr["IGST"] == DBNull.Value ? 0 : Convert.ToDouble(dr["IGST"]);
                    objInvoice.Freight = dr["Freight"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Freight"]);
                    for (int i = 0; i < 20; i++)
                    {
                        objInvoice.Shades.Add(new ShadeItem(i + 1));
                    }
                    string shadequery = "Select ShadeDetailsId,ItemName,HSINCode,ShadeCode,Inch_36,Inch_38,Inch_40,Inch_42,Inch_44,Inch_46,Inch_48,Inch_50,Rate from ShadeDetails where InvoiceId =" + Convert.ToInt32(dr["InvoiceId"]) + " order by ShadeDetailsId";
                    DataSet dsShades = Common.GetDataSet(shadequery);
                    if (dsShades != null && dsShades.Tables.Count > 0)
                    {
                        int index = 0;
                        foreach (var drShade in dsShades.Tables[0].AsEnumerable())
                        {
                            objInvoice.Shades[index].ItemName = Convert.ToString(drShade["ItemName"]);
                            objInvoice.Shades[index].HSINCode = Convert.ToString(drShade["HSINCode"]);
                            objInvoice.Shades[index].ShadeCode = Convert.ToString(drShade["ShadeCode"]);
                            objInvoice.Shades[index].Inch_36 = Convert.ToInt32(drShade["Inch_36"]);
                            objInvoice.Shades[index].Inch_38 = Convert.ToInt32(drShade["Inch_38"]);
                            objInvoice.Shades[index].Inch_40 = Convert.ToInt32(drShade["Inch_40"]);
                            objInvoice.Shades[index].Inch_42 = Convert.ToInt32(drShade["Inch_42"]);
                            objInvoice.Shades[index].Inch_44 = Convert.ToInt32(drShade["Inch_44"]);
                            objInvoice.Shades[index].Inch_46 = Convert.ToInt32(drShade["Inch_46"]);
                            objInvoice.Shades[index].Inch_48 = Convert.ToInt32(drShade["Inch_48"]);
                            objInvoice.Shades[index].Inch_50 = Convert.ToInt32(drShade["Inch_50"]);
                            objInvoice.Shades[index].Rate = Convert.ToDouble(drShade["Rate"]);
                            index++;
                        }
                    }
                    VMInvoice.ComputeAmount(ref objInvoice);
                    InvoiceList.Add(objInvoice);
                }
            }
            return InvoiceList;
        }
    }
}
