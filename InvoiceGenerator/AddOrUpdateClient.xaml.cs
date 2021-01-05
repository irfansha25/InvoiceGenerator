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
using ViewModelInvoice;

namespace InvoiceGenerator
{
    /// <summary>
    /// Interaction logic for AddOrUpdateClient.xaml
    /// </summary>
    public partial class AddOrUpdateClient : Window
    {
        Client clientInstance = new Client();
        VMClient vmClient = new VMClient();
        public AddOrUpdateClient(Client client)
        {
            InitializeComponent();
            clientInstance = client;
            ClearValidationRuleForClientName();
            this.DataContext = clientInstance;
        }

        public AddOrUpdateClient()
        {
            InitializeComponent();
            this.DataContext = clientInstance;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vmClient.AddOrUpdateClientDetails(clientInstance);
                MessageBox.Show("Saved successfully",Common.CompanyName);
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.CompanyName, MessageBoxButton.OK, MessageBoxImage.Error);
                this.DialogResult = false;
            }

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        private void ClearValidationRuleForClientName()
        {
            txtClientName.IsEnabled = false;
            Binding binding = BindingOperations.GetBinding(txtClientName, TextBox.TextProperty);
            binding.ValidationRules.Clear();
        }
    }
}
