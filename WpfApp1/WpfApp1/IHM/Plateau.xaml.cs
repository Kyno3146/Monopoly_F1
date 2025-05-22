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
using Monopoly.BDD;

namespace Monopoly.IHM
{
    /// <summary>
    /// Logique d'interaction pour Plateau.xaml
    /// </summary>
    public partial class Plateau : Window
    {
        #region attribut
        private string f1_j1;
        private string f1_j2;

        private bool dee; // dee en true veut dire joueur 1
        #endregion

        #region Constructeur
        /// <summary>
        /// Contructeur
        /// </summary>
        /// <param name="f1_j1"></param>
        /// <param name="f1_j2"></param>
        public Plateau(string f1_j1, string f1_j2 )
        {
            InitializeComponent();
            // Récupération des monoplaces
            this.f1_j1 = f1_j1;
            this.f1_j2 = f1_j2;

            // Initialisation de la monoplace
            InitMonoplcace(f1_j1, f1_j2);

            // Lancement du jeux
            startGame(this);

        }
        #endregion

        /// <summary>
        /// Initialisation de la monoplace
        /// </summary>
        /// <param name="f1_j1"></param>
        /// <param name="f1_j2"></param>
        /// <author>Barthou Sauze Thomas aidé par Copilot en raison des erreur de build</author>
        public void InitMonoplcace(string f1_j1, string f1_j2)
        {

            // Exemple d'ajout pour le joueur 1
            Image imgJ1 = new Image();
            string path = "Image/Monoplaces/" + f1_j1 + ".png";
            imgJ1.Source = new BitmapImage(new Uri(path, UriKind.Relative));
            imgJ1.Width = 50;
            imgJ1.Height = 50;

            // Position sur le plateau
            int row = 12;
            int col = 12;
            int cellSize = 50;
            Canvas.SetLeft(imgJ1, col * cellSize + 70);
            Canvas.SetTop(imgJ1, row * cellSize + 20);

            //Rotation
            RotateTransform rotateTransform = new RotateTransform(90);
            imgJ1.RenderTransform = rotateTransform;

            Monoplace.Children.Add(imgJ1);


            // Exemple d'ajout pour le joueur 2
            Image imgJ2 = new Image();
            string path2 = "Image/Monoplaces/" + f1_j2 + ".png";
            imgJ2.Source = new BitmapImage(new Uri(path2, UriKind.Relative));
            imgJ2.Width = 50;
            imgJ2.Height = 50;

            // Position sur le plateau
            int row2 = 12;
            int col2 = 12;
            int cellSize2 = 50;
            Canvas.SetLeft(imgJ2, col2 * cellSize2 + 70);
            Canvas.SetTop(imgJ2, row2 * cellSize2 + 50);

            //Rotation
            RotateTransform rotateTransform2 = new RotateTransform(90);
            imgJ2.RenderTransform = rotateTransform2;

            // Ajout de l'image au Canvas
            Monoplace.Children.Add(imgJ2);
        }

        /// <summary>
        /// Lancement de la console et du jeux
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        public void startGame(Plateau plateau)
        {
            ConsoleJeux.Text += " ---- Lancement du jeux ---- \n";
            ConsoleJeux.Text += " ---- Joueur 1 : " + f1_j1 + " ---- \n";
            ConsoleJeux.Text += " ---- Joueur 2 : " + f1_j2 + " ---- \n";
            //this passe en parametre le tableau
            Board board = new Board();
            Game game = new Game(this, board);
            game.StartGame();
        }

        /// <summary>
        /// Affiche les informations de la carte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewInfoCarte(object sender, MouseButtonEventArgs e)
        {
            List<string> Info = new List<string>();
            var image = sender as Image;
            var tag = image?.Tag?.ToString();

            if (!string.IsNullOrEmpty(tag)) // Ensure 'tag' is not null or empty
            {
                Card card = new Card(tag);
                Info = card.infoCarte(tag);
                InfoCarte infoCarte = new InfoCarte(Info);
                infoCarte.Show();
            }
            else
            {
                MessageBox.Show("Tag de l'image est invalide ou manquant.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void MooveF1(bool joueur, int position)
        {
            // Joueur 1
            if (joueur == false)
            {
                // Suppression de l'ancienne image
                Monoplace.Children.Clear();
                // Ajout de la nouvelle image
                Image imgJ1 = new Image();
                string path = "Image/Monoplaces/" + f1_j1 + ".png";
                imgJ1.Source = new BitmapImage(new Uri(path, UriKind.Relative));
                imgJ1.Width = 50;
                imgJ1.Height = 50;
                // Position sur le plateau
                int row = position / 10;
                int col = position % 10;
                int cellSize = 50;
                Canvas.SetLeft(imgJ1, col * cellSize + 70);
                Canvas.SetTop(imgJ1, row * cellSize + 20);
                //Rotation
                switch (position)
                {
                    case < 10:
                        imgJ1.RenderTransform = new RotateTransform(90);
                        break;
                    case >= 10 and < 20:
                        imgJ1.RenderTransform = new RotateTransform(180);
                        break;
                    case >= 20 and < 30:
                        imgJ1.RenderTransform = new RotateTransform(270);
                        break;
                    case >= 30 and < 40:
                        imgJ1.RenderTransform = new RotateTransform(0);
                        break;
                }

            }
            // Joueur 2
            else
            {
                // Suppression de l'ancienne image
                Monoplace.Children.Clear();
                // Ajout de la nouvelle image
                Image imgJ2 = new Image();
                string path = "Image/Monoplaces/" + f1_j2 + ".png";
                imgJ2.Source = new BitmapImage(new Uri(path, UriKind.Relative));
                imgJ2.Width = 50;
                imgJ2.Height = 50;
                // Position sur le plateau
                int row = position / 10;
                int col = position % 10;
                int cellSize = 50;
                Canvas.SetLeft(imgJ2, col * cellSize + 70);
                Canvas.SetTop(imgJ2, row * cellSize + 20);
                //Rotation
                switch (position)
                {
                    case < 10:
                        imgJ2.RenderTransform = new RotateTransform(90);
                        break;
                    case >= 10 and < 20:
                        imgJ2.RenderTransform = new RotateTransform(180);
                        break;
                    case >= 20 and < 30:
                        imgJ2.RenderTransform = new RotateTransform(270);
                        break;
                    case >= 30 and < 40:
                        imgJ2.RenderTransform = new RotateTransform(0);
                        break;
                }


            }

        }


        private void ExitToMenu(object sender, RoutedEventArgs e)
        {
            CommandeGeneral commande = new CommandeGeneral();
            //a redefinir
            int idjoueurDemande = 1;
            int idJoueur2 = 0;
            commande.ExitToMenu(this, idjoueurDemande, idJoueur2);
        }
    }
}
