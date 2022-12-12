using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Resa
    {
        string id_Usager;
        string email;
        int id_trajet;
        string nom;
        string prenom;
        string nbp;
        string date;
        string message;

        public string Id_Usager { get => id_Usager; set => id_Usager = value; }
        public string Email { get => email; set => email = value; }
        public int Id_trajet { get => id_trajet; set => id_trajet = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Nbp { get => nbp; set => nbp = value; }
        public string Date { get => date; set => date = value; }
    }
}
