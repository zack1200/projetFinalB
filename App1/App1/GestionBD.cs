using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class GestionBD
    {
        MySqlConnection con;
        ObservableCollection<Trajet> liste;
        static GestionBD gestionBD = null;
    }
}
