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
            this.f1_j1 = f1_j1;
            this.f1_j2 = f1_j2;
            MessageBox.Show(f1_j1);
            MessageBox.Show(f1_j2);

            // Lancement de la console du jeux
            lancementConsole();

            // Initialisation de la monoplace
            InitMonoplcace(f1_j1, f1_j2);

            // Initialisation du dee
            this.dee = true;
            lancementDee(dee); // Lancement du dee

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


        public void lancementConsole()
        {
            ConsoleJeux.Foreground = Brushes.Black;
            ConsoleJeux.Text = " ---- Lancement du jeux ---- \n";
        }

        public void lancementDee(bool dee)
        {
            int resultDee = 0;
            Random rand = new Random();
            resultDee = rand.Next(1, 7);
            if (dee)
            {
                ConsoleJeux.Text += "C'est à " + f1_j1 + " de jouer \n";
                ConsoleJeux.Text += "Lancer de dé : " + resultDee + "\n";
                dee = false;
            }
            else
            {
                ConsoleJeux.Text += "C'est à " + f1_j2 + " de jouer \n";
                ConsoleJeux.Text += "Lancer de dé : " + resultDee + "\n";
                dee = true;
            }
        }

    }
}
