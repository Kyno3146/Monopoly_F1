using System;

public class Property : Space  {
	/// <summary>
	/// The price of the property
	/// </summary>
	private int price;
	/// <summary>
	/// the rent if a player pass
	/// </summary>
	private int rent;
	/// <summary>
	/// The stae of the property(0-5)
	/// </summary>
	private int level;
	/// <summary>
	/// The cost of an upgrade
	/// </summary>
	private int upgradeValue;
	private int mortgageValue;
	private bool isMortgaged;
    private int position;
    private Player? player;


    /// <summary>
    /// The constructor
    /// </summary>
    public Property(int price, int rent, int upgradeValue, int mortageValue, int baseRent, int position) : base(position)
    {
		this.price = price;
        this.rent = rent;
		this.level = 0;
        this.upgradeValue = upgradeValue;
        this.mortgageValue = mortageValue;
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
        if (level < 5)
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

            else if (price == 30000)
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
    public override void Action(ref Player p)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// A function wich mortgege the property
    /// </summary>
    public void Mortgage() {
		throw new System.NotImplementedException("Not implemented");
	}


}
