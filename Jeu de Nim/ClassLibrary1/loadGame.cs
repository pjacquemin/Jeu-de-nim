using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using PackModel;

namespace PackXML
{
    public class loadGame
    {
        private XmlDocument savegameDoc;
        private String savegameFileName;
        private int diff,so,sj;
        public loadGame()
        {
            diff = 0;
            so = 0;
            sj = 0;
            this.savegameFileName = "sauvegarde.xml";
            this.savegameDoc = new XmlDocument();
            if (File.Exists(savegameFileName))
            {
                this.savegameDoc.Load(savegameFileName);
            }
        }
        public void suppJeu(listeSauvegarde lst)
        {
            XmlNodeList elemList = savegameDoc.GetElementsByTagName("savegame");

            foreach (XmlElement elmt in elemList)
            {
                if (elmt.Attributes["nompartie"].Value.Equals(lst.NomPartie) && Int32.Parse(elmt.Attributes["scorejoueur"].Value.ToString()).Equals(lst.ScoreJ) && Int32.Parse(elmt.Attributes["scoreordi"].Value.ToString()).Equals(lst.ScoreO) && Int32.Parse(elmt.Attributes["difficulte"].Value.ToString()).Equals(lst.Diff))
                {
                    elmt.ParentNode.RemoveChild(elmt);
                    break;
                }

            }
            savegameDoc.Save(savegameFileName);
            
        }
        public List<listeSauvegarde> getList()
        {
            List<listeSauvegarde> lsgti = new List<listeSauvegarde>();

            XmlNodeList elemList = savegameDoc.GetElementsByTagName("savegame");

            foreach (XmlElement elmt in elemList)
            {
                lsgti.Add(new listeSauvegarde(elmt.Attributes["nompartie"].Value.ToString(), Int32.Parse(elmt.Attributes["scorejoueur"].Value.ToString()), Int32.Parse(elmt.Attributes["scoreordi"].Value.ToString()), Int32.Parse(elmt.Attributes["difficulte"].Value.ToString())));
            }

            return lsgti;
        }
        public int getDiff(listeSauvegarde lst)
        {
            XmlNodeList elemList = savegameDoc.GetElementsByTagName("savegame");
            foreach (XmlElement elmt in elemList)
            {
                if(elmt.Attributes["nompartie"].Value.ToString() == lst.NomPartie && Int32.Parse(elmt.Attributes["scorejoueur"].Value.ToString()) == lst.ScoreJ && Int32.Parse(elmt.Attributes["scoreordi"].Value.ToString()) == lst.ScoreO && Int32.Parse(elmt.Attributes["difficulte"].Value.ToString()) == lst.Diff)
                {
                    diff = Int32.Parse(elmt.Attributes["difficulte"].Value.ToString());
                }               
            }
            return diff;
        }
        public int getScoreOrdi(listeSauvegarde lst)
        {
            XmlNodeList elemList = savegameDoc.GetElementsByTagName("savegame");
            foreach (XmlElement elmt in elemList)
            {
                if (elmt.Attributes["nompartie"].Value.ToString() == lst.NomPartie && Int32.Parse(elmt.Attributes["scorejoueur"].Value.ToString()) == lst.ScoreJ && Int32.Parse(elmt.Attributes["scoreordi"].Value.ToString()) == lst.ScoreO && Int32.Parse(elmt.Attributes["difficulte"].Value.ToString()) == lst.Diff)
                {
                    so = Int32.Parse(elmt.Attributes["scoreordi"].Value.ToString());
                }
            }
            return so;
        }
        public int getScoreJoueur(listeSauvegarde lst)
        {
            XmlNodeList elemList = savegameDoc.GetElementsByTagName("savegame");
            foreach (XmlElement elmt in elemList)
            {
                if (elmt.Attributes["nompartie"].Value.ToString() == lst.NomPartie && Int32.Parse(elmt.Attributes["scorejoueur"].Value.ToString()) == lst.ScoreJ && Int32.Parse(elmt.Attributes["scoreordi"].Value.ToString()) == lst.ScoreO && Int32.Parse(elmt.Attributes["difficulte"].Value.ToString()) == lst.Diff)
                {
                    sj = Int32.Parse(elmt.Attributes["scorejoueur"].Value.ToString());
                }
            }
            return sj;
        }
    }
}
