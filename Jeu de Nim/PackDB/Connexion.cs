using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace PackDB
{
    public class Connexion
    {
                
        private static SqlCeConnection connexion;

        public static SqlCeConnection getInstance()
        {
            String conString = Properties.Settings.Default.dbtestConnectionString;
            try
            {
                connexion = new SqlCeConnection(conString);
                connexion.Open();
            }
            catch (Exception e)
            {
                Console.Write("Erreur connexion bd => " + e.Message);
            }
            return connexion;
        }
        public static SqlCeConnection getConnexion()
        {
            return connexion;
        }
        


    }
}
