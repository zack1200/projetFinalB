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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjtTrajet : Page
    {
        public AjtTrajet()
        {
            this.InitializeComponent();
            listVille.ItemsSource = GestionUsagers.getInstance().GetVille();
            listVilleF.ItemsSource = GestionUsagers.getInstance().GetVille();
        }

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            string arret = "";

            int valide = 0;
            bool valide1 = true;

            reset();

            if (tbxDat.SelectedDate == null)
            {
                tbxDatDErr.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (listVille.SelectedIndex == -1)
            {
                tbxVilleDErr.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (br1.IsChecked == false && br2.IsChecked == false)
            {
                tbxArrErr.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxHrDep.SelectedTime == null)
            {
                tbxHrDepErr.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (br1.IsChecked == true)
            {
                arret = "Oui";
            }
            if (br2.IsChecked == true)
            {
                arret = "Aucun";
            }
            if (listVilleF.SelectedIndex == -1)
            {
                tbxVilleFErr.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxHrArr.SelectedTime == null)
            {
                tbxHrArrErr.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (TypeV.SelectedIndex == -1)
            {
                tbxTypeErr.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (NbrPlace.SelectedIndex == -1)
            {
                tbxNbPlceErr.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxEmail.Text.Trim() == "")
            {
                tblErreurEmail.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxId.Text.Trim() == "")
            {
                tblErreurId.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (Prix.SelectedIndex == -1)
            {
                tblErreurPrixl.Visibility = Visibility.Visible;
                valide += 1;
            }

            Ville vi = listVille.SelectedItem as Ville;
            Ville viF = listVilleF.SelectedItem as Ville;
            

            if (valide == 0 && valide1 == true)
            {
                Trajet t = new Trajet()
                {
                   
                 Date = tbxDat.SelectedDate.Value.ToString("yyyy-MM-dd"),
                 Heuredep =tbxHrDep.SelectedTime.ToString(),
                 NumVD = vi.IdV,
                 Villearret =arret,
                 Heurearr =tbxHrArr.Time.ToString(),
                 Villearr = viF.Nom,
                 Type = TypeV.SelectedItem.ToString() ,
                 Nbplace = NbrPlace.SelectedItem.ToString(),
                 Prix = Prix.SelectedItem.ToString() ,
                 Statut = "Disponible",
                 Usager = tbxId.Text,
                 Email = tbxEmail.Text,
                 
            };
                GestionBD.getInstance().AjouterTrajet(t);
            }

        }
        private void reset()
        {
            tbxDatDErr.Visibility = Visibility.Collapsed;
            tbxVilleDErr.Visibility = Visibility.Collapsed;
            tbxArrErr.Visibility = Visibility.Collapsed;
            tbxHrDepErr.Visibility = Visibility.Collapsed;
            tbxVilleFErr.Visibility = Visibility.Collapsed;
            tbxHrArrErr.Visibility = Visibility.Collapsed;
            tbxTypeErr.Visibility = Visibility.Collapsed;
            tbxNbPlceErr.Visibility = Visibility.Collapsed;
            tblErreurEmail.Visibility = Visibility.Collapsed;
            tblErreurId.Visibility = Visibility.Collapsed;
            tblErreurPrixl.Visibility = Visibility.Collapsed;


        }
    }
}
