using System;

public class Board {
	private Space[] spaces;

	/// <summary>
	/// Constructors
	/// </summary>
	public Board()
	{
		this.spaces = new Space[40];
		this.spaces[0] = new SpecialSpace(0);
        this.spaces[1] = new Property(60000, 2000, 50000, 1);
        this.spaces[2] = new CardSpace(2);
        this.spaces[3] = new Property(60000, 2000, 50000, 3);
        this.spaces[4] = new SpecialSpace(4);
        this.spaces[5] = new Property(200000, 25000, 0, 5);
        this.spaces[6] = new Property(100000, 6000, 50000, 6);
        this.spaces[7] = new Property(100000, 6000, 50000, 7);
        this.spaces[8] = new CardSpace(8);
        this.spaces[9] = new Property(120000, 8000, 50000, 9);
        this.spaces[10] = new SpecialSpace(10);
        this.spaces[11] = new Property(140000, 10000, 100000, 11);
        this.spaces[12] = new Property(150000, 0, 0, 12);
        this.spaces[13] = new Property(140000, 10000, 100000, 13);
        this.spaces[14] = new Property(160000, 12000, 100000, 14);
        this.spaces[15] = new Property(200000, 25000, 0, 15);
        this.spaces[16] = new Property(180000, 14000, 100000, 16);
        this.spaces[17] = new CardSpace(17);
        this.spaces[18] = new Property(180000, 14000, 100000, 18);
        this.spaces[19] = new Property(200000, 16000, 100000, 19);
        this.spaces[20] = new SpecialSpace(20);
        this.spaces[21] = new Property(220000, 18000, 150000, 21);
        this.spaces[22] = new CardSpace(22);
        this.spaces[23] = new Property(220000, 18000, 150000, 23);
        this.spaces[24] = new Property(240000, 20000, 150000, 24);
        this.spaces[25] = new Property(200000, 25000, 0, 25);
        this.spaces[26] = new Property(260000, 22000, 150000, 26);
        this.spaces[27] = new Property(260000, 22000, 150000, 27);
        this.spaces[28] = new Property(150000, 0, 0, 28);
        this.spaces[29] = new Property(280000, 24000, 150000, 29);
        this.spaces[30] = new SpecialSpace(30);
        this.spaces[31] = new Property(300000, 26000, 200000, 31);
        this.spaces[32] = new Property(300000, 26000, 200000, 32);
        this.spaces[33] = new CardSpace(33);
        this.spaces[34] = new Property(320000, 28000, 200000, 34);
        this.spaces[35] = new Property(200000, 25000, 0, 35);
        this.spaces[36] = new CardSpace(36);
        this.spaces[37] = new Property(350000, 35000, 200000, 37);
        this.spaces[38] = new SpecialSpace(38);
        this.spaces[39] = new Property(400000, 50000, 200000, 39);


    }

    /// <summary>
    /// manages the display of the board
    /// </summary>

    private Game game;

}
