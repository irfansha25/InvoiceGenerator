using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ViewInvoice
{
    public class ShadeItem : INotifyPropertyChanged
    {
        public ShadeItem(int srno)
        {
            this.SrNo = srno;
        }
        private string itemName;
        private string shadeCode;
        private string hsinCode;
        private int inch_36;
        private int inch_38;
        private int inch_40;
        private int inch_42;
        private int inch_44;
        private int inch_46;
        private int inch_48;
        private int inch_50;
        private double rate;
        private int srno;
        public string ItemName { get => itemName; set { itemName = value; OnPropertyChanged("ItemName"); } }
        public string ShadeCode { get => shadeCode; set { shadeCode = value; OnPropertyChanged("ShadeCode"); } }
        public string HSINCode { get => hsinCode; set { hsinCode = value; OnPropertyChanged("HSINCode"); } }
        public int Inch_36 { get => inch_36; set { inch_36 = value; OnPropertyChanged("Inch_36"); OnPropertyChanged("Quantity"); } }
        public int Inch_38 { get => inch_38; set { inch_38 = value; OnPropertyChanged("Inch_38"); OnPropertyChanged("Quantity"); } }
        public int Inch_40 { get => inch_40; set { inch_40 = value; OnPropertyChanged("Inch_40"); OnPropertyChanged("Quantity"); } }
        public int Inch_42 { get => inch_42; set { inch_42 = value; OnPropertyChanged("Inch_42"); OnPropertyChanged("Quantity"); } }
        public int Inch_44 { get => inch_44; set { inch_44 = value; OnPropertyChanged("Inch_44"); OnPropertyChanged("Quantity"); } }
        public int Inch_46 { get => inch_46; set { inch_46 = value; OnPropertyChanged("Inch_46"); OnPropertyChanged("Quantity"); } }
        public int Inch_48 { get => inch_48; set { inch_48 = value; OnPropertyChanged("Inch_48"); OnPropertyChanged("Quantity"); } }
        public int Inch_50 { get => inch_50; set { inch_50 = value; OnPropertyChanged("Inch_50"); OnPropertyChanged("Quantity"); } }
        public double Rate { get => rate; set { rate = value; OnPropertyChanged("Rate"); } }
        public int SrNo { get => srno; set { srno = value; OnPropertyChanged("SrNo"); } }
        public int Quantity { get => inch_36 + inch_38 + inch_40 + inch_42 + inch_44 + inch_46 + inch_48 + inch_50; }
        public double Amount { get => Quantity * Rate; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
