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
using Google.Protobuf.WellKnownTypes;
using System.Text.RegularExpressions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Connexion : Page
    {
        public Connexion()
        {
            this.InitializeComponent();
            listVille.ItemsSource = GestionUsagers.getInstance().GetVille();
        }
        private void btInsc_Click(object sender, RoutedEventArgs e)
        {
            string Statut = "";

            int valide = 0;
            bool valide1 = true;
            string expression = "^\\(\\d{3}\\)\\d{3}-\\d{4}$";

            reset();

            if (tbxNom.Text.Trim() == "")
            {
                tblErreurNom.Visibility = Visibility.Visible;
                valide += 1;
            }


            if (tbxPrenom.Text.Trim() == "")
            {
                tblErreurPrenom.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (tbxEmail.Text.Trim() == "")
            {
                tblErreurEmail.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxAdd.Text.Trim() == "")
            {
                tblErreurAdd.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (listVille.SelectedIndex == -1)
            {
                tblErreurVille.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxMdp.Text.Trim() == "")
            {
                tblErreurMdp.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (br1.IsChecked == true)
            {
                Statut = "Chauffeur";
            }
            if (br2.IsChecked == true)
            {
                Statut = "Passager";
            }
            if (tbxNum.Text.Trim() == "" || Regex.IsMatch(tbxNum.Text, expression) == false)
            {
                tblErreurNum.Visibility = Visibility.Visible;
                valide += 1;
            }
     

            Ville vi = listVille.SelectedItem as Ville;

            if (valide == 0 && valide1 == true)
            {
                Usager u = new Usager()
                {
                    Nom = tbxNom.Text,
                    Prenom = tbxPrenom.Text,
                    Email = tbxEmail.Text,
                    Add = tbxAdd.Text,
                    Ville = vi.IdV,
                    Mdp = tbxMdp.Text,
                    Statut = Statut,
                    Telephone = tbxNum.Text,
                };
                GestionUsagers.getInstance().AjouterUsager(u);
                tblSucces.Visibility = Visibility.Visible;
            }
        }
        private void reset()
        {
            tblErreurNom.Visibility = Visibility.Collapsed;
            tblErreurPrenom.Visibility = Visibility.Collapsed;
            tblErreurEmail.Visibility = Visibility.Collapsed;
            tblErreurAdd.Visibility = Visibility.Collapsed;
            tblErreurVille.Visibility = Visibility.Collapsed;
            tblErreurMdp.Visibility = Visibility.Collapsed;
            tblErreurNum.Visibility = Visibility.Collapsed;
            tblSucces.Visibility = Visibility.Collapsed;
        }
    }
}
