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
using MySqlX.XDevAPI;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    
    public sealed partial class Admintr : Page
    {
        List<Trajet> Csv
            ;
        public Admintr()
        {
            this.InitializeComponent();
            listTrajetsFini.ItemsSource = GestionBD.getInstance().GetTrajetsFini();
            listTrajets.ItemsSource = GestionBD.getInstance().GetTrajets();
        }

        private void btRecherche_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;
            reset();
            if (tbxDatDebut.SelectedDate == null || tbxDatDebut.SelectedDate > tbxDatFin.SelectedDate)
            {
                tblErreurRe.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxDatFin.SelectedDate == null || tbxDatDebut.SelectedDate > tbxDatFin.SelectedDate)
            {
                tblErreurRe.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (valide == 0)
            {
                

                Affiche.ItemsSource = GestionBD.getInstance().rechercher_Trajet(tbxDatDebut.SelectedDate.Value.ToString("yyyy-MM-dd"), tbxDatFin.SelectedDate.Value.ToString("yyyy-MM-dd"));
                Csv = new List<Trajet>(GestionBD.getInstance().rechercher_Trajet(tbxDatDebut.SelectedDate.Value.ToString("yyyy-MM-dd"), tbxDatFin.SelectedDate.Value.ToString("yyyy-MM-dd")));
            }
        }
        private void reset()
        {
            tblErreurRe.Visibility = Visibility.Collapsed;


        }

        private async void btExpo_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker();

            /******************** POUR WINUI3 ***************************/
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
            /************************************************************/

            picker.SuggestedFileName = "test2";
            picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".csv" });

            //crée le fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();
            // La fonction ToString de la classe Client retourne: nom + ";" + prenom

            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, Csv.ConvertAll(x => x.ToString()), Windows.Storage.Streams.UnicodeEncoding.Utf8);
        }




    }
}

