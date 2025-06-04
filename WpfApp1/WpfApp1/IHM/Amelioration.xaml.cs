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
    /// Logique d'interaction pour Amelioration.xaml
    /// </summary>
    public partial class Amelioration : Window
    {
        private Player player;
        private List<string> info;
        private Property property;
        private int indexPR;

        public Property[] Properties { get; }
        public int Position { get; }

        /// <summary>
        /// Constructor for the Amelioration window.
        /// </summary>
        /// <param name="propertyPlayer"></param>
        /// <param name="position"></param>
        /// <author>Barthoux Sauze Thomas</author>
        public Amelioration(Player Player)
        {
            this.player = Player;
            InitializeComponent();
            TitleUpgrade.Content += player.Name;

            SelectProperty(player);
        }

        /// <summary>
        /// Selects the property based on the player's properties and the case position.
        /// </summary>
        /// <param name="propertyPlayer"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void SelectProperty(Player player)
        {
            if (player.properties == null) 
            {
                MessageBox.Show("Aucune propriété trouvée pour le joueur.");
                this.Close();
                return;
            }
            else
            {
                foreach (Property pr in player.properties)
                {
                    Card tmp = new Card("");
                    info = tmp.infoCarte(pr.position.ToString());

                    lstCasePossible.Items.Add(info[0].ToString());
                }
            }

        }

        /// <summary>
        /// Handles the click event for the "Amelioration" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void btnAmelioration_Click(object sender, RoutedEventArgs e)
        {
            if (this.indexPR == null)
            {
                MessageBox.Show("Aucune propriété sélectionnée pour l'amélioration.");
                return;
            }
            else
            {
                player.properties[indexPR].Upgrade();
                MessageBox.Show($"Propriété améliorée au niveau {player.properties[indexPR].level.ToString()} avec succès !");
                this.Close(); // Ferme la fenêtre d'amélioration
            }
           
        }

        private void savePropertyselected(object sender, MouseButtonEventArgs e)
        {
            indexPR = lstCasePossible.SelectedIndex;

            Card tmp2 = new Card("");
            info = tmp2.infoCarte(player.properties[indexPR].position.ToString());

            if (player.properties[indexPR].position == 5 || player.properties[indexPR].position == 12 || player.properties[indexPR].position == 15 || player.properties[indexPR].position == 25 || player.properties[indexPR].position == 28 || player.properties[indexPR].position == 35)
            {
                MessageBox.Show("Cette case ne peut etre améliorée.");

            }
            else
            {
                labelselectpr.Content += info[0].ToString();
            }
        }

    }
}
