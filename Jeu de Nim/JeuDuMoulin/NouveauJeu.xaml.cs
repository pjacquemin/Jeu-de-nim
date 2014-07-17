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

namespace JeuDuMoulin
{
    /// <summary>
    /// Interaction logic for NouveauJeu.xaml
    /// </summary>
    public partial class NouveauJeu : Page
    {
        MainWindow mainW;
        private PackModel.Joueur joueur;
        public NouveauJeu(MainWindow mW, PackModel.Joueur joueur)
        {
            InitializeComponent();
            this.mainW = mW;
            this.joueur = joueur;
            bHumPC.Focus();
        }

        private void bRetour_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new login(mainW);
        }

        private void bHumPC_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new ChoixNiveau(mainW, joueur);

        }

       

        private void bCharger_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new PartiesSauvegardees(mainW,joueur);
        }

        private void bModif_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new ModifCompte(mainW, joueur);
        }
        

       

        

       
    }
}
