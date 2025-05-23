using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
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
    private bool Btn_clicked = false; // Indicates if the button has been clicked

    public Connect connect = new Connect();

    /// <summary>
    /// Constructor
    /// </summary>
    public Game(Plateau plateau, Board board) {
		this.board = board;
        this.plateau = plateau;
        this.bank = new Bank();
		InitPlayer();
    }

    public void InitPlayer()
	{
		this.playerNames =connect.SelectJoueur();

        this.players = new Player[2];
        this.players[0] = new Player(this.playerNames[0]);
        this.players[1] = new Player(this.playerNames[1]);
    }
	/// <summary>
	/// Constructor
	/// </summary>
	public Game(Plateau plateau) {
		this.players = new Player[2];
        this.players[0] = new Player(" 1");
        this.players[1] = new Player(" 2");
		this.bank = new Bank();
    }
    /// <summary>
    /// Starts the game
    /// </summary>
    public void StartGame(bool joueur, bool statutGame)
    {
        this.isPlayerTurn = joueur;
        this.isGameOver = statutGame;
        PlayTurn();

        if (this.Btn_Clicked == true)
        {
            if (!this.isGameOver)
            {
                if (this.isPlayerTurn == false)
                {
                    players[0].RollDice();
                    players[0].verifPosition(players[0].position);
                    plateau.ConsoleJeux.Text += $" ---- {playerNames[0]} a lancé le dé et a obtenu : {players[0].position} ---- \n";
                    plateau.MooveF1(isPlayerTurn, players[0].position);
                    this.isPlayerTurn = true;
                }
                else
                {
                    players[1].RollDice();
                    players[1].verifPosition(players[1].position);
                    plateau.MooveF1(isPlayerTurn, players[1].position);
                    plateau.ConsoleJeux.Text += $" ---- {playerNames[1]} a lancé le dé et a obtenu : {players[1].position} ---- \n";
                    this.isPlayerTurn = false;
                }
            }
            this.Btn_Clicked = false;
        }
    }

    /// <summary>
    /// Executes a player's turn
    /// </summary>
    public void PlayTurn()
    {
        if (this.isPlayerTurn == false) // Joueur 1
        {
            plateau.Jouer.Content = playerNames[0];
        }
        else // Joueur 2
        {
            plateau.Jouer.Content = playerNames[1];
        }
    }

    /// <summary>
    /// Ends the game and declares a winner
    /// </summary>
    public void EndGame() {
		throw new System.NotImplementedException("Not implemented");
	}

	private Player[] player;


    /// <summary>
    /// A bouger plus tard
    /// </summary>
    public bool Btn_Clicked { get; set; }
    public bool IsPlayerTurn
    {
        get => isPlayerTurn;
        set => isPlayerTurn = value;
    }
    public bool IsGameOver { get; set; }

}
