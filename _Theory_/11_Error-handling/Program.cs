/* Navigation Notes
    
    Runtime errors                                                      : line 36
    Try-catch block
    - single try-catch                                                  : line 52
    - multiple try-catch                                                : line 86
    - global try-catch                                                  : line 293
    - code inside catch block                                           : line 310
    

    Explicitly throwing exception                                       : line 128 & 393
    Build-in exception types                                            
    - most common exceptions                                            : line 158 & 423
    - stack overflow exception and recursive method                     : line 172

    Precise exceptions                                                  : line 182
    Re-trowing an exception
    - throw vs throw ex                                                 : line 243
    - system.Exception object                                           : line 281

    Exception filters (WHEN keyword)                                    : line 328    
    Custom exception                                                    : line 357 & 459
    Smart usage of exceptions                                           : line 375

    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

/*
    Main types of errors:
    * compilation errors - prevent from program to be compile and run
    * runtime errors - occurs during runtime of the program 
    * logical errors - program do not crash but do not work as expected
 
 */
/* RUNTIME ERRORS - represent with exceptions */
using System;

string runtimeName = "Martin";
//var number = int.Parse(runtimeName); // Format Exception 

/*
    * All EXCEPTIONS in C# are derived from System.Exception base class.
    * The STACK TRACE is the track of all methods that have been called leading to a particular point in the program execution.
*/

int ParseRuntimeStringToInt(string input){
    return int.Parse(input);
}
//var number = ParseRuntimeStringToInt(name);

/* TRY-CATCH BLOCK */
int ParseSingleTryCatchStringToInt(string input)
{
    return int.Parse(input);  // throw an exception if the string is not a number
}
Console.WriteLine("Single Try-catch block");
Console.Write("Enter a number:");
var singleTryCatchInput = Console.ReadLine();

/*
    * If we suspect some code may throw an exception and we want to handle it, we should put this code in the try block. 
    * Only use local try blocks when we truly see a risk of an error-causing situation and if we can actually handle it.
*/
try
{
    int singleTryCatchNumber = ParseSingleTryCatchStringToInt(singleTryCatchInput); // throw exception
    Console.WriteLine("String successfully parsed, result is: " + singleTryCatchNumber);
}
/*
    If an exception is thrown in the try block, the code execution will jump to the catch block, and the code defined inside will be executed.
*/
catch (Exception ex)
{

    Console.WriteLine("A exception was thrown " + ex.Message);
}
/*
    The code in the finally block will always be executed, no matter if the exception was thrown in the try block or not.
 */
finally // optional block   
{
    Console.WriteLine("This block is always executed.");
}

/* MULTIPLY TRY-CATCH BLOCKS */
int ParseMultiplyTryCatchStringToInt(string input)
{
    return int.Parse(input);  // throw an exception if the string is not a number
}
Console.WriteLine("\nMultiply Try-catch block");
Console.Write("Enter a number:");
var multiplyTryCatchInput = Console.ReadLine();

try
{
    int multiplyTryCatchNumber = ParseSingleTryCatchStringToInt(multiplyTryCatchInput); // throw exception from ParseSingleTryCatchStringToInt method
    var multiplyTryCatchResult = 10 / multiplyTryCatchNumber; // throw exception if the given number is zero
    Console.WriteLine($"10 / {multiplyTryCatchNumber} result is: " + multiplyTryCatchResult);
}
/*
    It is a good practice to catch as specific exceptions as possible. 
    The more specific the exception, the more accurately we can handle it.
 */
catch (FormatException ex)
{
    Console.WriteLine("Wrong format. Input string is not passable to int. " + "Exception message: " + ex.Message);
}
catch(DivideByZeroException ex){ // specific exception
    Console.WriteLine("You cannot divide by zero! " + "Exception message: " + ex.Message);
}
/* 
    If we expect some specific exceptions but we want to catch other kinds too, we can add a general catch clause after the more specific ones.  

    NOTES:
    In case of multiple catch blocks, when the exception is thrown, it will be caught by the first catch block that handles the matching exception type. Because of that, we should always write catch blocks from the most specific to the most generic.

    Generally catching generic exception is bad idea and we should always try to catch exceptions as much specific as possible
*/
catch (Exception ex){ // most generic system exception class
    Console.WriteLine("Unexpected error occurred." + "Exception error: " + ex.Message);
}
finally
{
    Console.WriteLine("This block is always executed.");
}

/* EXPLICITLY THROWING EXCEPTION */
// EXAMPLE1
// get first element from an collection
Console.WriteLine("\nExplicit throwing exception");
try
{
    var explicityThrowExceptionResult = GetFirstElement(new int[0]); // to handle this exception we need use catch block, if not the program will crash.
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

int GetFirstElement(IEnumerable<int> numbers){

    foreach (var item in numbers) // if the collection is empty that will never return a value
    {
        return item;
    }
    // not recommended way to return default value, in this case 0 as for empty collection
    //return 0; 

    // Better way is to throw custom exception
    throw new Exception("No value returned. The collection cannot be empty.");
}

// EXAMPLE 2
//var invalidPersonObject1 = new ExplicitThrownExceptionPerson("", -197); // without validation we can create invalid object
var invalidPersonObject2 = new ExplicitThrownExceptionPerson("Martin", 1996);

/* BUILD-IN EXCEPTION TYPES */
// EXAMPLE 2 - another case to throw exception is index exception
var numbers = new int[] { 1, 2, 3 };
//var fourth = numbers[4]; // IndexOutOfRangeException

// EXAMPLE 3 - when generating new methods with Visual Studio by default we getting new implemented exceptions. We creating method signature, but treating method as still in progress and allow Visual Studio to compile.

//bool checkNumbers = CheckIfNumber(7);

bool CheckIfNumber(int value)
{
    throw new NotImplementedException();
}

/* STACK OVERFLOW EXCEPTION & RECURSIVE METHODS */
RecursiveMethod(); 
void RecursiveMethod(int counter = 1){
    Console.WriteLine("I'm going to repeat myself: " + counter + " times.");
    // Make sure to set the breaking point to stop calling function itself, so StackOverflowException wont be thrown
    if(counter < 10){
        RecursiveMethod(counter + 1);
    }
}

/* PRECISE EXCEPTIONS */
Console.WriteLine("\nPrecise exceptions");
var preciseExceptionsNumbers = new int[]{1,2,5};
/*
    * Catching an exception of the System.Exception type is almost always considered a bad idea.
    * When we catch an exception, we should handle it appropriately.
 */

Console.WriteLine(IsFirstElementPositivePreciseException(preciseExceptionsNumbers));

int GetFirstElementPreciseException(IEnumerable<int> numbers)
{

    foreach (var item in numbers) // we could get null exception and we might catch or not, depend of the design of the method
    {
        return item;
    }
       
    throw new InvalidOperationException("No value returned. The collection cannot be empty.");
}

// Check if first element in the collection is positive
bool IsFirstElementPositivePreciseException(IEnumerable<int> numbers){
    // Design this new method in such a way that if the collection is empty, the returned value will be true.
    try
    {
        var firstElement = GetFirstElementPreciseException(numbers);
        return firstElement > 0;
    }
    //catch (Exception ex) // this exception is too wide and can catch other exceptions, like null exception

    /*
        We can now say that this method handles InvalidOperationException and does not handle NullReferenceException, because if it is thrown in the try block, the whole method will throw an exception and th's fine.
        
        A method should only handle an exception when it can do it in a reasonable way.

        We don't need to, nor should we try to handle all possible exceptions.

        If an input to a method is invalid, it is perfectly fine if the method throws an exception.

        This way, whoever sees this exception will be clearly informed that they did something wrong in their code.     
     */
    catch (InvalidOperationException ex) // more precise exception
    {
        Console.WriteLine("Collection is empty.");
        return true;
    }
    // Alternatively for other exceptions, we can catch it, wrap it in our own exception as the InnerException, and then explicitly throw this new exception.
    catch(NullReferenceException ex){
        /*
            We create a new exception object and pass the original 'ex' exception as the constructor 
            parameter, which will be assigned to the InnerException property 'ex' of the new exception.

            We say that the new exception wraps the old one.

            This way this method will still throw an exception for the null input, but it will be our own exception thrown explicitly, not the exception thrown when the GetFirstElement method tries to iterate the null collection.
         */
        throw new ArgumentNullException("The collection is null", ex);           
    }
}

/* THROW VS THROW ex */
// Exception re-throwing
bool IsFirstElementPositiveThrow(IEnumerable<int> numbers)
{   
    try
    {
        var firstElement = GetFirstElementPreciseException(numbers); // (1)
        return firstElement > 0;
    }
    
    catch (InvalidOperationException ex) // more precise exception
    {
        Console.WriteLine("Collection is empty.");
        return true;
    }
    
    catch (NullReferenceException ex)
    {
        /*
            Re-throwing an exception makes sense if we want to perform some additional steps, for example, show some message to the user or write the information about the issue in some logs. 
         */

        /*
            DIFFRENCE TWROW VS THROW ex:
            - The difference between them is that throw preserves the stack trace, which means the stack trace will point to the method that caused the exception in the first place.
            - Throw ex does not preserve the stack-trace. It means we lose the information about the first place from which the exception was thrown.        
            - Because of that, we should rather use throw, not throw ex.
         */

        //throw ex; // less used as we get partly from this line stack-trace (reset the stack trace). Stack-trace will point to the line of re-throwing.

        //throw; // better way as we get full stack-trace. Stack-trace will point to the method that caused the exception in the first place

        // most precise. Also we get partly stack-trace from this point/line , but because we  passed original exception ...("The collection is null", ex), as an argument to the new exception parameter. This way we don't lose valuable information about the origin of an exception and can stack-trace also that too
        throw new ArgumentNullException("The collection is null", ex);
    }
}

/* SYSTEM.EXCEPTION OBJECT */

/*
    in situations like when the exception is not handled handled but rather only logged or shown to the user and then re-thrown, it is fine to catch the base Exception type.
    
    ...
    catch(Exception ex){
        _logger(ex);
        throw;
    } 
 */

/* GLOBAL TRY-CATCH BLOCK */
/* 
 * Global try-catch block that can catch an exception not caught elsewhere, show it to the user and then shut the application down gracefully.
 * The global try-catch block should surround the entry point to the application. The entry point is the first method that is called and which then calls all other methods. In the console application it is the Main method in the Program class.
 * Since this is the last resort of error handling, we must expect any exceptions. A global try-catch block is a special place where catching the System.Exception is fine. We must catch all types of exceptions because if we don't catch some of them, the application will crash.
 
    try{
        public static void Main(string[] args){
            // Main program
        }
    }catch (Exception ex){
        Console.WriteLine("Sorry the application experienced an unexpected error and will be closed. " + "Message error: " + ex.Message);
        Console.WriteLine("Press any key...");  
        Console.ReadKey();
    }  
*/

/* CODE INSIDE CATCH BLOCK */
/*
    * Generally it is a bad practice to put any code that can possibly throw an exception inside a catch block. 
    * The catch block should be simple.
    * It may return some default value if this is how the method is designed, or print something to the console, log an error in some file or show some pop up to the user, example: 
    * It is possible to create nested try-catch blocks, but it's not advised use nested try-catch blocks. Such code is messy and unreadable and might be really tricky to follow.
        try{
            ...
        }catch(DividedByZeroException ex){
            try{
                // some code
            }catch(FormatException ex){
                // message
            }
        }
 
*/

/* EXCEPTION FILTERS (WHEN keyword) */

try
{
    var dataFromWeb = ProcessHttpRequest("www.google.com");
}
catch (HttpRequestException ex) when (ex.Message.StartsWith("4")) // that will be handled before code below. Because of that, we should always put more specific filters on the top and more generic ones on the bottom.
{
    Console.WriteLine("Resource not available.");
    throw;

}catch (HttpRequestException ex) when (ex.Message == "403")
{
    Console.WriteLine("Resource not available.");
    throw;
}
catch (HttpRequestException ex) when (ex.Message == "404")
{
    Console.WriteLine("Resource not found.");
    throw;
}
catch (HttpRequestException ex) when (ex.Message == "500")
{
    Console.WriteLine("Server internal error.");
    throw;
}

string ProcessHttpRequest(string adress) => "some data";

/* CUSTOM EXCEPTION */
try
{
    Console.WriteLine("\nCustom exception");   
}
catch (Exception)
{
    throw new CustomException("Server Error.", 500);    
}

/*
    Exceptions do have a lot of downsides:
    * they impact the performance of the application quite significantly. Of course, only if they are thrown. If we add a try-catch block but exceptions are not often thrown in the try the performance will hardly be impacted.
    * exceptions make the code harder to follow. When an exception is thrown, the normal execution of the code is disrupted and we suddenly jump to a completely different place in the code, specifically to the first catch block that can handle this exception.
    * Exceptions are a side effect of methods and, in a way, a hidden part of their signature. It may make the code harder to understand and maintain.
 
*/

/* SMART USAGE OF EXCEPTIONS */
/*
    Good practices regarding catching exceptions:
    LOCALLY
    * At the lowest possible level, which means locally, as close to the place of the exception throwing as possible, we should handle specific exception types.    
    * We should do it only when we have something meaningful to do about them. For example, returning a default value from a method, retrying to perform some action or adding more information to the exception
    * We should not perform catching logging here

    GLOBALLY
    * At the highest possible level, which means in the global catch block, we should catch all exceptions unhanded elsewhere so the application doesn't crash.
    * We should show the exception to the user in some readable way and apologize for the application issue.
    * We should also log this exception with all the details that may help us understand why it happened.
    * The exception caught in the global catch block always means there is something wrong going on in our application.
 
*/

Console.ReadLine();

class ExplicitThrownExceptionPerson
{

    public string Name { get; }
    public int YearOfBirth { get; }

    public ExplicitThrownExceptionPerson(string name, int yearOfBirth)
    {
        // Constructor do not have any validation
        //Name = name;
        //YearOfBirth = yearOfBirth;
        
        /*
            It makes sense to throw an exception, when:
            * we cannot handle invalid input reasonably. In our case we shouldn't set to default values if arguments are invalid. Better to throw exception
         */
        if(name == string.Empty){
            throw new Exception("The name cannot be empty."); // the message should be as detailed as possible and the more precise exception types as possible
        }

        if (yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year) {
            throw new Exception("The year of the birth must be between 1900 and the current year.");
        }

        Name = name;
        YearOfBirth = yearOfBirth;        
    }
    
}

class BuildInExceptionTypesPerson
{
    public string Name { get; }
    public int YearOfBirth { get; }

    public BuildInExceptionTypesPerson(string name, int yearOfBirth)
    {       
        /*
                                    Exception
                                        |
                                ArgumentException
                                |               |
                ArgumentNullException     ArgumentOutOfRangeException
        */

        // if the name is null we should use ArgumentNullException
        if(name is null){
            throw new ArgumentNullException("The name cannot be null."); 
        }

        if (name == string.Empty)
        {
            throw new ArgumentException("The name cannot be empty."); // more specific exception type
        }

        if (yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year)
        {
            throw new ArgumentOutOfRangeException("The year of the birth must be between 1900 and the current year.");
        }

        Name = name;
        YearOfBirth = yearOfBirth;
    }

}

public class CustomException : Exception
{
    public int StatusCodes { get; } // adding new prop 

    /* base Constructors of Exception class */
    public CustomException()
    {
    }

    public CustomException(string? message) : base(message)
    {
    }

    public CustomException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /* New constructors */
    public CustomException(string message, int statusCodes) : base(message){
        StatusCodes = statusCodes;
    }

    public CustomException(string message, int statusCodes, Exception innerException) : base(message, innerException){
        StatusCodes = statusCodes;
    }
}

