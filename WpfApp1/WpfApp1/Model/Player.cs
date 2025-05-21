using System;

/// <summary>  
/// Represents a player in the game  
/// </summary>  
public class Player
{
    /// <summary>  
    /// Player's name  
    /// </summary>  
    private string name;
    /// <summary>  
    /// Player's current money  
    /// </summary>  
    public int account;
    /// <summary>  
    /// Current board position  
    /// </summary>  
    public int position;
    /// <summary>  
    /// Owned properties  
    /// </summary>  
    private Property[] properties; // Fixed type to 'Property[]' instead of 'Player[]'

    private Dice dice; // Fixed ambiguity by ensuring only one 'dice' field exists  

<<<<<<< Updated upstream
    public int nb_championships;
    public int nb_museums;

    /// <summary>  
    /// Player's constructor  
    /// </summary>  
    /// <param name="n">the name of the player</param>  
    public Player(string n)
    {
        this.name = n;
        this.account = 1500; // Starting money  
        this.position = 0; // Starting position  
        this.properties = new Property[0]; // Initialize an empty array of properties  
        this.dice = new Dice(); // Initialize the dice field
        this.nb_championships = 0; // Initialize the number of championships 
        this.nb_museums = 0; // Initialize the number of museums

    }

    /// <summary>  
    /// Rolls the dice  
    /// </summary>  
    public void RollDice()
    {
        this.position += dice.Roll();
    }

=======
    /// <summary>  
    /// Player's constructor  
    /// </summary>  
    /// <param name="n">the name of the player</param>  
    public Player(string n)
    {
        this.name = n;
        this.account = 1500; // Starting money  
        this.position = 0; // Starting position  
        this.properties = new Property[0]; // Initialize an empty array of properties  
        this.dice = new Dice(); // Initialize the dice field  
    }

    /// <summary>  
    /// Rolls the dice  
    /// </summary>  
    public void RollDice()
    {
        this.position += dice.Roll();
    }

>>>>>>> Stashed changes
    /// <summary>  
    /// Buys a property  
    /// </summary>  
    public void Buy(Property p)
    {
        this.account -= p.price; // Deduct the price from the account  
        Array.Resize(ref this.properties, this.properties.Length + 1); // Resize the properties array  
        this.properties[this.properties.Length - 1] = p; // Add the property to the properties array
<<<<<<< Updated upstream
        if (p.position == 5 || p.position == 15 || p.position ==25 || p.position == 35)
        {
            this.nb_championships++; // Increment the number of championships if the property is a championship
        }
        else if (p.position == 12 || p.position == 28)
        {
            this.nb_museums++; // Increment the number of museums if the property is a museum
        }
=======
>>>>>>> Stashed changes
    }

    /// <summary>  
    /// Pays a specified amount  
    /// </summary>  
    /// <param name="s">the amount of money which is spent</param>  
    public void Pay(ref int s)
    {
        this.account -= s; // Deduct the amount from the account  
        s = 0; // Reset the amount to zero after payment  
    }

    private Property[] propertys;

    private Game game;
}
