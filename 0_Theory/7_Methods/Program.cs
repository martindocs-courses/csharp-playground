/* Navigation Notes
    
    Methods                             : line 29
    Foward reference                    : line 31
    Best practices                      : line 40
        Example 1                       : line 70
    
         
    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

/*
    example:
    void MethodName(); // method signature

    - void - method returs no data
    - HelloWorld - is method name
    - () - has no arguments, but it can accept multiple parameters of any data type

    Methos signature are:
    - Method Name: The name of the method itself.
    - Parameter Types: The types of parameters that the method accepts. The parameter names are not part of the signature; only the types and their order matter.
    - Number of Parameters: The number of parameters the method takes.

    Methods can return a value of any data type, such as bool, int, double, and arrays 
*/

/* METHODS */

// FOWRD REFERENCE - to methods within a class, meaning you can reference a method in the code before it is defined, as long as the method declaration is visible within the scope.

Console.WriteLine($"Foward reference");
Name(); // calling the method

void Name(){
    Console.WriteLine("My name is Martin");
}

// BEST PRACTICES
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