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
using Monopoly.BDD;
using Monopoly.IHM;

namespace WpfApp1.IHM
{
    /// <summary>  
    /// Interaction logic for MainWindow.xaml  
    /// </summary>  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        /// <summary>
        /// Open la fenetre pour lancer une partie 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JouerPartie(object sender, RoutedEventArgs e)
        {
            Plateau plateau = new Plateau();
            plateau.Show();
            this.Close();
        }
    }
}