using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class GestionVille
    {
        MySqlConnection con;
        ObservableCollection<Ville> liste3;
        static GestionVille gestionVille = null;

        public GestionVille()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq7;Uid=2023268;Pwd=2023268;"); ;
            liste3 = new ObservableCollection<Ville>();
        }
        public static GestionVille getInstance()
        {
            if (gestionVille == null)
                gestionVille = new GestionVille();

            return gestionVille;
        }
        public void AjouterVille(Ville e)
        {

            string nom = e.Nom;
            string codepostale = e.Codepostale;
           



            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into ville (nom, code_postal) values (@nom,@code_postal)  ";
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@code_postal", codepostale);
   
                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
