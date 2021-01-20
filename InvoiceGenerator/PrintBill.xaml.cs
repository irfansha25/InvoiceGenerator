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
using ViewInvoice;

namespace InvoiceGenerator
{
    /// <summary>
    /// Interaction logic for PrintBill.xaml
    /// </summary>
    public partial class PrintBill : Window
    {
        public PrintBill(TaxInvoice invoiceObject)
        {
            InitializeComponent();
            this.DataContext = invoiceObject;
        }
    }
}
