using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business;
using PackModel;
namespace Controller
{
    public class JoueurCont
    {
        private bool b;
        private PackModel.Joueur joueur;
        private Business.BusinessJoueur bj = new BusinessJoueur();

        public bool verifConnexion(String log, String pass)
        {

            b = bj.verifConnexion(log, pass);
            return b;
        }
        public PackModel.Joueur getInfoJoueur(String l, String m)
        {
            joueur = bj.getInfoJoueur(l, m);
            return joueur;
        }
        public void creerJoueur(String l, String m)
        {
            bj.creerJoueur(l, m);
        }
        public List<PackModel.Joueur> getTop()
        {
            return bj.getTop();
        }
        public void addPts(string login, int p)
        {
            bj.addPts(login, p);
        }
        public void suppJoueur(string log)
        {
            bj.suppJoueur(log);
        }
        public void modifJoueur(Joueur j, string l, string mdp)
        {
            bj.modifJoueur(j,l,mdp);
        }
    }
}
