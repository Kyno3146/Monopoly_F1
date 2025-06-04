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
using Org.BouncyCastle.Crypto.Digests;
using WpfApp1.IHM;

namespace Monopoly.IHM
{
    /// <summary>
    /// Logique d'interaction pour SelectF1_Joueur2.xaml
    /// </summary>
    public partial class SelectF1_Joueur2 : Window
    {
        #region attribut
        private string f1_Joueur1;
        public MainWindow main;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="f1_j1"></param>
        /// <author>Barthoux Sauze Thomas</author>
        public SelectF1_Joueur2(string f1_j1, string username2, MainWindow main)
        {
            InitializeComponent();
            this.LabelF1.Content = username2.ToString() + " selectionner votre monoplace"; 
            this.f1_Joueur1 = f1_j1;
            this.main = main;
        }

        #endregion

        #region Methode
        /// <summary>
        /// Methode play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void Play(object sender, RoutedEventArgs e)
        {
            if (sender is Button bouton)
            {
                string f1_choose2 = bouton.Tag?.ToString();

                Plateau plateau = new Plateau(this.f1_Joueur1, f1_choose2);
                plateau.Show();
                this.Close();
                main.Close();
            }
        }
        #endregion
    }
}
