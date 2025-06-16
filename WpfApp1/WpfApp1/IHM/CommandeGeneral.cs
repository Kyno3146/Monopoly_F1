using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Monopoly.IHM;
using WpfApp1.IHM;

namespace Monopoly.BDD
{
    public class CommandeGeneral
    {
        private Connect connexion = new Connect();

        public CommandeGeneral() { }

        /// <summary>  
        /// Exit the application when the exit menu item is clicked.  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        /// <author>Barthoux Sauze Thomas</author>  
        public void exit(object sender, RoutedEventArgs e)
        {
            // reset des joueurs en ligne
            connexion.UpdatePlayerCloseGame();

            Application.Current.Shutdown();
        }

        /// <summary>
        /// Exit to the main menu when the exit button is clicked.
        /// </summary>
        /// <param name="plateau"></param>
        /// <author>Barthoux Sauze Thomas</author>
        public void ExitToMenu(Plateau plateau, int idjoueurDemande, int idJoeur2)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Vous avez quitté le jeu", "Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Code pour quitter le jeu
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                plateau.Close();

                // Mettre à jour la base de données pour le joueur qui a quitté


            }

        }
    }
}
