// Game class handles the core logic of the game: roll dice, user input, validation
class Game{
    private int _tries = 0; // Tracks the number of attempts the user has made
    private const string _exitCommand = "exit"; // Command to exit the game
    private readonly RollDice _roll = new RollDice(); // Instance to handle dice rolling
    private readonly InputValidator _number = new InputValidator(); // Instance to validate user input
    public bool IsExitGame { get; private set; } = false; // Set the flag when exit the game to omit asking user to play again

    // Method to reset the tries counter (called when starting a new game)
    public void ResetTries()
    {
        _tries = 0;
    }

    // Core method that handles user input and game flow
    public void UserInput(){       

        var roll = _roll.Roll(); // Roll the dice at the start of the game

        // Loop that allows up to MaxTries attempts for the user to guess the number
        while (_tries < Constants.MaxTries)
        {
            Console.Write("Enter a number or type [exit]: ");
            
            var userNumber = Console.ReadLine();

            // If user types the exit command, the game exits
            if (ValidateExitCommand(userNumber)) return;

            // Check if the guess is valid, and if it's correct, or continue to next attempt
            if (ValidateGuess(userNumber, roll)) return;            
        }

        // If user reaches the max tries without guessing correctly
        Console.WriteLine("You loose.");
    }

    // Helper method to check if the user entered the exit command
    private bool ValidateExitCommand(string userInput) {
        if(!string.IsNullOrEmpty(userInput) && userInput.Trim().ToLower() == _exitCommand){
            IsExitGame = true; // Set the exit flag to True to omit asking user to play again
            return true;
        }
        return false;
    }

    // Helper method to validate and process the user's guess
    private bool ValidateGuess(string userInput, int roll)
    {
        if (!string.IsNullOrEmpty(userInput) && _number.IsValid(userInput, out int value))
        {
            _tries++; // Increment tries counter

            // Check if the guess matches the rolled number
            if (value == roll)
            {
                Console.WriteLine("You win!");
                return true;
            }else{
                Console.WriteLine("Wrong number.");            
            }            
        }else{
            Console.WriteLine("Invalid input. Enter a number between 1 and 6.");
        }
        
        return false; // If the guess was incorrect, return false to allow another try        
    }

}
