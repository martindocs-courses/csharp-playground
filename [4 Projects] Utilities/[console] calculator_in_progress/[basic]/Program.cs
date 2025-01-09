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
       
    * Return the value to the user  
    * Ask user if he/she wants to proceede with another calculation:
        - promt the user to enter 'y' or 'n'
        - use loop to validate the input
        - if 'y' repeat the calculations, if 'n' exit the program
 */
#endregion

using System.Reflection.Metadata.Ecma335;

double firstValue = UserInput("Enter the first number: ");
double secondValue = UserInput("Enter the second number: ");

char[] delimiters = { '+', '-', '*', '/' };
char operatorResult = ' ';
bool validOperator = false;

do {
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


switch(operatorResult){
    case ('+'):
        Console.WriteLine(Addition());
        break;
    case ('-'):
        Console.WriteLine(Subtraction());
        break;
    case ('*'):
        Console.WriteLine(Multiplication());
        break;
    case ('/'):
        Division();
        break;
}

// Function to ask user for valid number
double UserInput(string text){

    bool validNumber = false;
    double result = 0;

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

    return AbsoluteValue(result);
}

string Addition(){
    double result = firstValue + secondValue;

    return $"The result of {firstValue} + {secondValue} = {PrecisionChecks(result)}";

}

string Subtraction(){
    double result = firstValue - secondValue;

    return $"The result of {firstValue} - {secondValue} = {PrecisionChecks(result)}";
}

string Multiplication(){
    double result = firstValue * secondValue;

    return $"The result of {firstValue} * {secondValue} = {PrecisionChecks(result)}";
}

int Division(){

    throw new NotImplementedException("This feature is still under development.");
}

double AbsoluteValue(double vale){
    return Math.Abs(vale);
}

string PrecisionChecks(double value){
    if (value % 1 == 0)
    {
        return $"{(value):N0}"; ;
    }
    else
    {
        return $"{(value):N3}";
    }
}