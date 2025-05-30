using System;

/// <summary>
/// // Represents the dice used for movement
/// </summary>
public class Dice {
	/// <summary>
	/// Last rolled value
	/// </summary>
	public int value;
    private Random rand = new Random();

    /// <summary>
    /// The constructor of the dice
    /// </summary>
    public Dice() {
		this.value = 0;
    }
	/// <summary>
	/// Rolls the dice and returns a value
	/// </summary>
	public int Roll() {
        this.value = rand.Next(1, 13);
        return this.value;
    }

	private Player[] player;

}
