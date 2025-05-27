using System;
using System.Collections;
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
    public List<string> playerNames = new List<string>();
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
        this.players = new Player[2];
        this.players[0] = new Player(" 1");
        this.players[1] = new Player(" 2");
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
                    plateau.ConsoleJeux.Text += $"{playerNames[0]} possède {players[0].account} € \n";
                    if (players[0].isInJail == true)
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show("Vous êtes en prison, vous devez payer 50000 pour sortir", "Prison", MessageBoxButton.YesNo);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            int value = 50000;
                            players[0].Pay(ref value);
                            players[0].isInJail = false;
                        }
                        else
                        {
                            plateau.ConsoleJeux.Text += $" ---- {playerNames[0]} est toujours en prison ---- \n";
                            return;
                        }
                    }
                    else { 
                    int diceValue = players[0].RollDice();
                    MessageBox.Show($"Vous avez lancé le dé et obtenu : {diceValue}", "Lancement du dé", MessageBoxButton.OK, MessageBoxImage.Information); 
                    players[0].verifPosition(players[0].position);
                    plateau.ConsoleJeux.Text += $" ---- {playerNames[0]} a lancé le dé et a obtenu : {diceValue} ---- \n";
                    plateau.MooveF1(isPlayerTurn, players[0].position);
                    board.spaces[players[0].position].Action(ref players[0], plateau, this);
                        if (players[0] != null && players[0].properties != null && players[0].properties.Length > 0)
                    {
                        MessageBoxResult messageBoxAmelioration = MessageBox.Show("Souhaitez vous améliorer vos propriétés ?", "Amelioration", MessageBoxButton.YesNo);
                        if (messageBoxAmelioration == MessageBoxResult.Yes)
                        {
                            // Afficher la fenetre Ameliorations
                            // Amelioration amelioration = new Amelioration(player[0].properties);
                            // amelioration.Show();
                        }

                    }
                    this.isPlayerTurn = true;
                    }
                }
                else
                {
                    if (players[1].isInJail == true)
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show("Vous êtes en prison, vous devez payer 50000 pour sortir", "Prison", MessageBoxButton.YesNo);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            int value = 50000;
                            players[1].Pay(ref value);
                            players[1].isInJail = false;
                        }
                        else
                        {
                            plateau.ConsoleJeux.Text += $" ---- {playerNames[1]} est toujours en prison ---- \n";
                            return;
                        }
                    }
                    else
                    {
                        int diceValue = players[1].RollDice();
                        players[1].verifPosition(players[1].position);
                        plateau.ConsoleJeux.Text += $" ---- {playerNames[1]} a lancé le dé et a obtenu : {players[1].position} ---- \n";
                        plateau.MooveF1(isPlayerTurn, players[1].position);
                        board.spaces[players[1].position].Action(ref players[1], plateau, this);

                        if (players[1] != null && players[1].properties != null && players[1].properties.Length > 0)
                        {
                            MessageBoxResult messageBoxAmelioration = MessageBox.Show("Souhaitez vous améliorer vos propriétés ?", "Amelioration", MessageBoxButton.YesNo);
                            if (messageBoxAmelioration == MessageBoxResult.Yes)
                            {
                                // Afficher la fenetre Ameliorations  
                                // Amelioration amelioration = new Amelioration(players[1].properties);  
                                // amelioration.Show();  
                            }
                        }
                        this.isPlayerTurn = false;
                    }
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
