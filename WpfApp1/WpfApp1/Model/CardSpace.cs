using Monopoly.IHM;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Security;
using System;
using System.Windows;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

public class CardSpace : Space  {
	private Card[] deck;
	private int position;
	public CardSpace(int position) : base(position)
    {
        this.position = position;
        this.deck = new Card[0]; // Initialize an empty deck  
    }
	public Card DrawCard() {
		throw new System.NotImplementedException("Not implemented");
	}

	public override void Action(ref Player p, Plateau plat, Game g,ref Player p2, Board b) {
		p.account = 100000;
		Random rand = new Random();
		int id = rand.Next(1, 16); 
        if (p.position == 7 || p.position == 22 || p.position == 36)

            plat.ConsoleJeux.Text += $" ---- {p.Name} a pioch�� une carte Chance ! ---- \n";
        {
			if (id == 0)
			{
				plat.ConsoleJeux.Text += "Drapeu Rouge ! Tu retourne à la case départ !\n";
				p.position = 40; // Move to start position
			}
			else if (id == 1)
			{
				plat.ConsoleJeux.Text += "L'undercut à bien fonctionné, tu arrives directement à Monaco\n";
				p.position = 39; // Move to Monaco position
				b.spaces[p.position].Action(ref p, plat, g, ref p2, b); // Execute action for Monaco space
            }
			else if (id == 2)
			{
				plat.ConsoleJeux.Text += "Tu participes à une autre compétition : Avance sur la case Championnat la plus proche\n";
				if (p.position == 7)
				{
					p.position = 15; // Move to Championship position
				}
				else if (p.position == 22)
				{
					p.position = 25; // Move to Championship position
				}
				else if (p.position == 36)
				{
					p.position = 5; // Move to Championship position
					p.account += 200000; 
                }
                b.spaces[p.position].Action(ref p, plat, g, ref p2, b); // Execute action for Championship space
            }
			else if (id == 3) {
				plat.ConsoleJeux.Text += "Tu est invité dans le musée le plus proche !\n";
                if (p.position == 7)
                {
                    p.position = 12; // Move to Museum position
                }
                else if (p.position == 22)
                {
                    p.position = 28; // Move to Museum position
                }
                else if (p.position == 36)
                {
                    p.position = 12; // Move to Museum position
					p.account += 200000; 
                }
                b.spaces[p.position].Action(ref p, plat, g, ref p2, b); // Execute action for Museum space
            }
			else if (id == 4) {
				plat.ConsoleJeux.Text += "Avance jusque au circuit de Monza !\n";
				p.position = 37; // Move to Monza position
                b.spaces[p.position].Action(ref p, plat, g, ref p2, b); // Execute action for Monza space
            }
			else if (id == 5) { 
				plat.ConsoleJeux.Text += "Tu dois te rendre au Hungaroaring ! Reçois 200000€ pour êetre passé par la ligne de départ / arrivée !\n";
                p.position = 1; // Move to Hungaroaring position
                p.account += 200000; // Add money for passing start
                b.spaces[p.position].Action(ref p, plat, g, ref p2, b); // Execute action for Hungaroaring space
            }
			else if (id == 6) { 
				plat.ConsoleJeux.Text += "Tu as reçu une pénalité, recule de 3 cases !\n";
                p.position -= 3; // Move back 3 spaces
				b.spaces[p.position].Action(ref p, plat, g, ref p2, b); // Execute action for new position
            }
            else if (id == 7) { 
				plat.ConsoleJeux.Text += "Flavio Briatore a convaincu la FIA pour vous, recevez 200000€ ! \n";
                p.account += 200000; // Add money for FIA intervention
            }
			else if (id == 8) { 
				plat.ConsoleJeux.Text += "Tu à pris une course de suspention pour ton comportement en piste ! \n";
				p.position = 10; // Move to Suspension position
            }
			else if (id == 9) { 
				plat.ConsoleJeux.Text += "Tu dois payer pour toutes tes propriétés : 50 000€ par niveau de propriétés\n";
                int totalCost = 0;
                foreach (Property property in p.properties)
                {
                    if (property != null)
                    {
                        totalCost += property.level * 50000; // Calculate cost based on property level
                    }
                }
                if (totalCost > p.account)
                {
                    while (totalCost > p.account)
                    {
                        if (p.properties.Length == 0)
                        {
                            plat.ConsoleJeux.Text += "Vous n'avez pas assez d'argent pour payer vos propriétés et vous n'avez pas de propriétés à vendre.\n";
                            g.isGameOver = true; // End the game if no properties to sell and not enough money
                        }
                        else
                        {
                            MessageBox.Show("Vous n'avez pas assez d'argent pour payer vos propriétés. Vous devez hypotéquer des propriétés.", "Alerte", MessageBoxButton.OK, MessageBoxImage.Warning);
                            // Hyotèque
                        }
                    }
                    p.account -= totalCost; // Deduct total cost from account
                    plat.ConsoleJeux.Text += $"Vous avez payé {totalCost}€ pour vos propriétés.\n";
                }
                else
                {
                    p.account -= totalCost; // Deduct total cost from account
                    plat.ConsoleJeux.Text += $"Vous avez payé {totalCost}€ pour vos propriétés.\n";
                }
            }
			else if (id == 10) {
                MessageBoxResult messageBoxResult = MessageBox.Show("Tu dois payer une ammande de 150 000 € ou piocher une carte FIA ! (Oui pour payer l'ammande, non pour piocher)", "Amende", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    if (p.account < 150000)
                    {
                        while (150000 > p.account)
                        {
                            if (p.properties.Length == 0)
                            {
                                plat.ConsoleJeux.Text += "Vous n'avez pas assez d'argent pour payer vos propriétés et vous n'avez pas de propriétés à vendre.\n";
                                g.isGameOver = true; // End the game if no properties to sell and not enough money
                            }
                            else
                            {
                                MessageBox.Show("Vous n'avez pas assez d'argent pour payer vos propriétés. Vous devez hypotéquer des propriétés.", "Alerte", MessageBoxButton.OK, MessageBoxImage.Warning);
                                // Hypotèque 
                            }
                        }
                        p.account -= 150000; // Deduct fine from account
                        plat.ConsoleJeux.Text += "Vous avez payé une amende de 150 000 €.\n";
                    }
                    else
                    {
                        p.account -= 150000; // Deduct fine from account
                        plat.ConsoleJeux.Text += "Vous avez payé une amende de 150 000 €.\n";
                    }
                }
                else
                {
                    plat.ConsoleJeux.Text += "Vous avez pioché une carte FIA !\n";
                    b.spaces[2].Action(ref p, plat, g, ref p2, b); // Execute action for FIA card
                }
            }
            else if (id == 11) { 
                plat.ConsoleJeux.Text += "Tu as reçu une récompense des sponsors pour ta performance : 15000€\n";
                p.account += 15000; // Add money for sponsor reward
            }
			else if (id == 12) { 
                plat.ConsoleJeux.Text += "Tu est élu président au comité de sécurité des pilotes, payez 50 000 à votre adverssaire\n";
                if (p.account < 50000)
                {
                    while (50000 > p.account)
                    {
                        if (p.properties.Length == 0)
                        {
                            plat.ConsoleJeux.Text += "Vous n'avez pas assez d'argent pour payer vos propriétés et vous n'avez pas de propriétés à vendre.\n";
                            g.isGameOver = true; // End the game if no properties to sell and not enough money
                        }
                        else
                        {
                            MessageBox.Show("Vous n'avez pas assez d'argent pour payer vos propriétés. Vous devez hypotéquer des propriétés.", "Alerte", MessageBoxButton.OK, MessageBoxImage.Warning);
                            // Hypotèque
                        }
                    }
                    p.account -= 150000; // Deduct fine from account
                    plat.ConsoleJeux.Text += "Vous avez payé une amende de 150 000 €.\n";
                }
            }
			else if (id == 13) { 
                plat.ConsoleJeux.Text += "Vous avez gagné un prix pour votre performance : 50 000€\n";
                p.account += 50000; // Add money for performance award
            }
			else if (id == 14) { 
                plat.ConsoleJeux.Text += "Vous avez été élu driver of the day, recevez 20 000€ !\n";
                p.account += 20000; // Add money for driver of the day award
            }
			else if (id == 15) { 
                plat.ConsoleJeux.Text += "Tu est invité par Red Bull au RedBull ring, rndez-vous en Autriche !\n";
                
                if (p.position == 22 || p.position == 36)
                {
                    p.account += 200000; // Add money for passing start
                }
                p.position = 20; // Move to Red Bull Ring position
                b.spaces[p.position].Action(ref p, plat, g, ref p2, b); // Execute action for Red Bull Ring space
            }
        }
	}

	private Card[] cards;

}
