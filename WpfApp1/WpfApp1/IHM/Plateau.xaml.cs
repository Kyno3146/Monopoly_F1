using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private int positionJoueur1;
        private int positionJoueur2;
        private Image imgJ1;
        private Image imgJ2;

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
            
            startGame(this);
        }
        #endregion

        /// <summary>
        /// Initialisation de la monoplace grace au canvas
        /// </summary>
        /// <param name="f1_j1"></param>
        /// <param name="f1_j2"></param>
        /// <author>Barthou Sauze Thomas aidé par Copilot en raison des erreur de build</author>
        public void InitMonoplcace(string f1_j1, string f1_j2)
        {

            // Exemple d'ajout pour le joueur 1
            imgJ1 = new Image();
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
            imgJ2 = new Image();
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
            this.Show();
            this.ConsoleJeux.Text += " ---- Lancement du jeux ---- \n";
            this.ConsoleJeux.Text += " ---- Joueur 1 : " + f1_j1 + " ---- \n";
            this.ConsoleJeux.Text += " ---- Joueur 2 : " + f1_j2 + " ---- \n";
            //this passe en parametre le tableau
            Board board = new Board();
            Game game = new Game(plateau, board);
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
            double cellSize = 50;

            if (!joueur)
            {
                positionJoueur1 = position;
                // Retirer l'image si elle est déjà présente
                Monoplace.Children.Remove(imgJ1);

                // Calculer la position
                (double x, double y) = GetCanvasPosition(positionJoueur1, cellSize);

                // Mettre à jour la position et la rotation
                Canvas.SetLeft(imgJ1, x);
                Canvas.SetTop(imgJ1, y);
                imgJ1.RenderTransform = GetRotationTransform(positionJoueur1);

                // Réajouter l'image si besoin
                if (!Monoplace.Children.Contains(imgJ1))
                    Monoplace.Children.Add(imgJ1);
            }
            else
            {
                positionJoueur2 = position;
                Monoplace.Children.Remove(imgJ2);

                (double x, double y) = GetCanvasPosition(positionJoueur2, cellSize);

                // Décalage pour ne pas superposer avec joueur 1
                Canvas.SetLeft(imgJ2, x + 10);
                Canvas.SetTop(imgJ2, y + 10);
                imgJ2.RenderTransform = GetRotationTransform(positionJoueur2);

                if (!Monoplace.Children.Contains(imgJ2))
                    Monoplace.Children.Add(imgJ2);
            }
        }

        private void Enchere(object sender, RoutedEventArgs e)
        {
            List<string> info = new List<string>();
            var image = sender as Image;
            var tag = image?.Tag?.ToString();
            if (!string.IsNullOrEmpty(tag)) // Ensure 'tag' is not null or empty
            {
                Card card = new Card(tag);
                info = card.infoCarte(tag);
                Enchere enchere = new Enchere(info, f1_j1, f1_j2);
                enchere.Show();
            }
            else
            {
                MessageBox.Show("Tag de l'image est invalide ou manquant.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Fonction de calcul de position et rotation autour du plateau
        private (double x, double y) GetCanvasPosition(int position, double cellSize)
        {
            // Plateau 11x11, cases 0 à 10 en bas, 11 à 20 à gauche, 21 à 30 en haut, 31 à 39 à droite
            double offsetX = 180; // Décalage horizontal pour aligner avec le plateau
            double offsetY = 150;  // Correction : plus de décalage vertical
            int maxIndex = 10;   // 0 à 10 inclus = 11 cases

            double x = 0, y = 0;

            if (position >= 0 && position <= 10)
            {
                // Bas (de droite à gauche)
                x = (maxIndex - position) * cellSize + offsetX;
                y = maxIndex * cellSize + offsetY;
            }
            else if (position > 10 && position <= 20)
            {
                // Gauche (de bas en haut)
                x = offsetX;
                y = (maxIndex - (position - 10)) * cellSize + offsetY;
            }
            else if (position > 20 && position <= 30)
            {
                // Haut (de gauche à droite)
                x = (position - 20) * cellSize + offsetX;
                y = offsetY;
            }
            else if (position > 30 && position < 40)
            {
                // Droite (de haut en bas)
                x = maxIndex * cellSize + offsetX;
                y = (position - 30) * cellSize + offsetY;
            }
            return (x, y);
        }




        private RotateTransform GetRotationTransform(int position)
        {
            if (position < 10)
                return new RotateTransform(90);
            else if (position < 20)
                return new RotateTransform(180);
            else if (position < 30)
                return new RotateTransform(270);
            else
                return new RotateTransform(0);
        }
        #region exit


        private void ExitToMenu(object sender, RoutedEventArgs e)
        {
            CommandeGeneral commande = new CommandeGeneral();
            //a redefinir
            int idjoueurDemande = 1;
            int idJoueur2 = 0;
            commande.ExitToMenu(this, idjoueurDemande, idJoueur2);
        }

        #endregion
    }
}
