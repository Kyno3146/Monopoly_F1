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
        private int J1Values;
        private int J2Values;
        private bool IsplayerTurn = false; // false = joueur 1, true = joueur 2

        public Enchere(List<string> info, Player joueur1, Player joueur2, Game game)
        {
            InitializeComponent();
            this.info = info;
            if (game.IsPlayerTurnGame == false)
            {
                this.joueur1 = joueur1;
                this.joueur2 = joueur2;
            }
            else
            {
                this.joueur1 = joueur2;
                this.joueur2 = joueur1;
            }

            this.game = game;
            infoLoad(info);
            this.meilleurPrix = 0;

        }

        public int meilleurPrix
        {
            get { return MeilleurPrix; }
            set { MeilleurPrix = value; }
        }


        /// <summary>  
        /// Load the information of the card in the auction window.  
        /// </summary>  
        /// <param name="info"></param>  
        ///<author>Barthoux Sauze Thomas</author>  
        private void infoLoad(List<string> info)
        {
            MessageBox.Show(info[0].ToString());
            this.LabelCarte.Content = info[1];
            string imagePath = "Image/" + info[0] + ".png";
            imgCarte.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));

            this.description.Text = info[2];

            // Par défaut, vider les champs  
            this.valachat.Text = "";

            // Si valeur d'achat présente  
            if (info.Count > 3)
                this.valachat.Text = info[3];


            // Affichage des joueurs  
            this.Joueur1.Content += joueur1.Name;
            this.Joueur2.Content += joueur2.Name;

            if (GameContext.CurrentGame != null && game.IsPlayerTurnGame)
            {
                PropositionJ1.Background = Brushes.Red;
                PropostionJ2.Background = Brushes.Green;
            }
            else
            {
                PropositionJ1.Background = Brushes.Green;
                PropostionJ2.Background = Brushes.Red;
            }

        }

        /// <summary>
        /// Loads the text and enables/disables the input fields based on the current player's turn.
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        private void LoadText()
        {
            if (!IsplayerTurn) //Joueur 1
            {
                this.PropositionJ1.Text = "";
                this.PropostionJ2.Text = this.meilleurPrix.ToString();
                this.PropositionJ1.IsEnabled = true;
                this.PropostionJ2.IsEnabled = false;
                this.PropositionJ1.Background = Brushes.Green;
                this.PropostionJ2.Background = Brushes.Red;
            }
            else
            {
                this.PropositionJ1.Text = this.meilleurPrix.ToString();
                this.PropostionJ2.Text = "";
                this.PropositionJ1.IsEnabled = false;
                this.PropostionJ2.IsEnabled = true;
                this.PropositionJ1.Background = Brushes.Red;
                this.PropostionJ2.Background = Brushes.Green;
            }
        }

        /// <summary>
        /// This method is called when the "Enchérir" button is clicked.
        /// </summary>
        /// <param name="sender"></param>'
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void encherir(object sender, RoutedEventArgs e)
        {
            if (this.PropositionJ1.IsEnabled && !string.IsNullOrWhiteSpace(this.PropositionJ1.Text))
            {
                if (int.TryParse(this.PropositionJ1.Text, out J1Values))
                {
                    if (J1Values > this.meilleurPrix && J1Values <= this.joueur1.account)
                    {
                        this.meilleurPrix = J1Values;
                        MessageBox.Show($"{joueur1.Name} a enchéri {J1Values}.");
                        IsplayerTurn = true;
                        LoadText();
                    }
                    else
                    {
                        MessageBox.Show("Proposition invalide ou insuffisante.");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez entrer un nombre valide pour l'enchère du joueur 1.");
                }
            }
            else if (this.PropostionJ2.IsEnabled && !string.IsNullOrWhiteSpace(this.PropostionJ2.Text))
            {
                if (int.TryParse(this.PropostionJ2.Text, out J2Values))
                {
                    if (J2Values > this.meilleurPrix && J2Values <= this.joueur2.account)
                    {
                        this.meilleurPrix = J2Values;
                        MessageBox.Show($"{joueur2.Name} a enchéri {J2Values}.");
                        IsplayerTurn = false;
                        LoadText();
                    }
                    else
                    {
                        MessageBox.Show("Proposition invalide ou insuffisante.");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez entrer un nombre valide pour l'enchère du joueur 2.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer une proposition pour enchérir.");
            }
        }


        /// <summary>
        /// This class holds the current game context, allowing access to the current game instance.
        /// </summary>
        public static class GameContext
        {
            public static Game CurrentGame { get; set; }
        }


        /// <summary>
        /// Checks if the "Abandonner" button is pressed and prompts the user for confirmation.
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        private void Abandon(object sender, RoutedEventArgs e)
        {
            // Demande de confirmation
            if (MessageBox.Show("Voulez-vous vraiment abandonner l'enchère ?", "Confirmation", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            MessageBox.Show("Vous avez abandonné l'enchère.");

            // Recherche de la propriété concernée (à adapter selon ta logique exacte)
            Property proprieteEncheree = null;
            if (info.Count > 0)
            {
                foreach (var space in GameContext.CurrentGame.Board.spaces)
                {
                    if (space is Property prop && prop.position == getpositon())
                    {
                        proprieteEncheree = prop;
                        break;
                    }
                }
            }

            // Déterminer le joueur gagnant
            var gagnant = IsplayerTurn ? joueur1 : joueur2;

            // Débiter le compte et ajouter la propriété
            gagnant.account -= MeilleurPrix;

            if (proprieteEncheree != null)
            {
                var list = gagnant.properties?.ToList() ?? new List<Property>();
                list.Add(proprieteEncheree);
                proprieteEncheree.player = gagnant; // Assigner le joueur gagnant à la propriété
                gagnant.properties = list.ToArray();

                // Mise à jour des compteurs selon la position
                if (new[] { 5, 15, 25, 35 }.Contains(proprieteEncheree.position))
                    gagnant.nb_championships++;
                else if (new[] { 12, 28 }.Contains(proprieteEncheree.position))
                    gagnant.nb_museums++;
            }

            this.Close();
        }

        /// <summary>
        /// Returns the position of the player based on whose turn it is.
        /// Use for abandon
        /// </summary>
        /// <returns></returns>
        private int getpositon()
        {
            return game.IsPlayerTurnGame ? joueur2.position : joueur1.position;
        }


    }
}
