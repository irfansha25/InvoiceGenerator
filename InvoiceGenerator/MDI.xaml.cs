using System;
using System.Collections.Generic;
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

namespace InvoiceGenerator
{
    /// <summary>
    /// Interaction logic for MDI.xaml
    /// </summary>
    public partial class MDI : Window
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void MenuClientMaster_Click(object sender, RoutedEventArgs e)
        {
            ClientMaster cm = new ClientMaster();
            cm.Show();
        }

        private void MenuGenerateBill_Click(object sender, RoutedEventArgs e)
        {
            CreateInvoice createInvoice = new CreateInvoice();
            createInvoice.Show();
        }

        private void MenuInvoiceDetails_Click(object sender, RoutedEventArgs e)
        {
            InvoiceDetails invoiceDetails = new InvoiceDetails();
            invoiceDetails.Show();
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void MenuSetting_Click(object sender, RoutedEventArgs e)
        {
            GeneralSetting generalSetting = new GeneralSetting();
            generalSetting.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MenuExit_Click(null, null);
        }
    }
}
