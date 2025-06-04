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
using WpfApp1.IHM;

namespace Monopoly.IHM
{
    /// <summary>  
    /// Logique d'interaction pour Register.xaml  
    /// </summary>  
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        /// <summary>  
        /// Retour au menu login  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        /// <author>Barthoux Sauze Thomas</author>  
        private void Back_Login(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        /// <summary>  
        /// Enregistrement d'un nouvel utilisateur  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void RegisterUser(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Inscription réussie !", "Monopoly", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Connect connect = new Connect();
            string user = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Password;
            connect.Register(user, password);
            if (connect.IsRegistered.Equals(true)) 
            {
                MessageBox.Show("Inscription réussie !", "Monopoly", MessageBoxButton.OK, MessageBoxImage.Information);
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'inscription. Veuillez réessayer.", "Monopoly", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            mainWindow.Introfin(sender, e);
            this.Close();
        }
    }
}
