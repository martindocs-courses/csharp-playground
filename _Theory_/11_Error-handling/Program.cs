/* Navigation Notes
    
    Runtime errors                                                      : line 31
    Try-catch block
    - single try-catch                                                  : line 47
    - multiple try-catch                                                : line 81
    - global try-catch                                                  : line 288

    Explicitly throwing exception                                       : line 123
    Build-in exception types                                            
    - most common exceptions                                            : line 324
    - stack overflow exception and recursive method                     : line 167

    Precise exceptions                                                  : line 177
    Re-trowing an exception
    - throw vs throw ex                                                 : line 238
    - system.Exception object                                           : line 267


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

