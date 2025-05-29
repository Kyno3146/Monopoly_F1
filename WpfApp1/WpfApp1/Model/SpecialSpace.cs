using Monopoly.IHM;
using System;

public class SpecialSpace : Space
{
    private int position;
    private Space space;

    /// <summary>
    /// Constructor
    /// </summary>
    public SpecialSpace(int position) : base(position)
    {
        this.position = position;
        this.space = null!; // Initialize to a non-null value or use null-forgiving operator
    }

    /// <summary>
    /// Executes special space logic
    /// </summary>
    public override void Action(ref Player p, Plateau plat, Game g,ref Player p2, Board b)
    {
        if (this.position == 4)
        {
            int value = 200000;
            p.Pay(ref value);
        }
        if (this.position == 38)
        {
            int value = 100000;
            p.Pay(ref value);
        }
        if (this.position == 30)
        {
            p.position = 10;
            p.isInJail = true;
        }
    }
}
