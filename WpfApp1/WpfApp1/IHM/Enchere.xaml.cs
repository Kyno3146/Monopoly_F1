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
        private string joueur1; // Renamed field to lowercase to avoid conflict  
        private string joueur2;

        public Enchere(List<string> info, string joueur1, string joueur2)
        {
            InitializeComponent();
            this.info = info;
            this.joueur1 = joueur1;
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
            string imagePath = "Image/" + info[0] + ".png";
            this.imgCarte.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
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
            this.Joueur1.Content = "";
        }
    }
}
