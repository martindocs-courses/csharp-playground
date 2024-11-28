/* Navigation Notes
    
    Important concepts                  : line 29
    - Binary representation of a byte   : line 31 
    - ASCII                             : line 58
    
    Data type                           : line 68
    - Value vs Reference types          : line 70
    - Simple values types               : line 77
    - Integral types                    : line 82
    - Floating point types              : line 107
    - Reference Types                   : line 128
    - String data type                  : line 153
    - Example: Value & Reference Types  : line 160

    Converting data types               : line 199
    - widening conversion               : line 226
    - narrowing conversion              : line 237
    - use method helpers                : line 248

    Exercise 1                          : line 307
    Exercise 2                          : line 326
    
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


