﻿#pragma checksum "..\..\InvoiceDetails.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EB7202BAF1FC31853429AE09A166E06ED2E69C2D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using InvoiceGenerator;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using ViewModelInvoice;


namespace InvoiceGenerator {
    
    
    /// <summary>
    /// InvoiceDetails
    /// </summary>
    public partial class InvoiceDetails : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 30 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkIsClientFilter;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbClientNames;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkIsDateFilter;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpFromDate;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpToDate;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFilter;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvInvoiceDetails;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbCGSTAmount;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbSGSTAmount;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbIGSTAmount;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbGrandTotal;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExportCSV;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\InvoiceDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/InvoiceGenerator;component/invoicedetails.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\InvoiceDetails.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.chkIsClientFilter = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 2:
            this.cmbClientNames = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.chkIsDateFilter = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.dtpFromDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.dtpToDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.btnFilter = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\InvoiceDetails.xaml"
            this.btnFilter.Click += new System.Windows.RoutedEventHandler(this.BtnFilter_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lvInvoiceDetails = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            this.tbCGSTAmount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.tbSGSTAmount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.tbIGSTAmount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.tbGrandTotal = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.btnExportCSV = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\InvoiceDetails.xaml"
            this.btnExportCSV.Click += new System.Windows.RoutedEventHandler(this.BtnExportCSV_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\InvoiceDetails.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 8:
            
            #line 73 "..\..\InvoiceDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnInvoiceNumber_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

