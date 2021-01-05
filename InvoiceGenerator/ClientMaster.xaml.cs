using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ClientMaster.xaml
    /// </summary>
    public partial class ClientMaster : Window
    {
        VMClient vmClient = new VMClient();
        ObservableCollection<Client> clientList = new ObservableCollection<Client>();
        public ClientMaster()
        {
            InitializeComponent();
            clientList = new ObservableCollection<Client>(vmClient.GetAllClients());
            lvClients.ItemsSource = clientList;
        }

        private void BtnNewClient_Click(object sender, RoutedEventArgs e)
        {
            AddOrUpdateClient updateClient = new AddOrUpdateClient();
            if (CheckIsOkClick(updateClient))
                UpdateSourceCollection();
        }

        private static bool CheckIsOkClick(AddOrUpdateClient updateClient)
        {
            return updateClient.ShowDialog() == true;
        }

        private void BtnClientName_Click(object sender, RoutedEventArgs e)
        {
            Client clientToUpdate = ((Button)sender).Tag as Client;
            AddOrUpdateClient updateClient = new AddOrUpdateClient(clientToUpdate);
            if (updateClient.ShowDialog() == true)
                UpdateSourceCollection();
        }

        private void UpdateSourceCollection()
        {
            clientList.Clear();
            vmClient.GetAllClients().ForEach(x => clientList.Add(x));
        }
    }
}
