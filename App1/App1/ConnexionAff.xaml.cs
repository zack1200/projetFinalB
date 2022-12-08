// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    public sealed partial class ConnexionAff : ContentDialog
    {
        bool ok = false;
        string nom;
        string statut;

        public bool Ok { get => ok; }
        public string Nom { get => nom;}
        public string Statut { get => statut;}

        public ConnexionAff()
        {
            this.InitializeComponent();
        }


        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
           
            if (GestionUsagers.getInstance().Connexion(tbxEmail.Text, tbxMdp.Text))
            {
                statut = GestionUsagers.getInstance().Statut;
                ok = true;
            }
            else
            {
                args.Cancel = true;
            }
                
        }
    }
}
