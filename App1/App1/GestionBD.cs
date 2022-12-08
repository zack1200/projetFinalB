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
        ObservableCollection<Trajet> listeF;
        ObservableCollection<Trajet> listeR;
        static GestionBD gestionBD = null;

        public GestionBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq7;Uid=2023268;Pwd=2023268;"); ;
            liste = new ObservableCollection<Trajet>();
            listeF = new ObservableCollection<Trajet>();
            listeR = new ObservableCollection<Trajet>();
        }
        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }
        public ObservableCollection<Trajet> GetTrajets()
        {
            liste.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "select nom,heure_depart,ville_arrivee,heure_arrivee,type_vehicule,nb_place,prix,usager from trajet,ville " +
                "where trajet.ville=ville.id_ville and date>=CURDATE();";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            
                while (r.Read())
            {
                Trajet c = new Trajet()
                {
                    Usager = r.GetString("usager"),
                    Heuredep = r.GetString("heure_depart"),
                    Villedep = r.GetString("nom"),                    
                    Heurearr = r.GetString("heure_arrivee"),
                    Villearr=r.GetString("ville_arrivee"),
                    Type = r.GetString("type_vehicule"),
                    Nbplace = r.GetString("nb_place"),
                    Prix = r.GetString("prix"),
                };
                liste.Add(c);
            }
            r.Close();
            con.Close();
            return liste;     
        }

        public ObservableCollection<Trajet> GetTrajetsFini()
        {
            listeF.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "select nom,heure_depart,ville_arrivee,heure_arrivee,type_vehicule,nb_place,prix,usager from trajet,ville " +
                "where trajet.ville=ville.id_ville and date<CURDATE();";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                Trajet c = new Trajet()
                {
                    Usager = r.GetString("usager"),
                    Heuredep = r.GetString("heure_depart"),
                    Villedep = r.GetString("nom"),
                    Heurearr = r.GetString("heure_arrivee"),
                    Villearr = r.GetString("ville_arrivee"),
                    Type = r.GetString("type_vehicule"),
                    Nbplace = r.GetString("nb_place"),
                    Prix = r.GetString("prix"),

                };

                listeF.Add(c);
            }

            r.Close();
            con.Close();
            return listeF;

        }
        public ObservableCollection<Trajet> rechercher_Trajet(string dateDebut, string dateFin)
        {
            listeR.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "select nom,heure_depart,date,ville_arrivee,heure_arrivee,type_vehicule,nb_place,prix,usager from trajet,ville" +
                "               where trajet.ville=ville.id_ville and date>='" + dateDebut + "' and date<='" + dateFin + "'; ";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                Trajet c = new Trajet()
                {
                    Usager = r.GetString("usager"),
                    Heuredep = r.GetString("heure_depart"),
                    Villedep = r.GetString("nom"),
                    Heurearr = r.GetString("heure_arrivee"),
                    Villearr = r.GetString("ville_arrivee"),
                    Type = r.GetString("type_vehicule"),
                    Nbplace = r.GetString("nb_place"),
                    Prix = r.GetString("prix"),
                    Date=r.GetString("date"),
                };

                listeR.Add(c);
            }

            r.Close();
            con.Close();
            return listeR;

        }



    }
}
