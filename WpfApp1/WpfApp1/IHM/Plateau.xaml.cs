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
    /// Logique d'interaction pour Plateau.xaml
    /// </summary>
    public partial class Plateau : Window
    {
        #region attribut
        private string f1_j1;
        private string f1_j2;
        #endregion

        #region Constructeur
        /// <summary>
        /// Contructeur
        /// </summary>
        /// <param name="f1_j1"></param>
        /// <param name="f1_j2"></param>
        public Plateau(string f1_j1, string f1_j2 )
        {
            InitializeComponent();
            this.f1_j1 = f1_j1;
            this.f1_j2 = f1_j2;
            MessageBox.Show(f1_j1);
            MessageBox.Show(f1_j2);
        }
        #endregion

    }
}
