using System;
using Monopoly.IHM;

/// <summary>
/// A "game" Class which contains all the elements of the game
/// </summary>
public class Game {
	/// <summary>
	///  The game board containing all spaces
	/// </summary>
	private Board board;
	private Player[] players;
	private Bank bank;

	/// <summary>
	/// Constructor
	/// </summary>
	public Game(Plateau plateau) {
		this.players = new Player[2];
        this.players[0] = new Player("Player 1");
        this.players[1] = new Player("Player 2");
		this.bank = new Bank();
    }
	/// <summary>
	/// Starts the game
	/// </summary>
	public void StartGame() {
		throw new System.NotImplementedException("Not implemented");
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
