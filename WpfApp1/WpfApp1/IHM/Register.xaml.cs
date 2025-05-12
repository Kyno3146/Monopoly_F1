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
    }
}
