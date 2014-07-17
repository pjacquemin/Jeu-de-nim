using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackModel
{
    public class listeSauvegarde
    {
        private string nomPartie;
        private int diff;

        public int Diff
        {
            get { return diff; }
            set { diff = value; }
        }
        public string NomPartie
        {
            get { return nomPartie; }
            set { nomPartie = value; }
        }
        private int scoreJ, scoreO;

        public int ScoreO
        {
            get { return scoreO; }
            set { scoreO = value; }
        }

        public int ScoreJ
        {
            get { return scoreJ; }
            set { scoreJ = value; }
        }

    

        public listeSauvegarde(string np, int sj, int so, int diff)
        {
            this.diff = diff;
            nomPartie = np;
            scoreJ = sj;
            scoreO = so;
        }
    }
}
