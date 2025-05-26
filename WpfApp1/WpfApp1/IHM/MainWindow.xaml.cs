using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Monopoly.BDD;
using Monopoly.IHM;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System;

namespace WpfApp1.IHM
{
    /// <summary>  
    /// Interaction logic for MainWindow.xaml  
    /// </summary>  
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private int attemptCount = 0;
        private const int MaxAttempts = 5;

        private string username1;
        private string username2;
        private int comboboxselected;


        public static bool Connected { get; set; } = false;

        public MainWindow()
        {
            InitializeComponent();
            InitTimer();
            
        }

        /// <summary>
        /// Exit the application when the exit menu item is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit(object sender, RoutedEventArgs e)
        {
            CommandeGeneral commandeGeneral = new CommandeGeneral();
            commandeGeneral.exit(sender, e);
        }

        /// <summary>
        /// Open the login page when the login button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void LoginPage(object sender, RoutedEventArgs e)
        {
            if (Connected != false)
            {
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Close();
            }
        }

        /// <summary>
        /// Open la fenetre pour lancer une partie 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JouerPartie(object sender, RoutedEventArgs e)
        {
            if (Connected != false)
            {
                SelectF1 selectF1 = new SelectF1();
                selectF1.Show();
                this.Close();
            }
        }

        #region Statut Serveur
        /// <summary>
        /// Initialise le timer pour le test de connexion
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        private void InitTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// Vérifie le statut du serveur toutes les 10 secondes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Copilot-Visual</author>
        private void Timer_Tick(object sender, EventArgs e)
        {
            ServeurStatut();
        }

        /// <summary>
        /// Vérifie que le serveur est bien connecté
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        public void ServeurStatut()
        {
            if (attemptCount >= MaxAttempts)
            {
                Console.WriteLine("Nombre maximal de tentatives atteint. La connexion sera réessayée plus tard.");
                return; // Ne pas faire de nouvelle tentative
            }

            Connect connect = new Connect(this); // Crée une seule instance ici
            Connected = connect.Isconnect;

            if (Connected)
            {
                attemptCount = 0;
                Console.WriteLine("Connexion réussie.");
            }
            else
            {
                attemptCount++;
                Console.WriteLine($"Tentative de connexion échouée. Nombre de tentatives : {attemptCount}");
            }
        }

        /// <summary>
        /// Vérifie si le timer est tjr actif
        /// </summary>
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        protected override void OnClosed(EventArgs e)
        {
            timer?.Stop();
            base.OnClosed(e);
        }
        #endregion

        /// <summary>
        ///
        /// </summary>
        /// <param name="comboboxSelected"></param>
        public void statutUser(int comboboxSelected)
        {
            Connect connect = new Connect(this);
            List<string> Users = connect.SelectJoueur();

            // Réinitialisation par défaut
            User1.Content = "";
            User2.Content = "";
            icon1.Foreground = Brushes.Gray;
            icon2.Foreground = Brushes.Gray;

            // Affichage conditionnel
            if (Users.Count >= 1 && !string.IsNullOrWhiteSpace(Users[0]))
            {
                this.username1 = Users[0];
                User1.Content = Users[0];
                User1.Foreground = Brushes.Red;
                icon1.Foreground = Brushes.Red;
                User1.Tag = Users[0];
            }

            if (Users.Count >= 2 && !string.IsNullOrWhiteSpace(Users[1]))
            {
                this.username2 = Users[1];
                User2.Content = Users[1];
                User2.Foreground = Brushes.Green;
                icon2.Foreground = Brushes.Green;
                User2.Tag = Users[1];
            }
        }


        private void user1IHM(object sender, RoutedEventArgs e)
        {
            StatJoueur statJoueur = new StatJoueur(username1);
            statJoueur.Show();
        }

        private void user2IHM(object sender, RoutedEventArgs e)
        {
            StatJoueur statJoueur = new StatJoueur(username2);
            statJoueur.Show();
        }
    }
}