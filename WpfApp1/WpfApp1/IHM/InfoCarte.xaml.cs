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
    /// Logique d'interaction pour InfoCarte.xaml
    /// </summary>
    public partial class InfoCarte : Window
    {
        private List<string> info  = new List<string>();

        public InfoCarte(List<string> info)
        {
            InitializeComponent();
            this.info = info;
            infoLoad(info);
        }

        /// <summary>
        /// Affiche les informations de la carte
        /// </summary>
        /// <param name="info"></param>
        private void infoLoad(List<string> info)
        {
            this.LabelCarte.Content = info[1];
            string imagePath = "Image/" + info[0] + ".png";
            this.imgCarte.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            this.description.Text = info[2];

            // Par défaut, vider les champs
            this.valachat.Text = "";
            this.hypoteque.Text = "";

            // Si valeur d'achat présente
            if (info.Count > 3)
                this.valachat.Text = info[3];

            // Si hypothèque présente
            if (info.Count > 4)
                this.hypoteque.Text = info[4];

            // Si total est présent (en dernière position)
            if (info.Count > 5)
                this.valachat.Text += "\n" + info[info.Count - 1];  // Affiche le total dans valachat
        }

    }
}
