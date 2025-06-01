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
        private List<Property> propertyPlayer;
        private int Caseposition;
        private List<string> info;
        private Property property;
        private object selectedItem;

        public Property[] Properties { get; }
        public int Position { get; }

        /// <summary>
        /// Constructor for the Amelioration window.
        /// </summary>
        /// <param name="propertyPlayer"></param>
        /// <param name="position"></param>
        /// <author>Barthoux Sauze Thomas</author>
        public Amelioration(List<Property> propertyPlayer, int position)
        {
            this.Caseposition = position;
            this.propertyPlayer = propertyPlayer;
            SelectProperty(propertyPlayer);

            InitializeComponent();
        }

        /// <summary>
        /// Selects the property based on the player's properties and the case position.
        /// </summary>
        /// <param name="propertyPlayer"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void SelectProperty(List<Property> propertyPlayer)
        {
            foreach (Property pr in propertyPlayer)
            {
                if (pr.position == Caseposition)
                {
                    //Card card = new Card(pr.position.ToString());
                    //info = card.infoCarte(pr.position.ToString());
                    property = pr;

                    //MessageBox.Show("Propriété : " + info[0] + " - Niveau : " + property.price);
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
            if (this.property == null)
            {
                MessageBox.Show("Aucune propriété sélectionnée pour l'amélioration.");
                return;
            }

            if (lstAmelioration.SelectedItem is ListBoxItem selectedItem)
            {
                string text = selectedItem.Content.ToString();

                if (!string.IsNullOrWhiteSpace(text) && char.IsDigit(text[^1]))
                {
                    int levelselected = int.Parse(text[^1].ToString());

                    if (levelselected > property.level && levelselected < 6)
                    {
                        // ici tu peux appliquer l'amélioration
                        property.level = levelselected; 
                        property.Upgrade();
                        MessageBox.Show($"Propriété améliorée au niveau {property.level} avec succès !");
                        this.Close(); // Ferme la fenêtre d'amélioration
                    }
                    else
                    {
                        MessageBox.Show("Veuillez sélectionner un niveau supérieur à celui actuel de la propriété.");
                    }
                }
                else
                {
                    MessageBox.Show("Le niveau sélectionné n'est pas un chiffre valide.");
                }
            }
            else
            {
                MessageBox.Show("L'élément sélectionné n'est pas valide.");
            }
        }

    }
}
