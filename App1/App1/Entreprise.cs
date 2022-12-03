using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Entreprise
    {
        string nom;
        string email;
        string mdp;
        string fax;
        string solde;

        public string Nom { get => nom; set => nom = value; }
        public string Email { get => email; set => email = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Solde { get => solde; set => solde = value; }
    }
}
