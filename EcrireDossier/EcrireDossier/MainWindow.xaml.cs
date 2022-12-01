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

namespace EcrireDossier
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                //////////////////////////////////////////////////////////////ecritre
                ////s�lectionne l'emplacement du fichier
                //Windows.Storage.StorageFolder monDossier =
                //Windows.Storage.ApplicationData.Current.LocalFolder;

                ////cr�e le fichier
                //Windows.Storage.StorageFile monFichier =
                //    await monDossier.CreateFileAsync("monFichier.txt",
                //        Windows.Storage.CreationCollisionOption.ReplaceExisting);

                ////�crit dans le fichier
                //await Windows.Storage.FileIO.WriteTextAsync(monFichier, tbxEcrire.Text);

                //// packagging local state 
                ///

                ////////////////////////////////////////////////////////////////lecture
                ////s�lectionne l'emplacement du fichier
                //Windows.Storage.StorageFolder monDossier =
                //    Windows.Storage.ApplicationData.Current.LocalFolder;

                ////s�lectionne le fichier � lire
                //Windows.Storage.StorageFile monFichier =
                //    await monDossier.GetFileAsync("monFichier.txt");

                ////ouvre le fichier et lit le contenu
                //tblTexte.Text = await Windows.Storage.FileIO.ReadTextAsync(monFichier);
                /////////////////////////////////////////////////////////////////////////ecriture dans un fichier choisi
                //var picker = new Windows.Storage.Pickers.FileSavePicker();
                ///******************** POUR WINUI3 ***************************/
                //var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
                //WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
                ///************************************************************/


                //picker.SuggestedFileName = "test";
                //picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".csv" });//typr de fichier 

                ////cr�e le fichier
                //Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

                ////�crit dans le fichier
                //await Windows.Storage.FileIO.WriteTextAsync(monFichier, tblTexte.Text);
                ///////////////////////////////////////////////////////////////lire un fichier choisie 
                //var picker = new Windows.Storage.Pickers.FileOpenPicker();
                //picker.FileTypeFilter.Add(".txt");

                ///******************** POUR WINUI3 ***************************/
                //var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
                //WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
                ///************************************************************/

                ////s�lectionne le fichier � lire
                //Windows.Storage.StorageFile monFichier = await picker.PickSingleFileAsync();

                ////ouvre le fichier et lit le contenu
                //tblTexte.Text = await Windows.Storage.FileIO.ReadTextAsync(monFichier);



            }

        }
    }
}
