using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monopoly.BDD
{
    public class CommandeGeneral
    {
        public CommandeGeneral() { }

        /// <summary>
        /// Exit the application when the exit menu item is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Barthoux Sauze Thomas</author>
        public void exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
