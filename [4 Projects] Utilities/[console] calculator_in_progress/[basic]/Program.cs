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
         
    * Then ask the user to choose operator:
        - show to the user list of allow operators ['+', '-', '*', '/']
        - implement another do while loop for user to enter the allow operator
        - if the user enters wrong operators show the error message to the user and repeat loop
   
    * Next ask the user for the second number:
        - steps are the same as for the first number
         
    * Before value is returned to the user:
        - implement divide by zero error handling
        - for edge case when the user input lower number thatn zero, example: -18. modify value to absolute value 
        - calculate the values with choosen operator 
       
    * Return the value to the user  
    * Ask user if he/she wants to proceede with another calculation:
        - promt the user to enter 'y' or 'n'
        - use loop to validate the input
        - if 'y' repeat the calculations, if 'n' exit the program
 */
#endregion

int firstValue = AskUser("Enter the first number: ");

char[] delimiters = { '+', '-', '*', '/' };
char operatorResult = ' ';
bool validOperator = false;

do {
    Console.Write("Enter the operator ['+', '-', '*', '/']: ");
    string? inputOperator = Console.ReadLine();

    if (inputOperator != null) {
        char inputChar = inputOperator[0];
        bool isDelimiter = Array.Exists(delimiters, delimiter => delimiter == inputChar);
               
        if (isDelimiter) {
            operatorResult = inputChar;
            validOperator = true;
        }else{
            Console.WriteLine("\nPlease enter a valid operator.\n");
        }  
    }
} while (!validOperator);

int secondValue = AskUser("Enter the second number: ");

switch(operatorResult){
    case ('+'):
        Addition();
        break;
    case ('-'):
        Subtraction();
        break;
    case ('*'):
        Multiplication();
        break;
    case ('/'):
        Division();
        break;
}

// Function ask user for valid number
int AskUser(string text){

    bool validNumber = false;
    int result = 0;
    do
    {
        Console.Write($"{text}: ");
        string? number = Console.ReadLine();
        if (number != null)
        {
            if (int.TryParse(number, out result))
            {
                validNumber = true;
            }
            else
            {
                Console.WriteLine("\nPlease input a valid number.\n");
            }
        }
    } while (!validNumber);

    return result;
}

int Addition(){
    throw new NotImplementedException("This feature is still under development.");    
}

int Subtraction(){
    throw new NotImplementedException("This feature is still under development.");
}

int Multiplication(){

    throw new NotImplementedException("This feature is still under development.");
}

int Division(){

    throw new NotImplementedException("This feature is still under development.");
}
