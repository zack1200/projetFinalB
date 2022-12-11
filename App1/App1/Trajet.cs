using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Trajet
    {
        
        string date;
        string heuredep;
        string villedep;
        string villearret;
        string heurearr;
        string villearr;
        string type;
        string nbplace;
        string prix;
        string statut;
        string usager;
        string email;
        string historique;
        int numVD;
        int idtra;

        public string Date { get => date; set => date = value; }
        public string Heuredep { get => heuredep; set => heuredep = value; }
        public string Villedep { get => villedep; set => villedep = value; }
        public string Villearret { get => villearret; set => villearret = value; }
        public string Heurearr { get => heurearr; set => heurearr = value; }
        public string Villearr { get => villearr; set => villearr = value; }
        public string Type { get => type; set => type = value; }
        public string Nbplace { get => nbplace; set => nbplace = value; }
        public string Prix { get => prix; set => prix = value; }
        public string Statut { get => statut; set => statut = value; }
        public string Usager { get => usager; set => usager = value; }
        public string Email { get => email; set => email = value; }
        public string Historique { get => historique; set => historique = value; }
        public int NumVD { get => numVD; set => numVD = value; }
        public int Idtra { get => idtra; set => idtra = value; }
    }
}
