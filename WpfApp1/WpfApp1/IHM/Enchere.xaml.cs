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

        public Enchere(List<string> info, Player joueur1, Player joueur2)
        {
            InitializeComponent();
            this.info = info;
            this.joueur1 = joueur1;
            this.joueur2 = joueur2;
            infoLoad(info);
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
            this.LabelCarte.Content = info[1];
            string imagePath = "Image/" + info[0] + ".png";
            imgCarte.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));

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

            if (GameContext.CurrentGame != null && GameContext.CurrentGame.IsPlayerTurn)
            {
                PropositionJ1.Background = Brushes.Green;
                PropostionJ2.Background = Brushes.Red;
            }
            else
            {
                PropositionJ1.Background = Brushes.Red;
                PropostionJ2.Background = Brushes.Green;
            }

            this.MeilleurPrix = 0;

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
        /// Checks if the "Abandonner" button is pressed and prompts the user for confirmation.
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        public void checkAbandon(object sender, RoutedEventArgs e)
        {
            if (this.Abandonner.IsPressed)
            {
                MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment abandonner l'enchère ?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Vous avez abandonné l'enchère.");
                    if (!IsplayerTurn)
                    {
                        // Joueur 1 abandonne, donc c'est au joueur 2 de jouer  
                        joueur2.account -= MeilleurPrix; // Joueur 2 gagne l'enchère  
                    }
                    else
                    {
                        // Joueur 2 abandonne, donc c'est au joueur 1 de jouer  
                        joueur1.account -= MeilleurPrix; // Joueur 1 gagne l'enchère  
                    }
                    this.Close();
                }
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
            if (this.PropositionJ1.Text == "" && this.PropostionJ2.Text == "")
            {
                MessageBox.Show("Veuillez entrer une proposition pour enchérir.");
                return;
            }
            else if (this.PropositionJ1.Text != "") // Joueur 1 propose
            {
                if (int.TryParse(this.PropositionJ1.Text, out J1Values))
                {
                    if (J1Values > this.MeilleurPrix && J1Values <= this.joueur1.account)
                    {
                        this.MeilleurPrix = J1Values;
                        MessageBox.Show($"{joueur1.Name} a enchéri {J1Values}.");
                        IsplayerTurn = true; // Passage au joueur 2
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
            else if (this.PropostionJ2.Text != "") // Joueur 2 propose
            {
                if (int.TryParse(this.PropostionJ2.Text, out J2Values))
                {
                    if (J2Values > this.MeilleurPrix && J2Values <= this.joueur2.account)
                    {
                        this.MeilleurPrix = J2Values;
                        MessageBox.Show($"{joueur2.Name} a enchéri {J2Values}.");
                        IsplayerTurn = false; // Passage au joueur 1
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
        }


        public static class GameContext
        {
            public static Game CurrentGame { get; set; }
        }
    }
}
