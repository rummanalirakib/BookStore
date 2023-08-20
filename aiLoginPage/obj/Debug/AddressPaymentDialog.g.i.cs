﻿#pragma checksum "..\..\AddressPaymentDialog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9FD65B26EE5EE6B7BDDB527CB020708DA142CBDBB0A0EC66AB12D6C329CDD569"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BookStoreGUI;
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


namespace BookStoreGUI {
    
    
    /// <summary>
    /// AddressPaymentDialog
    /// </summary>
    public partial class AddressPaymentDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\AddressPaymentDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserName;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AddressPaymentDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ExpirationBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AddressPaymentDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CVVBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AddressPaymentDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CardNumBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\AddressPaymentDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label City;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\AddressPaymentDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label State;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\AddressPaymentDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Address;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AddressPaymentDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserName2;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AddressPaymentDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddressBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AddressPaymentDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StateBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AddressPaymentDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CityBox;
        
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
            System.Uri resourceLocater = new System.Uri("/BookStoreGUI;component/addresspaymentdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddressPaymentDialog.xaml"
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
            this.UserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ExpirationBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.CVVBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CardNumBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 20 "..\..\AddressPaymentDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddPayButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 21 "..\..\AddressPaymentDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemovePayButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.City = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.State = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.Address = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.UserName2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.AddressBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.StateBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.CityBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\AddressPaymentDialog.xaml"
            this.CityBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.CityBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 31 "..\..\AddressPaymentDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddAddressButton_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 32 "..\..\AddressPaymentDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveAddressButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

