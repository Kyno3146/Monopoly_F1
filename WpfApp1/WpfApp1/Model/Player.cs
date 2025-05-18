using System;

/// <summary>
/// Represents a player in the game
/// </summary>
public class Player {
	/// <summary>
	/// Player's name
	/// </summary>
	private string name;
	/// <summary>
	/// Player's current money
	/// </summary>
	public int account;
	/// <summary>
	/// Current board position
	/// </summary>
	public int position;
	/// <summary>
	/// Owned properties
	/// </summary>
	private Player[] properties;

	/// <summary>
	/// Player's constructor
	/// </summary>
	/// <param name="n">the name of the player</param>
	public Player(string n) {
		throw new System.NotImplementedException("Not implemented");
	}
	/// <summary>
	/// Rolls the dice
	/// </summary>
	public int RollDice() {
		throw new System.NotImplementedException("Not implemented");
	}
	/// <summary>
	/// Buys a property
	/// </summary>
	public void Buy(Property p) {
		throw new System.NotImplementedException("Not implemented");
	}
	/// <summary>
	/// Pays a specified amount
	/// </summary>
	/// <param name="s">the amount of money wich is spent</param>
	public void Pay(ref int s) {
		throw new System.NotImplementedException("Not implemented");
	}

	private Property[] propertys;
	private Space space;

	private Game game;
	private Dice dice;

}
