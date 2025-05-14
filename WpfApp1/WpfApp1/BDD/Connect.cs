using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Media;
using System.Windows;
using System.Data.Common;
using WpfApp1.IHM;

namespace Monopoly.BDD
{
    public class Connect
    {
        #region Database
        #region attributs
        /// <summary>
        /// Connection to the database
        /// </summary>
        private DbConnection connection;
        /// <summary>
        /// Connection a mainwindow
        /// </summary>
        private MainWindow mainWindow;
        /// <summary>
        /// Boolean to check if the connection is established
        /// </summary>
        private bool isConnect = false;

        #endregion

        #region constructor
        public Connect(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            ConnectBDD(mainWindow, null);
        }

        public bool Isconnect { get; private set; }
        #endregion

        #region methods
        private void ConnectBDD(object sender, RoutedEventArgs e)
        {

            string server = "localhost";
            string database = "Monopoly_f1";
            string username = "root";
            string password = "";
            string port = "3306";
            try
            {
                MySqlConnection conn = new MySqlConnection($"server={server}; database ={database}; username ={username}; password ={password}; port ={port}");
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    connection = conn;
                    if (mainWindow?.state != null)
                    {
                        mainWindow.state.Foreground = new SolidColorBrush(Colors.Green);
                        mainWindow.state.Text = "Connected";
                        this.Isconnect = true;
                    }
                }
                else
                {
                    if (mainWindow?.state != null)
                    {
                        mainWindow.state.Foreground = new SolidColorBrush(Colors.Red);
                        mainWindow.state.Text = "Not Connected";
                    }
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                mainWindow.Show();
            }
        }

        #endregion
        #endregion
    }
}
