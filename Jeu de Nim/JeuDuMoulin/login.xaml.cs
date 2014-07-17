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
using System.Data.SqlClient;
using System.Data.SqlServerCe;

using PackDB;
using Controller;

namespace JeuDuMoulin
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        
        PackModel.Joueur NouvJ;
        Controller.JoueurCont jc = new JoueurCont();

        MainWindow mainW;
        public login(MainWindow mW)
        {
            InitializeComponent();
            PackDB.Connexion.getInstance(); // get the connexion instance
            
            this.mainW = mW;
            mainW.KeyDown += new System.Windows.Input.KeyEventHandler(this.keyPress); // for context sensitive
            loginText.Focus(); // put the cursor on the login textbox
            
           
        }

        private void keyPress(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                if (loginText.IsFocused)
                    mdpText.Focus();
                else
                    if (mdpText.IsFocused)
                        bJouer.Focus();
            }
            if(e.Key == Key.F5)
                System.Diagnostics.Process.Start("chm\\chm.chm");
        }
        private void BoutonCréer_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new NouveauJoueur(mainW);

        }

        private void bJouer_Click(object sender, RoutedEventArgs e)
        {
            
            if (jc.verifConnexion(loginText.Text, mdpText.Password) == true)
            {
                
                NouvJ = jc.getInfoJoueur(loginText.Text, mdpText.Password); // get the data of the connected player
                mainW.Content = new NouveauJeu(mainW,NouvJ);
            }
            else
                MessageBox.Show("Mauvais login ou mot de passe");
                
        }
    }
}
