// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(Affichage));
        }
        private async void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "Conn":

                    //mainFrame.Navigate(typeof(ConnexionB));
                    ConnexionAff dialog = new ConnexionAff();
                    dialog.XamlRoot = stk.XamlRoot;
                    dialog.DefaultButton = ContentDialogButton.Primary;



                    await dialog.ShowAsync();



                    if (dialog.Ok == true)
                    {
                        if (GestionUsagers.getInstance().Statut.Equals("Passager"))
                        {
                            //connexion.Visibility = Visibility.Collapsed;
                            Aff.Visibility= Visibility.Visible;
                            


                        }
                        if (GestionUsagers.getInstance().Statut.Equals("Chauffeur"))
                        {
                            //connexion.Visibility = Visibility.Collapsed;
                            Aff.Visibility = Visibility.Visible;
                            AjtTrajet.Visibility = Visibility.Visible;

                        }
                        else
                        {

                        }
                    }


                    break;
                case "Aff":
                    mainFrame.Navigate(typeof(Affichage));
                    break;
                case "Res":
                    mainFrame.Navigate(typeof(Reservation));
                    break;
                case "AjtVille":
                    mainFrame.Navigate(typeof(AjtVille));
                    break;
                case "AjtTrajet":
                    mainFrame.Navigate(typeof(AjtTrajet));
                    break;
                case "Admintr":
                    mainFrame.Navigate(typeof(Admintr));
                    break;
                default:
                    break;
            }

        }


    }
}
