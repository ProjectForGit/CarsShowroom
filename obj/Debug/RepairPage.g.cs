﻿#pragma checksum "..\..\RepairPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A2B92A04061BDF8EA0A4018CEE8F26D2DFADBDDB3D8CFC9C5AA0A30D2BBF6D74"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CarsShowroom;
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


namespace CarsShowroom {
    
    
    /// <summary>
    /// RepairPage
    /// </summary>
    public partial class RepairPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 13 "..\..\RepairPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox accessoryBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\RepairPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox costTxt;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\RepairPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker receiptDate;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\RepairPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker issueDate;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\RepairPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox problemTxt;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\RepairPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\RepairPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox idAccessoryCheck;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\RepairPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox costCheck;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\RepairPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox receiptDateCheck;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\RepairPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox issueDateCheck;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\RepairPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox problemCheck;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\RepairPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/CarsShowroom;component/repairpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RepairPage.xaml"
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
            
            #line 9 "..\..\RepairPage.xaml"
            ((CarsShowroom.RepairPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.accessoryBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.costTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.receiptDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.issueDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.problemTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\RepairPage.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.idAccessoryCheck = ((System.Windows.Controls.CheckBox)(target));
            
            #line 19 "..\..\RepairPage.xaml"
            this.idAccessoryCheck.Click += new System.Windows.RoutedEventHandler(this.idAccessoryCheck_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.costCheck = ((System.Windows.Controls.CheckBox)(target));
            
            #line 20 "..\..\RepairPage.xaml"
            this.costCheck.Click += new System.Windows.RoutedEventHandler(this.costCheck_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.receiptDateCheck = ((System.Windows.Controls.CheckBox)(target));
            
            #line 21 "..\..\RepairPage.xaml"
            this.receiptDateCheck.Click += new System.Windows.RoutedEventHandler(this.receiptDateCheck_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.issueDateCheck = ((System.Windows.Controls.CheckBox)(target));
            
            #line 22 "..\..\RepairPage.xaml"
            this.issueDateCheck.Click += new System.Windows.RoutedEventHandler(this.issueDateCheck_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.problemCheck = ((System.Windows.Controls.CheckBox)(target));
            
            #line 23 "..\..\RepairPage.xaml"
            this.problemCheck.Click += new System.Windows.RoutedEventHandler(this.problemCheck_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
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
            case 14:
            
            #line 29 "..\..\RepairPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

