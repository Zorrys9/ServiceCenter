﻿#pragma checksum "..\..\..\Master\MasterMainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "33CF63E1D0AF12514A241F2678CEAF7D99FAF46D3C684717CF8CE44E11A3474F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ServiceCenter.Master;
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


namespace ServiceCenter.Master {
    
    
    /// <summary>
    /// MasterMainWindow
    /// </summary>
    public partial class MasterMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Master\MasterMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitUser;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Master\MasterMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeviceList;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Master\MasterMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OrdersCurrentList;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Master\MasterMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OrdersList;
        
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
            System.Uri resourceLocater = new System.Uri("/ServiceCenter;component/master/mastermainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Master\MasterMainWindow.xaml"
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
            this.ExitUser = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\Master\MasterMainWindow.xaml"
            this.ExitUser.Click += new System.Windows.RoutedEventHandler(this.ExitUser_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DeviceList = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Master\MasterMainWindow.xaml"
            this.DeviceList.Click += new System.Windows.RoutedEventHandler(this.DeviceList_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OrdersCurrentList = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Master\MasterMainWindow.xaml"
            this.OrdersCurrentList.Click += new System.Windows.RoutedEventHandler(this.OrdersCurrentList_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.OrdersList = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Master\MasterMainWindow.xaml"
            this.OrdersList.Click += new System.Windows.RoutedEventHandler(this.OrdersList_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

