using Monopoly.IHM;
using Org.BouncyCastle.Crypto.Macs;
using System;

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
	public override void Action(ref Player p, Plateau plat, Game g,ref Player p2) {
		p.account = 100000;
	}

	private Card[] cards;

}
