using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.IHM;

namespace Monopoly.IHM
{
    /// <summary>
    /// Logique d'interaction pour SelectF1.xaml
    /// </summary>
    public partial class SelectF1 : Window
    {
        public string username2;
        public MainWindow main;

        public SelectF1(string username1, string username2, MainWindow main)
        {
            InitializeComponent();
            LabelF1.Content = username1.ToString() + " selectionner votre monoplace";
            this.main = main;
            this.username2 = username2;
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            if (sender is Button bouton)
            {
                string f1_choose1 = bouton.Tag?.ToString();
                
                SelectF1_Joueur2 selectF1 = new SelectF1_Joueur2(f1_choose1, username2, main);
                selectF1.Show();
                this.Close();
            }
        }
    }
}
