using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PackDB;
using PackModel;
namespace Business
{
    public class BusinessJoueur
    {
        private PackDB.JoueurDB jdb;
        private bool b;
        public BusinessJoueur()
        {
            jdb = new PackDB.JoueurDB();
        }
        public bool verifConnexion(String log, String pass)
        {
            
            b = jdb.verifConnexion(log, pass);
            return b;
        }
        public PackModel.Joueur getInfoJoueur(String log, String pass)
        {
            PackModel.Joueur j = jdb.getInfoJoueur(log, pass);
            return j;
        }
        public void creerJoueur(String log, String pass)
        {
            jdb.creerJoueur(log, pass);
        }
        public List<PackModel.Joueur> getTop()
        {
            return jdb.getTop();
        }
        public void addPts(string login, int p)
        {
            jdb.addPts(login, p);
        }
        public void suppJoueur(string log)
        {
            jdb.suppJoueur(log);
        }
        public void modifJoueur(Joueur j, string l,string mdp)
        {
            jdb.modifJoueur(j, l, mdp);
        }
    }
}
