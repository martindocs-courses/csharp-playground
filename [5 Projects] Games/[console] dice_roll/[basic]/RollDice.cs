// RollDice handles the random dice roll logic
class RollDice
{   
    private static readonly Random _random = new Random();

    // Rolls a dice and returns a random number between DiceLowerLimit (1) and DiceUpperLimit (6 + 1)
    public int Roll() => _random.Next(Constants.DiceLowerLimit, Constants.DiceUpperLimit + 1);        
}

