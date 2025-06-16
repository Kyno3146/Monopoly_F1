import mysql.connector
import pandas as pd
import matplotlib.pyplot as plt
import matplotlib.ticker as ticker

def connecter():
    connexion = mysql.connector.connect(
        host="localhost",
        user="root",
        password="",
        database="monopoly_f1"
    )
    curseur = connexion.cursor()
    return connexion, curseur

def fermer(connexion, curseur):
    if curseur:
        curseur.close()
    if connexion and connexion.is_connected():
        connexion.close()

def courbe_inscriptions():
    connexion, curseur = connecter()

    try:
        curseur.execute("SELECT date_inscription FROM users")
        dates = [row[0].date() for row in curseur.fetchall() if row[0] is not None]

        # 🔹 Analyse
        df = pd.DataFrame(dates, columns=["date"])
        df_count = df.groupby("date").size().cumsum()

        # 🔹 Graphique
        plt.figure(figsize=(12, 6))
        plt.plot(df_count.index, df_count.values, marker='o', linestyle='-')
        plt.title("Courbe cumulative des inscriptions d'utilisateurs")
        plt.xlabel("Date")
        plt.ylabel("Nombre total d'inscriptions")
        plt.grid(True)
        plt.tight_layout()
        plt.xticks(rotation=45)
        plt.show()

    except Exception as e:
        print(f" Erreur : {e}")

    finally:
        fermer(connexion, curseur)


def diagramme_frequentation_propriete():
    connexion, curseur = connecter()

    try:
        # 🔹 Récupérer propriétés
        curseur.execute("SELECT nomPropriete, nbPassage FROM propriete")
        proprietes = curseur.fetchall()

        donnees = proprietes
        df = pd.DataFrame(donnees, columns=["nom", "nbPassage"])

        # 🔹 Trier par nbPassage décroissant
        df = df.sort_values(by="nbPassage", ascending=False)

        # 🔹 Tracer le diagramme
        plt.figure(figsize=(14, 8))
        plt.barh(df["nom"], df["nbPassage"], color="green")
        plt.title("Fréquentation des cases (propriétés)")
        plt.xlabel("Nombre de passages")
        plt.ylabel("Nom de la case")
        plt.gca().invert_yaxis()  # pour avoir la plus fréquentée en haut
        plt.tight_layout()
        plt.show()

    except Exception as e:
        print("Erreur :", e)

    finally:
        fermer(connexion, curseur)


def courbe_parties_jouees():
    connexion, curseur = connecter()

    try:

        query = "SELECT datePartie FROM historiquepartie"
        df = pd.read_sql(query, connexion)
        connexion.close()

        df['datePartie'] = pd.to_datetime(df['datePartie'])
        df['jour'] = df['datePartie'].dt.date

        # Regrouper par date
        parties_par_jour = df.groupby('jour').size()

        # Créer une plage continue de dates
        all_days = pd.date_range(start=df['jour'].min(), end=df['jour'].max())
        parties_par_jour = parties_par_jour.reindex(all_days.date, fill_value=0)

        # Tracer
        plt.figure(figsize=(12, 6))
        parties_par_jour.plot(marker='o')
        plt.title("Nombre de parties jouées par jour (jours sans parties inclus)")
        plt.xlabel("Date")
        plt.ylabel("Nombre de parties")
        plt.grid(True)
        plt.xticks(rotation=45)
        plt.tight_layout()
        plt.show()

    except Exception as e:
        print(f"Erreur : {e}")
    finally:
        fermer(connexion, curseur)

def diagramme_pourcentage_achat_proprietes():
    connexion, curseur = connecter()
    try:

        # Requête SQL : totalachat et nbPassage pour chaque propriété
        curseur.execute("""
            SELECT nomPropriete, totalachat, nbPassage
            FROM propriete
            WHERE nbPassage > 0
            ORDER BY nomPropriete;
        """)
        resultats = curseur.fetchall()

        #  Création du DataFrame
        df = pd.DataFrame(resultats, columns=["Propriété", "TotalAchats", "Passages"])
        df["Pourcentage"] = (df["TotalAchats"] / df["Passages"]) * 100

        #  Tracé du diagramme
        plt.figure(figsize=(14, 6))
        plt.bar(df["Propriété"], df["Pourcentage"], color="green")
        plt.xticks(rotation=90)
        plt.ylabel("Pourcentage d'achat (%)")
        plt.title("Pourcentage d'achat par propriété (totalachat / passages)")
        plt.tight_layout()
        plt.grid(axis='y')
        plt.show()

    except Exception as e:
        print(f"Erreur : {e}")
    finally:
        fermer(connexion, curseur)

def diagramme_revenus_proprietes():
    connexion, curseur = connecter()
    try:

        #  Requête SQL : revenus générés par propriété
        curseur.execute("""
            SELECT nomPropriete, revenueGenere
            FROM propriete
            ORDER BY nomPropriete;
        """)
        resultats = curseur.fetchall()

        #  Création du DataFrame
        df = pd.DataFrame(resultats, columns=["Propriété", "Revenus"])

        #  Tracé du diagramme
        plt.figure(figsize=(14, 6))
        plt.bar(df["Propriété"], df["Revenus"], color="seagreen")
        plt.xticks(rotation=90)
        plt.ylabel("Revenus générés (€)")
        plt.title("Revenus générés par propriété")
        plt.tight_layout()
        plt.grid(axis='y')
        plt.gca().yaxis.set_major_formatter(ticker.FuncFormatter(lambda x, _: f'{int(x):,}'.replace(',', ' ')))
        plt.show()

    except Exception as e:
        print(f"Erreur : {e}")
    finally:
        fermer(connexion, curseur)


def diagramme_achats_proprietes():
    connexion, curseur = connecter()
    try:


        # Requête SQL
        curseur.execute("""
            SELECT nomPropriete, totalachat
            FROM propriete
            ORDER BY nomPropriete;
        """)
        resultats = curseur.fetchall()

        # Création du DataFrame
        df = pd.DataFrame(resultats, columns=["Propriété", "Achats"])

        # Tracé du diagramme
        plt.figure(figsize=(14, 6))
        plt.bar(df["Propriété"], df["Achats"], color="royalblue")
        plt.xticks(rotation=90)
        plt.ylabel("Nombre total d'achats")
        plt.title("Nombre total d'achats par propriété")
        plt.gca().yaxis.set_major_formatter(ticker.FuncFormatter(lambda x, _: f'{int(x):,}'.replace(',', ' ')))
        plt.tight_layout()
        plt.grid(axis='y')
        plt.show()

    except mysql.connector.Error as err:
        print(f"Erreur de connexion ou d'exécution SQL : {err}")
    finally:
        fermer(connexion, curseur)


def diagramme_frequentation_evenements():
    connexion, curseur = connecter()

    try:
        # 🔹 Récupérer propriétés
        curseur.execute("SELECT nomCase, nbPassage FROM caseevenement")
        evenements = curseur.fetchall()

        donnees = evenements
        df = pd.DataFrame(donnees, columns=["nom", "nbPassage"])

        # 🔹 Trier par nbPassage décroissant
        df = df.sort_values(by="nbPassage", ascending=False)

        # 🔹 Tracer le diagramme
        plt.figure(figsize=(14, 8))
        plt.barh(df["nom"], df["nbPassage"], color="green")
        plt.title("Fréquentation des cases (evenements)")
        plt.xlabel("Nombre de passages")
        plt.ylabel("Nom de la case")
        plt.gca().invert_yaxis()  # pour avoir la plus fréquentée en haut
        plt.tight_layout()
        plt.show()

    except Exception as e:
        print("Erreur :", e)

    finally:
        fermer(connexion, curseur)


def diagramme_encheres_par_case():
    # Connexion à la base de données MySQL
    connexion, curseur = connecter()
    try:


        # Requête SQL : nombre d'enchères par propriété
        curseur.execute("""
            SELECT p.nomPropriete, COUNT(e.id) AS nb_encheres
            FROM enchere e
            JOIN propriete p ON e.idPropriete = p.id
            GROUP BY p.nomPropriete
            ORDER BY p.nomPropriete;
        """)
        resultats = curseur.fetchall()

        # Création du DataFrame
        df = pd.DataFrame(resultats, columns=["Case", "Enchères"])

        # Tracé du diagramme
        plt.figure(figsize=(14, 6))
        plt.bar(df["Case"], df["Enchères"], color="slateblue")
        plt.xticks(rotation=90)
        plt.ylabel("Nombre d'enchères")
        plt.title("Nombre d'enchères par propriété")
        plt.gca().yaxis.set_major_formatter(ticker.FuncFormatter(lambda x, _: f'{int(x):,}'.replace(',', ' ')))
        plt.tight_layout()
        plt.grid(axis='y')
        plt.show()

    except mysql.connector.Error as err:
        print(f"Erreur de connexion ou d'exécution SQL : {err}")
    finally:
            fermer(connexion, curseur)




def diagramme_courbes_top8_encheres():
    # Connexion à la base de données MySQL
    connexion, curseur = connecter()
    try:


        # Étape 1 : Identifier les 8 propriétés avec le plus d'enchères
        curseur.execute("""
            SELECT p.id, p.nomPropriete, COUNT(e.id) AS nb_encheres
            FROM enchere e
            JOIN propriete p ON e.idPropriete = p.id
            GROUP BY p.id, p.nomPropriete
            ORDER BY nb_encheres DESC
            LIMIT 5;
        """)
        top_props = curseur.fetchall()
        top_ids = [row[0] for row in top_props]

        # Étape 2 : Récupérer les montants d'enchères pour ces propriétés
        format_strings = ','.join(['%s'] * len(top_ids))
        curseur.execute(f"""
            SELECT p.nomPropriete, e.montantFinal
            FROM enchere e
            JOIN propriete p ON e.idPropriete = p.id
            WHERE p.id IN ({format_strings})
            ORDER BY p.nomPropriete, e.id;
        """, top_ids)
        resultats = curseur.fetchall()

        # Création du DataFrame
        df = pd.DataFrame(resultats, columns=["Propriété", "Montant"])

        # Tracé des courbes
        plt.figure(figsize=(14, 7))
        for nom_propriete, groupe in df.groupby("Propriété"):
            plt.plot(groupe["Montant"].values, label=nom_propriete)

        plt.title("Évolution des montants d'enchères (Top 8 propriétés)")
        plt.xlabel("Numéro d'enchère (ordre chronologique)")
        plt.ylabel("Montant de l'enchère (€)")
        plt.legend(loc='upper right', bbox_to_anchor=(1.15, 1), fontsize='small')
        plt.tight_layout()
        plt.grid(True)
        plt.show()

    except mysql.connector.Error as err:
        print(f"Erreur de connexion ou d'exécution SQL : {err}")
    finally:
        fermer(connexion, curseur)

def courbe_victoires_defaites_joueur(id_joueur):
    connexion, curseur = connecter()
    try:

        # Requête SQL : toutes les parties avec gagnant et date
        curseur.execute("""
            SELECT DATE(datePartie) AS jour, gagnant, perdant
            FROM historiquepartie
            ORDER BY jour;
        """)
        parties = curseur.fetchall()

        # Création du DataFrame
        df = pd.DataFrame(parties, columns=["jour", "gagnant", "perdant"])
        df["jour"] = pd.to_datetime(df["jour"])
        df["victoire"] = (df["gagnant"] == id_joueur).astype(int)
        df["defaite"] = (df["perdant"] == id_joueur).astype(int)

        # Regrouper par jour et cumuler
        df_grouped = df.groupby("jour")[["victoire", "defaite"]].sum().cumsum()

        # Tracé des courbes
        plt.figure(figsize=(10, 5))
        plt.plot(df_grouped.index, df_grouped["victoire"], label="Victoires", marker='o')
        plt.plot(df_grouped.index, df_grouped["defaite"], label="Défaites", marker='x')
        plt.title(f"Évolution des victoires et défaites du joueur {id_joueur}")
        plt.xlabel("Date")
        plt.ylabel("Nombre cumulatif")
        plt.legend()
        plt.grid(True)
        plt.xticks(rotation=45)
        plt.tight_layout()
        plt.show()

    except mysql.connector.Error as err:
        print(f"Erreur SQL : {err}")
    finally:
        fermer(connexion, curseur)

def courbe_encheres_gagnees_par_partie_par_joueur(id_joueur):
    connexion, curseur = connecter()
    try:
        # Requête SQL pour compter les enchères gagnées par partie pour un joueur donné
        curseur.execute("""
            SELECT idPartie, COUNT(*) AS nb_encheres_gagnees
            FROM enchere
            WHERE gagnant = %s
            GROUP BY idPartie
            ORDER BY idPartie;
        """, (id_joueur,))
        resultats = curseur.fetchall()
        parties = [row[0] for row in resultats]
        nb_encheres = [row[1] for row in resultats]

        # Tracé du graphique
        plt.figure(figsize=(12, 6))
        plt.plot(parties, nb_encheres, marker='o', linestyle='-', color='green')
        plt.title(f"Nombre d'enchères gagnées par partie pour le joueur {id_joueur}")
        plt.xlabel("ID de la partie")
        plt.ylabel("Nombre d'enchères gagnées")
        plt.grid(True)
        plt.tight_layout()
        plt.show()
    except Exception as e:
        print(f"Erreur : {e}")
    finally:
        fermer(connexion, curseur)

def courbe_cumulee_proprietes_achetees_par_joueur(id_joueur):
    connexion, curseur = connecter()
    try:
        # Requête SQL pour récupérer les propriétés achetées par partie pour un joueur donné
        curseur.execute("""
            SELECT id, 
                   CASE 
                       WHEN idJoueur1 = %s THEN nbProprieteJ1
                       WHEN idJoueur2 = %s THEN nbProprieteJ2
                       ELSE NULL
                   END AS nb_proprietes
            FROM historiquePartie
            WHERE idJoueur1 = %s OR idJoueur2 = %s
            ORDER BY id;
        """, (id_joueur, id_joueur, id_joueur, id_joueur))
        resultats = curseur.fetchall()
        parties = []
        nb_proprietes_cumulees = []
        cumul = 0
        for row in resultats:
            if row[1] is not None:
                parties.append(row[0])
                cumul += row[1]
                nb_proprietes_cumulees.append(cumul)

        # Tracé du graphique
        plt.figure(figsize=(12, 6))
        plt.plot(parties, nb_proprietes_cumulees, marker='o', linestyle='-', color='teal')
        plt.title(f"Cumul des propriétés achetées par partie pour le joueur {id_joueur}")
        plt.xlabel("ID de la partie")
        plt.ylabel("Cumul des propriétés achetées")
        plt.grid(True)
        plt.tight_layout()
        plt.show()
    except Exception as e:
        print(f"Erreur : {e}")
    finally:
        fermer(connexion, curseur)

def courbe_cumulee_hypotheques_par_joueur(id_joueur):
    connexion, curseur = connecter()
    try:
        # Requête SQL pour récupérer les hypothèques par partie pour un joueur donné
        curseur.execute("""
            SELECT id, 
                   CASE 
                       WHEN idJoueur1 = %s THEN nbHypothequeJ1
                       WHEN idJoueur2 = %s THEN nbHypothequeJ2
                       ELSE NULL
                   END AS nb_hypotheques
            FROM historiquePartie
            WHERE idJoueur1 = %s OR idJoueur2 = %s
            ORDER BY id;
        """, (id_joueur, id_joueur, id_joueur, id_joueur))
        resultats = curseur.fetchall()
        parties = []
        nb_hypotheques_cumulees = []
        cumul = 0
        for row in resultats:
            if row[1] is not None:
                parties.append(row[0])
                cumul += row[1]
                nb_hypotheques_cumulees.append(cumul)

        # Tracé du graphique
        plt.figure(figsize=(12, 6))
        plt.plot(parties, nb_hypotheques_cumulees, marker='o', linestyle='-', color='red')
        plt.title(f"Cumul des propriétés hypothéquées par partie pour le joueur {id_joueur}")
        plt.xlabel("ID de la partie")
        plt.ylabel("Cumul des propriétés hypothéquées")
        plt.grid(True)
        plt.tight_layout()
        plt.show()
    except Exception as e:
        print(f"Erreur : {e}")
    finally:
        fermer(connexion, curseur)


def courbe_depenses_encheres_par_joueur(id_joueur):
    connexion, curseur = connecter()
    try:
        # Requête SQL pour récupérer les montants dépensés aux enchères gagnées par partie pour un joueur donné
        curseur.execute("""
            SELECT idPartie, montantFinal
            FROM enchere
            WHERE gagnant = %s
            ORDER BY idPartie;
        """, (id_joueur,))
        resultats = curseur.fetchall()

        # Agrégation des montants par partie
        depenses_par_partie = {}
        for id_partie, montant in resultats:
            if id_partie in depenses_par_partie:
                depenses_par_partie[id_partie] += montant
            else:
                depenses_par_partie[id_partie] = montant

        # Tri des parties et calcul du cumul
        parties = sorted(depenses_par_partie.keys())
        depenses_cumulees = []
        cumul = 0
        for partie in parties:
            cumul += depenses_par_partie[partie]
            depenses_cumulees.append(cumul)

        # Tracé du graphique
        plt.figure(figsize=(12, 6))
        plt.plot(parties, depenses_cumulees, marker='o', linestyle='-', color='darkblue')
        plt.title(f"Cumul des dépenses aux enchères par partie pour le joueur {id_joueur}")
        plt.xlabel("ID de la partie")
        plt.ylabel("Cumul des montants dépensés")
        plt.grid(True)
        plt.tight_layout()
        plt.gca().yaxis.set_major_formatter(ticker.FuncFormatter(lambda x, _: f'{int(x):,}'.replace(',', ' ')))
        plt.show()
    except Exception as e:
        print(f"Erreur : {e}")
    finally:
        fermer(connexion, curseur)

def diagramme_achats_par_propriete_par_joueur(id_joueur):
    connexion, curseur = connecter()
    try:
        # Requête SQL avec le bon nom de colonne
        curseur.execute("""
            SELECT p.nomPropriete, COUNT(*) AS nb_achats
            FROM enchere e
            JOIN propriete p ON e.idPropriete = p.id
            WHERE e.gagnant = %s
            GROUP BY p.nomPropriete
            ORDER BY nb_achats DESC;
        """, (id_joueur,))
        resultats = curseur.fetchall()
        noms_proprietes = [row[0] for row in resultats]
        nb_achats = [row[1] for row in resultats]

        # Tracé du diagramme en barres
        plt.figure(figsize=(14, 6))
        plt.bar(noms_proprietes, nb_achats, color='mediumseagreen')
        plt.title(f"Nombre d'achats par propriété pour le joueur {id_joueur}")
        plt.xlabel("Nom de la propriété")
        plt.ylabel("Nombre d'achats")
        plt.xticks(rotation=45, ha='right')
        plt.tight_layout()
        plt.show()
    except Exception as e:
        print(f"Erreur : {e}")
    finally:
        fermer(connexion, curseur)



diagramme_achats_par_propriete_par_joueur(1)