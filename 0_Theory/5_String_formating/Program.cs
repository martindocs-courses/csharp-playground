/* Navigation Notes
    
    String formating                    : line 27
    - composite formating               : line 29    
    - string interpolation              : line 40
    - formating currency                : line 44
    - formating numbers                 : line 49
    - formating procentage              : line 58
    - combining formating               : line 62
      * Exercise 1                      : line 71
    - padding & alignment               : line 86
    - other helper methods              : line 92 & 97 & 106
      * Exercise 2                      : line 111
      * Exercise 3                      : line 144
    - index of & substring              : line 159
    - indexof & lastindexof             : line 194
      * Exercise 4                      : line 208
      * Exercise 5                      : line 223
    - indexofany                        : line 247
      * Exercise 6                      : line 257
     
    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/


/* STRING FORMATING */

// COMPOSITE FORMATING - Composite formatting uses numbered placeholders within a string. At run time, everything inside the braces is resolved to a value that is also passed in based on their position.
using System.Xml.Linq;

Console.WriteLine("\nString formating");

string myName = "Martin";
int myAge = 35;

string myResult = string.Format("My name is {0} and my age is {1}", name, myAge); // {0}.. {1} etc. are replacement tokens
Console.WriteLine(myResult);

// STRING INTERPOLATION - use the variable name inside of the curly braces, but must prefix it with the $ directive.

Console.WriteLine($"Hello my name is {myName}."); // string template

//  FORMATING CURRENCY (C), depending on culture (country/region) and language of the end user, a five character code that includes the user's country/region and language
decimal price = 12.89m;
int discount = 1;
Console.WriteLine($"Price: {price:C} (Save {discount:C})");

// FORMATING NUMBERS (N) numeric format, same goes here, formating is diffrent, a five character code that includes the user's country/region and language
decimal measurment = 12345.43m;

// By default, the N numeric format specifier displays only two digits after the decimal point.
Console.WriteLine($"Measurment: {measurment:N} units");

// Display four digits after the decimal point
Console.WriteLine($"Measurment: {measurment:N4} units");

// FORMATING PROCENTAGES (P)
decimal tax = .245m;
Console.WriteLine($"Tax rate: {tax:P2}");

// COMBINIG FORMATING
decimal newPrice = 55.99m;
decimal salesPrice = 45.99m;

string myDiscount = String.Format("You saved {0:C2} off the regular {1:C2} price. ", (newPrice - salesPrice), newPrice);
Console.WriteLine(myDiscount);
myDiscount += $"A discount of {((newPrice - salesPrice) / newPrice):P2}";
Console.WriteLine(myDiscount);

// EXERCISE 1: Display the invoice number using string interpolation
Console.WriteLine("\nExercise 3");

int invoiceNumber = 1201;
decimal productShares = 25.4568m;
decimal subtotal = 2750.00m;
decimal taxPercentage = .15825m;
decimal totalValue = 3185.19m;

Console.WriteLine($"Invoice Number: {invoiceNumber}");
Console.WriteLine($"    Shares: {productShares:N3} Product");
Console.WriteLine($"        Sub Total: {subtotal:C}");
Console.WriteLine($"            tax: {taxPercentage:P2}");
Console.WriteLine($"        Total Billed: {totalValue:C}");

// PADDING AND ALIGNMENT
Console.WriteLine("\nPadding and Alignment");
// PadLeft(), PadRight -  add blank spaces for formatting purposes, where PadLeft(number) is counted from the right to the left, PadRight(number) counted from left to the right 
Console.WriteLine(" Hi my name is Martin ".PadLeft(25, '*').PadRight(28, '*'));

Console.WriteLine("\nOther string helper methods");
// Trim(), TrimStart(), TrimEnd(), GetHashcode(), Length() - compare two strings or facilitate comparison
Console.WriteLine("     Hi my name is Martin    ".Trim());
Console.WriteLine("     Hi my name is Martin    ".Length);
Console.WriteLine("Hi my name is Martin".Length);

// Contains(), StartsWith(), EndsWith(), Substring() - help determine what's inside of a string, or even retrieve just a part of the string 
string someName = "Martin";
if (someName.StartsWith('O'))
    Console.WriteLine("Is your name Martin?");
else if (someName.Contains('n'))
    Console.WriteLine("What is your name?");
else
    Console.WriteLine("Hmm not sure what is your name...");

// Replace(), Insert(), Remove() - change the content of the string by replacing, inserting, or removing parts
Console.WriteLine("My name is Martin".Replace("Martin", "Adam"));
Console.WriteLine("My name is Martin".Insert(0, "- "));
Console.WriteLine("My name is Martin".Remove(0, 3));

//  EXERCISE 2: Remove characters in specific locations from a string
Console.WriteLine("\nExercise 4");

string removeData = "12345John Smith          5000  3  ";
// The Remove() method works similarly to the Substring() method. You supply a starting position and the length to remove those characters from the string.
string updateData = removeData.Remove(5, 20);
Console.WriteLine(updateData);

Console.WriteLine();

// replaces every instance of the given characters, not just the first or last instance.
string dashes = "This--is--ex-amp-le--da-ta";
dashes = dashes.Replace("--", " ");
dashes = dashes.Replace("-", "");

Console.WriteLine(dashes);

// Split(), ToCharArray() - turn a string into an array of strings or characters
Console.WriteLine("\nSplit() & ToCharArray()");
string someText = "This is some random text";
string[] textArray = someText.Split(" ");
foreach (var text in textArray)
{
    Console.WriteLine(text);
}

char[] charArray = "abc".ToCharArray();
foreach (var text in charArray)
{
    Console.WriteLine(text);
}


// EXERCISE 3: Working with padded strings
Console.WriteLine("\nExercise 5");
string paymentID = "769C";
string payeeName = "Mr. Stephen Ortega";
var formattedLine = paymentID.PadRight(6);
string paymentAmount = "$5,000.00";

formattedLine += payeeName.PadRight(24);
formattedLine += paymentAmount.PadLeft(10);

// line of numbers above the output to more easily count the padding
Console.WriteLine("1234567890123456789012345678901234567890");
Console.WriteLine($"{formattedLine}");


// INDEXOF() & SUBSTRING()
Console.WriteLine("\nIndexOf & Substring");

// IndexOf() -  returns the index of the first occurrence of a specified character or substring within a given string. Return -1 if the character or string is not found.
string messageindex = "Find what is (inside the parentheses)";

int openingPosition = messageindex.IndexOf('(');
openingPosition += 1; // to remove opening parentheses
int closingPosition = messageindex.IndexOf(')');

int length = closingPosition - openingPosition;
Console.WriteLine(messageindex.Substring(openingPosition, length));

// AVOID HARDCODED MAGIC VALUES

/* MAGIC SRINGS & MAGIC NUMBERS
    Hardcoded strings like "(" in the previous code listing are known as "magic strings" and hardcoded numeric values like openingPosition += 1 are known as "magic numbers". These "Magic" values are undesirable for many reasons and you should try to avoid them if possible. 
    The compiler doesn't catch "<sapn>" at compile time because the value is in a string. The misspelling leads to problems at run time, and depending on the complexity of your code, it might be difficult to track down.
*/

/* CONST 
    A constant allows you to define and initialize a variable whose value can never be changed. You would then use that constant in the rest of the code whenever you needed that value. This ensures that the value is only defined once and misspelling the const variable is caught by the compiler. 
*/

const string openParentheses = "(";
const string closingParentheses = ")";

int openingPosition2 = messageindex.IndexOf(openParentheses);
int closingPosition2 = messageindex.IndexOf(closingParentheses);

openingPosition2 += openParentheses.Length;
int length2 = closingPosition2 - openingPosition2;

Console.WriteLine(messageindex.Substring(openingPosition2, length2));

// INDEXOF() & LASTINDEXOF()
Console.WriteLine("\nIndexOf & LastIndexOf");

// LastIndexOf() - returns the index position of the last occurrence of a character or string within a given string. Return -1 if the character or string is not found.

string messageIndexOf = "Hi my name is Martin!";

const char letterN = 'n';

int first_n = messageIndexOf.IndexOf(letterN);
int last_n = messageIndexOf.LastIndexOf(letterN);

Console.WriteLine($"For the message: {messageIndexOf}, the first 'n' is at position {first_n} and the last 'n' is at position {last_n}");

// EXERCISE 4: Retrieve the last occurrence of a sub string
Console.WriteLine("\nExercise 6");
string messageIndexOf2 = "(What if) I am (only interested) in the last (set of parentheses)?";

const string searchedSymbol = "(";
const string searchedSymbol2 = ")";
const int shiftBracket = 1;

int openPosition = messageIndexOf2.LastIndexOf(searchedSymbol);
openPosition += shiftBracket;

int closePosition = messageIndexOf2.LastIndexOf(searchedSymbol2);
int lengthOfPositions = closePosition - openPosition;
Console.WriteLine(messageIndexOf2.Substring(openPosition, lengthOfPositions));

// EXERCISE 5: Retrieve all instances of substrings inside parentheses
Console.WriteLine("\nExercise 7");

string messageIndexOf3 = "(What if) there are (more than) one (set of parentheses)?";

while (true)
{

    int openPos = messageIndexOf3.IndexOf(searchedSymbol);

    if (openPos == -1) break;

    openPos += shiftBracket;

    int closePos = messageIndexOf3.IndexOf(searchedSymbol2);
    int len = closePos - openPos;


    Console.WriteLine(messageIndexOf3.Substring(openPos, len));

    messageIndexOf3 = messageIndexOf3.Substring(closePos + shiftBracket);

}

// INDEXOFANY - reports the index of the first occurrence of any character in a supplied array of characters. Returns -1 if all characters in the array of characters are not found.
Console.WriteLine("\nIndexOfAny");

string messageIndexOf4 = "Hello my name is Martin!";
char[] charsToFind = ['e', 'm', 'a'];

int indexChars = messageIndexOf4.IndexOfAny(charsToFind);

Console.WriteLine($"Found '{messageIndexOf4[indexChars]}' at the index: {indexChars}");

// EXERCISE 6: Retrieve all instances of substrings inside parentheses
Console.WriteLine("\nExercise 8");

string messageIndex5 = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";

// IndexOfAny() helper method requires a char array of characters. 
char[] symbols = { '[', '{', '(' };
//char[] symbols = [ '[', '{', '(' ]; // newer way

int clPosition = 0;

while (true)
{

    int opPosition = messageIndex5.IndexOfAny(symbols, clPosition);

    if (opPosition == -1) break;

    string currentSymbol = messageIndex5.Substring(opPosition, 1); // shift by one so 

    // Now  find the matching closing symbol
    char machingSymbol = ' ';

    switch (currentSymbol)
    {

        case "[":
            machingSymbol = ']';
            break;
        case "{":
            machingSymbol = '}';
            break;
        case "(":
            machingSymbol = ')';
            break;
    }

    // To find the clPosition, use an overload of the IndexOf method to specify 
    // that the search for the matchingSymbol should start at the opPosition in the string. 

    opPosition += 1;
    clPosition = messageIndex5.IndexOf(machingSymbol, opPosition);

    int len1 = clPosition - opPosition;

    Console.WriteLine(messageIndex5.Substring(opPosition, len1));
}