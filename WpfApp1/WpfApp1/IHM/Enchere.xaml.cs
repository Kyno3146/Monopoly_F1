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
    /// Logique d'interaction pour Enchere.xaml  
    /// </summary>  
    public partial class Enchere : Window
    {
        private List<string> info = new List<string>();
        private Player joueur1; // Renamed field to lowercase to avoid conflict  
        private Player joueur2;
        private Game game;
        private int MeilleurPrix;
        private int propositionJ1Value;
        private int propositionJ2Value;

        public Enchere(List<string> info, Player joueur1, Player joueur2)
        {
            InitializeComponent();
            this.info = info;
            this.joueur1 = joueur1;
            this.joueur2 = joueur2;
            infoLoad(info);
        }

        /// <summary>  
        /// Load the information of the card in the auction window.  
        /// </summary>  
        /// <param name="info"></param>  
        ///<author>Barthoux Sauze Thomas</author>  
        private void infoLoad(List<string> info)
        {
            this.LabelCarte.Content = info[1];
            string imagePath = $"/Image/{info[0]}.png";
            this.imgCarte.Source = new BitmapImage(new Uri(imagePath));

            this.description.Text = info[2];

            // Par défaut, vider les champs  
            this.valachat.Text = "";

            // Si valeur d'achat présente  
            if (info.Count > 3)
                this.valachat.Text = info[3];

            // Si total est présent (en dernière position)  
            if (info.Count > 5)
                this.valachat.Text += "\n" + info[info.Count - 1]; // Affiche le total dans valachat  

            // Affichage des joueurs  
            this.Joueur1.Content += joueur1.Name;
            this.Joueur2.Content += joueur2.Name;
        }

        /// <summary>
        /// This method is called when the "Enchérir" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void encherir(object sender, RoutedEventArgs e)
        {
            if (game.IsPlayerTurn == false) // joueur 1
            {
                this.PropostionJ2.Text = MeilleurPrix.ToString();
                this.PropositionJ1.Text = "";

                this.PropositionJ1.Background = Brushes.Green;
                this.PropostionJ2.Background = Brushes.Red;

                this.propositionJ1Value = int.Parse(PropositionJ1.Text);

                if (propositionJ1Value > MeilleurPrix)
                {
                    MeilleurPrix = int.Parse(this.PropositionJ1.Text);
                }
                else if (this.Abandonner.IsPressed) 
                {
                    MessageBox.Show(Joueur1 + "abandonné l'enchère.");
                    
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("La proposition doit être supérieure à la meilleure offre actuelle.");
                    return;
                }
            }
            else
            {
                this.PropositionJ1.Text = MeilleurPrix.ToString();
                this.PropostionJ2.Text = "";

                this.PropositionJ1.Background = Brushes.Red;
                this.PropostionJ2.Background = Brushes.Green;

                this.propositionJ2Value = int.Parse(PropositionJ1.Text);

                if (propositionJ2Value > MeilleurPrix)
                {
                    MeilleurPrix = int.Parse(this.PropositionJ1.Text);
                }
                else
                {
                    MessageBox.Show("La proposition doit être supérieure à la meilleure offre actuelle.");
                    return;
                }
            }
        }
    }
}
