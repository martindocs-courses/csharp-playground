/* Navigation Notes
    
    Important concepts                  : line 55
    - Binary representation of a byte   : line 57 
    - ASCII                             : line 84
    
    Data type                           : line 94
    - Value vs Reference types          : line 96
    - Simple values types               : line 103
    - Integral types                    : line 108
    - Floating point types              : line 135
    - Reference Types                   : line 156
    - String data type                  : line 181
    - Example: Value & Reference Types  : line 188

    Converting data types               : line 227
    - widening conversion               : line 254
    - narrowing conversion              : line 265
    - use method helpers                : line 276

    Exercise 1                          : line 335
    Exercise 2                          : line 354
    
    Array helper methods                : line 374
    - sort() & reverse()                : line 377
    - clear() & resize()                : line 393
    - ToCharArray()                     : line 463
    - join()                            : line 474
    - split()                           : line 478

    String formating                    : line 486
    - composite formating               : line 488    
    - string interpolation              : line 497
    - formating currency                : line 501
    - formating numbers                 : line 506
    - formating procentage              : line 515
    - combining formating               : line 519
      * Exercise 3                      : line 528
    - padding & alignment               : line 543
    - other helper methods              : line 549 & 554
      * Exercise 4                      : line 568
      * Exercise 5                      : line 601
    - index of & substring              : line 616
    - indexof & lastindexof             : line 651
      * Exercise 6                      : line 665
      * Exercise 7                      : line 680
    - indexofany                        : line 703
      * Exercise 8                      : line 713
     
    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/


/* IMPORTANT CONCEPTS */

// Binary representation of a byte
/*
 1 bit  - binary switch (0 or 1)
 8 bits - is 1 byte, where each bit can represent 256 different combinations with just 8 bits if you use a binary (base-2) numeral system.
 
Example: 
 In a binary numeral system, you can represent the number 97 as 
 To convert a decimal number to binary, you can use a method called repeated division by 2. This method involves dividing the decimal number by 2, recording the remainder, and repeating the process with the quotient until the quotient is zero. The binary equivalent is the sequence of remainders read in reverse order.

    97/2 => Quotient:48, remainder: 1
    48/2 => Quotient:24, remainder: 0 => 01
    24/2 => Quotient:12, remainder: 0 => 001
    12/2 => Quotient:6,  remainder: 0 => 0001
    6/2  => Quotient:3,  remainder: 0 => 00001
    3/2  => Quotient:1,  remainder: 1 => 100001
    1/2  => Quotient:0,  remainder: 1 => 1100001
    
    Reading the remainders from bottom to top, we get the binary equivalent of 97 decimal, which is 1100001 binary.    

Binary Place Value Table:

 The first row has eight columns that correspond to a position in a byte. Each position represents a different numeric value. The second row can store the value of an individual bit, either 0 or 1.

    128	64	32	16	8	4	2	1
    0	1	1	0	0	0	0	1  => 64 + 32 + 1 => 97 decimal
*/

// ASCII - used to represent textual data, like upper and lowercase letters, numbers, tab, backspace, newline and many mathematical symbols

/*
    Where for example letter 'a' is  equivalent to the decimal value 97.
    Then, you would use the same binary numeral system in reverse to find how an ASCII letter a is stored by the computer.

    Example above 'Binary Place Value Table' where 97 = 64 + 32 + 1, the 8-bit binary ASCII code for a is 01100001. 
*/


/* DATA TYPE - defines how much memory to save for a value. */

// VALUES vs REFERENCE TYPES
/*
    Variables of references types - store references to their data (objects), that is they point to data values stored somewhere else.

    Variables of value types - directly contain their data.
*/

// SIMPLE VALUES TYPES - set of predefined types provided by C# as keywords.
/*
  These keywords are aliases (a nickname) for predefined types defined in the .NET Class Library. For example, the C# keyword int is an alias of a value type defined in the .NET Class Library as System.Int32.
*/

// INTEGRAL TYPES 

/*
   An integral type is a simple value type that represents whole numbers with no fraction: 1, 2, 4. 

   Most popular is 'int' data type. There are two subcategories of integral types: signed and unsigned integral types.
*/

// Signed type - uses its bytes to represent an equal number of positive and negative numbers.
using System.Reflection.Metadata;

Console.WriteLine("Signed integral types: ");

Console.WriteLine($"sbyte: {sbyte.MinValue} to {sbyte.MaxValue}");
Console.WriteLine($"short: {short.MinValue} to {short.MaxValue}");
Console.WriteLine($"int: {int.MinValue} to {int.MaxValue}");
Console.WriteLine($"long: {long.MinValue} to {long.MaxValue}");

// Unsigned types - uses its bytes to represent only positive numbers. 
Console.WriteLine("");
Console.WriteLine("Unsigned integral types:");

Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");

// FLOATING-POINT TYPES 

/*
    A floating point is a simple value type that represents numbers to the right of the decimal place.

    There are FLOAT and DOUBLE values are stored internally in a binary (base 2) format, while DECIMAL is stored in a decimal (base 10) format.

    Therefore, Float and Double are useful because large numbers can be stored  using a small memory footprint. Also, Float and Double should only be used when an approximation is useful. 
    When you need more a more precise answer, you should use Decimal. Each value of type Decimal has a relatively large memory footprint, however performing math operations (like financial data) gives you a more precise result.  
*/

Console.WriteLine("");
Console.WriteLine("Floating point types:");
Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");

/*   
  Because floating-point types can hold large numbers with precision, their values can be represented using "E notation", which is a form of scientific notation that means "times 10 raised to the power of." So, a value like 5E+2 would be the value 500 because it's the equivalent of 5 * 10^2, or 5 x 10 * 10.  
*/

// REFERENCE TYPES 

/*
  Reference types include arrays, classes, and strings. 

  A value type variable stores its values directly in an area of storage called the stack. The stack is memory allocated to the code that is currently running on the CPU. When the stack frame has finished executing, the values in the stack are removed.

  A reference type variable stores its values in a separate memory region called the heap. The heap is a memory area that is shared across many applications running on the operating system at the same time.
*/

Console.WriteLine("\nReference types");

/*
 A variable that could hold a reference, or rather, a memory address of a value in the heap. Because it's not pointing to a memory address, it's called a null reference.
*/
int[] data;


/*
 The new keyword informs .NET Runtime to create an instance of int array, and then coordinate with the operating system to store the array sized for two int values in memory. The .NET Runtime complies, and returns a memory address of the new int array. Finally, the memory address is stored in the variable data. The int array's elements default to the value 0, because that is the default value of an int. 
*/
data = new int[2];
Console.WriteLine(string.Join("", data));


// STRING DATA TYPES 
Console.WriteLine("\nString reference type");

// The string data type is also a reference type.
string name = "Martin"; // new instance of System.String
Console.WriteLine(name);

// EXAMPLE: VALUE AND REFERENCE TYPES 
Console.WriteLine("\nExample: Value type and Reference Types");

// Value type
Console.WriteLine("\nValue type");
int value1 = 10;
int  value2 = value1; // the value1 is copied and stored in value2 
value2 = 20; // when value2 is changed to 20, the value1 remains 10

Console.WriteLine($"Value1: {value1}");
Console.WriteLine($"Value2: {value2}");

// Reference type
Console.WriteLine("\nReference Type");
int[] ref1 = new int[2]{1,2};
Console.WriteLine($"ref1: {ref1[0]}");

int[] ref2 = ref1; // ref2 points to the same memory location as ref1
ref2[0] = 2; // when ref2[0] is changed to 2, ref1[0] also changes because they both point to the same memory location. 

Console.WriteLine($"ref1: {ref1[0]}");
Console.WriteLine($"ref2: {ref2[0]}");

/*
 When in doubt, stick with the basics:
    - int for most whole numbers
    - decimal for numbers representing money
    - bool for true or false values
    - string for alphanumeric value

 Examples of data types can be useful:

    - byte: working with encoded data that comes from other computer systems or using different character sets.
    - double: working with geometric or scientific purposes. double is used frequently when building games involving motion.
    - System.DateTime for a specific date and time value.
    - System.TimeSpan for a span of years / months / days / hours / minutes / seconds / millisecond
*/


/* CONVERTING DATA TYPES */
Console.WriteLine("\nData Type conversion");
// Attept to add an int and string and save result in an int
int number1 = 5;
string number2 = "5";

// wont work, because compiler doesn't implicitly perform the conversion from string to int for you
//int intResult = number1 + number2; 
//Console.WriteLine(stringResult);

// it works, because is safer operation would be to convert int into a string and perform concatenation instead, so result will be 55
string stringResult = number1 + number2; 
Console.WriteLine(stringResult);

/*
 
 To perform data conversion, you can use one of several techniques:
   - Use a helper method on the data type
   - Use a helper method on the variable
   - Use the Convert class' methods 
*/
Console.WriteLine("\nWidening conversion");

// Attepting to change the value data type 
int number3 = 3;
Console.WriteLine($"int: {number3}"); // result 3

// WIDENING CONVERSION, which is convert a value from a data type that could hold less information (int) to a data type that can hold more information (decimal). 
// When you know you're performing a widening conversion, you can rely on implicit conversion.
decimal number4 = number3; // WIDENING CONVERSION
Console.WriteLine($"decimal: {number4}"); // result 3

// Explicit conversion using cast operator ()
Console.WriteLine("\nNarrowing conversion");

decimal number5 = 3.14m;
Console.WriteLine($"decimal: {number5}");

// NARROWING CONVERSION means that you're attempting to convert a value from a data type that can hold more information to a data type that can hold less information and you may loose some information.
// When you know you're performing a narrowing conversion, you need to perform a cast. 
int number6 = (int)number5; // NARROWING CONVERSION
Console.WriteLine($"int: {number6}");

decimal myDecimal = 1.23456789m;
float myFloat = (float)myDecimal;

Console.WriteLine($"Decimal: {myDecimal}");
Console.WriteLine($"Float  : {myFloat}");

//  USE METHOD HELPERS
Console.WriteLine("\nHelper methods to convert data types");
Console.WriteLine("\nToString()");

// ToString() to convert a number to a string
/*
  Every data type variable has a ToString() method. What the ToString() method does depends on how it's implemented on a given type. However, on most primitives, it performs a widening conversion.  
*/

int first = 5;
int second = 10;

string msg = first.ToString() + second.ToString();
Console.WriteLine(msg);

Console.WriteLine("\nParse()");
/*
    Most of the numeric data types have a Parse() method, which converts a string into the given data type.
    If the values that can't be converted to an int? An exception is thrown at runtime. The easiest way to mitigate this situation is by using TryParse(), which is a better version of the Parse() method.
*/

string first2 = "5";
//string second2 = "martin";
string second2 = "4";

// Will throw an error on runtime (throw an exception) if the values can't be converted
int msg2 = int.Parse(first2) + int.Parse(second2);

// safer alternative to Parse() is TryParse(), because it returns a boolean indicating whether the conversion was successful or not. 
bool msg3 = int.TryParse(first2, out int result1);
bool msg33 = int.TryParse(second2, out int result2);

if(msg3 && msg33){
    Console.WriteLine(result1 + result2);
}

Console.WriteLine("\nConvert class");
// Convert a string to a int with Convert class. The Convert class has many helper methods to convert a value from one type into another.

string convertValue1 = "3";
string convertValue2 = "6";

int result = Convert.ToInt32(convertValue1) + Convert.ToInt32(convertValue2);
Console.WriteLine(result);

/*
 The Convert class is best for converting fractional numbers into whole numbers (int) because it rounds up the way you would expect.
 */

Console.WriteLine("\nCasting vs Converting class");
/*
 When doing narrowing converting the CAST with trucate the fraction. Use the CONVERT class when you want to perform rounding, not a truncation of information.
 */
int castConverting = (int)1.5m; // trucate the value
Console.WriteLine(castConverting); 

int classConverting = Convert.ToInt32(1.5m); // rounds up the value
Console.WriteLine(classConverting);

// EXERCISE 1: Combine string array values as strings and as integers
Console.WriteLine("\nExercise 1");
string[] values = { "12.3", "45", "ABC", "11", "DEF" };

string message = "";
decimal total = 0m;

foreach (var item in values)
{
    if(decimal.TryParse(item, out decimal value)){
        total += value;
    }else{
        message += item;
    }
}

Console.WriteLine($"Message: {message}");
Console.WriteLine($"Total: {total}");

// EXERCISE 2: Output math operations as specific number types
Console.WriteLine("\nExercise 1");

int value11 = 11;
decimal value22 = 6.2m;
float value33 = 4.3f;

// Your code here to set result11
int result11 = Convert.ToInt32(value11 / value22);
Console.WriteLine($"Divide value1 by value2, display the result as an int: {result11}");

// Your code here to set result22
decimal result22 = value22 / (decimal)value33;
Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result22}");

// Your code here to set result33
float result33 = value33 / value11;
Console.WriteLine($"Divide value3 by value1, display the result as a float: {result33}");


/* ARRAY HELPER METHODS */
Console.WriteLine("\nArray methods");

// SORT() & REVERSE()
string[] pallets = ["B14", "A11", "B12", "A13"];

Console.WriteLine("Sorted..."); // sort in ASC order
Array.Sort(pallets);
//Console.WriteLine(string.Join(" ", pallets));
foreach (var pallet in pallets)
{
    Console.WriteLine(pallet);
}

Console.WriteLine();
Console.WriteLine("Reversed..."); // reverse the array order
Array.Reverse(pallets);
Console.WriteLine(string.Join(" ", pallets));

// CLEAR() & RESIZE()
Console.WriteLine("\nClear array");

/* 
  Clear() method

  Enables you to eliminate the contents of specific elements in your array, replacing them with the array's default value. if you clear an element in a string array, the cleared value is replaced with null. Similarly, when you clear an element in an int array, the replacement is 0 

  Clear values in array has no longer reference a string in memory and it point to nothing. Accesing cleared values will give null value. When displaying null values C# Compiler implicitly converts the null value to an empty string for presentation.
*/
Array.Clear(pallets, 0, 2); // start from 0 index and clear two elements
foreach (var pallet in pallets)  
{
    Console.WriteLine($"values: {pallet}");
    
}

// You can't use toLower() string meyhod as this give error, bc pallets[0] value is null and not empty string
// so to avoid error we need add if statement
if(pallets[0] != null)
    Console.WriteLine("\nAccessing cleared value: " + pallets[0].ToLower());
else
    Console.WriteLine("You can't use ToLower() method on null value.");

// Resize(), allows you to add or remove elements from your array.
Console.WriteLine("\nResize array");

// Add elements 
Array.Resize(ref pallets, 3); // we passing reference value
Console.WriteLine(string.Join(" ", pallets));

pallets[0] = "C01";
pallets[1] = "C02";

Console.WriteLine(string.Join(" ", pallets));

// Remove elements.
// We can't just remove null values from array. We need use two steps aproach
Array.Resize(ref pallets, 7);

// cont non-null values
int count = 0;
foreach (var pallet in pallets)
{
    if (pallet != null)
        count++;
}

Console.WriteLine($"old pallets: {string.Join("-", pallets)}");

// create new array
string[] newPallets = new string[count];

int index = 0;
// and copy non-null values to newwly array
foreach (var pallet in pallets)
{
    if(pallet != null)
        newPallets[index] = pallet;
    index++;
}

Console.WriteLine($"new pallets: {string.Join("-", newPallets)}");

/*
    To perform data transformation, you need to accept incoming data as a string, parse it into smaller data elements, then manipulate it to match different format required.  
*/

string letters = "abcd123";

// We use ToCharArray() method used to create an array of char, where each element of the array represents one character of the original string.
char[] lettersArray = letters.ToCharArray();
Array.Reverse(lettersArray);

/*
    For non-primitive (reference) types like string, List<T>, or your own classes, casting is not possible unless the types are explicitly compatible (e.g., via inheritance or interfaces). Instead, you typically use constructors or helper methods to convert between types. 
 */
string resultArray = new string(lettersArray);

Console.WriteLine(resultArray);

// JOIN()
string resultArray2 = String.Join(",", lettersArray);
Console.WriteLine(resultArray2);

// SPLIT() -  designed for variables of type string and creates an array of strings
string[] items = resultArray2.Split(',');
foreach (string item in items)
{
    Console.WriteLine(item);
}


/* STRING FORMATING */

// COMPOSITE FORMATING - Composite formatting uses numbered placeholders within a string. At run time, everything inside the braces is resolved to a value that is also passed in based on their position.
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
myDiscount += $"A discount of {((newPrice - salesPrice)/newPrice):P2}";
Console.WriteLine(myDiscount);

// EXERCISE 3: Display the invoice number using string interpolation
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
if(someName.StartsWith('O'))
    Console.WriteLine("Is your name Martin?");
else if(someName.Contains('n'))
    Console.WriteLine("What is your name?");
else
    Console.WriteLine("Hmm not sure what is your name...");

// Replace(), Insert(), Remove() - change the content of the string by replacing, inserting, or removing parts
Console.WriteLine("My name is Martin".Replace("Martin", "Adam"));
Console.WriteLine("My name is Martin".Insert(0, "- "));
Console.WriteLine("My name is Martin".Remove(0, 3));

//  EXERCISE 4: Remove characters in specific locations from a string
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


// EXERCISE 5: Working with padded strings
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

// EXERCISE 6: Retrieve the last occurrence of a sub string
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

// EXERCISE 7: Retrieve all instances of substrings inside parentheses
Console.WriteLine("\nExercise 7");

string messageIndexOf3 = "(What if) there are (more than) one (set of parentheses)?";

while(true){

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

// EXERCISE 8: Retrieve all instances of substrings inside parentheses
Console.WriteLine("\nExercise 8");

string messageIndex5 = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";

// IndexOfAny() helper method requires a char array of characters. 
char[] symbols = { '[', '{', '(' };
//char[] symbols = [ '[', '{', '(' ]; // newer way

int clPosition = 0;

while(true){

    int opPosition = messageIndex5.IndexOfAny(symbols, clPosition);

    if(opPosition == -1) break;

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