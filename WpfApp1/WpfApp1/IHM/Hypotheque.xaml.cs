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
    /// Logique d'interaction pour Hypotheque.xaml
    /// </summary>
    public partial class Hypotheque : Window
    {
        #region Attributs
        private Card card;
        private Player player;
        private List<string> info = new List<string>();
        private int index;
        #endregion

        #region Constructeurs
        public Hypotheque(Player p)
        {
            InitializeComponent();
            this.player = p;
            SelectProperty(player);
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Initialise la liste des propriétés avec leurs informations.
        /// </summary>
        /// <param name="propriete"></param>
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
        /// Affiche la valeur d'hypothèque de la propriété sélectionnée dans la liste.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void lstPropriete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtValeurHypotheque.Text = info[4];
        }

        private void savePropertyselected(object sender, MouseButtonEventArgs e)
        {
            index = lstCasePossible.SelectedIndex;

            Card tmp2 = new Card("");
            info = tmp2.infoCarte(player.properties[index].position.ToString());
            //labelselectpr.Content += info[0].ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHypothequer_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Voulez-vous bien hypotèquer cette propriété ?", "Hypothèque", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                // Logique pour hypothéquer la propriété
                player.properties[index].isMortgaged = true; // Marquer la propriété comme hypothéquée
                player.account += player.properties[index].price / 2; // Ajouter la moitié du prix de la propriété au compte du joueur

                // Appeler la méthode pour hypothéquer la propriété
                // HypothequeProperty(selectedProperty);
                MessageBox.Show($"La propriété {info[0]} a été hypothéquée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion
    }
}
