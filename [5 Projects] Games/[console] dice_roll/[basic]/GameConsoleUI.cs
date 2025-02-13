// GameConsoleUI handles the user interface and interaction with the game
class GameConsoleUI
{
    private readonly Game _game; // Game instance to handle game logic     

    public GameConsoleUI(Game game)
    {
        _game = game;
    }

    public void GameUI()
    {
        // Game loop: keeps asking user if they want to play again after each game
        while (true)
        {
            Console.WriteLine("Dice rolled. Guess what number in 3 tries.");
            _game.UserInput(); // Initiates the game logic where user guesses the number

            // Check if user wants to exit the game. If yes omit asking user to start again 
            if (!_game.IsExitGame){
                Console.WriteLine("Do you want start again? [y/n]");
                var userInput = Console.ReadLine();

                if(GameRestartConfirmation(userInput)) continue;

                if (ShouldExit(userInput)) break;           
            }else{
                break; // end the game 
            }
        }

        Console.WriteLine("Goodbye!");

    }

    // Helper method to confirm if the user wants to restart the game
    private bool GameRestartConfirmation(string userInput)
    {
        if (!string.IsNullOrEmpty(userInput) && userInput.Trim().ToLower() == "y")
        {
            _game.ResetTries(); // Reset the game tries counter
            Console.Clear(); // Clear the console for a fresh start
            return true;
        }

        return false;
    }

    // Helper method to check if the user wants to exit the game
    private bool ShouldExit(string userInput){
        if (userInput?.Trim().ToLower() != "y"){
            return true; // User chooses to exit the game
        }

        return false;
    }

}