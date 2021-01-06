using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using ViewInvoice;

namespace ViewModelInvoice
{
    public class VMInvoice
    {
        public void SaveInvoice(TaxInvoice taxInvoice)
        {
            StringBuilder sbQuery = new StringBuilder();
            if (taxInvoice.InvoiceId > 0)
            {
                sbQuery.Append("Update InvoiceMaster Set InvoiceDate='" + taxInvoice.InvoiceDate.ToString("dd-MMM-yyyy hh:mm:ss") + "', Freight=" + taxInvoice.Freight + ",");
                sbQuery.Append("Discount=" + taxInvoice.Discount + ", CGST=" + taxInvoice.CGST + ", SGST=" + taxInvoice.SGST + ", IGST=" + taxInvoice.IGST + " ");
                sbQuery.Append("where InvoiceId = " + taxInvoice.InvoiceId + "; ");
                sbQuery.Append("Delete from ShadeDetails where Invoiceid=" + taxInvoice.InvoiceId + ";");
                Common.ExecuteNonQuery(sbQuery.ToString());
            }
            else
            {
                sbQuery.Append("Insert into InvoiceMaster(InvoiceNumber,InvoiceDate,ClientId,Freight,Discount,CGST,SGST,IGST) ");
                sbQuery.Append("Values ('" + taxInvoice.InvoiceNo + "','" + taxInvoice.InvoiceDate.ToString("dd-MMM-yyyy hh:mm:ss") + "'," + taxInvoice.ClientId + "," + taxInvoice.Freight + "," + taxInvoice.Discount + "," + taxInvoice.CGST + "," + taxInvoice.SGST + "," + taxInvoice.IGST + ");");
                sbQuery.Append("SELECT CAST(SCOPE_IDENTITY() AS INT) AS LAST_IDENTITY;");
                taxInvoice.InvoiceId = (int)Common.ExecuteScalar(sbQuery.ToString());
            }

            foreach (var item in taxInvoice.Shades.Where(x => !string.IsNullOrEmpty(x.ShadeCode)))
            {
                sbQuery.Clear();
                sbQuery.Append("Insert into ShadeDetails(InvoiceId,ItemName,HSINCode,ShadeCode,Inch_36,Inch_38,Inch_40,Inch_42,Inch_44,Inch_46,Inch_48,Inch_50,Rate) Values ");
                sbQuery.Append("(" + taxInvoice.InvoiceId + ",");
                sbQuery.Append("'" + item.ItemName + "','"+item.HSINCode+"','" + item.ShadeCode + "',");
                sbQuery.Append("" + item.Inch_36 + "," + item.Inch_38 + "," + item.Inch_40 + "," + item.Inch_42 + "," + item.Inch_44 + "," + item.Inch_46 + "," + item.Inch_48 + "," + item.Inch_50 + "," + item.Rate + ")");
                Common.ExecuteNonQuery(sbQuery.ToString());
                sbQuery.Clear();
                sbQuery.Append("Delete from ShadeMaster where ShadeCode='" + item.ShadeCode + "' And ClientId=" + taxInvoice.ClientId);
                sbQuery.Append("Insert into ShadeMaster(ShadeCode,ItemName,ClientId,Rate) Values ");
                sbQuery.Append("('" + item.ShadeCode + "','" + item.ItemName + "'," + taxInvoice.ClientId + "," + item.Rate + ")");
                Common.ExecuteNonQuery(sbQuery.ToString());

            }

        }
        public static void ComputeAmount(ref TaxInvoice invoiceObject)
        {
            invoiceObject.TotalAmount = invoiceObject.Shades.Sum(x => x.Amount);
            invoiceObject.DiscountedAmount = Math.Round((invoiceObject.Discount * invoiceObject.TotalAmount) / 100, 2);
            invoiceObject.CGSTAmount = Math.Round((invoiceObject.CGST * (invoiceObject.TotalAmount - invoiceObject.DiscountedAmount)) / 100, 2);
            invoiceObject.SGSTAmount = Math.Round((invoiceObject.SGST * (invoiceObject.TotalAmount - invoiceObject.DiscountedAmount)) / 100, 2);
            invoiceObject.IGSTAmount = Math.Round((invoiceObject.IGST * (invoiceObject.TotalAmount - invoiceObject.DiscountedAmount)) / 100, 2);
            invoiceObject.GrandTotal = Math.Round((invoiceObject.TotalAmount - invoiceObject.DiscountedAmount) + invoiceObject.Freight + invoiceObject.CGSTAmount + invoiceObject.SGSTAmount + invoiceObject.IGSTAmount, 2);
            invoiceObject.GrandTotalInWords = VMInvoice.NumberToWords((int)invoiceObject.GrandTotal);
        }
        public string CreateInvoiceNumber()
        {
            DateTime currentDate = DateTime.Now;
            DateTime startDate, endDate;
            if (currentDate.Month >= 4)
            {
                startDate = new DateTime(currentDate.Year, 4, 1);
                endDate = new DateTime(currentDate.Year + 1, 3, 31);
            }
            else
            {
                startDate = new DateTime(currentDate.Year - 1, 4, 1);
                endDate = new DateTime(currentDate.Year, 3, 31);
            }
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("Select count(invoiceid) from InvoiceMaster where InvoiceDate Between '" + startDate.ToString("dd-MMM-yyyy") + "' And '" + endDate.ToString("dd-MMM-yyyy") + "'");
            int counter = (int)Common.ExecuteScalar(sbQuery.ToString());
            return "SE/" + startDate.Year + "-" + endDate.Year + "/" + (Common.GeneralSetting.StartInvoiceNumber+counter + 1).ToString();

        }
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 10000000) > 0)
            {
                words += NumberToWords(number / 10000000) + " crore ";
                number %= 10000000;
            }
            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 100000) + " lakh ";
                number %= 100000;
            }
            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

    }
}
