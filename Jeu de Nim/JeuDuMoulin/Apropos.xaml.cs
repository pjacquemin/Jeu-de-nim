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
    /// Interaction logic for Apropos.xaml
    /// </summary>
    public partial class Apropos : Page
    {
        MainWindow mainW;
        Jeu j;
        public Apropos(MainWindow mW, Jeu j)
        {
            InitializeComponent();
            mainW = mW;
            this.j = j;
        }

        private void bRetour_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = j;
        }
    }
}
