namespace dice_roll.Game
{
    // RollDice handles the random dice roll logic
    class RollDice
    {
        // This is dependency of the RollDIce class, so it' a bad practice to create object here
        // private static readonly Random _random = new Random();
        // and the dependencies should rather be given to a class via the constructor than created right in this class.
        private readonly Random _random;

        /*
            Constructor Injection is one way of providing dependencies to a class. Instead of the class creating its own dependencies, it receives them as arguments in its constructor. This means the class does not need to worry about how its dependencies are created, and the dependencies are "injected" from outside.
         */
        public RollDice(Random random)
        {
            _random = random;
        }

        // Rolls a dice and returns a random number between DiceLowerLimit (1) and DiceUpperLimit (6 + 1)
        public int Roll() => _random.Next(Constants.DiceLowerLimit, Constants.DiceUpperLimit + 1);
    }
}
