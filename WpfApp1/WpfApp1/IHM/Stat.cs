using MySql.Data.MySqlClient;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Monopoly.IHM
{
    internal class Stat
    {
        private const string ConnStr = "Server=localhost;Database=monopoly_f1;Uid=root;Pwd=;";

        private static MySqlConnection OuvrirConnexion()
        {
            var conn = new MySqlConnection(ConnStr);
            conn.Open();
            return conn;
        }

        private static void FermerConnexion(MySqlConnection conn)
        {
            if (conn?.State == ConnectionState.Open)
                conn.Close();
        }

        private static List<Tuple<string, long>> GetStringLong(string sql)
        {
            using var conn = OuvrirConnexion();
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            var list = new List<Tuple<string, long>>();
            while (reader.Read())
                list.Add(new(reader.GetString(0), reader.GetInt64(1)));
            return list;
        }

        #region ROOT
        public static void CourbeInscriptions(Canvas cible)
        {
            using var conn = OuvrirConnexion();
            using var cmd = new MySqlCommand("SELECT date_inscription FROM users WHERE date_inscription IS NOT NULL AND date_inscription != '0000-00-00'", conn);
            using var reader = cmd.ExecuteReader();
            var dates = new List<DateTime>();
            while (reader.Read())
            {
                try
                {
                    if (!reader.IsDBNull(0))
                    {
                        var val = reader.GetValue(0);
                        if (val is DateTime dt)
                        {
                            dates.Add(dt.Date);
                        }
                        else if (DateTime.TryParse(val.ToString(), out var parsed))
                        {
                            dates.Add(parsed.Date);
                        }
                    }
                }
                catch { }
            }

            if (dates.Count == 0) return;

            dates.Sort();
            var cumul = new Dictionary<DateTime, int>();
            int c = 0;
            foreach (var d in dates)
                cumul[d] = ++c;

            var model = new PlotModel { Title = "Inscriptions cumulées" };
            model.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "yyyy-MM-dd" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Inscriptions" });
            var s = new LineSeries { MarkerType = MarkerType.Circle };
            foreach (var kv in cumul)
                s.Points.Add(DateTimeAxis.CreateDataPoint(kv.Key, kv.Value));
            model.Series.Add(s);

            AfficherPlotDansCanvas(model, cible);
        }

        public static void DiagrammeFrequentationPropriete(Canvas cible)
        {
            var data = GetStringLong("SELECT nomPropriete, nbPassage FROM propriete");
            data.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            PlotBarChart(data, "Passages", "Fréquentation des propriétés", cible, horizontal: true);
        }

        public static void CourbePartiesJouees(Canvas cible)
        {
            using var conn = OuvrirConnexion();
            var dt = new DataTable();
            using var da = new MySqlDataAdapter("SELECT datePartie FROM historiquepartie", conn);
            da.Fill(dt);

            var dict = new SortedDictionary<DateTime, int>();
            foreach (DataRow row in dt.Rows)
            {
                if (row["datePartie"] is DateTime d)
                    dict[d.Date] = dict.GetValueOrDefault(d.Date) + 1;
            }

            if (dict.Count == 0) return;

            var min = dict.Keys.Min();
            var max = dict.Keys.Max();
            for (var d = min; d <= max; d = d.AddDays(1))
                dict.TryAdd(d, 0);

            var model = new PlotModel { Title = "Parties jouées par jour" };
            model.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "yyyy-MM-dd" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Parties" });

            var s = new LineSeries { MarkerType = MarkerType.Circle };
            foreach (var kv in dict.OrderBy(kv => kv.Key))
                s.Points.Add(DateTimeAxis.CreateDataPoint(kv.Key, kv.Value));
            model.Series.Add(s);
            AfficherPlotDansCanvas(model, cible);
        }

        public static void DiagrammeFrequentationEvenements(Canvas cible)
        {
            var data = GetStringLong("SELECT nomCase, nbPassage FROM caseevenement");
            PlotBarChart(data, "Passages", "Fréquentation des événements", cible, horizontal: true);
        }

        public static void DiagrammeAchatsPropriete(Canvas cible)
        {
            var data = GetStringLong("SELECT nomPropriete, totalachat FROM propriete");
            PlotBarChart(data, "Achats", "Total des achats par propriété", cible);
        }

        public static void DiagrammeCourbesTopEncheres(Canvas cible, int topN = 5)
        {
            using var conn = OuvrirConnexion();
            using var cmd = new MySqlCommand($@"
                SELECT p.id, p.nomPropriete, COUNT(e.id) AS cnt
                FROM enchere e JOIN propriete p ON e.idPropriete = p.id
                GROUP BY p.id, p.nomPropriete ORDER BY cnt DESC LIMIT {topN}
            ", conn);
            var ids = new List<int>();
            var noms = new List<string>();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ids.Add(rdr.GetInt32(0));
                noms.Add(rdr.GetString(1));
            }
            rdr.Close();

            var model = new PlotModel { Title = "Évolution des montants d'enchères" };
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Montant (€)" });
            model.Axes.Add(new CategoryAxis { Position = AxisPosition.Bottom });

            for (int i = 0; i < ids.Count; i++)
            {
                int id = ids[i];
                string nom = noms[i];
                using var cmd2 = new MySqlCommand(
                    "SELECT montantFinal FROM enchere WHERE idPropriete = @id ORDER BY id", conn);
                cmd2.Parameters.AddWithValue("@id", id);
                using var rdr2 = cmd2.ExecuteReader();
                var series = new LineSeries { Title = nom };
                int j = 1;
                while (rdr2.Read())
                {
                    double val = rdr2.GetDouble(0);
                    series.Points.Add(new DataPoint(j++, val));
                }
                model.Series.Add(series);
            }
            AfficherPlotDansCanvas(model, cible);
        }

        public static void DiagrammeEncheresParCase(Canvas cible)
        {
            var data = GetStringLong(@"
                SELECT p.nomPropriete, COUNT(e.id)
                FROM enchere e
                JOIN propriete p ON e.idPropriete = p.id
                GROUP BY p.nomPropriete
            ");
            PlotBarChart(data, "Enchères", "Nombre d'enchères par propriété", cible);
        }

        #endregion

        #region Joueur

        public static void DiagrammePourcentageAchatPropriete(Canvas cible)
        {
            using var conn = OuvrirConnexion();
            using var cmd = new MySqlCommand(
                "SELECT nomPropriete, totalachat, nbPassage FROM propriete WHERE nbPassage > 0", conn);
            using var reader = cmd.ExecuteReader();
            var noms = new List<string>();
            var vals = new List<double>();
            while (reader.Read())
            {
                noms.Add(reader.GetString(0));
                double pourcentage = reader.GetDouble(1) / reader.GetDouble(2) * 100;
                vals.Add(pourcentage);
            }
            PlotBarChart(noms, vals, "Pourcentage d'achat (%)", "Achats par propriété", cible);
        }

        public static void DiagrammeRevenusPropriete(Canvas cible)
        {
            var data = GetStringLong("SELECT nomPropriete, revenueGenere FROM propriete");
            PlotBarChart(data, "Revenus (€)", "Revenus générés par propriété", cible);
        }

        public static void CourbeVictoiresDefaites(Canvas cible, int idJoueur)
        {
            using var conn = OuvrirConnexion();
            using var cmd = new MySqlCommand(@"
                SELECT DATE(datePartie), gagnant, perdant FROM historiquepartie
            ", conn);
            using var rdr = cmd.ExecuteReader();
            var dictV = new SortedDictionary<DateTime, int>();
            var dictD = new SortedDictionary<DateTime, int>();

            while (rdr.Read())
            {
                var d = rdr.GetDateTime(0).Date;
                if (rdr.GetInt32(1) == idJoueur)
                    dictV[d] = dictV.GetValueOrDefault(d) + 1;
                if (rdr.GetInt32(2) == idJoueur)
                    dictD[d] = dictD.GetValueOrDefault(d) + 1;
            }

            int cv = 0, cd = 0;
            var model = new PlotModel { Title = $"Statistiques joueur {idJoueur}" };
            model.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "yyyy-MM-dd" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });

            var sv = new LineSeries { Title = "Victoires", MarkerType = MarkerType.Circle };
            var sd = new LineSeries { Title = "Défaites", MarkerType = MarkerType.Cross };

            var dates = new SortedSet<DateTime>(dictV.Keys.Concat(dictD.Keys));
            foreach (var d in dates)
            {
                cv += dictV.GetValueOrDefault(d);
                cd += dictD.GetValueOrDefault(d);
                sv.Points.Add(DateTimeAxis.CreateDataPoint(d, cv));
                sd.Points.Add(DateTimeAxis.CreateDataPoint(d, cd));
            }

            model.Series.Add(sv);
            model.Series.Add(sd);
            AfficherPlotDansCanvas(model, cible);
        }

        #endregion

        #region Affichage
        private static void PlotBarChart(List<Tuple<string, long>> data, string labelY, string title, Canvas cible, bool horizontal = false)
        {
            var noms = data.Select(d => d.Item1).ToList();
            var vals = data.Select(d => (double)d.Item2).ToList();
            PlotBarChart(noms, vals, labelY, title, cible, horizontal);
        }

        private static void PlotBarChart(List<string> noms, List<double> vals, string labelY, string title, Canvas cible, bool horizontal = false)
        {
            var model = new PlotModel { Title = title };
            if (horizontal)
            {
                var catAxis = new CategoryAxis { Position = AxisPosition.Left };
                catAxis.Labels.AddRange(noms);
                model.Axes.Add(catAxis);
                model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = labelY });

                var bs = new BarSeries();
                bs.ItemsSource = vals.Select((v, i) => new BarItem { Value = v, CategoryIndex = i }).ToList();
                model.Series.Add(bs);
            }
            else
            {
                var catAxis = new CategoryAxis { Position = AxisPosition.Bottom };
                catAxis.Labels.AddRange(noms);
                model.Axes.Add(catAxis);
                model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = labelY });

                //var cs = new ColumnSeries();
                //cs.ItemsSource = vals.Select((v, i) => new ColumnItem { Value = v, CategoryIndex = i }).ToList();
                //model.Series.Add(cs);
            }
            AfficherPlotDansCanvas(model, cible);
        }

        private static void AfficherPlotDansCanvas(PlotModel model, Canvas cible)
        {
            cible.Children.Clear();

            var plotView = new OxyPlot.Wpf.PlotView
            {
                Model = model,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                VerticalAlignment = System.Windows.VerticalAlignment.Stretch
            };

            void ResizePlotView(object sender, SizeChangedEventArgs e)
            {
                plotView.Width = cible.ActualWidth;
                plotView.Height = cible.ActualHeight;
            }

            cible.SizeChanged += ResizePlotView;

            plotView.Width = cible.ActualWidth;
            plotView.Height = cible.ActualHeight;

            Canvas.SetLeft(plotView, 0);
            Canvas.SetTop(plotView, 0);
            cible.Children.Add(plotView);
        }
        #endregion
    }
}