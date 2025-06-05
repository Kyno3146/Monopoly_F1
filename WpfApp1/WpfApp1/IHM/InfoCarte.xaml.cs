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
        #region Attributs
        private List<string> info  = new List<string>();
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur de la fenêtre d'information de la carte.
        /// </summary>
        /// <param name="info"></param>
        public InfoCarte(List<string> info)
        {
            InitializeComponent();
            this.info = info;
            infoLoad(info);
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Affiche les informations de la carte
        /// </summary>
        /// <param name="info"></param>
        /// <author>Barthoux Sauze Thomas</author>
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
            {
                int position = int.Parse(info[5]);
                if (OnGetRent != null)
                {
                    int rent = OnGetRent(position);
                    this.loyer.Text = rent.ToString() + " €";
                }
                else
                {
                    this.loyer.Text = "N/A";
                }
            }

        }

        /// <summary>
        /// Delegate to get the rent for a property based on its position.
        /// </summary>
        /// <author >Ia</author>
        public Func<int, int>? OnGetRent { get; set; }

        /// <summary>
        /// Closes the InfoCarte window when the exit button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void ExitInfo(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
