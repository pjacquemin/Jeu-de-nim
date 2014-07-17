using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackModel
{
    class Jeu
    {
        private int Id, difficulte;
        private String Type;
        public Jeu(int Id, int diff, String type)
        {
            this.Id = Id;
            this.difficulte = diff;
            this.Type = type;
        }
    }
}
