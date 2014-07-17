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
    /// Interaction logic for NouveauJoueur.xaml
    /// </summary>
    public partial class NouveauJoueur : Page
    {
        MainWindow mainW;

        private Controller.JoueurCont controller = new Controller.JoueurCont();
        public NouveauJoueur(MainWindow mW)
        {
            InitializeComponent();
            this.mainW = mW;
            loginNouv.Focus();
        }

        private void bRetourNouv_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new login(mainW);
        }

        private void bCreerNouv_Click(object sender, RoutedEventArgs e)
        {
            if (mdpNouv.Password == confMdpNouv.Password)
            {
                controller.creerJoueur(loginNouv.Text, mdpNouv.Password);
                mainW.Content = new login(mainW);
            }
            else {
                MessageBox.Show("Les mots de passes ne sont pas les mêmes !!!");
            }
                

        }
    }
}
