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
    /// Interaction logic for ChoixNiveau.xaml
    /// </summary>
    public partial class ChoixNiveau : Page
    {
        MainWindow mainW;
        PackModel.Joueur joueur;
        public ChoixNiveau(MainWindow mW, PackModel.Joueur joueur)
        {
            InitializeComponent();
            mainW = mW;
            this.joueur = joueur;
            bNiv2.Focus();
        }

        private void bNiv1_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new Jeu(mainW,0,joueur);
        }

        private void bNiv2_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new Jeu(mainW,1,joueur);
        }

        private void bRetour_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new NouveauJeu(mainW, joueur);
        }
    }
}
