using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Monopoly.BDD;
using static Monopoly.IHM.Enchere;

namespace Monopoly.IHM
{
    /// <summary>
    /// Logique d'interaction pour Plateau.xaml
    /// </summary>
    public partial class Plateau : Window
    {
        #region Attributs
        private string f1_j1;
        private string f1_j2;
        private Player joueur1;
        private Player joueur2;
        private Image imgJ1;
        private Image imgJ2;
        private bool isMooveF1Executing;
        private Game game;

        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="f1_j1">Chemin ou nom de l'image du joueur 1</param>
        /// <param name="f1_j2">Chemin ou nom de l'image du joueur 2</param>
        public Plateau(string f1_j1, string f1_j2)
        {
            InitializeComponent();

            this.f1_j1 = f1_j1;
            this.f1_j2 = f1_j2;

            // Configuration initiale de la fenêtre
            this.WindowState = WindowState.Normal;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.ResizeMode = ResizeMode.CanResize;

            InitMonoplace(f1_j1, f1_j2);

            // Maximiser sans bordure
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;

            Jouer.Content = "Joueur 1";

            startGame(this);
        }
        #endregion

        /// <summary>
        /// Initialise la grille Monoplace avec les images des joueurs
        /// </summary>
        /// <param name="f1_j1"></param>
        /// <param name="f1_j2"></param>
        public void InitMonoplace(string f1_j1, string f1_j2)
        {
            Monoplace.Children.Clear();

            // Joueur 1
            imgJ1 = new Image
            {
                Source = new BitmapImage(new Uri($"Image/Monoplaces/{f1_j1}.png", UriKind.RelativeOrAbsolute)),
                Width = 50,
                Height = 50
            };
            (int row1, int col1) = GetGridPosition(0);
            Grid.SetRow(imgJ1, row1);
            Grid.SetColumn(imgJ1, col1);
            imgJ1.RenderTransform = GetRotationTransform(0);
            Monoplace.Children.Add(imgJ1);

            // Joueur 2
            imgJ2 = new Image
            {
                Source = new BitmapImage(new Uri($"Image/Monoplaces/{f1_j2}.png", UriKind.RelativeOrAbsolute)),
                Width = 50,
                Height = 50,
                Margin = new Thickness(10, 10, 0, 0) // Décalage pour éviter la superposition
            };
            (int row2, int col2) = GetGridPosition(1);
            Grid.SetRow(imgJ2, row2);
            Grid.SetColumn(imgJ2, col2);
            imgJ2.RenderTransform = GetRotationTransform(0);
            Monoplace.Children.Add(imgJ2);
        }

        /// <summary>
        /// Démarre le jeu et affiche la console
        /// </summary>
        /// <param name="plateau"></param>
        public void startGame(Plateau plateau)
        {
            this.Show();
            this.ConsoleJeux.Text += " ---- Lancement du jeu ---- \n";
            this.ConsoleJeux.Text += $" ---- Joueur 1 : {f1_j1} ---- \n";
            this.ConsoleJeux.Text += $" ---- Joueur 2 : {f1_j2} ---- \n";


            Board board = new Board();
            this.game = new Game(plateau, board);
            this.game.StartGame(false, false);
            GameContext.CurrentGame = this.game;

        }

        /// <summary>
        /// Affiche les informations d'une carte au clic
        /// </summary>
        private void viewInfoCarte(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image image && image.Tag is string tag && !string.IsNullOrEmpty(tag))
            {
                Card card = new Card(tag);
                List<string> info = card.infoCarte(tag);
                InfoCarte infoCarte = new InfoCarte(info);
                infoCarte.Show();
            }
            else
            {
                MessageBox.Show("Tag de l'image est invalide ou manquant.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Déplace la monoplace du joueur à la nouvelle position
        /// </summary>
        /// <param name="joueur">false pour joueur 1, true pour joueur 2</param>
        /// <param name="position">Nouvelle position sur le plateau</param>
        public void MooveF1(bool joueur, int position)
        {
            if (position < 0 || position > 39)
            {
                MessageBox.Show("Position de joueur invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            (int row, int col) = GetGridPosition(position);

            Image img = joueur ? imgJ2 : imgJ1;
            Thickness margin = joueur ? new Thickness(10, 10, 0, 0) : new Thickness(0);

            // Vérifie si l'image est déjà à la bonne position et avec les bons paramètres
            bool positionChanged = Grid.GetRow(img) != row || Grid.GetColumn(img) != col;
            bool marginChanged = img.Margin != margin;
            bool rotationChanged = !(img.RenderTransform is RotateTransform rt && rt.Angle == GetRotationTransform(position).Angle);

            if (positionChanged)
            {
                // Retire l'image uniquement si elle est déjà présente
                if (img.Parent is Panel parentPanel)
                    parentPanel.Children.Remove(img);

                Grid.SetRow(img, row);
                Grid.SetColumn(img, col);
                img.Margin = margin;
                img.RenderTransform = GetRotationTransform(position);
                Monoplace.Children.Add(img);
            }
            else
            {
                // Met à jour la marge et la rotation uniquement si besoin
                if (marginChanged)
                    img.Margin = margin;
                if (rotationChanged)
                    img.RenderTransform = GetRotationTransform(position);
            }
        }

        /// <summary>
        /// Gère l'ouverture de la fenêtre d'enchère pour une carte
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        private void Enchere(object sender, RoutedEventArgs e)
        {
            if (sender is Image image && image.Tag is string tag && !string.IsNullOrEmpty(tag))
            {
                Card card = new Card(tag);
                List<string> info = card.infoCarte(tag);
                Enchere enchere = new Enchere(info, joueur1, joueur2);
                enchere.Show();
            }
            else
            {
                MessageBox.Show("Tag de l'image est invalide ou manquant.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Calcule la position dans la grille en fonction du numéro de case
        /// </summary>
        /// <param name="position">Position sur le plateau (0-39)</param>
        /// <returns>Tuple (row, col)</returns>
        /// <author>Barthoux Sauze Thomas</author>
        private (int row, int col) GetGridPosition(int position)
        {
            if (position >= 0 && position <= 10)
                return (11, 11 - position + 1);          // Bas (droite à gauche)
            if (position > 10 && position <= 20)
                return (11 - (position - 10), 1);   // Gauche (bas en haut)
            if (position > 20 && position <= 30)
                return (1, position - 20 + 1);      // Haut (gauche à droite)
            if (position > 30 && position < 40)
                return (position - 30 + 1, 11);     // Droite (haut en bas)
            return (0, 0);                          // Position par défaut si invalide
        }

        /// <summary>
        /// Retourne la rotation pour l'image du joueur en fonction de sa position
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        private RotateTransform GetRotationTransform(int position)
        {
            if (position >= 0 && position < 10)
                return new RotateTransform(90);
            else if (position >= 10 && position < 20)
                return new RotateTransform(180);
            else if (position >= 20 && position < 30)
                return new RotateTransform(270);
            else
                return new RotateTransform(0);
        }

        #region Exit
        /// <summary>
        /// Exit the application when the exit menu item is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void ExitToMenu(object sender, RoutedEventArgs e)
        {
            CommandeGeneral commande = new CommandeGeneral();
            int idJoueurDemande = 1; // à redéfinir selon logique
            int idJoueur2 = 0;       // idem
            commande.ExitToMenu(this, idJoueurDemande, idJoueur2);
        }

        #endregion

        /// <summary>
        /// This method is called when the "Jouer" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void Jouer_click(object sender, RoutedEventArgs e)
        {
            if (this.game == null)
            {
                MessageBox.Show("Le jeu n'est pas initialisé.");
                return;
            }
            game.Btn_Clicked = true;
            game.StartGame(game.IsPlayerTurn, game.IsGameOver);
        }
    }
}
