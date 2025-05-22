using System;
using System.Diagnostics.Eventing.Reader;
using Monopoly.BDD;
using Monopoly.IHM;

/// <summary>
/// A "game" Class which contains all the elements of the game
/// </summary>
public class Game {
	/// <summary>
	///  The game board containing all spaces
	/// </summary>
	private Board board;
    private Plateau plateau;
    private Player[] players;
	private Bank bank;
    private List<string> playerNames = new List<string>();
	private bool isGameOver = false; // Indicates if the game is over
	private bool isPlayerTurn = false; // Indicates if it's the player's turn false = joueur 1 true = joueur 2

    public Connect connect = new Connect();

    /// <summary>
    /// Constructor
    /// </summary>
    public Game(Plateau plateau, Board board) {
		this.board = board;
        this.plateau = plateau;
        this.bank = new Bank();
		InitPlayer();
		StartGame();
    }

	public void InitPlayer()
	{
		this.playerNames =connect.SelectJoueur();

        this.players = new Player[2];
        this.players[0] = new Player(this.playerNames[0]);
        this.players[1] = new Player(this.playerNames[1]);
    }

	/// <summary>
	/// Starts the game
	/// </summary>
	public void StartGame() {
		if (this.isPlayerTurn == false)
		{
            players[0].RollDice();
			plateau.MooveF1(isPlayerTurn, players[0].position);
        }

    }
	/// <summary>
	/// Executes a player's turn
	/// </summary>
	public void PlayTurn() {
		throw new System.NotImplementedException("Not implemented");
	}
	/// <summary>
	/// Ends the game and declares a winner
	/// </summary>
	public void EndGame() {
		throw new System.NotImplementedException("Not implemented");
	}

	private Player[] player;

}
