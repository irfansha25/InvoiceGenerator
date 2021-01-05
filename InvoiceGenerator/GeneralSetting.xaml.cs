using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
    /// Interaction logic for GeneralSetting.xaml
    /// </summary>
    public partial class GeneralSetting : Window
    {
        public GeneralSetting()
        {
            InitializeComponent();
            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                availablePrinters.Add(printer.ToString());
            }
            setting = Common.GeneralSetting;
            this.DataContext = setting;
            cmbPrinters.ItemsSource = availablePrinters;
        }
        List<string> availablePrinters = new List<string>();
        VMSetting vmSetting = new VMSetting();
        Setting setting = new Setting();
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            vmSetting.SaveSetting(setting);
            //Common.GeneralSetting.PrinterName = setting.PrinterName;
            //Common.GeneralSetting.CGSTLessThan1000 = setting.CGSTLessThan1000;
            //Common.GeneralSetting.SGSTLessThan1000 = setting.SGSTLessThan1000;
            //Common.GeneralSetting.CGSTGreaterThan1000 = setting.CGSTGreaterThan1000;
            //Common.GeneralSetting.SGSTGreaterThan1000 = setting.SGSTGreaterThan1000;
            MessageBox.Show("Setting saved successfully", Common.CompanyName);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
