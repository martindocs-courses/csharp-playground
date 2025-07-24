namespace dice_roll.Game
{
    // InputValidator is used to validate user input and ensure it's a valid dice number within the range of 1 to 6
    class InputValidator
    {
        private const int defaultValue = 0;

        // Validates if the user input is a valid number between DiceLowerLimit (1) and DiceUpperLimit (6)
        public bool IsValid(string number, out int value)
        {
            value = defaultValue;

            // If within the valid range and is number, return true
            if (int.TryParse(number, out int result) && result >= Constants.DiceLowerLimit && result <= Constants.DiceUpperLimit)
            {
                value = result;
                return true;
            }

            return false;
        }
    }
}