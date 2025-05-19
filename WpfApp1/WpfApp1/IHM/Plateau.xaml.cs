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
            // Position sur le plateau (exemple)
            Canvas.SetLeft(imgJ1, 400);
            Canvas.SetTop(imgJ1, 300);
            Monoplace.Children.Add(imgJ1);

            // Exemple d'ajout pour le joueur 2
            Image imgJ2 = new Image();
            string path2 = "Image/Monoplaces/" + f1_j2 + ".png";
            imgJ2.Source = new BitmapImage(new Uri(path2, UriKind.Relative));
            imgJ2.Width = 50;
            imgJ2.Height = 50;
            Canvas.SetLeft(imgJ2, 450);
            Canvas.SetTop(imgJ2, 400);
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
            //Game game = new Game(plateau);
            //game.StartGame();
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
            Card card = new Card(tag);
            Info = card.infoCarte(tag);
            InfoCarte infoCarte = new InfoCarte(Info);
            infoCarte.Show();
        }

    }
}
