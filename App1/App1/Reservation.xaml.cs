// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Google.Protobuf.WellKnownTypes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Reservation : Page
    {
        public Reservation()
        {
            this.InitializeComponent();
            listTrajet.ItemsSource = GestionBD.getInstance().GetTrajets();
           



        }
        //private void btAchat_Click(object sender, RoutedEventArgs e)
        //{
        //    int valide = 0;
            
        //    reset();

        //    //if (listTrajet.SelectedItem is null)
        //    //{
        //    //    tbxErrResa.Visibility = Visibility.Visible;
        //    //}

        //    if (valide == 0 )
        //    {
        //        Trajet c = listTrajet.SelectedItem as Trajet;
        //        GestionResa.getInstance().Ajouter_Resa(GestionUsagers.getInstance().Id_usager , GestionUsagers.getInstance().Email, c);
        //        GestionBD.getInstance().Resa(c);
        //        GestionBD.getInstance().ResaP(c);
        //        GestionBD.getInstance().ResaG(c);
        //    }
        //}

        private void reset()
        {
            


        }

        private void listTrajet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listTrajet.SelectedItem != null)
            {
                int valide = 0;

                reset();

                //if (listTrajet.SelectedItem is null)
                //{
                //    tbxErrResa.Visibility = Visibility.Visible;
                //}

                if (valide == 0)
                {
                    Trajet c = listTrajet.SelectedItem as Trajet;
                    GestionResa.getInstance().Ajouter_Resa(GestionUsagers.getInstance().Id_usager, GestionUsagers.getInstance().Email, c);
                    GestionBD.getInstance().Resa(c);
                    GestionBD.getInstance().ResaP(c);
                    GestionBD.getInstance().ResaG(c);         
                }
            }
            
        }
    }
}
