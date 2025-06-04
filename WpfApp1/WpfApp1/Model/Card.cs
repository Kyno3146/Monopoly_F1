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

        // Gestion des diff�rentes case 
        switch (nom)
        {
            case "case_depart":
            case "0":
                nom = "case_depart";
                info.Add(nom);
                info.Add("Case de d�part");
                this.description = "Feux aux vert vous gagner 200 000�";
                info.Add(this.description);
                this.value = 200000;
                info.Add("+" + this.value.ToString());
                break;

            case "case_Hongrie":
            case "1":
                nom = "case_Hongrie";
                info.Add(nom);
                info.Add("Circuit de Hongrie");
                this.description = "Circuit de Hongrie";
                info.Add(this.description);
                this.value = 60000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(1.ToString());
                break;

            case "case_f1_radio1":
            case "case_radio_f1_team2":
            case "case_radio_f1_team3":
            case "2":
            case "17":
            case "33":
                if (nom == "2")
                    nom = "case_f1_radio1";
                else if (nom == "17")
                    nom = "case_f1_radio_team2";
                else if (nom == "33")
                    nom = "case_f1_radio_team3";
                info.Add(nom);
                info.Add("Radio F1 - �v�nement");
                this.description = "Une communication radio intervient. Votre ing�nieur vous r�pond.";
                info.Add(this.description);
                break;

            case "case_Canada":
            case "3":
                nom = "case_Canada";
                info.Add(nom);
                info.Add("Circuit du Canada");
                this.description = "Circuit de Montr�al";
                info.Add(this.description);
                this.value = 60000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(3.ToString());
                break;

            case "case_formula_e":
            case "5":
                nom = "case_formula_e";
                info.Add(nom);
                info.Add("Formule E");
                this.description = "D�couvrez la comp�tition �lectrique";
                info.Add(this.description);
                this.value = 200000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(5.ToString());
                break;

            case "case_licence":
            case "4":
                nom = "case_licence";
                info.Add(nom);
                info.Add("Licence Pilote");
                this.description = "Vous obtenez une licence de course. N�cessaire pour certaines comp�titions.";
                info.Add(this.description);
                this.value = 200000;
                info.Add("-" + this.value.ToString());
                break;

            case "case_imola":
            case "6":
                nom = "case_imola";
                info.Add(nom);
                info.Add("Circuit d'Imola");
                this.description = "Circuit l�gendaire d'Italie";
                info.Add(this.description);
                this.value = 100000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(6.ToString());
                break;

            case "case_fia":
            case "case_fia3":
            case "7":
            case "22":
            case "36":
                nom = "case_fia";
                info.Add(nom);
                info.Add("FIA - �v�nement");
                this.description = "Visite � la FIA, �v�nement sp�cial ou amende";
                info.Add(this.description);
                break;

            case "case_jeddah":
            case "8":
                nom = "case_jeddah";
                info.Add(nom);
                info.Add("Circuit de Jeddah");
                this.description = "Course urbaine en Arabie Saoudite";
                info.Add(this.description);
                this.value = 100000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(8.ToString());
                break;

            case "case_gpAbu":
            case "9":
                nom = "case_gpabu";
                info.Add(nom);
                info.Add("Grand Prix d'Abu Dhabi");
                this.description = "Derni�re course de la saison";
                info.Add(this.description);
                this.value = 120000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(9.ToString());
                break;

            case "case_raceban":
            case "10":
                nom = "case_raceban";
                info.Add(nom);
                info.Add("Interdiction de Course");
                this.description = "Vous �tes suspendu pour une course.";
                info.Add(this.description);
                break;

            case "case_azerbaijan":
            case "11":
                nom = "case_azerbaijan";
                info.Add(nom);
                info.Add("Circuit d'Azerba�djan");
                this.description = "Course dans les rues de Bakou";
                info.Add(this.description);
                this.value = 140000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(11.ToString());
                break;

            case "case_prost":
            case "12":
                nom = "case_prost";
                info.Add(nom);
                info.Add("L�gende - Alain Prost");
                this.description = "Vous rencontrez Alain Prost. Gagnez une carte bonus.";
                info.Add(this.description);
                this.value = 150000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(12.ToString());
                break;

            case "case_austin":
            case "13":
                nom = "case_austin";
                info.Add(nom);
                info.Add("Circuit d'Austin");
                this.description = "Course au Texas, USA";
                info.Add(this.description);
                this.value = 140000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(13.ToString());
                break;

            case "case_mexico":
            case "14":
                nom = "case_mexico";
                info.Add(nom);
                info.Add("Grand Prix du Mexique");
                this.description = "Course en altitude, Mexico City";
                info.Add(this.description);
                this.value = 160000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(14.ToString());
                break;

            case "case_gt_world":
            case "15":
                nom = "case_gt_world";
                info.Add(nom);
                info.Add("GT World");
                this.description = "Championnat du monde GT, participez avec votre �curie.";
                info.Add(this.description);
                this.value = 200000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(15.ToString());
                break;

            case "case_Pays_Bas":
            case "16":
                nom = "case_Pays_Bas";
                info.Add(nom);
                info.Add("Circuit des Pays-Bas");
                this.description = "Course � Zandvoort";
                info.Add(this.description);
                this.value = 180000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(16.ToString());
                break;

            case "case_chine":
            case "18":
                nom = "case_chine";
                info.Add(nom);
                info.Add("Grand Prix de Chine");
                this.description = "Course sur le circuit de Shanghai";
                info.Add(this.description);
                this.value = 180000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(17.ToString());
                break;

            case "case_bahrain":
            case "19":
                nom = "case_bahrain";
                info.Add(nom);
                info.Add("Grand Prix du Bahre�n");
                this.description = "Course nocturne dans le d�sert";
                info.Add(this.description);
                this.value = 200000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(18.ToString());
                break;

            case "case_trevehivernal":
            case "20":
                nom = "case_trevehivernal";
                info.Add(nom);
                info.Add("Tr�ve Hivernale");
                this.description = "Pause dans la saison. Aucun effet.";
                info.Add(this.description);
                break;

            case "case_vegas":
            case "21":
                nom = "case_vegas";
                info.Add(nom);
                info.Add("Grand Prix de Las Vegas");
                this.description = "Course spectaculaire sur le Strip";
                info.Add(this.description);
                this.value = 220000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(21.ToString());
                break;

            case "case_australie":
            case "23":
                nom = "case_australie";
                info.Add(nom);
                info.Add("Grand Prix d'Australie");
                this.description = "Course d'ouverture � Melbourne";
                info.Add(this.description);
                this.value = 220000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(23.ToString());
                break;

            case "case_autriche":
            case "24":
                nom = "case_autriche";
                info.Add(nom);
                info.Add("Grand Prix d'Autriche");
                this.description = "Red Bull Ring";
                info.Add(this.description);
                this.value = 240000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(24.ToString());
                break;

            case "case_wrc":
            case "25":
                nom = "case_wrc";
                info.Add(nom);
                info.Add("Championnat WRC");
                this.description = "Participer au rallye mondial";
                info.Add(this.description);
                this.value = 200000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(25.ToString());
                break;

            case "case_singapour":
            case "26":
                nom = "case_singapour";
                info.Add(nom);
                info.Add("Grand Prix de Singapour");
                this.description = "Course nocturne dans les rues";
                info.Add(this.description);
                this.value = 260000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(26.ToString());
                break;

            case "case_silverstone":
            case "27":
                nom = "case_silverstone";
                info.Add(nom);
                info.Add("Silverstone - Royaume-Uni");
                this.description = "L'un des circuits les plus anciens";
                info.Add(this.description);
                this.value = 260000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(27.ToString());
                break;

            case "case_Senna":
            case "28":
                nom = "case_Senna";
                info.Add(nom);
                info.Add("L�gende - Ayrton Senna");
                this.description = "Hommage � Senna. Bonus de popularit�.";
                info.Add(this.description);
                this.value = 150000;
                info.Add(this.value.ToString());
                info.Add(28.ToString());
                break;

            case "case_espagne":
            case "29":
                nom = "case_espagne";
                info.Add(nom);
                info.Add("Grand Prix d'Espagne");
                this.description = "Circuit de Barcelone";
                info.Add(this.description);
                this.value = 280000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(29.ToString());
                break;

            case "case_commisaire":
            case "30":
                nom = "case_commisaire";
                info.Add(nom);
                info.Add("Bureau des Commissaires");
                this.description = "Inspection ou p�nalit� possible.";
                info.Add(this.description);
                MessageBox.Show("Cela seras un Race Ban pour vous !");
                break;

            case "case_japon":
            case "31":
                nom = "case_japon";
                info.Add(nom);
                info.Add("Grand Prix du Japon");
                this.description = "Circuit de Suzuka";
                info.Add(this.description);
                this.value = 300000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(31.ToString());
                break;

            case "case_bresil":
            case "32":
                nom = "case_bresil";
                info.Add(nom);
                info.Add("Grand Prix du Br�sil");
                this.description = "Course � Interlagos";
                info.Add(this.description);
                this.value = 300000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(32.ToString());
                break;

            case "case_belgique":
            case "34":
                nom = "case_belgique";
                info.Add(nom);
                info.Add("Grand Prix de Belgique");
                this.description = "Spa-Francorchamps";
                info.Add(this.description);
                this.value = 320000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(34.ToString());
                break;

            case "case_wec":
            case "35":
                nom = "case_wec";
                info.Add(nom);
                info.Add("Championnat WEC");
                this.description = "World Endurance Championship";
                info.Add(this.description);
                this.value = 200000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(35.ToString());
                break;

            case "case_monza":
            case "37":
                nom = "case_monza";
                info.Add(nom);
                info.Add("Circuit de Monza");
                this.description = "Temple de la vitesse en Italie";
                info.Add(this.description);
                this.value = 350000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(37.ToString());
                break;

            case "case_amende_FIA":
            case "38":
                nom = "case_amende_FIA";
                info.Add(nom);
                info.Add("Amende FIA");
                this.description = "Vous recevez une amende. Payer 100 000�";
                info.Add(this.description);
                this.value = 100000;
                info.Add("-" + this.value.ToString());
                break;

            case "case_monaco":
            case "39":
                nom = "case_monaco";
                info.Add(nom);
                info.Add("Grand Prix de Monaco");
                this.description = "Course urbaine prestigieuse";
                info.Add(this.description);
                this.value = 400000;
                info.Add(this.value.ToString());
                this.hypoteque = this.value / 2;
                info.Add(this.hypoteque.ToString());
                info.Add(39.ToString());
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
