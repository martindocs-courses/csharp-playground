/*
    Author: Marcin Tatarski
    Description: A simple calculator to perform basic arithmetic operations.

    Level: Basic

    Concepts: 
    * Input/output handling.
    * Conditional statements for operator selection.
    * Basic error handling.
    
    Features:  
    * addition, 
    * subtraction, 
    * multiplication, 
    * division    
 */

// NOTE: This calculator is a work in progress.
// Currently, operations are not implemented.

#region Pseudocode
/*
    * Ask user to input first number:
        - implement do while loop for the first number and to ask the user for the number. 
        - if the number is valid exit the loop
        - before exiting the loop check if it's an valid number by using TryParse method
        - if the number is incorrect show the error message to the user and repeat the loop
         
    * Next ask the user for the second number:
        - steps are the same as for the first number

    * Then ask the user to choose operator:
        - show to the user list of allow operators ['+', '-', '*', '/']
        - implement do while loop for user to enter the allow operator
        - if the user enters wrong operators show the error message to the user and repeat loop   
         
    * Before value is returned to the user:
        - implement divide by zero error handling
        - for edge case when the user input lower number than zero, example: -18. modify value to absolute value 
        - calculate the values with choosen operator 
       
    * Return the whole number or decimal value, depend of the user input        
    * Ask user if he/she wants to proceede with another calculation:
        - promt the user to enter 'y' or 'n'
        - if 'y' use recursive method to repeat calculations
        - if 'n' or any other character, exit the program
 */
#endregion


class BasicCalculator
{

    static void Main(){
        Calculator();
    }

    static void Calculator(){
    
        double firstValue = UserInput("Enter the first number: ");
        double secondValue = UserInput("Enter the second number: ");

        char[] delimiters = { '+', '-', '*', '/' };
        char operatorResult = ' ';
        bool validOperator = false;

        // Loop until a valid operator is entered by the user.
        do
        {
            Console.Write("Enter the operator ['+', '-', '*', '/']: ");
            string? inputOperator = Console.ReadLine();

            if (inputOperator != null) {
                char inputChar = inputOperator.Trim()[0];
                bool isDelimiter = Array.Exists(delimiters, delimiter => delimiter == inputChar);
               
                if (isDelimiter) {
                    operatorResult = inputChar;
                    validOperator = true;
                }else{
                    Console.WriteLine("\nPlease enter a valid operator.\n");
                }  
            }
        } while (!validOperator);

        // Perform the operation based on the selected operator.
        switch (operatorResult){
            case ('+'):
                Addition(firstValue, secondValue);
                break;
            case ('-'):
                Subtraction(firstValue, secondValue);
                break;
            case ('*'):
                Multiplication(firstValue, secondValue);
                break;
            case ('/'):
                try{
                    Division(firstValue, secondValue);
                }catch(DivideByZeroException ex){
                    Console.WriteLine($"\n{ex.Message}");
                }
                break;
            
        }

        Restart();
    }

    // Prompts the user to input a valid number and validates the input.
    static double UserInput(string text){

        bool validNumber = false;
        double result = 0;

        // Invalid input prompts the user to retry.
        do
        {
            Console.Write($"{text}: ");
            string? number = Console.ReadLine();

            if (number != null)
            {
                if (double.TryParse(number, out result))
                {
                    validNumber = true;
                }
                else
                {
                    Console.WriteLine("\nPlease input a valid number.\n");
                }
            }
        } while (!validNumber);

        // Return the absolute value of the input to avoid negative values if desired.
        return AbsoluteValue(result);
    }

    // Performs addition of the two user inputs and displays the result.
    static void Addition(double number1, double number2){
        double result = number1 + number2;

        Console.WriteLine($"The result of {number1} + {number2} = {PrecisionChecks(result)}");
    }

    // Performs subtraction of the two user inputs and displays the result.
    static void Subtraction(double number1, double number2)
    {
        double result = number1 - number2;

        Console.WriteLine($"The result of {number1} - {number2} = {PrecisionChecks(result)}");
    }

    // Performs multiplication of the two user inputs and displays the result.
    static void Multiplication(double number1, double number2)
    {
        double result = number1 * number2;

        Console.WriteLine($"The result of {number1} * {number2} = {PrecisionChecks(result)}");
    }

    // Performs division of the two user inputs and displays the result.
    static void Division(double number1, double number2)
    {
        // Division by zero with double inputs normally results in infinity
        double result = number1 / number2;

        // Handle divide-by-zero for integer-equivalent second values.
        // We're explicitly throwing an exception for user feedback if the second number is zero
        if ((int)number2 == 0){
            throw new DivideByZeroException("DivideByZeroException: Calculation in 'Division' method encountered an unexpected divide by zero.");
        }else{
            Console.WriteLine($"The result of {number1} / {number2} = {PrecisionChecks(result)}");
        }
    }

    static double AbsoluteValue(double vale){
        return Math.Abs(vale);
    }

    // If calculation of two numbers has any digits after the decimal point, the return number display tree digit after decimal point. Othervise the return value is whole number.  
    static string PrecisionChecks(double value){
        if (value % 1 == 0)
        {
            return $"{(value):N0}"; ;
        }
        else
        {
            return $"{(value):N3}";
        }
    }

    // Restart the app
    static void Restart(){
        Console.WriteLine("\nDo you want to perform another calculation? (yes/no)");
        string? restart = Console.ReadLine();

        if(restart?.ToLower() != null){
            if(restart == "y"){
                Console.Clear();
                Calculator();
            }else{
                Console.WriteLine("Goodbaye!");
                return;
            }
        }
    }
}