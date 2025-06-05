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
    /// Logique d'interaction pour StatJoueur.xaml
    /// </summary>
    public partial class StatJoueur : Window
    {
        #region Attributs
        private string nom;
        private Connect connexion;
        private List<string> listeItemRoot;
        private List<string> listeItemUser;
        public bool realPlayer = true;
        #endregion

        #region Constructeurs
        public StatJoueur(string nom)
        {
            this.nom = nom;
            InitializeComponent();
            InitIHM(this.nom);
            VerificationUser(nom);
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Affiche les premiéres données de l'utilisateur dans la fenêtre
        /// </summary>
        /// <param name="nom"></param>
        /// <author>Barthoux Sauze Thomas</author>
        public void InitIHM(string nom)
        {
            this.connexion = new Connect();
            this.NomJoueur.Text = "Statistique de " + nom;
            int idJoueur = connexion.GetUser(nom);
            List<int> StatBasique = connexion.StatBasique(idJoueur);
            if (StatBasique.Count > 0)
            {
                this.NbPartieJouerValue.Text = StatBasique[2].ToString();
                this.NbPartieGagnerValue.Text = StatBasique[0].ToString();
                this.NbPartiePerduValue.Text = StatBasique[1].ToString();

                double ratio = (double)StatBasique[0] / StatBasique[2];
                this.RatioValue.Text = (ratio * 100).ToString("0.00") + " %";
            }
            else
            {
                MessageBox.Show("Aucune statistique trouvée pour ce joueur.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void VerificationUser(string nom)
        {
            if (nom.Equals("root"))
            {
                listItemRoot();
            }
            else if (nom.Equals("invite"))
            {
                MessageBox.Show("Vous n'avez pas accès à cette page /n Merci de vous connecter", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                this.realPlayer = false;
                this.Close();
                return;
            }
            else
            {
                listItemUser();
            }
        }

        /// <summary>
        /// Affiche les options disponibles pour un utilisateur Root dans la liste des propriétés
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        public void listItemRoot()
        {
            this.listeItemRoot = new List<string>
            {
                "1",
                "2",
                "3",
                "4"
            };
            foreach (string item in listeItemRoot)
            {
                this.ListeProprietes.Items.Add(item);
            }
        }

        /// <summary>
        /// Affiche les options disponibles pour un utilisateur normal dans la liste des propriétés
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        public void listItemUser()
        {
            this.listeItemUser = new List<string>
            {
                "Voir les statistiques personnelles",
                "Voir les parties en cours",
                "Voir les parties terminées"
            };
            foreach (string item in listeItemUser)
            {
                this.ListeProprietes.Items.Add(item);
            }
        }

        #endregion
    }
}
