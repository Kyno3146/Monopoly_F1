using Monopoly.IHM;
using System;
using System.Windows;

public class Property : Space  {
	/// <summary>
	/// The price of the property
	/// </summary>
	public int price;
	/// <summary>
	/// the rent if a player pass
	/// </summary>
	private int rent;
	/// <summary>
	/// The stae of the property(0-5)
	/// </summary>
	public int level;
	/// <summary>
	/// The cost of an upgrade
	/// </summary>
	private int upgradeValue;
	private int mortgageValue;
	public bool isMortgaged;
    public int position;
    public Player? player;


    /// <summary>
    /// The constructor
    /// </summary>
    public Property(int price, int rent, int upgradeValue, int position) : base(position)
    {
		this.price = price;
        this.rent = rent;
		this.level = 0;
        this.upgradeValue = upgradeValue;
        this.mortgageValue = price / 2;
        this.isMortgaged = false;
        this.position = position;
        this.player = null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="System.InvalidOperationException"></exception>
    /// <author>Riviere Kylian</author>
    public void Upgrade() {
        if (level < 5 && upgradeValue>0)
        {
            if (price == 60000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 10000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 30000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 90000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 160000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 250000;
                }
            }
            else if (price == 100000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 30000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 90000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 170000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 400000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 550000;
                }
            }
            else if (price == 120000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 40000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 100000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 300000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 450000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 600000;
                }
            }
            else if (price == 140000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 50000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 150000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 450000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 625000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 750000;
                }
            }
            else if (price == 160000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 60000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 180000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 500000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 700000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 900000;
                }
            }
            else if (price == 180000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 70000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 200000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 550000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 700000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 900000;
                }
            }
            else if (price == 200000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 80000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 220000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 600000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 800000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 1000000;
                }
            }
            else if (price == 220000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 90000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 250000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 700000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 875000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 1050000;
                }
            }
            else if (price == 240000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 100000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 300000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 750000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 925000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 1100000;
                }
            }
            else if (price == 260000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 110000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 330000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 800000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 975000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 1150000;
                }
            }
            else if (price == 280000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 120000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 360000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 850000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 1025000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 1200000;
                }
            }
            else if (price == 300000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 130000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 390000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 900000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 1100000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 1275000;
                }
            }
            else if (price == 320000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 150000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 450000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 1000000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 1200000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 1400000;
                }
            }
        
            else if (price == 350000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 175000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 500000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 1100000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 1300000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 1500000;
                }
            }
            else if (price == 400000)
            {
                if (this.level == 0)
                {
                    this.level = 1;
                    this.rent = 200000;
                }
                else if (this.level == 1)
                {
                    this.level = 2;
                    this.rent = 800000;
                }
                else if (this.level == 2)
                {
                    this.level = 3;
                    this.rent = 1400000;
                }
                else if (this.level == 3)
                {
                    this.level = 4;
                    this.rent = 1700000;
                }
                else if (this.level == 4)
                {
                    this.level = 5;
                    this.rent = 2000000;
                }
                this.player.Pay(ref upgradeValue);
            }
        }
        else
        {
           throw new System.InvalidOperationException("La propriété est déja au niveau maximum !");
        }
        
        
    }

    /// <summary>
    /// Player pays rent if owned
    /// </summary>
    public override void Action(ref Player p, Plateau plat, Game g, ref Player p2, Board b)
    {
        if (player != null)
        {
            int rent = 0;
            if (p.position == 5 || p.position == 15 || p.position == 25 || p.position == 35)
            {
                if (player.nb_championships == 1)
                {
                    rent = 50000;
                    p.Pay(ref rent);
                }
                else if (player.nb_championships == 2)
                {
                    rent = 100000;
                    p.Pay(ref rent);
                }
                else if (player.nb_championships == 3)
                {
                    rent = 150000;
                    p.Pay(ref rent);
                }
                else if (player.nb_championships == 4)
                {
                    rent = 200000;
                    p.Pay(ref rent);
                }
            }
            else if (p.position == 12 || p.position == 28)
            {
                Dice d = new Dice();
                d.Roll();
                if (player.nb_museums == 1)
                {
                    rent = d.value * 4;
                    p.Pay(ref rent);
                }
                else if (player.nb_museums == 2)
                {
                    rent = d.value * 10;
                    p.Pay(ref rent);
                }
            }
            else
            {
                rent = this.rent;
                p.Pay(ref rent);
            }
        }
        else
        {
            MessageBoxResult messageBoxAchat = MessageBox.Show($"Voulez vous acheter cette propriété pour {this.price} ?", "Achat", MessageBoxButton.YesNo);
            if (messageBoxAchat == MessageBoxResult.Yes)
            {
                if (p.account >= price)
                {
                    p.Buy(this);
                    player = p;
                    plat.ConsoleJeux.Text += $"{p.Name} a acheté la propriété pour {this.price} !\n";
                }
                else
                {
                        MessageBoxResult messageBoxHypotèque = MessageBox.Show("Vous n'avez pas assez d'argent pour acheter cette propriété, voulez vous hypotéquer une de vos propriétés ? (2 max)", "Hypothèque", MessageBoxButton.YesNo);
                    if (messageBoxHypotèque == MessageBoxResult.Yes)
                    {
                        // hypotéquer une propriété
                        if (p.account >= price)
                        {
                            p.Buy(this);
                            player = p;
                            plat.ConsoleJeux.Text += $"{p.Name} a acheté la propriété {this.position} pour {this.price} !\n";
                        }
                        else
                        {
                            MessageBoxResult messageBoxHypotèque2 = MessageBox.Show("Vous n'avez pas assez d'argent pour acheter cette propriété, voulez vous hypotéquer une de vos propriétés ? (1 max)", "Hypothèque", MessageBoxButton.YesNo);
                            if (messageBoxHypotèque2 == MessageBoxResult.Yes)
                            {
                                // hypotheque une propriété
                                if (p.account >= price)
                                {
                                    p.Buy(this);
                                    player = p; 
                                    plat.ConsoleJeux.Text += $"{p.Name} a acheté la propriété {this.position} pour {this.price} !\n";
                                }
                                else
                                {
                                    MessageBox.Show("Vous n'avez toujours pas assez d'argent pour acheter cette propriété ! Cette proprité va donc être mise à l'enchère");
                                    Card card = new Card(position.ToString());
                                    List<string> info = card.infoCarte(position.ToString());
                                    plat.ConsoleJeux.Text += " ---- Enchère ---- \n";
                                    Enchere enchere = new Enchere(info, p, p2,g);
                                    enchere.Show();
                                }

                            }
                            else
                            {
                                Card card = new Card(position.ToString());
                                List<string> info = card.infoCarte(position.ToString());
                                plat.ConsoleJeux.Text += " ---- Enchère ---- \n";
                                Enchere enchere = new Enchere(info, p, p2,g);
                                enchere.Show();
                            }



                        }
                    }
                    else
                    {
                        Card card = new Card(position.ToString());
                        List<string> info = card.infoCarte(position.ToString());
                        plat.ConsoleJeux.Text += " ---- Enchère ---- \n";
                        Enchere enchere = new Enchere(info, p, p2,g);
                        enchere.Show();
                    }

                    }
                }
            else
            {
                Card card = new Card(position.ToString());
                List<string> info = card.infoCarte(position.ToString());
                plat.ConsoleJeux.Text += " ---- Enchère ---- \n";
                Enchere enchere = new Enchere(info, p, p2,g);
                enchere.Show();
            }
        }
    }
    /// <summary>
    /// A function wich mortgege the property
    /// </summary>
    public void Mortgage() {
        if (!isMortgaged && player != null)
        {
            isMortgaged = true;
            player.account += mortgageValue;
        }
        else
        {
            throw new System.InvalidOperationException("La propriété est déja hypothéquée !");
        }
    }


}
