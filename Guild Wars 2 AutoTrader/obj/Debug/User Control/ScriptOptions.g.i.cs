﻿#pragma checksum "..\..\..\User Control\ScriptOptions.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "822314862D2C431BCF62BD4FE1A842A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Guild_Wars_2_AutoTrader.User_Control;
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


namespace Guild_Wars_2_AutoTrader.User_Control {
    
    
    /// <summary>
    /// ScriptOptions
    /// </summary>
    public partial class ScriptOptions : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\User Control\ScriptOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid OptionsGrid;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\User Control\ScriptOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Options;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\User Control\ScriptOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RemoveAllOrdersCb;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\User Control\ScriptOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox BuyAndSellCb;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\User Control\ScriptOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox BuyWeaponsCb;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\User Control\ScriptOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RemoveBuyOrdersCb;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\User Control\ScriptOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SellWeaponsCb;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\User Control\ScriptOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock IndexTb;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\User Control\ScriptOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GenerateScriptBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Guild Wars 2 AutoTrader;component/user%20control/scriptoptions.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\User Control\ScriptOptions.xaml"
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
            this.OptionsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Options = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.RemoveAllOrdersCb = ((System.Windows.Controls.CheckBox)(target));
            
            #line 56 "..\..\..\User Control\ScriptOptions.xaml"
            this.RemoveAllOrdersCb.Click += new System.Windows.RoutedEventHandler(this.RemoveAllOrdersCb_Changed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BuyAndSellCb = ((System.Windows.Controls.CheckBox)(target));
            
            #line 64 "..\..\..\User Control\ScriptOptions.xaml"
            this.BuyAndSellCb.Click += new System.Windows.RoutedEventHandler(this.BuyAndSellCb_Changed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BuyWeaponsCb = ((System.Windows.Controls.CheckBox)(target));
            
            #line 73 "..\..\..\User Control\ScriptOptions.xaml"
            this.BuyWeaponsCb.Click += new System.Windows.RoutedEventHandler(this.BuyWeaponsCb_Changed);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RemoveBuyOrdersCb = ((System.Windows.Controls.CheckBox)(target));
            
            #line 80 "..\..\..\User Control\ScriptOptions.xaml"
            this.RemoveBuyOrdersCb.Click += new System.Windows.RoutedEventHandler(this.RemoveBuyOrdersCb_Changed);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SellWeaponsCb = ((System.Windows.Controls.CheckBox)(target));
            
            #line 87 "..\..\..\User Control\ScriptOptions.xaml"
            this.SellWeaponsCb.Click += new System.Windows.RoutedEventHandler(this.SellWeaponsCb_Changed);
            
            #line default
            #line hidden
            return;
            case 8:
            this.IndexTb = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.GenerateScriptBtn = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\..\User Control\ScriptOptions.xaml"
            this.GenerateScriptBtn.Click += new System.Windows.RoutedEventHandler(this.GenerateScriptBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

