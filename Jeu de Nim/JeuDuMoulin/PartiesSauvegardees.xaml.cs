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
using PackModel;
using System.Windows.Markup;
using System.Xml.Resolvers;
using System.Xml;
using System.Xml.Linq;
using System.IO;



namespace JeuDuMoulin
{
    /// <summary>
    /// Interaction logic for PartiesSauvegardees.xaml
    /// </summary>
    public partial class PartiesSauvegardees : Page
    {
        MainWindow mainW;
        private PackModel.Joueur joueur;
        public PartiesSauvegardees(MainWindow mW, PackModel.Joueur joueur)
        {
            InitializeComponent();
            mainW = mW;
            PackXML.loadGame xlg = new PackXML.loadGame();
            this.joueur = joueur;
            List<listeSauvegarde> saveList = xlg.getList();
            this.dataGrid1.DataContext = saveList;
            
        }

        private void bCharger_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGrid1.SelectedItem != null)
            {

                //build selected item as a listeSauvegarde
                listeSauvegarde selectedSaveGameTableItem = ((listeSauvegarde)dataGrid1.SelectedItem);

                //build the game from the LoadSaveGame
                PackXML.loadGame xlg = new PackXML.loadGame();

                Jeu jeu = new Jeu(mainW, xlg.getDiff(selectedSaveGameTableItem), xlg.getScoreJoueur(selectedSaveGameTableItem), xlg.getScoreOrdi(selectedSaveGameTableItem), joueur);
                mainW.Content = jeu;

            }
            else
            {
                MessageBox.Show("Veuillez choisir une partie dans le listing !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }

        private void bRetour_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new NouveauJeu(mainW,joueur);
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bSupp_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGrid1.SelectedItem != null)
            {

                //build selected item as a listeSauvegarde
                listeSauvegarde selectedSaveGameTableItem = ((listeSauvegarde)dataGrid1.SelectedItem);

                //build the game from the LoadSaveGame
                PackXML.loadGame xlg = new PackXML.loadGame();
                xlg.suppJeu(selectedSaveGameTableItem);
                List<listeSauvegarde> saveList = xlg.getList();
                this.dataGrid1.DataContext = saveList;

            }
            else
            {
                MessageBox.Show("Veuillez choisir une partie dans le listing !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }

       
    }
}
