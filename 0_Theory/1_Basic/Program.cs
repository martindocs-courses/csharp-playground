/* Navigation Notes
    
    Literal values      : line 22 
    Variables           : line 45
    String formating    : line 75
 
    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/


// Write to the console output and put the line feed at the end
Console.WriteLine("Hello, World!");

// Same as above, but Without line feed
Console.Write("Everything on");
Console.Write(" ");
Console.Write("one line");
Console.WriteLine("");


/* LITERAL VALUES - It's constant and is never change. */

// Characters Literal (char) - single characters in single quotes
Console.WriteLine('A');

// String literals (string) - surrounded in double quotes
Console.WriteLine("This is literal string");

// Integer literals (int) - whole numbers, no fraction
Console.WriteLine(123);

// Floating-point literals (float) - it contains a decimals and it's best to use for fixed fractional values
Console.WriteLine(0.25f); // precision ~6-9 digits, where f or F is literal suffix

// Double literals (double) - compiler defaults to a double literal if a decimal number is entered without a literal suffix.
Console.WriteLine(3.1456); // precision ~15-17 digits

// Decimal literals (decimal) - 
Console.WriteLine(3.14m); // precision 28-29 digitsm where m or M is literal suffix

// Boolean literals (bool) - true or false
Console.WriteLine(true); // precision 28-29 digitsm where m or M is literal suffix


/* VARIABLES */
/*
    - use camelVaseVariableNames 
    - name of variable should be descriptive and meaningful. Chose the name that represent the data it holds
    - variable name shoudn't use data type of the variable - string strName 
 */

// Decrale variable and initialize it
string firstName = "Martin";
int age = 23;
decimal luckyNumber = 3.14m; 
bool userAsnwer = false;

Console.Write(firstName + " is " + age + " years old, " + "and his lucky number is " + luckyNumber);
Console.WriteLine("");

// Implicityly typed local variables, by using 'var' keyword
/*
    - it needs to be initialized right after declaring
    - data type is implied by the assigend value 
    - practical used
    * when a variable is obvious from its initialization
    * developing application and we may not immediately know what data type to use 
    
    - in most cases you should use the actuall data type when possible.
 */
var msg = "hello"; // => string data type
Console.WriteLine(msg);

/* STRING FORMATING */