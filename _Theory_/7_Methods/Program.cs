/* Navigation Notes
    
    Methods                                     : line 40
    Foward reference                            : line 42
    Best practices                              : line 54
        Example 1                               : line 84
    Methods with Parameters                     : line 173
    Methods Scope                               : line 193
    Value and Reference type parameters         : line 251
    Methods with named & optional parameters    : line 323
    - named methods parameters                  : line 334
    - optional (default) methods parameters     : line 387
    Methods with returning values               : line 439
    - return integer                            : line 491
    - return double                             : line 506
    - return string                             : line 519
    - return booleans                           : line 551
    - return arrays                             : line 590
         
    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

/*
    example:
    void MethodName(); // method signature

    - void - method returs no data
    - HelloWorld - is method name
    - () - has no arguments, but it can accept multiple parameters of any data type

    Methods signature are:
    - Method Name: The name of the method itself.
    - Parameter Types: The types of parameters that the method accepts. The parameter names are not part of the signature; only the types and their order matter.
    - Number of Parameters: The number of parameters the method takes.

    Methods can return a value of any data type, such as bool, int, double, and arrays 
*/

/* METHODS */

// FOWRD REFERENCE - to methods within a class, meaning you can reference a method in the code before it is defined, as long as the method declaration is visible within the scope.

using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine($"Foward reference");
Name(); // calling the method

void Name(){
    Console.WriteLine("My name is Martin");
}

/* BEST PRACTICES */
Console.WriteLine($"\nBest Practices");
/*
    - When choosing a method name, it's important to keep the name concise and make it clear what task the method performs.
    - Method names should be Pascal case and generally shouldn't start with digits.
    - Names for parameters should describe what kind of information the parameter represents. 
*/

void ShowData(int length, int width){    
    Console.WriteLine($"The result of {length} * {width} = {length * width}");
}

ShowData(2, 3);

Console.WriteLine();
void DisplayRandomNumbers(){

    Random random = new Random();

    for (int i = 0; i < 5; i++)
    {
        Console.Write($"{random.Next(1, 100)} ");
    }

    Console.WriteLine();
}

Console.WriteLine("Generating random numbers:");
DisplayRandomNumbers();

/* EXAMPLE 1 */
Console.WriteLine($"\nValid IPv4 address");
/*
    You're given the following rules:
    ----------------------------------
    A valid IPv4 address consists of four numbers separated by dots
    Each number must not contain leading zeroes
    Each number must range from 0 to 255
    1.1.1.1 and 255.255.255.255 are examples of valid IP addresses.

    The IPv4 address is provided as a string. You can assume that it only consists of digits and dots (there are no letters in the string provided).

 Pseudocode
    is ivp4 valid:
    * if consist of 4 numbers and numbers can't contain leading zero
    * if is separated by dots
    * if numbers are between 0 and 255

    else is invalid  
*/

string[] ipv4Input = { "107.31.1.5", "255.0.0.255", "555..0.555", "255...255" };
string[] address;
bool validLength = false;
bool validZeros = false;
bool validRange = false;

foreach (var ip in ipv4Input)
{
    address = ip.Split(".", StringSplitOptions.RemoveEmptyEntries);
    ValidateLength();
    ValidateZeros();
    ValidateRange();

    if (validLength && validZeros && validRange)
    {
        Console.WriteLine($"{ip} is a valid IPv4 address");
    }
    else
    {
        Console.WriteLine($"{ip} is an invalid IPv4 address");
    }
}

void ValidateLength()
{

    //address = ipv4Input.Split(".");
    validLength = address.Length == 4;
};

void ValidateZeros()
{

    //address = ipv4Input.Split(".");

    foreach (var number in address)
    {
        if (number.Length > 1 && number.StartsWith('0'))
        {
            validZeros = false;
            return; // terminates execution of the method and returns control to the method caller aka. where the method ValidateZeros() was invoked
        }
    }

    validZeros = true;
};


void ValidateRange()
{

    // omits empty entries from the address array and prevent attempts to parse empty strings.
    //address = ipv4Input.Split(".", StringSplitOptions.RemoveEmptyEntries);

    foreach (var number in address)
    {
        int value = int.Parse(number);
        if (value < 0 || value > 255)
        {
            validRange = false;
            return;
        }
    }

    validRange = true;
};


/* METHODS WITH PARAMETERS */
Console.WriteLine($"\nMethods with parameters");

/*
    The terms 'parameter' and 'argument' are often used interchangeably. However, 'parameter' refers to the variable in the method signature. The 'argument' is the value passed when the method is called.
*/

// the method CountTo accepts an integer parameter named max. The parameter is referenced in the for loop of the method. When CountTo is called, the integer 5 is supplied as an argument.
int a = 2;
int b = 3;

int result = SumUp(a, b);

int SumUp(int x, int y){
    return x + y;
}

Console.WriteLine($"The sum of {a} + {b} = {result}");


/* METHOD SCOPE */
Console.WriteLine($"\nMethod scope");
/*
    'Scope' is the region of a program where certain data is accessible. Variables declared inside a method, or any code block, are only accessible within that region.
    
    Statements declared outside of any code block are called top-level statements. Variables declared in top-level statements are called 'global variables'. 
    Global variables can be useful for different methods that need to access the same data. However, it's important to pay attention to variable names in different scopes.
*/

string[] students = { "Jenna", "Ayesha", "Carlos", "Viktor" };

DisplayStudents(students);
DisplayStudents(new string[] { "Robert", "Vanya" });

//the method parameter students takes precedence over the global students array.
void DisplayStudents(string[] students)
{
    foreach (string student in students)
    {
        Console.Write($"{student}, ");
    }
    Console.WriteLine();
}

Console.WriteLine();

// Since the variable pi is set to the same fixed value and used in both methods, this value is a good candidate for a global variable.
double pi = 3.14159;

PrintCircleArea(12);
PrintCircleCircumference(12);

void PrintCircleArea(int radius)
{
    //double pi = 3.14159;
    double area = pi * (radius * radius);
    Console.WriteLine($"Area = {area}");
}

void PrintCircleCircumference(int radius)
{
    //double pi = 3.14159;
    double circumference = 2 * pi * radius;
    Console.WriteLine($"Circumference = {circumference}");
}

Console.WriteLine();
// or call methods inside other methods. As long as a method is defined within the scope of the program, it can be called anywhere.
void PrintCircleInfo(int radius)
{
    Console.WriteLine($"Circle with radius {radius}");
    PrintCircleArea(radius);
    PrintCircleCircumference(radius);
}

PrintCircleInfo(24);


/* VALUE AND REFERENCE TYPE PARAMETERS */
Console.WriteLine($"\nValue and reference type parameters");

/*
    In C#, variables can be categorized into two main types, value types and reference types. 

    Value types such as int, bool, float, double, and char directly contain values. Reference types such as string, array, and objects (such as instances of Random) don't store their values directly. Instead, reference types store an address where their value is being stored.

    When an argument is passed to a method, value type variables have their values copied into the method. Each variable has its own copy of the value, so the original variable isn't modified.

    With reference types, the address of the value is passed into the method. The variable given to the method references the value at that address, so operations on that variable affect the value that is referenced by the other.    
*/

// Passed by value
Console.WriteLine();
int a2 = 3;
int b2 = 4;
int c2 = 0;

Multiply(a2, b2, c2);
Console.WriteLine($"global statement: {a2} x {b2} = {c2}");

void Multiply(int a, int b, int c)
{
    c = a * b;
    Console.WriteLine($"inside Multiply method: {a} x {b} = {c}");
}


// Passed by reference
Console.WriteLine();
int[] array = { 1, 2, 3, 4, 5 };

PrintArray(array);
Clear(array); // array remains altered outside of the Clear method scope.
PrintArray(array);

void PrintArray(int[] array)
{
    foreach (int a in array)
    {
        Console.Write($"{a} ");
    }
    Console.WriteLine();
}

void Clear(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = 0;
    }
}

/*  
    It is important to remember that string is a reference type, but it is immutable. That means once it has been assigned a value, it can't be altered. In C#, when methods and operators are used to modify a string, the result that is returned is actually a new string object.
*/
Console.WriteLine();

string status = "Healthy";

Console.WriteLine($"Start: {status}");
SetHealth(false);
Console.WriteLine($"End: {status}");

void SetHealth(bool isHealthy)
{                      
    status = (isHealthy ? "Healthy" : "Unhealthy");
    Console.WriteLine($"Middle: {status}");
}


/* METHODS WITH NAMED AND OPTIONAL PARAMETERS */
Console.WriteLine($"\nMethods with named parameters");

/*
     Named arguments allow you to specify the value for a parameter using its name rather than position. Optional parameters allow you to omit those arguments when calling the method. 
*/

string[] guestList = { "Rebecca", "Nadia", "Noor", "Jonte" };
string[] rsvps_named = new string[10];
int count = 0;

// NAMED PARAMETERS
void RSVP_Named(string name, int partySize, string allergies, bool inviteOnly){
    if(inviteOnly){
        // search guestList before adding rsvp
        bool found = false;
        foreach (string guest in guestList)
        {
            if(guest.Equals(name)){
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine($"Sorry, {name} is not on the guest list");
            return;
        }
    }

    rsvps_named[count] = $"Name: {name}, \tParty Size: {partySize}, \tAllergies: {allergies}";
    count++;
}


void ShowRSVPs_Named(){
    Console.WriteLine("\nTotal RSVPs");
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine(rsvps_named[i]);
    }
}

// Named argument by specifying the parameter name followed by the argument value.
RSVP_Named(name:"Rebecca", partySize:1, allergies:"none", inviteOnly: true);

// It isn't necessary to name all of the arguments. You can mix positional arguments with named.
// Named arguments, when used with positional arguments, are valid if they're used in the correct position.
RSVP_Named("Nadia", partySize:2, "Nuts", inviteOnly:true);
// That won't work
//RSVP_Named(allergies: "Nadia", partySize:2, "Nuts", inviteOnly:true); 

// Named arguments are also valid as long as they're not followed by any positional arguments.
//RSVP_Named(allergies: "Jackfruit", inviteOnly: true, "Thony", 1); // THIS IS INVALID

// the named arguments don't have to appear in the original order. However, the unnamed argument Tony is a positional argument, and must appear in the matching position.
RSVP_Named("Tony", inviteOnly: true, allergies: "Jackfruit", partySize: 1);

// or just use positional arguments
RSVP_Named("Linh", 2, "none", false);
RSVP_Named("Noor", 4, "none", false);
RSVP_Named("Jonte", 2, "Stone fruit", false);
ShowRSVPs_Named();

// OPTIONAL(DEFAULT) PARAMETERS
Console.WriteLine($"\nMethods with optional parameters");

/*
    A parameter becomes optional when it's assigned a default value. If an optional parameter is omitted from the arguments, the default value is used when the method executes. Required parameters should be declared first before any optional ones.  
*/
string[] rsvps_optional = new string[10];
count = 0;

void RSVP_Optional(string name, int partySize = 1, string allergies = "none", bool inviteOnly = true){

    if (inviteOnly)
    {
        // search guestList before adding rsvp
        bool found = false;
        foreach (string guest in guestList)
        {
            if (guest.Equals(name))
            {
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine($"Sorry, {name} is not on the guest list");
            return;
        }
    }

    rsvps_optional[count] = $"Name: {name}, \tParty Size: {partySize}, \tAllergies: {allergies}";
    count++;
};

void ShowRSVPs_optional()
{
    Console.WriteLine("\nTotal RSVPs");
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine(rsvps_optional[i]);
    }
}

RSVP_Optional("Rebecca");
RSVP_Optional("Nadia", 2, "Nuts");
RSVP_Optional(name: "Linh", partySize: 2, inviteOnly: false);
RSVP_Optional("Tony", allergies: "Jackfruit", inviteOnly: true);
RSVP_Optional("Noor", 4, inviteOnly: false);
RSVP_Optional("Jonte", 2, "Stone fruit", false);
ShowRSVPs_optional();


/* METHODS WITH RETURNING VALUES */
Console.WriteLine($"\nMethods with returning values");

/*
    Methods can return a value by including the return type in the method signature. Methods can return any data type, or they can return nothing at all. The return type must always be specified before the method name. 
    
    VOID - Using void as the return type means the method only performs operations and doesn't return a value. 

    When a data type (such as int, string, bool, etc.) is used, the method performs operations and then returns the specified type upon completion. Inside the method, the keyword return is used to return the result. In void methods, you can also use the return keyword to terminate the method.
*/

double total = 0;
double minimumSpend = 30.00;

double[] items = { 15.97, 3.50, 12.25, 22.99, 10.98 };
double[] discounts = { 0.30, 0.00, 0.10, 0.20, 0.50 };

for (int i = 0; i < items.Length; i++)
{
    total += GetDiscountedPrice(i);
}

Console.WriteLine($"Total: ${total}");

//if(TotalMeetsMinimum()){
//    total -= 5.00;
//}

// OR

total -= TotalMeetsMinimum() ? 5.00 : 0.00;

Console.WriteLine($"Total with discount: ${FormatDecimal(total)}");

double GetDiscountedPrice(int itemIndex)
{
    // Calculate the discounted price of the item
    return items[itemIndex] * (1 - discounts[itemIndex]);    
}

bool TotalMeetsMinimum()
{
    // Check if the total meets the minimum
    return total > minimumSpend;
}

string FormatDecimal(double input)
{
    // Format the double so only 2 decimal places are displayed
    return input.ToString().Substring(0, 5);
}

// RETURNING AN INTEGER
Console.WriteLine($"\nMethods with returning INT");

double usd = 23.73;
int vnd = UsdToVnd(usd);

Console.WriteLine($"${usd} USD = ${vnd} VND");

// method that converts american currency (USD) to Vietnam currency (VND)
int UsdToVnd(double usd){
    int rate = 23500;
    // We need do implisit cast of the result, because there is data loss occurring as a result of this conversion.    
    return (int) (usd * rate);
}

// RETURNING AN DOUBLE
Console.WriteLine($"\nMethods with returning DOUBLE");

Console.WriteLine($"${vnd} VND = ${VndToUsd(vnd)} USD");

double VndToUsd(int vnd){
    /*
        If you set rate to an int instead of double, you'll notice that the compiler doesn't present you with any errors. This happens because the value of vnd / rate is implicitly casted to the double data type specified in the method signature.     
     */
    double rate = 23500;
    return vnd / rate;
}

// RETURNING STRING
Console.WriteLine($"\nMethods with returning STRING");

Console.WriteLine(ReverseString("Martin"));
Console.WriteLine(ReverseSentence("Martin Martin Martin"));

// reverse word
string ReverseString(string word){

    string result = "";

    for (int i = word.Length - 1; i >= 0; i--)
    {
        result += word[i];
    }

    return result;
}

// reverse words in a sentence
string ReverseSentence(string input){
    string result = "";
    string[] words = input.Split(" ");

    for (int i = 0; i < words.Length; i++)
    {   
        result += ReverseString(words[i]) + " ";
    }

    return result.Trim();
}

// RETURNING BOOLEANS
Console.WriteLine($"\nMethods with returning BOOLEANS");

string[] words = { "racecar", "talented", "deified", "tent", "tenet" };

Console.WriteLine("Is it a palindrome?");
foreach (var word in words)
{
    Console.WriteLine($"{word}: {IsPalindromeV2(word)}");
}

bool IsPalindromeV1(string word){

    string temp = ReverseString(word);
  
    if (word != temp)
    {
        return false;
    }
  
    return true;
}

bool IsPalindromeV2(string word){

    int start = 0;
    int end = word.Length - 1;
    while(start < end){

        if (word[start] != word[end])
            return false;

        start++;
        end--;
    }  
    
    return true;
}

// RETURNING ARRAYS
Console.WriteLine($"\nMethods with returning ARRAYS");

// Find two coins whose sum is equal to a target value. 
int target1 = 60;
int[] coins1 = new int[]{ 5, 5, 50, 25, 25, 10, 5 };
TwoCoins1(coins1, target1);

int[] TwoCoins1(int[] coins, int target){
   
    for (int i = 0; i < coins.Length; i++)
    {   
        for (int j = i + 1; j < coins.Length; j++)
        {
            if (coins[i] + coins[j] == target)
            {
                Console.WriteLine($"Matched {coins[i]} and {coins[j]} coins to match the target value: {target}");
                return new int[]{ coins[i], coins[j]};
            }
        }

    }

    Console.WriteLine($"No two coins found to match the target value");
    return new int[0];
}

// Find multiple pairs of coins that make change. 
int target2 = 30;
int[,] result2 = TwoCoins2(coins1, target2);

if(result2.Length == 0){

    Console.WriteLine("No two coins make change");
}else{

    Console.WriteLine("Change found at positions:");

    for (int i = 0; i < result2.GetLength(0);i++)
    {
        if (result2[i, 0] == -1) {
            break;
        }
        Console.WriteLine($"{result2[i, 0]}, {result2[i, 1]}");
    }
}

int[,] TwoCoins2(int[] coins, int target){

    int[,] result = { { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 } };
    int count = 0;

    for (int curr = 0; curr < coins.Length; curr++)
    {
        for(int next = curr + 1; next < coins.Length; next++){
        
            if(coins[curr] + coins[next] == target){

                result [count, 0] = curr;
                result [count, 1] = next;
                count++;
            }

            // prevent from out of bound if there is more there are more than five pairs found
            if (count == result.GetLength(0)){
                return result;
            }
        }
    }
    
    if(count == 0){
        return new int[0, 0];
    }

    return result;
}

