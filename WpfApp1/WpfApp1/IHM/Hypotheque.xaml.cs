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
        private List<Property> properties;
        #endregion

        #region Constructeurs
        public Hypotheque(List<Property> properties)
        {
            InitializeComponent();
            this.properties = properties;
            InitValue(properties);
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Initialise la liste des propriétés avec leurs informations.
        /// </summary>
        /// <param name="propriete"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void InitValue(List<Property> propriete)
        {
            List<string> infoCarte;
            foreach (Property prop in propriete)
            {
                infoCarte = card.infoCarte(prop.position.ToString());
                lstPropriete.Items.Add(infoCarte[1]);
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
            if (lstPropriete.SelectedItem != null)
            {
                string selectedProperty = lstPropriete.SelectedItem.ToString();
                List<string> infoCarte = card.infoCarte(selectedProperty);
                this.txtValeurHypotheque.Text = infoCarte[4];
            }
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
                string selectedProperty = lstPropriete.SelectedItem.ToString();
                // Appeler la méthode pour hypothéquer la propriété
                // HypothequeProperty(selectedProperty);
                MessageBox.Show($"La propriété {selectedProperty} a été hypothéquée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion
    }
}
