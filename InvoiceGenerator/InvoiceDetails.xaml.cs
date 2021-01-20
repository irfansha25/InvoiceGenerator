using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
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
    /// Interaction logic for InvoiceDetails.xaml
    /// </summary>
    public partial class InvoiceDetails : Window
    {
        InvoiceFilter filterInvoice = new InvoiceFilter();
        VMClient vmClient = new VMClient();
        VMFilterInvoice vmFilterInvoice = new VMFilterInvoice();
        public InvoiceDetails()
        {
            InitializeComponent();
            cmbClientNames.ItemsSource = vmClient.GetAllClients();
            cmbClientNames.SelectedIndex = 0;
            DateTime currentDate = DateTime.Now;
            if (currentDate.Month >= 4)
            {
                dtpFromDate.SelectedDate = new DateTime(currentDate.Year, 4, 1);
                dtpToDate.SelectedDate = new DateTime(currentDate.Year + 1, 3, 31);
            }
            else
            {
                dtpFromDate.SelectedDate = new DateTime(currentDate.Year - 1, 4, 1);
                dtpToDate.SelectedDate = new DateTime(currentDate.Year, 3, 31);
            }
            this.DataContext = filterInvoice;
        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            filterInvoice.TaxInvoices.Clear();
            if (chkIsClientFilter.IsChecked == true && chkIsDateFilter.IsChecked == true)
                vmFilterInvoice.GetFilterInvoice((int)cmbClientNames.SelectedValue, dtpFromDate.SelectedDate.Value, dtpToDate.SelectedDate.Value).ForEach(x => filterInvoice.TaxInvoices.Add(x));
            else if (chkIsClientFilter.IsChecked == true)
                vmFilterInvoice.GetFilterInvoice((int)cmbClientNames.SelectedValue).ForEach(x => filterInvoice.TaxInvoices.Add(x));
            else if (chkIsDateFilter.IsChecked == true)
                vmFilterInvoice.GetFilterInvoice(dtpFromDate.SelectedDate.Value, dtpToDate.SelectedDate.Value).ForEach(x => filterInvoice.TaxInvoices.Add(x));
            filterInvoice.FilterCGSTAmount = filterInvoice.TaxInvoices.Sum(x => x.CGSTAmount);
            filterInvoice.FilterSGSTAmount = filterInvoice.TaxInvoices.Sum(x => x.SGSTAmount);
            filterInvoice.FilterIGSTAmount = filterInvoice.TaxInvoices.Sum(x => x.IGSTAmount);
            filterInvoice.FilterGrandTotal = filterInvoice.TaxInvoices.Sum(x => x.GrandTotal);
        }

        private void BtnInvoiceNumber_Click(object sender, RoutedEventArgs e)
        {
            TaxInvoice invoiceToPrint = ((Button)sender).Tag as TaxInvoice;
            CreateInvoice invoice = new CreateInvoice(invoiceToPrint);
            invoice.ShowDialog();
        }

        private void BtnExportCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                List<string> columnNames = new List<string>() { "Invoice Number", "Client Name", "Invoice Date", "CGST Amount", "SGST Amount", "IGST Amount", "Grand Total" };
                sb.AppendLine(string.Join(",", columnNames));

                foreach (var tax in filterInvoice.TaxInvoices)
                {
                    List<string> fields = new List<string>() {tax.InvoiceNo, tax.ClientName, tax.InvoiceDate.ToString("dd-MMM-yyyy") , tax.CGSTAmount.ToString() ,
                   tax.SGSTAmount.ToString(), tax.IGSTAmount.ToString(),tax.GrandTotal.ToString()};
                    sb.AppendLine(string.Join(",", fields));
                }
                if (!Directory.Exists(Environment.CurrentDirectory.ToString() + "\\Invoices"))
                    Directory.CreateDirectory(Environment.CurrentDirectory.ToString() + "\\Invoices");
                File.WriteAllText(Environment.CurrentDirectory.ToString() + "\\Invoices\\InvoiceLog_" + DateTime.Now.ToString("dd_MMM_yyyy_HH_mm_ss") + ".csv", sb.ToString());
                MessageBox.Show("File is exported successfully", Common.CompanyName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.CompanyName, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
