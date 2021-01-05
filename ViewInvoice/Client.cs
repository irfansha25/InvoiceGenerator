using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
namespace ViewInvoice
{
    public class Client : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string clientName;
        private string managerName;
        private string address;
        private string contactNumber;
        private string emailId;
        private string gstNo;
        private double discount;
        //private double cGST;
        //private double sGST;
        private double iGST;

        public int ClientId { get; set; }

        public string ClientName { get => clientName; set { clientName = value; OnPropertyChanged("ClientName"); } }

        public string ManagerName { get => managerName; set { managerName = value; OnPropertyChanged("ManagerName"); } }

        public string Address { get => address; set { address = value; OnPropertyChanged("Address"); } }

        public string ContactNumber { get => contactNumber; set { contactNumber = value; OnPropertyChanged("ContactNumber"); } }

        public string EmailId { get => emailId; set { emailId = value; OnPropertyChanged("EmailId"); } }

        public string GstNo { get => gstNo; set { gstNo = value; OnPropertyChanged("GstNo"); } }

        public double Discount { get => discount; set { discount = value; OnPropertyChanged("Discount"); } }

        //public double CGST { get => cGST; set { cGST = value; OnPropertyChanged("CGST"); } }

        //public double SGST { get => sGST; set { sGST = value; OnPropertyChanged("SGST"); } }

        public double IGST { get => iGST; set { iGST = value; OnPropertyChanged("IGST"); } }



        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
