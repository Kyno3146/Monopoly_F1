using System;

public abstract class Space {
	private int position;

	/// <summary>
	/// Constructors
	/// </summary>
	public Space(int position) {
		this.position = position;
    }

	public abstract void Action(ref Player p);

    private Board board;
	private Player[] player;

}
