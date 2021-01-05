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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        VMLogin vmUser = new VMLogin();
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string validateMessage = vmUser.ValidateCredentials(txtUserName.Text, txtPassword.Password);
            if (!string.IsNullOrEmpty(validateMessage))
                MessageBox.Show(validateMessage, Common.CompanyName, MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
               if( vmUser.CheckUserName(txtUserName.Text, txtPassword.Password))
                {
                    MDI main = new MDI();
                    main.Show();
                    this.Close();
                }
               else
                    MessageBox.Show("UserName or password does not exist", Common.CompanyName, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }
    }
}
