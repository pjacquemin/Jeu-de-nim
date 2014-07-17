using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using IA;
using Microsoft.VisualBasic;
using Controller;
namespace JeuDuMoulin
{
    /// <summary>
    /// Interaction logic for Jeu.xaml
    /// </summary>
    /// 
    public partial class Jeu : Page
    {
        MainWindow mainW;
        private Ordi ordi;
        private int[] tabJeu = new int[9]; // game array : contains value for each match
        private int[] tabJeuSave = new int[9];
        private int diff=0; // for the difficulty
        private int i = 0;
        private int z = 0;      
        private int indice = 0;
        private int col = 0;
        private int scoreJ; // player score 
        private int scoreO; // IA score
        private bool played; // used for testing if the player have remove one matche
        private int p = 0;
        private int nbRest = 0;
        private PackModel.Joueur joueur;
        private Controller.JoueurCont jc = new JoueurCont();
        BitmapImage bi3 = new BitmapImage();       

        public Jeu(MainWindow mW, int diff, PackModel.Joueur joueur)
        {
            InitializeComponent();
            while (i < 9)
            {        
                tabJeu[i] = 0;                 
                i++;
            }
            
            this.scoreJ = 0;
            this.scoreO = 0;
            this.diff = diff;
            played = false;          
            i = 0;
            
            this.joueur = joueur;
            this.mainW = mW;
            mainW.KeyDown += new System.Windows.Input.KeyEventHandler(this.keyPress); // for context sensitive
            bi3.BeginInit();
            bi3.UriSource = new Uri("Images\bleu.bmp", UriKind.Relative);
            bi3.EndInit();
        }
        public Jeu(MainWindow mW, int diff, int scoreJ, int scoreO, PackModel.Joueur joueur)
        {
            InitializeComponent();
            while (i < 9)
            {
                tabJeu[i] = 0;
                i++;
            }
            played = false;
            if (joueur.First == true)
            {
                played = true;
                this.iaJouer();                
            }
            plateau.Fill = joueur.Color;
            this.scoreJ = scoreJ;
            this.scoreO = scoreO;
            label2.Content = "Votre score = " + scoreJ + " |";
            label3.Content = "Score ordinateur = " + scoreO;
            this.diff = diff;
            
            i = 0;
            this.joueur = joueur;
            this.mainW = mW;
            bi3.BeginInit();
            bi3.UriSource = new Uri("Images\bleu.bmp", UriKind.Relative);
            bi3.EndInit();
        }
        private void keyPress(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == Key.F5)
            {
                System.Diagnostics.Process.Start("chm\\chm.chm");
            }
            if (e.Key == Key.F1)
            {
                mainW.Content = new NouveauJeu(mainW, joueur);
            }
            if (e.Key == Key.F2)
            {
                string result = Microsoft.VisualBasic.Interaction.InputBox("Nom de la partie?");
                if (result != null)
                {
                    PackXML.saveGame sg = new PackXML.saveGame(result, scoreJ, scoreO, diff);
                }
            }
            if (e.Key == Key.F3)
            {
                mainW.Content = new Scores(mainW, this);
            }
            if (e.Key == Key.F4)
            {
                mainW.Content = new Options(mainW, this);
            }
            if (e.Key == Key.F6)
            {
                mainW.Content = new Apropos(mainW, this);
            }
            if (e.Key == Key.F7)
            {
                Application.Current.Shutdown();
            }
        }
        // functions for options
        public void setFirst(bool f)
        {
            joueur.First = f;
        }
        public void setBg(System.Windows.Media.Brush color)
        {
            joueur.Color = color;
            plateau.Fill = color;
        }
        public void Handle_MouseDown(object sender, MouseEventArgs args)
        {
            if (verifPerdu() == false && verifGagne() == false) // if nobody have win
            {
                if (i <= 2)
                {

                    string nom = ((Image)sender).Name; // get the name of the clicked match
                    indice = Convert.ToInt32(nom.Substring(5, 1)); // extract the number of this match
                    if (i == 0) // if the player haven't remove one match yet
                        col = findLine(indice); // save the line where the player remove his first match
                    if (findLine(indice) == col || i == 0) // if the player remove the next match on the same line
                    {
                        played = true;
                        Image img = (Image)sender;
                        img.Source = bi3; // we remove it on the interface
                        tabJeu[indice - 1] = 1; // and in the game array
                    }
                    else
                    {
                        MessageBox.Show("Veuillez retirer des allumettes que dans une seule colonne !!!");
                        i--;
                    }
                    if (i == 2)
                    {
                        if (verifGagne() == false && verifPerdu()==false)
                            iaJouer(); // if the player have removed 3 matches, it's the IA turn

                    }
                    else
                        i++;
                }
            }
         
        }
    
        private int findLine(int ind)
        {
            if (ind == 1 || ind == 2 || ind == 3 || ind == 4 || ind == 5)
                return 1;
            else
                if (ind == 6 || ind == 7 || ind == 8)
                    return 2;
                else
                    return 3;
        }
        private bool verifGagne() // function to check if the player have won
        {
            p = 0;
            nbRest = 0;
            while (p < 9)
            {
                if (tabJeu[p] == 0)
                {
                    nbRest++;
                }
                p++;
            }

            if (nbRest == 1 && played == true)
            {
                scoreJ++;
                MessageBox.Show("Vous avez gagné !");
                joueur.NbPartiesGagnees1++;
                jc.addPts(joueur.Login1, joueur.NbPartiesGagnees1);
                mainW.Content = new Jeu(mainW, this.diff, scoreJ, scoreO, joueur);                
                return true;
            }
            else
            {
                return false;
            }

            

        }
        private bool verifPerdu() // function to check if the player have lost
        {
            p = 0;
           nbRest = 0;
            while (p < 9)
            {
                if (tabJeu[p] == 0)
                {
                    nbRest++;
                }
                p++;
            }

            if (nbRest == 1 && played == false)
            {
                scoreO++;
                MessageBox.Show("Vous avez perdu !");
                mainW.Content = new Jeu(mainW, this.diff, scoreJ, scoreO, joueur);
                return true;
                
            }
            else
            {
                return false;
            }
            
           

        }
        private void iaJouer() // function called for IA playing
        {
            if (verifPerdu() == false && verifGagne() == false)
            {
                if (played == true) // if the player have played
                {
                    label1.Content = "Au tour de l'IA !";
                    ordi = new Ordi(diff, tabJeu);
                    Array.Copy(tabJeu, tabJeuSave, 9); // we save the game array 
                    tabJeu = ordi.Jouer(); // the IA plays
                    z = 0;
                    // and we search the removed matches by the IA
                    while (z < 9)
                    {
                        if (tabJeu[z] != tabJeuSave[z])
                        {
                            switch (z)
                            {

                                case 0:
                                    image1.Source = bi3;
                                    break;
                                case 1: image2.Source = bi3;
                                    break;
                                case 2: image3.Source = bi3;
                                    break;
                                case 3: image4.Source = bi3;
                                    break;
                                case 4: image5.Source = bi3;
                                    break;
                                case 5: image6.Source = bi3;
                                    break;
                                case 6: image7.Source = bi3;
                                    break;
                                case 7: image8.Source = bi3;
                                    break;
                                case 8: image9.Source = bi3;
                                    break;
                            }
                        }
                        z++;
                    }

                    label1.Content = "A votre tour !";
                    i = 0;
                    played = false;
                }
                else
                    MessageBox.Show("Veuillez retirer au moins une allumette !");
            }
          
        }           

        private void bNouveauJeu_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new NouveauJeu(mainW, joueur);
        }

        private void bScores_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new Scores(mainW,this);
        }

        private void bOptions_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new Options(mainW,this);
        }

        private void bAide_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("chm\\chm.chm");
        }

        private void bApropos_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new Apropos(mainW,this);
        }

        private void bQuitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (verifPerdu() == false && verifGagne() == false)
                iaJouer();
      
        }

        private void bSauvegarder_Click(object sender, RoutedEventArgs e)
        {
            string result = Microsoft.VisualBasic.Interaction.InputBox("Nom de la partie?"); // inputbox for getting the name of the game
            if (result != null)
            {
                PackXML.saveGame sg = new PackXML.saveGame(result, scoreJ, scoreO, diff);
            }
        }

        



  

    }
}
