﻿#pragma checksum "..\..\..\NouveauJoueur.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "069C18C9AD43DC6324DE6E6A244D2229"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.1
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace JeuDuMoulin {
    
    
    /// <summary>
    /// NouveauJoueur
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class NouveauJoueur : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\NouveauJoueur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginNouv;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\NouveauJoueur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox mdpNouv;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\NouveauJoueur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox confMdpNouv;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\NouveauJoueur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bCreerNouv;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\NouveauJoueur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bRetourNouv;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/JeuDeNim;component/nouveaujoueur.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\NouveauJoueur.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.loginNouv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.mdpNouv = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.confMdpNouv = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.bCreerNouv = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\NouveauJoueur.xaml"
            this.bCreerNouv.Click += new System.Windows.RoutedEventHandler(this.bCreerNouv_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.bRetourNouv = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\NouveauJoueur.xaml"
            this.bRetourNouv.Click += new System.Windows.RoutedEventHandler(this.bRetourNouv_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

