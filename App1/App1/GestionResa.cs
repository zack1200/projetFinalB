using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class GestionResa
    {
        
        MySqlConnection con;
        ObservableCollection<Resa> liste3;
        ObservableCollection<Resa> liste;
        static GestionResa gestionResa = null;

        public GestionResa()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq7;Uid=2023268;Pwd=2023268;"); ;
            liste3 = new ObservableCollection<Resa>();
            liste = new ObservableCollection<Resa>();
        }
        public static GestionResa getInstance()
        {
            if (gestionResa == null)
                gestionResa = new GestionResa();

            return gestionResa;
        }
        public void Ajouter_Resa(string idU ,string Email, Trajet c)
        {


            int Id_trajet = c.Idtra;



            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into reservation (id_usager, email, id_trajet) VALUES (@id_Usager,@email,@id_trajet);  ";
                commande.Parameters.AddWithValue("@id_Usager", idU);
                commande.Parameters.AddWithValue("@email", Email);
                commande.Parameters.AddWithValue("@id_trajet", Id_trajet);
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
        public ObservableCollection<Resa> GetResa(string idu)
        {
            liste.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "select nom,prenom,date,nb_place from reservation,usager,trajet where usager.id_usager=reservation.id_usager and " +
                "trajet.id_trajet=reservation.id_trajet and date>=curdate() and trajet.usager ='" + idu + "';";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                Resa c = new Resa()
                {
                    Nom = r.GetString("nom"),
                    Prenom = r.GetString("prenom"),
                    Date = r.GetString("date"),
                    Nbp= r.GetString("nb_place"),
                };
                liste.Add(c);
            }
            r.Close();
            con.Close();
            return liste;
        }
    }
}
