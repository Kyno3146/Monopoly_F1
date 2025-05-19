using System;
using System.Web;
using System.Windows;

public class Card {
	private string description;
	private Effects effectType;
	private int value;
	private int hypoteque;
	private int coutupgrade; 
	private string NomCarte;
	private Property property;

	/// <summary>
	/// Constructor
	/// </summary>
	public Card(string card) {
		this.NomCarte = card;
	}
	public void ApplyEffect(Player p, Game g) {
		throw new System.NotImplementedException("Not implemented");
	}

	private Effects effects;

	private CardSpace cardSpace;

    /// <summary>
    /// Returns the name of the card
    /// </summary>
    /// <param name="nom"></param>
    /// <returns></returns>
	/// <author>Barthoux Sauze Thomas</author>
    public List<string> infoCarte(string nom)
    {
        List<string> info = new List<string>();

        switch (nom)
        {
            case "case_depart":
                info.Add(nom);
                info.Add("Case de départ");
                this.description = "Feux aux vert vous gagner 200 000€";
                info.Add(this.description);
                this.value = 200000;
                info.Add("+" + this.value.ToString());
                break;

            case "case_Hongrie":
                info.Add(nom);
                info.Add("Circuit de Hongrie");
                this.description = "Circuit de Hongrie";
                info.Add(this.description);
                this.value = 60000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_f1_radio1":
            case "case_f1_radio_team2":
            case "case_f1_radio_team3":
                info.Add(nom);
                info.Add("Radio F1 - Événement");
                this.description = "Une communication radio intervient. Votre ingénieur vous répond.";
                info.Add(this.description);
                break;

            case "case_Canada":
                info.Add(nom);
                info.Add("Circuit du Canada");
                this.description = "Circuit de Montréal";
                info.Add(this.description);
                this.value = 60000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_formula_e":
                info.Add(nom);
                info.Add("Formule E");
                this.description = "Découvrez la compétition électrique";
                info.Add(this.description);
                this.value = 200000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_licence":
                info.Add(nom);
                info.Add("Licence Pilote");
                this.description = "Vous obtenez une licence de course. Nécessaire pour certaines compétitions.";
                info.Add(this.description);
                this.value = 200000;
                info.Add("-" + this.value.ToString());
                break;

            case "case_imola":
                info.Add(nom);
                info.Add("Circuit d'Imola");
                this.description = "Circuit légendaire d'Italie";
                info.Add(this.description);
                this.value = 100000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_fia":
                info.Add(nom);
                info.Add("FIA - Événement");
                this.description = "Visite à la FIA, événement spécial ou amende";
                info.Add(this.description);
                break;

            case "case_jeddah":
                info.Add(nom);
                info.Add("Circuit de Jeddah");
                this.description = "Course urbaine en Arabie Saoudite";
                info.Add(this.description);
                this.value = 100000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_gpabu":
                info.Add(nom);
                info.Add("Grand Prix d'Abu Dhabi");
                this.description = "Dernière course de la saison";
                info.Add(this.description);
                this.value = 120000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_raceban":
                info.Add(nom);
                info.Add("Interdiction de Course");
                this.description = "Vous êtes suspendu pour une course.";
                info.Add(this.description);
                break;

            case "case_azerbaijan":
                info.Add(nom);
                info.Add("Circuit d'Azerbaïdjan");
                this.description = "Course dans les rues de Bakou";
                info.Add(this.description);
                this.value = 140000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_prost":
                info.Add(nom);
                info.Add("Légende - Alain Prost");
                this.description = "Vous rencontrez Alain Prost. Gagnez une carte bonus.";
                info.Add(this.description);
                this.value = 150000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_austin":
                info.Add(nom);
                info.Add("Circuit d'Austin");
                this.description = "Course au Texas, USA";
                info.Add(this.description);
                this.value = 140000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_mexico":
                info.Add(nom);
                info.Add("Grand Prix du Mexique");
                this.description = "Course en altitude, Mexico City";
                info.Add(this.description);
                this.value = 160000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_gt_world":
                info.Add(nom);
                info.Add("GT World");
                this.description = "Championnat du monde GT, participez avec votre écurie.";
                info.Add(this.description);
                this.value = 200000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_Pays_Bas":
                info.Add(nom);
                info.Add("Circuit des Pays-Bas");
                this.description = "Course à Zandvoort";
                info.Add(this.description);
                this.value = 180000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_chine":
                info.Add(nom);
                info.Add("Grand Prix de Chine");
                this.description = "Course sur le circuit de Shanghai";
                info.Add(this.description);
                this.value = 180000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_bahrain":
                info.Add(nom);
                info.Add("Grand Prix du Bahreïn");
                this.description = "Course nocturne dans le désert";
                info.Add(this.description);
                this.value = 200000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_trevehivernal":
                info.Add(nom);
                info.Add("Trêve Hivernale");
                this.description = "Pause dans la saison. Aucun effet.";
                info.Add(this.description);
                break;

            case "case_vegas":
                info.Add(nom);
                info.Add("Grand Prix de Las Vegas");
                this.description = "Course spectaculaire sur le Strip";
                info.Add(this.description);
                this.value = 220000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_australie":
                info.Add(nom);
                info.Add("Grand Prix d'Australie");
                this.description = "Course d'ouverture à Melbourne";
                info.Add(this.description);
                this.value = 220000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_autriche":
                info.Add(nom);
                info.Add("Grand Prix d'Autriche");
                this.description = "Red Bull Ring";
                info.Add(this.description);
                this.value = 240000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_wrc":
                info.Add(nom);
                info.Add("Championnat WRC");
                this.description = "Participer au rallye mondial";
                info.Add(this.description);
                this.value = 200000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_singapour":
                info.Add(nom);
                info.Add("Grand Prix de Singapour");
                this.description = "Course nocturne dans les rues";
                info.Add(this.description);
                this.value = 260000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_silverstone":
                info.Add(nom);
                info.Add("Silverstone - Royaume-Uni");
                this.description = "L'un des circuits les plus anciens";
                info.Add(this.description);
                this.value = 260000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_Senna":
                info.Add(nom);
                info.Add("Légende - Ayrton Senna");
                this.description = "Hommage à Senna. Bonus de popularité.";
                info.Add(this.description);
                this.value = 150000;
                info.Add(this.value.ToString());
                break;

            case "case_espagne":
                info.Add(nom);
                info.Add("Grand Prix d'Espagne");
                this.description = "Circuit de Barcelone";
                info.Add(this.description);
                this.value = 280000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_commisaire":
                info.Add(nom);
                info.Add("Bureau des Commissaires");
                this.description = "Inspection ou pénalité possible.";
                info.Add(this.description);
                MessageBox.Show("Cela seras un Race Ban pour vous !");
                break;

            case "case_japon":
                info.Add(nom);
                info.Add("Grand Prix du Japon");
                this.description = "Circuit de Suzuka";
                info.Add(this.description);
                this.value = 300000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_bresil":
                info.Add(nom);
                info.Add("Grand Prix du Brésil");
                this.description = "Course à Interlagos";
                info.Add(this.description);
                this.value = 300000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_belgique":
                info.Add(nom);
                info.Add("Grand Prix de Belgique");
                this.description = "Spa-Francorchamps";
                info.Add(this.description);
                this.value = 320000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_wec":
                info.Add(nom);
                info.Add("Championnat WEC");
                this.description = "World Endurance Championship";
                info.Add(this.description);
                this.value = 200000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_monza":
                info.Add(nom);
                info.Add("Circuit de Monza");
                this.description = "Temple de la vitesse en Italie";
                info.Add(this.description);
                this.value = 350000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            case "case_amende_FIA":
                info.Add(nom);
                info.Add("Amende FIA");
                this.description = "Vous recevez une amende. Payer 100 000€";
                info.Add(this.description);
                this.value = 100000;
                info.Add("-" + this.value.ToString());
                break;

            case "case_monaco":
                info.Add(nom);
                info.Add("Grand Prix de Monaco");
                this.description = "Course urbaine prestigieuse";
                info.Add(this.description);
                this.value = 400000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                break;

            default:
                info.Add(nom);
                info.Add("Case inconnue");
                this.description = "Aucune information disponible pour cette case.";
                info.Add(this.description);
                break;
        }

        return info;
    }


}
