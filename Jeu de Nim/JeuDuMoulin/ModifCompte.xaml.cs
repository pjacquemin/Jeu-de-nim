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
using Controller;

namespace JeuDuMoulin
{
    /// <summary>
    /// Logique d'interaction pour ModifCompte.xaml
    /// </summary>
    public partial class ModifCompte : Page
    {
        private Joueur joueur;
        private JoueurCont jc;
        MainWindow mainW;
        public ModifCompte(MainWindow mW, Joueur joueur)
        {
            InitializeComponent();
            mainW = mW;
            this.joueur = joueur;
            jc = new JoueurCont();
            loginText.Focus();
            mainW.KeyDown += new System.Windows.Input.KeyEventHandler(this.keyPress); // context sensitive
        }

        private void bRetour_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = new NouveauJeu(mainW, joueur);

        }
        private void keyPress(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                if (mdpText.IsFocused)
                    mdpText2.Focus();
                else
                {
                    if (mdpText2.IsFocused)
                        bModif.Focus();
                    else
                        mdpText.Focus();

                }
            }
        }
        private void bSupp_Click(object sender, RoutedEventArgs e)
        {
            jc.suppJoueur(joueur.Login1); // delete the current connected player
            MessageBox.Show("Profil supprimé !");
            mainW.Content = new login(mainW);
        }

        private void bModif_Click(object sender, RoutedEventArgs e)
        {
            if (loginText.Text != null && mdpText.Password != null && mdpText2.Password != null) // check if the password textbox and the login textbox aren't empty
            {
                if (mdpText.Password == mdpText2.Password) 
                {
                    jc.modifJoueur(joueur, loginText.Text, mdpText.Password);
                    MessageBox.Show("Modification(s) apportée(s)");
                    mainW.Content = new login(mainW); // go to the login menu
                }
                else
                    MessageBox.Show("Erreur dans le formulaire : les mots de passes entrés ne correspondent pas !");
            }
            else
                MessageBox.Show("Erreur dans le formulaire : des champs sont incomplets !");
           
        }
    }
}
