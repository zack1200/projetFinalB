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
    public sealed partial class Connexion : Page
    {
        public Connexion()
        {
            this.InitializeComponent();
            listVille.ItemsSource = GestionUsagers.getInstance().GetVille();
        }
        private void btInsc_Click(object sender, RoutedEventArgs e)
        {
            Ville vi = listVille.SelectedItem as Ville;


            Usager u = new Usager()
            {
                Nom=tbxNom.Text,
                Prenom=tbxPrenom.Text,
                Email=tbxEmail.Text,
                Add=tbxAdd.Text,
                Ville=vi.IdV,
                Mdp=tbxMdp.Text,
                Statut="chauffeur",
                Telephone="0000000000"
            };
            GestionUsagers.getInstance().AjouterUsager(u);


        }
    }
}
