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
using Controller;
using PackModel;
namespace JeuDuMoulin
{
    /// <summary>
    /// Interaction logic for Scores.xaml
    /// </summary>
    public partial class Scores : Page
    {
        MainWindow mainW;
        Jeu j;
        private int i;
        private Controller.JoueurCont jc;
        List<PackModel.Joueur> lst = new List<PackModel.Joueur>();
        public Scores(MainWindow mW, Jeu j)
        {
            InitializeComponent();
            this.j = j;
            mainW = mW;
            jc = new JoueurCont();
            this.dataGrid1.DataContext = jc.getTop();
            lst = jc.getTop(); // get the players order by score
          
        }

        private void bRetour_Click(object sender, RoutedEventArgs e)
        {           
            mainW.Content = j;
        }

        private void bRapport_Click(object sender, RoutedEventArgs e)
        {
            ExcelDoc excell_app = new ExcelDoc();
            excell_app.createDoc();


            excell_app.createHeaders(3, 1, "Nom joueur", "A2", "A2", 2, true, 25);
            excell_app.createHeaders(3, 2, "Parties gagnées", "B2", "B2", 2, true, 15);
            i = 6;
            foreach (PackModel.Joueur j in jc.getTop())
            {
                excell_app.addData(i, 1, j.Login1, "A" + i, "A" + i, "");
                excell_app.addData(i, 2, j.NbPartiesGagnees1.ToString(), "B" + i, "B" + i, "");
                i++;
            }
        }
    }
}
