/* Navigation Notes
    
    Stateless methods           : line 12 
    Stateful methods            : line 20
    Return values               : line 41
    Method param and args       : line 58
    Overloaded methods          : line 76
    If-Else / If-Else If-Else   : line 109
    
    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

/* STATELESS METHODS / STATIC METHODS */
/*
   Methods that are implemented so that they can work without referencing or changing any values already stored in memory.

    Examples:
    Console.WriteLine(); - method doesn't rely on any values stored in memory. 
*/

// STATEFUL METHODS / INSTANCE METHODS
/*
    Methods that are built in such a way that they rely on values stored in memory by previous lines of code that have already been executed.
    Stateful (instance) methods keep track of their state in fields, which are variables defined on the class. Each new instance of the class gets its own copy of those fields in which to store state. 
*/


/* Example of creating the instance of the class and calling the method */

// We need create instance of the Random class to create dice object
Random dice = new Random();

// so we can call the method Next() and pass the values to generate the value
int roll = dice.Next(1, 7); // Next is statefull method

// Some methods (statefull) require you to create an instance of a class before you call them, while others do not (stateless).

// print to teh console rolled dice number
Console.WriteLine("Roll the dice....");
Console.WriteLine($"Rolled number: {roll}");

/* RETURN VALUES */
/* 
 -  Void methods they don't return a value when they finish.
 -  A method can be designed to return any data type, even another class.
 - When calling a method that returns a value, you'll often assign the return value to a variable.

    Random dice = new();
    int roll = dice.Next(1, 7);

 - to use the return value directly

    Console.WriteLine(dice.Next(1, 7));

*/


/* METHOD PARAMETERS AND ARGUMENTS IN THE CALLING STATEMENT */

// Random dice = new Random();

/*
 - When you call a method, you can pass in values that the method will use to complete its task. These values are called ARGUMENTS. 

    int roll = dice.Next(1, 7); 

 - The method uses the arguments to assign values to the PARAMETERS that are defined in the METHOD'S SIGNATURE. 

    The Next() method includes a method signature that accepts two parameters of type int.    

 - Often times, the terms 'parameter' and 'argument' are used interchangeably. However, 'parameter' refers to the variable that's being used inside the method. An 'argument' is the value that's passed when the method is called.
 - Methods use a 'method signature' to define the number of parameters that the method will accept, as well as the data type of each parameter. The coding statement that calls the method must adhere the requirements specified by the method signature. Some methods provide options for the number and type of parameters that the method accepts.
*/

/* OVERLOADED METHODS */

/*
 
 - An overloaded method is defined with multiple method signatures. Overloaded methods provide different ways to call the method or provide different types of data.

    int number = 7;
    string text = "seven";

    Console.WriteLine(number); // method uses a method signature that defines an int parameter.
    Console.WriteLine(); // method uses a method signature that defines zero parameters.
    Console.WriteLine(text); // method uses a method signature that defines a string parameter.
 
*/

// return random numbers
Random dice22 = new();
int roll1 = dice22.Next(); // no low or upper boundary, so retuen value is from 0 to max value int can store
int roll2 = dice22.Next(101); // specify top value, so return int value is from 0 to 100
int roll3 = dice22.Next(50, 101); // boundry from 50 to 100

Console.WriteLine($"\n\nFirst roll {roll1}");
Console.WriteLine($"Second roll {roll2}");
Console.WriteLine($"Thirdó roll {roll3}");

// return max value of two numbers
int firstValue = 100;
int secondValue = 66;
int largerValue = Math.Max(firstValue, secondValue);

Console.WriteLine($"The larger value of {firstValue} and {secondValue} is: {largerValue}");


/* IF-ELSE */



/*
 
 You'll use the Random.Next() method to simulate rolling three six-sided dice. You'll evaluate the rolled values to calculate the score. If the score is greater than an arbitrary total, then you'll display a winning message to the user. If the score is below the cutoff, you'll display a losing message to the user.

If any two dice you roll result in the same value, you get two bonus points for rolling doubles.
If all three dice you roll result in the same value, you get six bonus points for rolling triples.
If the sum of the three dice rolls, plus any point bonuses, is 15 or greater, you win the game. Otherwise, you lose.
 
 */

// Example 1 of if-else statement
var rollDice = new Random(); // modern way, implicit typing

int rollDice1 = rollDice.Next(1, 7);
int rollDice2 = rollDice.Next(1, 7);
int rollDice3 = rollDice.Next(1, 7);

int total = rollDice1 + rollDice2 + rollDice3;

Console.WriteLine($"\n\nDice roll: {rollDice1} + {rollDice2} + {rollDice3} = {total}");

//if( total > 14)
//{
//    Console.WriteLine("You win!");
//} else if ( total < 15)
//{
//    Console.WriteLine("You lose.");
//}

// or shorter

if ((rollDice1 == rollDice2) || (rollDice2 == rollDice3) || (rollDice1 == rollDice3))
{
    if ((rollDice1 == rollDice2) && (rollDice2 == rollDice3))
    {
        Console.WriteLine("You rolled triples! +6 bonus to total!");
        total += 6;
        Console.WriteLine($"Your dice roll is {total}");
    }
    else
    {
        Console.WriteLine("You rolled doubles! +2 bouns to total!");
        total += 2;
        Console.WriteLine($"Your dice roll is {total}");
    }
}



if( total >= 15)
{
    Console.WriteLine("You win!");
} else 
{
    Console.WriteLine("You lose.");
}


// Example 2 of if-else
string message = "The C# is the best langauge for desktop apps.";

if (message.Contains("C#"))
{
    Console.WriteLine("\n\nYes you like C#!");
}else
{
    Console.WriteLine("Not sure what you like");
}