﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Usager
    {
        string nom;
        string prenom;
        string email;
        string mdp;
        string add;
        int ville;
        string telephone;
        string statut;
        string portefeuille;
        string gain;
        string entreprise;
        string id_usager;


        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        public string Add { get => add; set => add = value; }
        public int Ville { get => ville; set => ville = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Statut { get => statut; set => statut = value; }
        public string Portefeuille { get => portefeuille; set => portefeuille = value; }
        public string Gain { get => gain; set => gain = value; }
        public string Entreprise { get => entreprise; set => entreprise = value; }
        public string Id_usager { get => id_usager; set => id_usager = value; }
    }
}
