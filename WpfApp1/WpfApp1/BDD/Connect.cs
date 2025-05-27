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

        public Connect()
        {
            ConnectBDD(null, null);
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
                MySqlConnection conn = new MySqlConnection($"server={server}; database={database}; user={username}; password={password}; port={port}");
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    connection = conn;
                    this.Isconnect = true;
                    if (mainWindow?.state != null)
                    {
                        mainWindow.state.Foreground = new SolidColorBrush(Colors.Green);
                        mainWindow.state.Text = "Connected";
                    }
                }
                else
                {
                    this.Isconnect = false;
                    if (mainWindow?.state != null)
                    {
                        mainWindow.state.Foreground = new SolidColorBrush(Colors.Red);
                        mainWindow.state.Text = "Not Connected";
                    }
                }
            }
            catch (Exception ex)
            {
                this.Isconnect = false;
                MessageBox.Show(ex.Message);
                mainWindow?.Show();
            }
        }

        #endregion
        #endregion

        #region requette

        private bool isRegistered = false;

        public bool IsRegistered
        {
            get { return isRegistered; }
            set { isRegistered = value; }
        }

        /// <summary>
        /// Login method to check if the user exists in the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <author>Barthoux Sauze Thomas</author>
        public int Login(string user, string password)
        {
            if (connection is not null)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    // Il faut ensuite écrire le texte de la requête, par exemple :  
                    command.CommandText = "Select id from users where username = @username and password = @password";

                    // Si la requête contient des paramètres (c’est le cas ici, avec le paramètre id) il faut régler leur valeur :  
                    // username  
                    DbParameter param = command.CreateParameter();
                    param.DbType = System.Data.DbType.String;
                    param.ParameterName = "@username";
                    param.Value = user;
                    command.Parameters.Add(param);

                    // password  
                    DbParameter param2 = command.CreateParameter();
                    param2.DbType = System.Data.DbType.String;
                    param2.ParameterName = "@password";
                    param2.Value = password;
                    command.Parameters.Add(param2);

                    // Et enfin, exécuter la requête et récupérer les valeurs
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert.ToInt32(reader["id"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1; // Retourne une valeur par défaut en cas d'exception  
                }
            }
            return -1; // Retourne une valeur par défaut si la connexion est nulle  
        }

        /// <summary>
        /// Register method to add a new user to the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <author>Barthoux Sauze Thomas</author>
        public void Register(string username, string password)
        {
            if (connection is not null)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO users (username, password, date_inscription) VALUES (@username, @password, @date)";

                    DbParameter param = command.CreateParameter();
                    param.DbType = System.Data.DbType.String;
                    param.ParameterName = "@username";
                    param.Value = username;
                    command.Parameters.Add(param);

                    DbParameter param2 = command.CreateParameter();
                    param2.DbType = System.Data.DbType.String;
                    param2.ParameterName = "@password";
                    param2.Value = password;
                    command.Parameters.Add(param2);

                    DbParameter param3 = command.CreateParameter();
                    param3.DbType = System.Data.DbType.Date;
                    param3.ParameterName = "@date";
                    param3.Value = DateTime.Now;
                    command.Parameters.Add(param3);

                    command.ExecuteNonQuery();
                    this.isRegistered = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// ConnectJoueur method to update the player connection status in the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="id"></param>
        /// <param name="comboboxselected"></param>
        /// <author>Barthoux Sauze Thomas</author>
        public void ConnectJoueur(int comboboxselected, string username, int id)
        {
            if (connection != null)
            {
                try
                {
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE player_connected SET username = @username, idJoueur = @id WHERE idComboBox = @comboboxselected";

                        var paramUsername = command.CreateParameter();
                        paramUsername.DbType = System.Data.DbType.String;
                        paramUsername.ParameterName = "@username";
                        paramUsername.Value = username;
                        command.Parameters.Add(paramUsername);

                        var paramId = command.CreateParameter();
                        paramId.DbType = System.Data.DbType.Int32;
                        paramId.ParameterName = "@id";
                        paramId.Value = id;
                        command.Parameters.Add(paramId);

                        var paramCombobox = command.CreateParameter();
                        paramCombobox.DbType = System.Data.DbType.Int32;
                        paramCombobox.ParameterName = "@comboboxselected";
                        paramCombobox.Value = comboboxselected;
                        command.Parameters.Add(paramCombobox);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la mise à jour : " + ex.Message);
                }
            }
        }



        /// <summary>
        /// SelectJoueur method to get the list of connected players
        /// </summary>
        /// <returns></returns>
        /// <author>Barthoux Sauze Thomas</author>
        public List<string> SelectJoueur()
        {
            List<string> usernames = new List<string>();
            usernames.Clear();

            if (connection != null)
            {
                try
                {
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT username FROM player_connected";

                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string username = reader.GetString(reader.GetOrdinal("username"));
                                usernames.Add(username);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la lecture des joueurs connectés : " + ex.Message);
                }
            }

            return usernames;
        }

        /// <summary>
        /// GetUser method to retrieve the user ID based on the username
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        /// <author>Barthoux Sauze Thomas</author>
        public int GetUser(string nom)
        {
            int id = -1;
            if (connection != null)
            {
                try
                {
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT id FROM users WHERE username = @username";
                        var paramNom = command.CreateParameter();
                        paramNom.DbType = System.Data.DbType.String;
                        paramNom.ParameterName = "@username";
                        paramNom.Value = nom;
                        command.Parameters.Add(paramNom);
                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = reader.GetInt32(reader.GetOrdinal("id"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la récupération de l'utilisateur : " + ex.Message);
                }
            }
            return id;
        }


        /// <summary>
        /// nbParties method to get the number of games played by a player
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        /// <author>Barthoux Sauze Thomas</author>
        public List<int> StatBasique(int id)
        {
            List<int> statBasique = new List<int>();
            statBasique.Clear();
            if (connection != null)
            {
                try
                {
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT (SELECT COUNT(*) FROM historiquepartie WHERE gagnant = @id) AS nb_gagnes, (SELECT COUNT(*) FROM historiquepartie WHERE perdant = @id) AS nb_perdus, (SELECT COUNT(*) FROM historiquepartie WHERE idJoueur1 = @id OR idJoueur2 = @id) AS nb_total";

                        var paramNom = command.CreateParameter();
                        paramNom.DbType = System.Data.DbType.String;
                        paramNom.ParameterName = "@id";
                        paramNom.Value = id;
                        command.Parameters.Add(paramNom);
                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int nbGagnes = reader.GetInt32(reader.GetOrdinal("nb_gagnes"));
                                int nbPerdus = reader.GetInt32(reader.GetOrdinal("nb_perdus"));
                                int nbTotal = reader.GetInt32(reader.GetOrdinal("nb_total"));
                                statBasique.Add(nbGagnes);
                                statBasique.Add(nbPerdus);
                                statBasique.Add(nbTotal);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la récupération des statistiques : " + ex.Message);
                }
            }
            return statBasique;

            #endregion
        }


        /// <summary>
        /// UpdatePlayerCloseGame method to update the player status when the game is closed
        /// </summary>
        /// <author>Barthoux Sauze Thomas</author>
        public void UpdatePlayerCloseGame()
        {
            if (connection != null)
            {
                try
                {
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE player_connected SET username = 'invite', idJoueur = 9999999 WHERE idJoueur < 9999999";
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la mise à jour des joueurs : " + ex.Message);
                }
            }
        }

        /// <summary>
        /// DisconnectJoueur method to disconnect a player based on the combobox selection
        /// </summary>
        /// <param name="comboboxselected"></param>
        /// <author>Barthoux Sauze Thomas</author>
        public void DisconnectJoueur(int comboboxselected)
        {
            if (connection != null)
            {
                try
                {
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE player_connected SET username = 'invite', idJoueur = 9999999 WHERE idComboBox = @comboboxselected";
                        var paramCombobox = command.CreateParameter();
                        paramCombobox.DbType = System.Data.DbType.Int32;
                        paramCombobox.ParameterName = "@comboboxselected";
                        paramCombobox.Value = comboboxselected;
                        command.Parameters.Add(paramCombobox);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la déconnexion du joueur : " + ex.Message);
                }
            }
        }



    }
}
