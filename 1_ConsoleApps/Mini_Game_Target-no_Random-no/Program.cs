
/*
    The game should select a target number that is a random number between one and five (inclusive). The player must roll a six-sided dice. To win, the player must roll a number greater than the target number. At the end of each round, the player should be asked if they would like to play again, and the game should continue or terminate accordingly. 
 */

using System.Reflection.Metadata.Ecma335;
Random random = new();

Console.WriteLine("Would you like to play? (Y/N)");
string? input = Console.ReadLine();

if (input != null)
{
    if (ShouldPlay(input))
    {
        PlayGame();
    }
}

void PlayGame()
{
    var play = true;

    while (play)
    {

        var target = GetTarget();
        var roll = RollDice();

        Console.WriteLine($"Roll a number greater than {target} to win!");
        Console.WriteLine($"You rolled a {roll}");
        Console.WriteLine(WinOrLose(roll, target));
        Console.WriteLine("\nPlay again? (Y/N)");
        input = Console.ReadLine();

        if (input != null)
        {
            play = ShouldPlay(input);
        }

    }
}

bool ShouldPlay(string value)
{
    if (value.ToLower() == "n")
    {
        return false;
    }
    return true;
}

int RollDice()
{

    return random.Next(1, 7);
}

int GetTarget()
{
    return random.Next(1, 6);
}

string WinOrLose(int roll, int target)
{

    if (roll > target)
    {
        return "You win!";
    }

    return "You lose!";
}