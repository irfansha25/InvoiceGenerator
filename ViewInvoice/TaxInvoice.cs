using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ViewInvoice
{
    public class TaxInvoice : INotifyPropertyChanged
    {
        private string invoiceNo;
        private DateTime invoiceDate;
        public ObservableCollection<ShadeItem> Shades { get; set; } = new ObservableCollection<ShadeItem>();
        public ObservableCollection<Shade> ClientShades { get; set; } = new ObservableCollection<Shade>();
        public event PropertyChangedEventHandler PropertyChanged;

        private string clientName;
        private string managerName;
        private string address;
        private string gstNo;
        private double discount;
        private double cGST;
        private double sGST;
        private double iGST;
        private bool isValid = true;
        private int clientId;
        public int InvoiceId { get; set; }
        public int ClientId { get => clientId; set { clientId = value; OnPropertyChanged("ClientId"); } }
        public bool IsValid { get => isValid; set { isValid = value; OnPropertyChanged("IsValid"); } }
        public string ManagerName { get => managerName; set { managerName = value; OnPropertyChanged("ManagerName"); } }

        public string Address { get => address; set { address = value; OnPropertyChanged("Address"); } }

        public string GstNo { get => gstNo; set { gstNo = value; OnPropertyChanged("GstNo"); } }

        public double Discount { get => discount; set { discount = value; OnPropertyChanged("Discount"); } }

        public double CGST { get => cGST; set { cGST = value; OnPropertyChanged("CGST"); } }

        public double SGST { get => sGST; set { sGST = value; OnPropertyChanged("SGST"); } }

        public double IGST { get => iGST; set { iGST = value; OnPropertyChanged("IGST"); } }

        public string InvoiceNo { get => invoiceNo; set { invoiceNo = value; OnPropertyChanged("InvoiceNo"); } }
        public DateTime InvoiceDate { get => invoiceDate; set { invoiceDate = value; OnPropertyChanged("InvoiceDate"); } }

        public string ClientName { get => clientName; set { clientName = value; OnPropertyChanged("ClientName"); } }

        private double totalAmount;
        public double TotalAmount { get => totalAmount; set { totalAmount = value; OnPropertyChanged("TotalAmount"); } }

        private double discountedAmount;
        public double DiscountedAmount { get => discountedAmount; set { discountedAmount = value; OnPropertyChanged("DiscountedAmount"); } }

        private double cgstAmount;
        public double CGSTAmount { get => cgstAmount; set { cgstAmount = value; OnPropertyChanged("CGSTAmount"); } }

        private double sgstAmount;
        public double SGSTAmount { get => sgstAmount; set { sgstAmount = value; OnPropertyChanged("SGSTAmount"); } }

        private double igstAmount;
        public double IGSTAmount { get => igstAmount; set { igstAmount = value; OnPropertyChanged("IGSTAmount"); } }

        private double grandTotal;
        public double GrandTotal { get => grandTotal; set { grandTotal = value; OnPropertyChanged("GrandTotal"); } }

        private double freight;
        public double Freight { get => freight; set { freight = value; OnPropertyChanged("Freight"); } }

        private string grandTotalInWords;
        public string GrandTotalInWords { get => grandTotalInWords; set { grandTotalInWords = value; OnPropertyChanged("GrandTotalInWords"); } }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
