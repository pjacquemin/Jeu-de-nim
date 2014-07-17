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
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Page
    {
        MainWindow mainW;
        Jeu j;

        public Options(MainWindow mW, Jeu j)
        {
            InitializeComponent();
            mainW = mW;
            this.j = j;
        }

        private void bRetourOptions_Click(object sender, RoutedEventArgs e)
        {
            mainW.Content = j;
        }

        private void bAplliquer_Click(object sender, RoutedEventArgs e)
        {
           
            if (rb1.IsChecked == true)
                j.setBg(c1.Fill);
            else
                if (rb2.IsChecked == true)
                    j.setBg(c2.Fill);
                else
                    if (rb3.IsChecked == true)
                        j.setBg(c3.Fill);
            if (rbJ.IsChecked == true)
                j.setFirst(false);
            else
                j.setFirst(true);
            
        }
    }
}
