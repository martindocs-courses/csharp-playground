/* Navigation Notes
    
    Methods                                     : line 34
    Foward reference                            : line 36
    Best practices                              : line 47
        Example 1                               : line 77
    Methods with Parameters                     : line 166
    Methods Scope                               : line 186
    Value and Reference type parameters         : line 244
    Methods with named & optional parameters    : line 316
    - named methods parameters                  : line 327
    - optional methods parameters               : line 380
         
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
    A parameter becomes optional when it's assigned a default value. If an optional parameter is omitted from the arguments, the default value is used when the method executes.  
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