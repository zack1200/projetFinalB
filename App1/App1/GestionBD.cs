using Microsoft.UI.Xaml;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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

        MainWindow csv;
        MySqlConnection con;
        ObservableCollection<Trajet> liste;
        ObservableCollection<Trajet> listeF;
        ObservableCollection<Trajet> listeR;
        static GestionBD gestionBD = null;
        Window fenetre;
        public Window Fenetre { get => fenetre; set => fenetre = value; }
        public MainWindow Csv { get => csv; set => csv = value; }
        internal ObservableCollection<Trajet> ListeR { get => listeR; set => listeR = value; }

        public GestionBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=2023268-zakaria-el-bahodi;Uid=2023268;Pwd=2023268;");
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
            commande.CommandText = "select id_trajet,date,nom,heure_depart,ville_arrivee,heure_arrivee,type_vehicule,nb_place,prix,usager from trajet,ville " +
                "where trajet.ville=ville.id_ville and date>=CURDATE() and nb_place>0;";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            
                while (r.Read())
            {
                Trajet c = new Trajet()
                {
                    Date=r.GetString("date"),
                    Usager = r.GetString("usager"),
                    Heuredep = r.GetString("heure_depart"),
                    Villedep = r.GetString("nom"),                    
                    Heurearr = r.GetString("heure_arrivee"),
                    Villearr=r.GetString("ville_arrivee"),
                    Type = r.GetString("type_vehicule"),
                    Nbplace = r.GetString("nb_place"),
                    Prix = r.GetString("prix"),
                    Idtra = r.GetInt32("id_trajet"),
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
        public  ObservableCollection<Trajet> rechercher_Trajet(string dateDebut, string dateFin)
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
        public void AjouterTrajet(Trajet c)
        {
            string Date = c.Date ;
            string heuredep = c.Heuredep;
            int villedep = c.NumVD;
            string villearret = c.Villearret;
            string heurearr = c.Heurearr;
            string villearr = c.Villearr;
            string type = c.Type;
            string nbplace = c.Nbplace;
            string prix = c.Prix;
            string statut = c.Statut;
            string usager = c.Usager;
            string email = c.Email;
            


            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into trajet (date, heure_depart, ville, ville_arret, heure_arrivee, ville_arrivee, type_vehicule, nb_place, prix, statut, usager, email) " +
                    "VALUES" +
                    "             (@date,@heuredep,@villedep,@villearret,@heurearr,@villearr,@type,@nbplace,@prix,@statut,@usager,@email); ";

                commande.Parameters.AddWithValue("@date", Date);
                commande.Parameters.AddWithValue("@heuredep", heuredep);
                commande.Parameters.AddWithValue("@villedep", villedep);
                commande.Parameters.AddWithValue("@villearret", villearret);
                commande.Parameters.AddWithValue("@heurearr",heurearr );
                commande.Parameters.AddWithValue("@villearr", villearr);
                commande.Parameters.AddWithValue("@type", type);
                commande.Parameters.AddWithValue("@nbplace", nbplace);
                commande.Parameters.AddWithValue("@prix", prix);
                commande.Parameters.AddWithValue("@statut", statut);
                commande.Parameters.AddWithValue("@usager", usager);
                commande.Parameters.AddWithValue("@email", email);


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
        public int Resa(Trajet c)
        {
            int Id_trajet = c.Idtra;            
            int retour = 0;
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "update trajet,usager set nb_place = nb_place - 1 Where id_trajet = @id_trajet ;";
                
            commande.Parameters.AddWithValue("@id_trajet", Id_trajet);           
            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();
            con.Close();
            return retour;
        }
        public int ResaP(Trajet c)

        {
            int Id_trajet = c.Idtra;

            int retour = 0;

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = 
                "update usager, trajet set portefeuille = portefeuille + prix  where id_trajet = @id_trajet and id_usager = trajet.usager;";

            commande.Parameters.AddWithValue("@id_trajet", Id_trajet);
            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();

            con.Close();

            return retour;
        }
        public int ResaG(Trajet c)

        {
            int Id_trajet = c.Idtra;

            int retour = 0;

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText =  "update usager, trajet set gain = gain + prix  where id_trajet = @id_trajet and id_usager = trajet.usager; ";

            commande.Parameters.AddWithValue("@id_trajet", Id_trajet);
            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();

            con.Close();

            return retour;
        }
    }





}

