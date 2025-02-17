/* Navigation Notes
    
    Literal values      : line 25 
    Variables           : line 49
    String formating    : line 91
    Basic operation     : line 137
 
    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/


// Write to the console output and put the line feed at the end
using System.Runtime.Intrinsics.X86;

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

// Implicityly typed local variables, when use 'var' keyword
/*
    Primary rule of thumb:
    * USE var when it increases readability or makes the code less verbose without sacrificing clarity.
      
    Examples: 
    -------------
    1. The Type Is Obvious from the Assignment

    If the type is immediately clear to any developer reading the code, using var is acceptable and often preferred for brevity.

        var count = 10; // Clearly an int
        var name = "Alice"; // Clearly a string
        var numbers = new List<int>(); // Clearly a List<int>

    2. The Type Is Long or Complex

    When explicitly writing out the type would make the code unnecessarily verbose, var improves readability.

        var lookup = new Dictionary<string, List<int>>(); // More readable than explicitly declaring the type

    3. When Using Anonymous Types

    You must use var for anonymous types because they have no named type.

        var person = new { Name = "John", Age = 30 }; // Compiler infers the anonymous type

    4. When Using LINQ or Similar APIs

    LINQ often involves complex return types that are cumbersome to write explicitly.

        var results = myList.Where(x => x > 10).Select(x => x * 2);
  

    * AVOID var when it makes the code harder to understand or when the type is not obvious.
    
    1.The Type Is Not Immediately Obvious

    If the type of the variable is not clear at a glance, avoid using var to make the code more readable.

        var result = ProcessData(); // What does ProcessData return? Unclear.

        Instead:

        int result = ProcessData(); // Explicit type improves clarity.

    2. When Working with Primitive Types

    While var works fine for primitives, explicitly typing them can make the code more self-documenting.

        int age = 30; // Explicitly indicates the variable is an integer.

    3. When Explicit Typing Improves Readability

    If using var makes the code harder to understand, prefer explicit typing.

        List<string> names = new List<string>(); // Clearer than var names = new List<string>();
    

    Also the var keyword:
    - needs to be initialized right after declaring
    - data type is implied by the assigend value 
    - practical used
    * when a variable is obvious from its initialization
    * developing application and we may not immediately know what data type to use 
    * 
    - in most cases you should use the actuall data type when possible.
 */
var msg = "hello"; // => string data type
Console.WriteLine(msg);

/* Explicit Typing var name = "martin" vs implisit 'var' typing:

    * use Explicit Typing if:
    - The type isn't obvious from the context.
    - You want to make the type more explicit for readability or clarity.
    - The type is not easily inferred, like with complex types or in cases where the type could be ambiguous.

    * use Implicit Typing (for example var dice = new Random();)
    - The type is clearly defined from the context, like when using new.
    - The variable is of a complex or long type, such as when working with LINQ queries or anonymous types (where explicit typing would be cumbersome).
*/


/* STRING FORMATING */

// Format literal string - character escape sequences 
/*
    \n - new line
    \t - add tab 
    \" - double quotation
    \r - carrige return
    \\ - display single backslash

 */

Console.WriteLine("First line\nSecond line");
Console.WriteLine("Front text\tspaced text");
Console.WriteLine("Front text\t\"spaced text with quotes\"");
Console.WriteLine("C:\\Windows");

// Verbatim string literal - keep all whitespaces and characters without the need to escape the backslash

Console.WriteLine(@"    C:\Windows\
user");

// Unicode escape characters (UTF-16) - encoded characters in literal string using \u

Console.WriteLine("\u3053");

// String concatenation - literal string and a variable

string firstName2 = "Martin";
string newMessage = "Hello " + firstName2;
Console.WriteLine(newMessage);

// String concatenation - literal string and multiple variables
string greetings = "Hi";
string veryNewMessage = greetings + " " + firstName2 + "!"; // SHOULD BE AVOIDED INTERMEDIATE VARIABLES
Console.WriteLine(veryNewMessage); // not prefered
Console.WriteLine(greetings + " " + firstName2 + "!"); // better way

// String interpolation - used when combine many literal strings and variables into a single formatted message, by using one or more interpolation expression {} The literal string becomes a template when it's prefixed by the $ character.

Console.WriteLine($"Jo {firstName2}!");

// Combine verbatim literals and string interpolation
string projectName = "My-Project";
Console.WriteLine($@"C:\User\{projectName}");

/* BASIC OPERIATION */

/*
    + addition
    - substraction
    * multiplication
    / division     

    Order of operation:
    PEMDAS - () Parentheses (whatever is inside the parenthesis is performed first)
              Math.Pow() Exponents
               * / Multiplication and Division (from left to right)
                + - Addition and Subtraction (from left to right)    
 */

// mixed data types to force implicit type conversion
string myName = "Martin";
int sold = 5;
Console.WriteLine(myName + " sold " + sold); // string + int => output string

// adding numbers and concatenating string
Console.WriteLine(myName + " sold " + sold + 5); // same as about output string, so string + int => string + string => Martin sold 55, insted of 10

// adding parentheses to clarify your intention to the compiler
Console.WriteLine(myName + " sold " + (sold + 5)); // now variable sold + 5 is caclulated first before concatenating

// if divide thow 'int' the decimal are truncated from the quotient
int quotient = 7 / 5;
Console.WriteLine(quotient);

// to get the division we need use difrent data types like decimal
decimal quotient2 = 7.0m / 5;
Console.WriteLine(quotient2); // at least of the numbers need be decimal or both

// for working with variables of 'int' type if wee need truncated values we nned preform data type casting

int first = 7;
int second = 5;

Console.WriteLine((decimal) first / (decimal) second);

// remainder after integer division
Console.WriteLine($"Modulus of 200 / 5: {200 / 5}");

// +=, -=, *=, ++, and -- they call compound assignment because they compound some operation in addition to assigning the result to the variable. 

// Position the increment and decrement operators variable++ or ++variable
/*
 
    If you use the operator before the value as in ++value, then the increment will happen before the value is retrieved. Likewise, value++ will increment the value after the value has been retrieved. 
 */
int value = 1;
value++;

Console.WriteLine($"Fiest value {value}");
Console.WriteLine($"Second value {value++}"); // still 2
Console.WriteLine($"Third {++value}"); // change to 4

int x = 5;
if(x > 0){
    int y = 6;
    x += y;
    Console.WriteLine(x);
}

Console.ReadLine();