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
    
    public sealed partial class AjtVille : Page
    {
        public AjtVille()
        {
            this.InitializeComponent();
        }

        private void btAjt_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;
            bool valide1 = true;

            reset();

            if (tbxNom.Text.Trim() == "")
            {
                tblErreurNom.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (tbxPost.Text.Trim() == "")
            {
                tblErreurPost.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (valide == 0 && valide1 == true)
            {
                Ville vi = new Ville()
                {
                    
                    Nom = tbxNom.Text,
                    Codepostale=tbxPost.Text,

                };
                GestionVille.getInstance().AjouterVille(vi);
                tblEmp.Visibility = Visibility.Visible;
            }
        }
        private void reset()
        {
            tblErreurNom.Visibility = Visibility.Collapsed;
            tblErreurPost.Visibility = Visibility.Collapsed;           
        }
    }
    
}
