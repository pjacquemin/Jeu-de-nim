using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;
using System.Text;


namespace PackXML
{
    public class saveGame
    {
        private XmlDocument savegameDoc;
        private String FileName;

        public saveGame(String nomPartie, int scoreJoueur, int scoreOrdi, int diff)
        {
            this.FileName = "sauvegarde.xml";
            this.sauvegarde(nomPartie, scoreJoueur, scoreOrdi, diff);
        }
        public void sauvegarde(String np, int sj, int so, int diff)
        {
            if (!File.Exists(FileName))
            {
                initSavegameFile();
            }
            this.savegameDoc = new XmlDocument();
            this.savegameDoc.Load(FileName);
            System.Xml.XmlNode racine = savegameDoc.DocumentElement;
            System.Xml.XmlNode savegame = savegameDoc.CreateNode(System.Xml.XmlNodeType.Element, "savegame", "savegames");

            XmlAttribute xa = savegameDoc.CreateAttribute("nompartie");
            xa.InnerText = np;
            savegame.Attributes.Append(xa);
            xa = savegameDoc.CreateAttribute("scorejoueur");
            xa.InnerText = ""+sj;
            savegame.Attributes.Append(xa);
            xa = savegameDoc.CreateAttribute("scoreordi");
            xa.InnerText = ""+so;
            savegame.Attributes.Append(xa);
            xa = savegameDoc.CreateAttribute("difficulte");
            xa.InnerText = "" + diff;
            savegame.Attributes.Append(xa);

            racine.AppendChild(savegame);
            savegameDoc.Save(FileName);
        }
        private void initSavegameFile()
        {
            FileStream fs = new FileStream(FileName, FileMode.Append);
            XmlWriter w = XmlWriter.Create(fs);

            w.WriteStartDocument();
            w.WriteStartElement("sauvegardes");
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Flush();
            fs.Close();
        }
    }
}
