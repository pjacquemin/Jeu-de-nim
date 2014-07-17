using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
namespace PackDB
{
    public class JoueurDB
    {
        private bool b;
        private PackModel.Joueur j;

        public void suppJoueur(string login) // function to delete one player
        {
            try
            {

                SqlCeCommand com = new SqlCeCommand("delete from joueur where login='"+login+"'", PackDB.Connexion.getConnexion());
                SqlCeDataReader reader = com.ExecuteReader();

            }
            catch (Exception e)
            {
                Console.Write("Erreur verif connexion => " + e.Message);
            }

        }
        public void modifJoueur(PackModel.Joueur joueur, string log, string mdp) // function to update one player
        {
            try
            {

                SqlCeCommand com = new SqlCeCommand("UPDATE Joueur set login='" + log + "', mdp='"+ mdp+ "' WHERE login='" + joueur.Login1 + "'", PackDB.Connexion.getConnexion());
                SqlCeDataReader reader = com.ExecuteReader();

            }
            catch (Exception e)
            {
                Console.Write("Erreur verif connexion => " + e.Message);
            }

        }

        public bool verifConnexion(String login, String pass) // function to verif if the login and password are correct
        {

            try
            {

                SqlCeCommand com = new SqlCeCommand("SELECT * FROM joueur where login='" + login + "' and mdp='" + pass + "'", PackDB.Connexion.getConnexion());
                SqlCeDataReader reader = com.ExecuteReader();

                if (reader.Read())
                    b = true;
                else
                    b = false;

            }
            catch (Exception e)
            {
                Console.Write("Erreur verif connexion => " + e.Message);
            }
            return b;


        }
        public void addPts(String login, int nbpg) // function to add points to one player
        {
            try
            {
                SqlCeCommand com = new SqlCeCommand("UPDATE Joueur set NbPartiesGagnees='"+ nbpg +"' WHERE login='"+login+"'", PackDB.Connexion.getConnexion());
                SqlCeDataReader reader = com.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.Write("Erreur verif connexion => " + e.Message);
            }
        }
        public List<PackModel.Joueur> getTop() // function to get the player by score
        {
            List<PackModel.Joueur> lst = new List<PackModel.Joueur>();
            try
            {
                SqlCeCommand com = new SqlCeCommand("SELECT * FROM joueur order by NbPartiesGagnees DESC", PackDB.Connexion.getConnexion());
                SqlCeDataReader reader = com.ExecuteReader();

                while (reader.Read())
                    lst.Add(new PackModel.Joueur(reader.GetString(0), reader.GetString(1), (int)reader.GetDecimal(3), (int)reader.GetDecimal(2)));                 
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur top joueurs bd =>"+e.Message);
            }
            
            return lst;  
        }
        public PackModel.Joueur getInfoJoueur(String log, String pass) // function to get the player informations
        {
            try
            {

                SqlCeCommand com = new SqlCeCommand("SELECT * FROM joueur where login='" + log + "' and mdp='" + pass + "'", PackDB.Connexion.getConnexion());
                SqlCeDataReader reader = com.ExecuteReader();

                if (reader.Read())
                    j = new PackModel.Joueur(reader.GetString(0), reader.GetString(1), (int)reader.GetDecimal(3), (int)reader.GetDecimal(2));
               

            }
            catch (Exception e)
            {
                Console.Write("Erreur info joueur bd => " + e.Message);
            }
            
            return j;

        }
        
        public void creerJoueur(String log, String pass) // function for create one player
        {
            try
            {
                SqlCeCommand com = new SqlCeCommand("INSERT INTO joueur (login,mdp,NbParties,NbPartiesGagnees) VALUES ('"+log+"','"+pass+"',0,0)", PackDB.Connexion.getConnexion());
                com.ExecuteNonQuery();
                Console.Write("ok");

            }
            catch (Exception e)
            {
                Console.Write("Erreur creation joueur bd => " + e.Message);
            }
        }
    }
}
