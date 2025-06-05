using Monopoly.IHM;
using System;
using System.Windows;

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
            if (p.account < value)
            {
                while (p.account < value)
                {
                    if (p.properties.Length == 0)
                    {
                        MessageBox.Show("Vous n'avez plus d'argent ni de propriétés à hypotéquer, vous avez perdu !");
                        g.isGameOver = true;
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas assez d'argent pour payer cette amende.Vous devez hypotéquer une propriété");
                        Hypotheque hypotheque = new Hypotheque(p);
                        hypotheque.ShowDialog();
                    }
                }
                p.Pay(value);
            }
        }
        if (this.position == 38)
        {
            int value = 100000;
            if (p.account < value)
            {
                while (p.account < value)
                {
                    if (p.properties.Length == 0)
                    {
                        MessageBox.Show("Vous n'avez plus d'argent ni de propriétés à hypotéquer, vous avez perdu !");
                        g.isGameOver = true;
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas assez d'argent pour payer cette amende.Vous devez hypotéquer une propriété");
                        Hypotheque hypotheque = new Hypotheque(p);
                        hypotheque.ShowDialog();
                    }
                }
                p.Pay(value);
            }
            }
        if (this.position == 30)
        {
            p.position = 10;
            p.isInJail = true;
            plat.MooveF1(g.IsPlayerTurnGame ,p.position);
        }
    }
}
