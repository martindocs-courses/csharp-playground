/* This program prompts the user for two numbers and performs a calculation
 (addition, subtraction, or multiplication) based on user input. */

// Entry point of the program
Console.WriteLine("Hello");

// Prompt the user for the first number. Exit if the user chooses to.
int? firstNumber = InputNumbers("first");

// Using .HasValue and .Value explicitly makes it clear that the nullable variable is not null
if (firstNumber.HasValue)
{
    // Prompt the user for the second number. Exit if the user chooses to.
    int? secondNumber = InputNumbers("second");

    if (secondNumber.HasValue)
    {
        // Only invoke the Calculation method if both numbers are valid.
        Calculation(firstNumber.Value, secondNumber.Value);
    }
}

Console.WriteLine("Press the key to close");
Console.ReadKey();

// User prompt for the number input
// Using int? handle cases where the user chooses exit
int? InputNumbers(string text)
{
    int errorCount = 0; // Track invalid attempts

    do
    {
        Console.Write($"Input the {text} number: ");
        string? inputValue = Console.ReadLine();

        if (inputValue != null)
        {
            try
            {
                return int.Parse(inputValue);
            }
            // Handle invalid input formats (e.g., letters or symbols).
            catch (FormatException ex)
            {
                ErrorMessage(ex.Message);
            }
            // Handle numbers too large or small for the int type.
            catch (OverflowException ex)
            {
                ErrorMessage(ex.Message);
            }

            errorCount++;
        }

        // After three invalid attempts, the user is prompted to exit or retry.
        if (errorCount == 3)
        {
            errorCount = 0;

            Console.WriteLine("\rToo many invalid attempts. Press [E] to Exit or any other key to retry.");
            string? exit = Console.ReadLine()?.ToLower();

            if (exit == "e")
            {
                return null;
            }
        }
    } while (true);
}

// Perform the calculation based on user-selected operations.
void Calculation(int value1, int value2)
{
    do
    {
        Console.WriteLine("What do you want to do with those numbers?\r\n[A]dd\r\n[S]ubtract\r\n[M]ultiply\r\n[E]xit Program");

        string? inputOperator = Console.ReadLine()?.ToLower();

        if (inputOperator != null)
        {
            if (inputOperator == "a")
            {
                Console.WriteLine(Add(value1, value2));
                break;
            }
            else if (inputOperator == "s")
            {
                Console.WriteLine(Subtract(value1, value2));
                break;
            }
            else if (inputOperator == "m")
            {
                Console.WriteLine(Multiply(value1, value2));
                break;
            }
            else if (inputOperator == "e")
            {
                break;
            }
            else
            {
                Console.WriteLine("\n" + "Invalid choice" + "\n");
            }
        }
    } while (true);
}

// Addition operation
string Add(int value1, int value2)
{
    return value1 + " + " + value2 + " = " + (value1 + value2);
}

// Subtraction operation
string Subtract(int value1, int value2)
{
    return value1 + " - " + value2 + " = " + (value1 - value2);
}

// Multiplication operation
string Multiply(int value1, int value2)
{
    return value1 + " * " + value2 + " = " + (value1 * value2);
}

// Display error messages
void ErrorMessage(string message)
{
    Console.WriteLine("\n" + message + "\n");
}