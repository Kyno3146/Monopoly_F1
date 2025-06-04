using System.Data.Common;
using System.Windows;
using Monopoly.BDD;
using WpfApp1.IHM;
using MySql.Data.MySqlClient;
using System.Windows.Controls;
using System;
using System.Drawing;
using System.Windows.Media;


namespace Monopoly.IHM
{
    /// <summary>
    /// Logique d'interaction pour LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        private int nbLogin =0;

        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Exit the application when the exit menu item is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Connect connect = new Connect();
            if (nbLogin > 2)
            {
                MessageBox.Show("Vous avez atteint le nombre maximum de tentatives de connexion.");
                return;
            }
            int comboboxselected = 0;
            string user = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Password;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez entrer un nom d'utilisateur et un mot de passe.");
                return;
            }

            int userId = connect.Login(user, password);

            if (userId >= 0)
            {
                MessageBox.Show("Connexion réussie !");
                if(ComboPlayer.Text == "Joueur 1")
                {
                    comboboxselected = 0;
                    connect.ConnectJoueur(comboboxselected, user, userId);
                    redirection(comboboxselected);
                }
                else if (ComboPlayer.Text == "Joueur 2")
                {
                    comboboxselected = 1;
                    connect.ConnectJoueur(comboboxselected, user, userId);
                    redirection(comboboxselected);
                }

            }
        }
        
        /// <summary>
        /// Retours mainwindow
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        private void redirection(int comboboxSelected)
        {
            MainWindow window = new MainWindow();
            window.statutUser(comboboxSelected);
            window.Show();

            window.VideoIntro.Visibility = Visibility.Collapsed;
            window.videoIntro.Volume = 0;

            this.Close();
        }


        /// <summary>
        /// Ouvre la page Register
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }


    }
}
