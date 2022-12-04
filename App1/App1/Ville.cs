using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Ville
    {
        int idV;
        string nom;
        string codepostale;

        public string Nom { get => nom; set => nom = value; }
        public string Codepostale { get => codepostale; set => codepostale = value; }
        public int IdV { get => idV; set => idV = value; }
    }
}
