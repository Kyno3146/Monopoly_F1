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

namespace Monopoly.IHM
{
    /// <summary>
    /// Logique d'interaction pour SelectF1_Joueur2.xaml
    /// </summary>
    public partial class SelectF1_Joueur2 : Window
    {
        #region attribut
        /// <summary>
        /// attribut venant de l'ihm joueur 1
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        private string f1_Joueur1;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="f1_j1"></param>
        /// <author>Barthoux Sauze Thomas</author>
        public SelectF1_Joueur2(string f1_j1)
        {
            InitializeComponent();
            this.f1_Joueur1 = f1_j1;
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
            }
        }
        #endregion
    }
}
