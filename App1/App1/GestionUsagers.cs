using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace App1
{
    internal class GestionUsagers
    {
        MySqlConnection con;
        ObservableCollection<Usager> listeU;
        ObservableCollection<Ville> listeV;
        bool connexion =false;
        static GestionUsagers gestionUsagers = null;
        string nom ,email,statut,mdp;

        public string Nom { get => nom; }
        public string Email { get => email; }
        public string Statut { get => statut;  }

        public GestionUsagers()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq7;Uid=2023268;Pwd=2023268;"); ;
            listeU = new ObservableCollection<Usager>();
            listeV = new ObservableCollection<Ville>();
        }
        public static GestionUsagers getInstance()
        {
            if (gestionUsagers == null)
                gestionUsagers = new GestionUsagers();

            return gestionUsagers;
        }
        public ObservableCollection<Ville> GetVille()
        {
            listeV.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from ville";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                Ville c = new Ville()
                {                    
                    Nom = r.GetString("nom"),
                    IdV = r.GetInt32("id_ville"),
                };


                listeV.Add(c);
            }

            r.Close();
            con.Close();
            return listeV;
        }

        public void AjouterUsager(Usager e)
        {
            
            string nom =e.Nom;
            string prenom =e.Prenom;
            string email= e.Email;
            string mdp =e.Mdp;
            string add=e.Add;
            int ville=e.Ville;
            string telephone=e.Telephone;
            string statut=e.Statut;
           


            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into usager (nom, prenom, email, mot_de_passe, adresse, ville, telephone, statut) values (@nom,@prenom,@email,@mot_de_passe,@adresse,@ville,@telephone,@statut)  ";

                

                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);
                commande.Parameters.AddWithValue("@email", email);
                commande.Parameters.AddWithValue("@mot_de_passe", mdp);
                commande.Parameters.AddWithValue("@adresse", add);
                commande.Parameters.AddWithValue("@ville", ville);
                commande.Parameters.AddWithValue("@telephone", telephone);
                commande.Parameters.AddWithValue("@statut", statut);



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

        public bool Connexion(string e, string m)
        {
           

            try
            {
                
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = " Select nom, statut from usager where email =@email and mot_de_passe = @mdp ";
                commande.Parameters.AddWithValue("@email", e);
                commande.Parameters.AddWithValue("@mdp", m);
                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                if (r.Read())
                {
                    statut = r.GetString("statut");
                    connexion = true;
                    nom = r.GetString("nom");

                }
                else
                {
                    connexion = false;
                }

                con.Close();
                
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return connexion;
        }





    }


}
