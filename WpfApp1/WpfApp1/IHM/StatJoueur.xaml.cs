using Monopoly.BDD;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Python.Runtime;


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
                "Courbe d'inscription",
                "Courbe de fréquentation",
                "Case évènement le plus visité",
                "Propriété le plus visité",
                "Propriété le plus acheter",
                /// Permet de voir les total enchères en cumulé en fonction des parties
                "Analyse des enchéres",
                "Qu'elle case est le plus au enchére"
            };
            foreach (string item in listeItemRoot)
            {
                this.ListeProprietes.Items.Add(item);
                this.ListeProprietes.Tag = item;
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
                "Courbe de victoire",
                "Enchére gagné par partie",
                "Propriété le plus acheté au enchére",
                "Courbe de vos dépense aux enchére",
                "Courbe de propriété acheté",
                "Courbe de propriété hypothéquer"
            };
            foreach (string item in listeItemUser)
            {
                this.ListeProprietes.Items.Add(item);
                this.ListeProprietes.Tag = item;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Barthouux sauze Thomas</author>
        private void ChoixStat(object sender, MouseButtonEventArgs e)
        {
            /// Python
            PythonEngine.Initialize(); // Initialisation de l'interpréteur Python
            dynamic script = PythonEngine.ImportModule("Graphiques"); // Importation du script Python
            ///

            Connect connexion = new Connect();
            if (this.nom == "root")
            {
                var selectedItem = ListeProprietes.SelectedItem as string; // si tu ajoutes des strings simple
                switch (selectedItem)
                {
                    case "Courbe d'inscription":

                        script.courbe_inscriptions();
                        break;
                    case "Courbe de fréquentation":

                        break;
                    case "Case évènement le plus visité":

                        break;
                    case "Propriété le plus visité":

                        break;
                    case "Propriété le plus acheter":

                        break;
                    case "Analyse des enchéres":

                        break;
                    case "Qu'elle case est le plus cher gagné":

                        
                        break;
                    default:
                        MessageBox.Show("Fonctionnalité non implémentée pour cet utilisateur.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
            }
            else if (this.nom == "invite")
            {
                MessageBox.Show("Vous n'avez pas accès à cette page /n Merci de vous connecter", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                this.realPlayer = false;
                this.Close();
                return;
            }
            else
            {
                string selectedItem = (string)((ListBoxItem)sender).Content;
                switch (selectedItem)
                {
                    case "Courbe de victoire":
                        break;
                    case "Enchére gagné par partie":
                        break;
                    case "Propriété le plus acheté au enchére":
                        break;
                    case "Courbe de vos dépense aux enchére":
                        break;
                    case "Courbe de propriété acheté":
                        break;
                    case "Courbe de propriété hypothéquer":
                        break;
                    default:
                        MessageBox.Show("Fonctionnalité non implémentée pour cet utilisateur.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
            }
        }


        #endregion
    }
}
