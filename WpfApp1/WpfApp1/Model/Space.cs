using System;
using System.Windows.Media.Imaging;
using Monopoly.IHM;

public abstract class Space {
	private int position;

	/// <summary>
	/// Constructors
	/// </summary>
	public Space(int position) {
		this.position = position;
    }

	public abstract void Action(ref Player p, Plateau plat, Game g, ref Player p2);

    private Board board;
	private Player[] player;

}
