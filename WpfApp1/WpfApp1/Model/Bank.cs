using System;

/// <summary>
/// Manages money and property transactions
/// </summary>
public class Bank {
	/// <summary>
	/// Total money in the bank
	/// </summary>
	private int funds;

	/// <summary>
	/// a constructor for the bank
	/// </summary>
	public Bank() {
        this.funds = 100000000;
    }
	/// <summary>
	/// Handles transactions
	/// </summary>
	public void RecieveMoney(int amount)
    {
        this.funds += amount;
    }

    public void GiveMoney(int amount)
    {
        this.funds -= amount;
    }





    private Game game;

}
