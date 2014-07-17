using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackModel
{
    
    public class Joueur
    {
        private string Login, MDP;
        private bool first = false;
        private System.Windows.Media.Brush color;

        public System.Windows.Media.Brush Color
        {
            get { return color; }
            set { color = value; }
        }


        public bool First
        {
            get { return first; }
            set { first = value; }
        }
        public string Login1
        {
            get { return Login; }
            set { Login = value; }
        }
        private int NbPartiesGagnees, NbParties;

        public int NbParties1
        {
            get { return NbParties; }
            set { NbParties = value; }
        }

        public int NbPartiesGagnees1
        {
            get { return NbPartiesGagnees; }
            set { NbPartiesGagnees = value; }
        }
        public Joueur(String Log, String MDP, int NbPartiesGagnees, int NbParties)
        {
            this.Login = Log;
            this.MDP = MDP;
            this.NbParties = NbParties;
            this.NbPartiesGagnees = NbPartiesGagnees;
        }
       
      


    }
}
