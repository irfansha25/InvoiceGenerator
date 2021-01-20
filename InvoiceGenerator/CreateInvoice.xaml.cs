using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewInvoice;
using ViewModelInvoice;

namespace InvoiceGenerator
{
    /// <summary>
    /// Interaction logic for CreateInvoice.xaml
    /// </summary>
    public partial class CreateInvoice : Window
    {
        public CreateInvoice()
        {
            InitializeComponent();
            LoadClientAndContext();
            cmbClientName.SelectedIndex = -1;
        }
        public CreateInvoice(TaxInvoice taxInvoice)
        {
            InitializeComponent();
            invoiceObject = taxInvoice;
            LoadClientAndContext();
        }
        VMClient vmClient = new VMClient();
        TaxInvoice invoiceObject = new TaxInvoice();
        VMInvoice vmInvoice = new VMInvoice();
        public void LoadClientAndContext()
        {
            cmbClientName.ItemsSource = vmClient.GetAllClients();
            this.DataContext = invoiceObject;
        }

        private void CmbClientName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (invoiceObject.InvoiceId == 0)
                LoadInvoiceDetails(cmbClientName.SelectedItem as Client);
        }
        private void LoadInvoiceDetails(Client client)
        {

            if (client == null) return;
            invoiceObject.ClientShades.Clear();
            vmClient.GetShades(client.ClientId).ForEach(x => invoiceObject.ClientShades.Add(x));
            invoiceObject.ClientId = client.ClientId;
            invoiceObject.ClientName = client.ClientName;
            invoiceObject.Address = client.Address;
            invoiceObject.GstNo = client.GstNo;
            invoiceObject.InvoiceDate = DateTime.Now;
            invoiceObject.Discount = client.Discount;
            //invoiceObject.CGST = client.CGST;
            //invoiceObject.SGST = client.SGST;
            invoiceObject.IGST = client.IGST;
            invoiceObject.Shades.Clear();
            for (int i = 0; i < 20; i++)
            {
                invoiceObject.Shades.Add(new ShadeItem(i + 1));
            }
            //lvClients.ItemsSource = invoiceObject.Shades;
        }

        private void CmbClientShades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            Int32 itemIndex = lvClients.Items.IndexOf(comboBox.DataContext);
            if (comboBox.SelectedValue != null)
                invoiceObject.Shades[itemIndex].Rate = (double)comboBox.SelectedValue;
            else
                invoiceObject.Shades[itemIndex].Rate = 0;
        }

        private void LvClients_LostFocus(object sender, RoutedEventArgs e)
        {
            invoiceObject.IsValid = true;
            if (invoiceObject.Shades.Any(x => !string.IsNullOrEmpty(x.ShadeCode)))
                VMInvoice.ComputeAmount(ref invoiceObject);
            else
                invoiceObject.IsValid = false;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (invoiceObject.InvoiceId == 0)
                invoiceObject.InvoiceNo = vmInvoice.CreateInvoiceNumber();
            vmInvoice.SaveInvoice(invoiceObject);
            MessageBox.Show("Invoice " + invoiceObject.InvoiceNo + " saved successfully", Common.CompanyName);
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Common.GeneralSetting.PrinterName))
            {
                MessageBox.Show("Kindly configure printer in setting", Common.CompanyName);
                return;
            }
            if (Common.GeneralSetting.IsPrintToBill)
            {
                PrintDocument pd = new PrintDocument();//3508 x 2480
                pd.PrinterSettings.PrinterName = Common.GeneralSetting.PrinterName;
                pd.PrintPage += Pd_PrintPage;
                pd.Print();
            }
            else
            {
                PrintDialog printDlg = new PrintDialog();
                Nullable<Boolean> print = printDlg.ShowDialog();
                if (print == true)
                {
                    PrintBill objPrintbill = new PrintBill(invoiceObject);
                    objPrintbill.Show();
                    printDlg.PrintVisual(objPrintbill, "Window Printing");
                    objPrintbill.Close();
                }
            }
            MessageBox.Show("Printed successfully", Common.CompanyName);
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Get the Graphics object  
            Graphics g = e.Graphics;

            //Create a font Arial with size 16  
            Font font = new Font("Verdana", 10);

            //Create a solid brush with black color  
            SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);
            //g.MeasureString()
            //Draw "Hello Printer!";  
            float diff = Common.Coordinates["AddressDiff"].Y;
            g.DrawString(invoiceObject.ClientName, font, brush, Common.Coordinates["ClientName"]);
            List<string> addressList = WrapText(invoiceObject.Address, 370, "Verdana", 10);
            if (addressList.Count > 1)
            {
                g.DrawString(addressList[0], font, brush, Common.Coordinates["Address"]);
                g.DrawString(addressList[1], font, brush, new System.Drawing.PointF(Common.Coordinates["Address"].X, Common.Coordinates["Address"].Y + diff));
            }
            else
                g.DrawString(invoiceObject.Address, font, brush, Common.Coordinates["Address"]);
            g.DrawString(invoiceObject.GstNo, font, brush, Common.Coordinates["GstNo"]);
            g.DrawString(invoiceObject.InvoiceNo, font, brush, Common.Coordinates["InvoiceNo"]);
            g.DrawString(invoiceObject.InvoiceDate.ToString("dd-MMM-yyyy"), font, brush, Common.Coordinates["InvoiceDate"]);
            g.DrawString(invoiceObject.TotalAmount.ToString(), font, brush, Common.Coordinates["TotalAmount"]);
            g.DrawString(invoiceObject.DiscountedAmount.ToString(), font, brush, Common.Coordinates["DiscountedAmount"]);
            g.DrawString(invoiceObject.Freight.ToString(), font, brush, Common.Coordinates["Freight"]);
            g.DrawString(invoiceObject.CGSTAmount.ToString(), font, brush, Common.Coordinates["CGSTAmount"]);
            g.DrawString(invoiceObject.SGSTAmount.ToString(), font, brush, Common.Coordinates["SGSTAmount"]);
            g.DrawString(invoiceObject.IGSTAmount.ToString(), font, brush, Common.Coordinates["IGSTAmount"]);
            g.DrawString(invoiceObject.GrandTotal.ToString(), font, brush, Common.Coordinates["GrandTotal"]);
            g.DrawString(invoiceObject.GrandTotalInWords + " only", new Font("Verdana", 8), brush, Common.Coordinates["GrandTotalInWords"]);
            g.DrawString(invoiceObject.Discount.ToString(), font, brush, Common.Coordinates["Discount"]);
            g.DrawString(invoiceObject.CGST.ToString(), font, brush, Common.Coordinates["CGST"]);
            g.DrawString(invoiceObject.SGST.ToString(), font, brush, Common.Coordinates["SGST"]);
            g.DrawString(invoiceObject.IGST.ToString(), font, brush, Common.Coordinates["IGST"]);
            int count = 0;
            diff = Common.Coordinates["ShadesDiff"].Y;
            foreach (var shade in invoiceObject.Shades.Where(x => !string.IsNullOrEmpty(x.ShadeCode)))
            {
                g.DrawString(shade.ItemName, font, brush, new System.Drawing.PointF(Common.Coordinates["ItemName"].X, Common.Coordinates["ItemName"].Y + diff * count));
                g.DrawString(shade.HSINCode, font, brush, new System.Drawing.PointF(Common.Coordinates["HSINCode"].X, Common.Coordinates["HSINCode"].Y + diff * count));
                g.DrawString(shade.ShadeCode, font, brush, new System.Drawing.PointF(Common.Coordinates["ShadeCode"].X, Common.Coordinates["ShadeCode"].Y + diff * count));
                g.DrawString(shade.Inch_36.ToString(), font, brush, new System.Drawing.PointF(Common.Coordinates["Inch_36"].X, Common.Coordinates["Inch_36"].Y + diff * count));
                g.DrawString(shade.Inch_38.ToString(), font, brush, new System.Drawing.PointF(Common.Coordinates["Inch_38"].X, Common.Coordinates["Inch_38"].Y + diff * count));
                g.DrawString(shade.Inch_40.ToString(), font, brush, new System.Drawing.PointF(Common.Coordinates["Inch_40"].X, Common.Coordinates["Inch_40"].Y + diff * count));
                g.DrawString(shade.Inch_42.ToString(), font, brush, new System.Drawing.PointF(Common.Coordinates["Inch_42"].X, Common.Coordinates["Inch_42"].Y + diff * count));
                g.DrawString(shade.Inch_44.ToString(), font, brush, new System.Drawing.PointF(Common.Coordinates["Inch_44"].X, Common.Coordinates["Inch_44"].Y + diff * count));
                g.DrawString(shade.Inch_46.ToString(), font, brush, new System.Drawing.PointF(Common.Coordinates["Inch_46"].X, Common.Coordinates["Inch_46"].Y + diff * count));
                g.DrawString(shade.Inch_48.ToString(), font, brush, new System.Drawing.PointF(Common.Coordinates["Inch_48"].X, Common.Coordinates["Inch_48"].Y + diff * count));
                g.DrawString(shade.Inch_50.ToString(), font, brush, new System.Drawing.PointF(Common.Coordinates["Inch_50"].X, Common.Coordinates["Inch_50"].Y + diff * count));
                g.DrawString(shade.Quantity.ToString(), font, brush, new System.Drawing.PointF(Common.Coordinates["Quantity"].X, Common.Coordinates["Quantity"].Y + diff * count));
                g.DrawString(shade.Rate.ToString(), font, brush, new System.Drawing.PointF(Common.Coordinates["Rate"].X, Common.Coordinates["Rate"].Y + diff * count));
                g.DrawString(shade.Amount.ToString(), font, brush, new System.Drawing.PointF(Common.Coordinates["Amount"].X, Common.Coordinates["Amount"].Y + diff * count));
                count++;
            }
        }
        static List<string> WrapText(string text, double pixels, string fontFamily, float emSize)
        {
            string[] originalLines = text.Split(new string[] { " " },
                StringSplitOptions.None);

            List<string> wrappedLines = new List<string>();

            StringBuilder actualLine = new StringBuilder();
            double actualWidth = 0;

            foreach (var item in originalLines)
            {
                FormattedText formatted = new FormattedText(item,
                    CultureInfo.CurrentCulture,
                    System.Windows.FlowDirection.LeftToRight,
                    new Typeface(fontFamily), emSize, System.Windows.Media.Brushes.Black);

                actualLine.Append(item + " ");
                actualWidth += formatted.Width;

                if (actualWidth > pixels)
                {
                    wrappedLines.Add(actualLine.ToString());
                    actualLine.Clear();
                    actualWidth = 0;
                }
            }

            if (actualLine.Length > 0)
                wrappedLines.Add(actualLine.ToString());

            return wrappedLines;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel", Common.CompanyName, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void TxtFreight_LostFocus(object sender, RoutedEventArgs e)
        {
            invoiceObject.GrandTotal = Math.Round((invoiceObject.TotalAmount - invoiceObject.DiscountedAmount) + invoiceObject.Freight + invoiceObject.CGSTAmount + invoiceObject.SGSTAmount + invoiceObject.IGSTAmount, 2);
            invoiceObject.GrandTotalInWords = VMInvoice.NumberToWords((int)invoiceObject.GrandTotal);
        }

        private void TxtRate_TextChanged(object sender, TextChangedEventArgs e)
        {
            invoiceObject.IsValid = true;
            lvClients.ToolTip = string.Empty;
            if (invoiceObject.Shades.Where(x => x.Rate>0).Count() > 0)
            {
                if (invoiceObject.Shades.Where(x => x.Rate > 0).All(x => x.Rate < 1000))
                {
                    invoiceObject.CGST = Common.GeneralSetting.CGSTLessThan1000;
                    invoiceObject.SGST = Common.GeneralSetting.SGSTLessThan1000;
                }
                else if (invoiceObject.Shades.Where(x => x.Rate > 0).All(x => x.Rate >= 1000))
                {
                    invoiceObject.CGST = Common.GeneralSetting.CGSTGreaterThan1000;
                    invoiceObject.SGST = Common.GeneralSetting.SGSTGreaterThan1000;
                }
                else
                {
                    invoiceObject.IsValid = false;
                    lvClients.ToolTip = "GST is not valid for shades. Kindly generate seperate bill";
                }
            }
        }
    }
}
