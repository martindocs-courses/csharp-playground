/* Navigation Notes
    
    String Helper methods               : line 22 
    Methods returning boolean value     : line 34
    Logical negation                    : line 43
    Ternary conditional operator        : line 50
    Variable scope                      : line 96
    Switch statement                    : line 155
    For loop                            : line 214
    While loop                          : line 238
    User input ( nullable type string)  : line 282
    Exercises                           : line 330
        - exercise 1                    : line 323
        - exercise 2                    : line 370
        - exercise 3                    : line 418

    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/


/* STRING HELPER METHODS */

// ToUpper() , ToLower() - change strings to upper-case or lower-case
using System.Diagnostics;
using System.Security;
Console.WriteLine("String Helper methods\n------------------------");
Console.WriteLine("a" == "A".ToLower()); // True

// Trim() - remove any leading or trailing blank spaces
Console.WriteLine("a" == "a ".Trim()); // True


/* METHODS RETURNING BOOLEAN VALUE */
Console.WriteLine("\nMethods returning boolean value\n-------------------------------");
// Contains(), StartsWith(), and EndsWith()
string pangram = "The quick brown fox jumps over the lazy dog.";
Console.WriteLine(pangram.Contains("fox")); // True
Console.WriteLine(pangram.StartsWith("cow")); // False
Console.WriteLine(pangram.EndsWith("dog.")); // True


/* LOGICAL NEGATION */

// ! - it forces your code to reverse its evaluation of the operand
Console.WriteLine($"\nLogical negation\n------------------------");
Console.WriteLine(!pangram.Contains("fox"));


/* CONDITIONAL OPERATOR / TERNARY CONDITIONAL OPERATOR */
Console.WriteLine($"\nTernary conditional operator\n----------------------------");

int purchase1 = 1000;
int purchase2 = 1200;

int discount = purchase2 > 1000 ? 100 : 50;
Console.WriteLine($"Your purchase is {purchase2}");
Console.WriteLine($"You are eligible to £{discount} discount.");

// inline conditional poerator
Console.WriteLine($"Discount: {(purchase2 > 1000 ? 100 : 50)}");

// example1, flip the coin
Random coin = new();
int flip = coin.Next(0, 2);

Console.WriteLine($"\nFlip the coin... You've got: {(flip == 0 ? "head": "tail")}");

// example2, decision logic
Console.WriteLine("\n");
string permission = "Admin";
int level = 65;

if (permission.Contains("Admin"))
{
    if(level > 55){
        Console.WriteLine("Welcome, Super Admin user.");
    }else{
        Console.WriteLine("Welcome, Admin user.");
    }

}else if (permission.Contains("Manager")){

    if(level >= 20){
        Console.WriteLine("Contact an Admin for access.");
    }else{
        Console.WriteLine("You do not have sufficient privileges.");
    }

}else   
{
    Console.WriteLine("You do not have sufficient privileges.");
}


/* VARIABLE SCOPE */
Console.WriteLine("\nVariable scope\n------------------------");

// EXAMPE 1
bool flag1 = true;
int globalValue1;
//  the compiler interprets flag as a Boolean variable that could be assigned a value of either true or false
if (flag1) {
    //int localValue = 20; // local variable
    globalValue1 = 30;
    Console.WriteLine($"Inside the code block: {globalValue1}"); // 20, if local variable exists
}

//globalValue = 10;
//Console.WriteLine($"Outside the code block: {globalValue1}"); // can't be accessed

// EXAMPLE 2
int globalValue2;
// the complier concludes that the contents of the if statement code block will always be executed.
if (true)
{
    //int localValue = 20; // local variable
    globalValue2 = 15;
    Console.WriteLine($"Inside the code block: {globalValue2}"); // 20, if local variable exists
}

//globalValue = 10;
Console.WriteLine($"Outside the code block: {globalValue2}"); // can't be accessed

// if one line of code, prefered you still use indentation
bool flag3 = true;
if(flag3) 
    Console.WriteLine(flag3);

// EXAMPLE 3
Console.WriteLine("\n");
int[] numbers = [ 4, 8, 15, 16, 23, 42 ]; // collection expression
//Console.WriteLine(string.Join(',', numbers));

int total = 0;
bool found = false;

foreach (var number in numbers)
{
    total += number;

    if (number == 42){
        found = true;       
    }
    
}

if(found){
    Console.WriteLine("Set contains 42");
}

Console.WriteLine($"Total: {total}");


/* SWITCH STATEMENT */
Console.WriteLine("\nSwitch statement\n------------------------");
/*
    The switch is best used when:
    - You have a single value (variable or expression) that you want to match against many possible values.
    - For any given match, you need to execute a couple of lines of code at most.
*/

int employeeLevel = 500;
string employeeName = "Martin";

string title = "";

switch(employeeLevel){

    case 100:
        title = "Junior";
        break; // also can use return;
    case 200:
        title = "Senior";
        break;  // also can use return;
    case 300:
        title = "Manager";
        break; // also can use return;
    case 400:
        title = "Senior Manager";
        break; // also can use return;
    default: //  If no default is included, control is transferred to the end point of the switch statement.
        title = "Associate";
        break; // also can use return;
}

Console.WriteLine($"{employeeName}, {title}");

// fall through to the next case section
int employeeLevel2 = 200;
string title2 = "";

switch (employeeLevel2)
{

    case 100:
    case 200:
        title2 = "Senior";
        break;  // also can use return;
    case 300:
        title2 = "Manager";
        break; // also can use return;
    case 400:
        title2 = "Senior Manager";
        break; // also can use return;
    default: //  If no default is included, control is transferred to the end point of the switch statement.
        title2 = "Associate";
        break; // also can use return;
}

Console.WriteLine($"{employeeName}, {title2}");


/* FOR LOOP */
Console.WriteLine("\nFOR loop\n------------------------");
/*
    - The for statement should be used when you know the number of times you need to iterate through a block of code ahead of time.
    - The for statement allows you to control the way in which each iteration is handled.
    
    Also:
    - 'FOR' loop: iterates through a code block a specific number of times
    - 'FOREACH' loop: enumerates through a block of code once for each item in a sequence of data like an array or collection.
    - 'WHILE' loop: iterates through a block of code until a condition is met. 
*/

for (int i = 0; i <= 10; i++)
{

    if(i == 3){
        break; // exit the iteration and allows to continue code after loop or in other words transfers control to the statement that follows the terminated statement.
        //return; // exit the loop and return to the caller 
        //continue; // go back to top of the loop without executing code belove
    }
    Console.WriteLine(i);
}


/* WHILE LOOP */
Console.WriteLine("\nWhile loop\n------------------------");
// do-while loop - executes a statement or a block of statements at least one or more times.

Random random = new Random();
int current = 0;

/* 
    It's also important to notice that the code inside of the do-while code block is influencing whether to continue iterating through the code block or not. A code block that influences the exit criteria is a primary reason to select a do-while or while statements rather than one of the other iteration statements.  
*/

// do-while
do
{
    current = random.Next(1, 11);
    Console.WriteLine($"current - {current}");
} while (current != 7);

Console.WriteLine("");

// while
int current2 = random.Next(1, 11);
while (current2 >= 3){
    Console.WriteLine($"current2 - {current2}");
    current2 = random.Next(1, 11);
}
Console.WriteLine($"Last number current2: {current2}");

// continue statement - to short-circuit the remainder of the code in the code block and continue to the next iteration / Transfers execution to the end of the current iteration. 

Console.WriteLine("");
Random random3 = new Random();
int current3 = random.Next(1, 11);

do
{
    current3 = random.Next(1, 11);

    if (current3 >= 8) continue; // the continue key word will transfer control to the end of the code block

    Console.WriteLine($"current3 - {current3}"); // executed only if the values are between 1 and 7
} while (current3 != 7); // and the while will evaluate (current != 7)


/* USER INPUT */
Console.WriteLine("\nUser Input\n------------------------");
// Console.ReadLine(); - nullable type string (designated string?) 
string? readResult;
bool validEntry = false;

Console.WriteLine("Enter a string containing at least three characters: ");

do{
    readResult = Console.ReadLine();
    if(readResult != null){
        
        if(readResult.Length >= 3){
            validEntry = true;
        }else{
            Console.WriteLine("Invalid input!!");
        }

    }
}while(validEntry == false);

// to use Console.ReadLine() for numeric values we nned int.TryParse() method
string? userInput;
int numericValue = 0;
bool validNumber = false;

Console.WriteLine("\nPlease enter a valid number");
do
{
    userInput = Console.ReadLine();
   
    if (userInput != null && userInput != ""){
        validNumber = int.TryParse(userInput, out numericValue);       
    }
    else{
        Console.WriteLine("Invalid entry");            
    }

    if(!validNumber && userInput != ""){
        Console.WriteLine("The input need to be a number!!");
    }
    

} while (validNumber == false);

Console.WriteLine($"Your number is: {numericValue}");


/* EXERCISES */

// EXERCISE 1
Console.WriteLine("\nExercise 1\n------------------------");
/*
    - Solution must include either a do-while or while iteration.

    - Before the iteration block: must use a Console.WriteLine() statement to prompt the user for an integer value between 5 and 10.

    Inside the iteration block:

    - must use a Console.ReadLine() statement to obtain input from the user.
    - must ensure that the input is a valid representation of an integer.
    - If the integer value isn't between 5 and 10, your code must use a Console.WriteLine() statement to prompt the user for an integer value between 5 and 10.
    - must ensure that the integer value is between 5 and 10 before exiting the iteration.
    - Below (after) the iteration code block: must use a Console.WriteLine() statement to inform the user that their input value has been accepted.  
*/

bool validNumberExercise1;
int numericValueExercise1;
string? userInputExercise1;

Console.WriteLine("\nPlease enter an value between 5 and 10.");

do {
    userInputExercise1 = Console.ReadLine();
    validNumberExercise1 = int.TryParse(userInputExercise1, out numericValueExercise1);

    if (!validNumberExercise1) {
        Console.WriteLine("Please enter the number");
    }else{
        if (numericValueExercise1 <= 5 || numericValueExercise1 >= 10){            
            Console.WriteLine("Invalid value! Please enter value between 5 and 10");
            validNumberExercise1 = false;      
        }
    }
} while (!validNumberExercise1);

Console.WriteLine($"\nYour input value {numericValueExercise1} has been accepted.");

// EXERCISE 2
Console.WriteLine("\nExercise 2\n------------------------");
/*
    - Solution must include either a do-while or while iteration.

    - Before the iteration block: solution must use a Console.WriteLine() statement to prompt the user for one of three role names: Admin, Manager, or User.

    Inside the iteration block:

    - must use a Console.ReadLine() statement to obtain input from the user.
    - must ensure that the value entered matches one of the three role options.
    - should use the Trim() method on the input value to ignore leading and trailing space characters.
    - should use the ToLower() method on the input value to ignore case.
    - If the value entered isn't a match for one of the role options, your code must use a Console.WriteLine() statement to prompt the user for a valid entry.
    - Below (after) the iteration code block: must use a Console.WriteLine() statement to inform the user that their input value has been accepted.
*/

Console.WriteLine("\nEnter your role name (Admin), Manager, or User");
string? userInputExercise2 = "";
bool role = false;

while(!role){

    //userInputExercise2 = Console.ReadLine()?.Trim().ToLower(); // ?. optional chaining or null-conditional operator
    /*
     ?. optional chaining - allows you to safely access members (methods, properties, or fields) of an object that might be null. If the object is null, the operation is simply skipped, and null is returned instead of throwing a NullReferenceException.     
    */

    userInputExercise2 = Console.ReadLine();
    
    if (userInputExercise2 != null && userInputExercise2 != ""){
        if(
            userInputExercise2.Trim().ToLower().Contains("admin") || 
            userInputExercise2.Trim().ToLower().Contains("manager") || 
            userInputExercise2.Trim().ToLower().Contains("user")
        )
        {
            role = true;    
        }else{
            Console.WriteLine($"The role name that you entered, \"{userInputExercise2}\" is not valid. Enter your role name (Admin, Manager, or User)");
        }
    }else{
        Console.WriteLine("Please enter a value");
    }
}

Console.WriteLine($"\nYour input value ({userInputExercise2}) has been accepted.");

// EXERCISE 3
Console.WriteLine("\nExercise 3\n------------------------");
/*
    - solution must use the following string array to represent the input to your coding logic:
        
    string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };

    - must declare an integer variable named periodLocation that can be used to hold the location of the period character within a string.

    - must include an outer foreach or for loop that can be used to process each string element in the array. The string variable that you'll process inside the loops should be named myString.

    - In the outer loop, your solution must use the IndexOf() method of the String class to get the location of the first period character in the myString variable. The method call should be similar to: myString.IndexOf("."). If there's no period character in the string, a value of -1 will be returned.

    - must include an inner do-while or while loop that can be used to process the myString variable.

    - In the inner loop, your solution must extract and display (write to the console) each sentence that is contained in each of the strings that are processed.

    - In the inner loop, your solution must not display the period character.

    - In the inner loop, your solution must use the Remove(), Substring(), and TrimStart() methods to process the string information. 
*/


string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };

int periodLocation;
bool periodExistance = true;
string currentSentence;

foreach (var myString in myStrings)
{
    currentSentence = myString;
    periodLocation = currentSentence.IndexOf(".");

    if (periodLocation > 0)
    {
        while (periodExistance)
        {
            periodLocation = currentSentence.IndexOf(".");

            if (periodLocation > 0)
            {
                Console.WriteLine($"{currentSentence.Substring(0, periodLocation)}");
                currentSentence = currentSentence.Remove(0, periodLocation + 1).TrimStart();
            }
            else
            {
                Console.WriteLine(currentSentence);
                periodExistance = false;
            }
        };
    }
    else
    {
        Console.WriteLine(myString);
    }
}