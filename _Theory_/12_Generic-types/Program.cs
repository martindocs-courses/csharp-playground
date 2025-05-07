/* Navigation Notes
    
    Generic                                                         : line 26
    Simplified List                                                 : line 36 & 256
    - adding elements to list                                       : line 70
    - removing element from te list                                 : line 76   

    Generic type                                                    : line 98 & 332
    - default keyword                                               : line 375

    Tuples                                                          : line 115 & 415
    - build-in tuples                                               : line 159

    ArrayList                                                       : line 187
    - issue with ArrayList                                          : line 212

    Generics methods                                                : line 248
    - one generic type parameter (extension method)                 : line 428 
    - multiple type parameters                                      : line 439

    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

/*
    GENERIC - They are parameterized by types, example: new List<T>

    T - means any type. When we create an instance of the list class for example, we will provide a concrete type instead of this generic T.
    
    new List<int> - integer type

    In a way, generic types are like templates of classes. 
    By using generic types, we can define the behavior of a type such as a list once and reuse it for multiple types, reducing the amount of code we need to write.
*/

/* SIPLIFIED LIST */
/*
   DATA STRUCTURES - are types meant for storing and organizing data so that it can be accessed and modified efficiently.

    Different types of data structures are suited to different kinds of applications, and some are highly specialized for specific tasks.

    Some common examples of data structures include arrays, stacks, queues, or dictionaries.   
*/

using System.Collections;
using System.Linq.Expressions;
Console.WriteLine("Simplified LIST");
var newList = new List<int>(3);

Console.WriteLine("Empty list: new List<int>(3)");
Console.WriteLine($"Number of elements - {newList.Count}"); // 0
Console.WriteLine($"Total size of list - {newList.Capacity}\n"); // 3

newList.Add(1);
newList.Add(5);

Console.WriteLine("Adding two numbers");
Console.WriteLine($"Number of elements - {newList.Count}"); // 2
Console.WriteLine($"Total size of list - {newList.Capacity}\n"); // 3

newList.Add(3);
newList.Add(6);

Console.WriteLine("Adding another two numbers, list expanding");
Console.WriteLine($"Number of elements - {newList.Count}"); // 4
Console.WriteLine($"Total size of list (double) - {newList.Capacity}\n"); // 6

/*
 
ADDING ELEMENTS TO LIST:
 * The array cannot be resized. In this case, the list class creates a new array, double the size of the old one.
 * It copies all elements from the old array to the new array. And finally it replaces the old array with the newly created and larger one.
 * Copying the old array into the new one can take a lot of time, especially for large lists.
 * This process also increases memory usage as at some point in time there must be two arrays in memory.
 
REMOVING ELEMENT FROM THE LIST:
 * when an item is removed from the list, all elements that were to the right of it must be moved one place to the left. So there are no gaps between items.
 * Deleting can take a while if we remove the element close to the beginning of the list because then we need to move more elements to the left.
 * Then the size field must be decremented.
 * Moving many elements to the left when a list is large can be quite a performance-heavy operation.

 */

Console.WriteLine("ADD TO LIST- Simplified List");
var simplifiedAddToList = new SimpliedListOfIns();
simplifiedAddToList.Add(10);
simplifiedAddToList.Add(20);
simplifiedAddToList.Add(30);
simplifiedAddToList.Add(40);
simplifiedAddToList.Add(50);

simplifiedAddToList.ShowArray();

Console.WriteLine("\n\nREMOVE FROM LIST - Simplified List");
simplifiedAddToList.RemoveAt(2);
simplifiedAddToList.ShowArray();

/* GENERIC TYPES */
Console.WriteLine("\n\nGeneric Types");
/* 
    Generic types are parameterized by other types, so we can create a generic SimpleList class and make it parameterized by the type of items that will be stored inside. 
*/

var genericString = new GenericType<string>();
genericString.Add("Martin");
genericString.Add("Adam");

var genericNumbers = new GenericType<int>();
genericNumbers.Add(1);
genericNumbers.Add(2);

genericString.ShowArray();
genericNumbers.ShowArray();

/* TUPLES */
Console.WriteLine("\n\nTuples");

var tuplesNumbers = new List<int> { 5, 3, 2, 8, 18, 7 };
//var tuplesStrings = new List<string> { "martin", "adam" };

SimpleTuple<int, int> minAndMax = GetMinAndMax(tuplesNumbers);

Console.WriteLine("Smallest number is: " + minAndMax.Value1);
Console.WriteLine("Largest number is: " + minAndMax.Value2);

// Creating custom tuples variables
var twoTuplesStrings = new SimpleTuple<string, string> ("Martin", "Adam" );
//var twoTuplesDiffTypes = new SimpleTuple<string, int> ("Martin", 1 , true); // can't have more than 2 types, and we need manually rewrite the method to have multiple types
var twoTuplesDiffTypes2 = new Tuple<string, int, bool> ("Martin", 1 , true); // build-in Tuples will support multiple types

// Find the min and max number in the collection of int
SimpleTuple<int, int> GetMinAndMax(IEnumerable<int> input)
{
    if (!input.Any())
    {
        throw new InvalidOperationException($"The input collection cannot be empty.");
    }

    int min = input.First();
    int max = input.First();

    foreach (var number in input)
    {
        if (number > max)
        {
            max = number;
        }

        if (number < min)
        {
            min = number;
        }
    }

    return new SimpleTuple<int, int>(min, max);
}


// BUILD-IN TUPLES 
Tuple<int, int> GetMinAndMax2(IEnumerable<int> input)
{
    if (!input.Any())
    {
        throw new InvalidOperationException($"The input collection cannot be empty.");
    }

    int min = input.First();
    int max = input.First();

    foreach (var number in input)
    {
        if (number > max)
        {
            max = number;
        }

        if (number < min)
        {
            min = number;
        }
    }

    return new Tuple<int, int>(min, max);
}


/* ARRAYLIST (used mostly in old co-debase) - is not parameterized by the types of elements it stores. Everything it holds as an instance of the System.Object type. */
/*
    All types are derived from System.Object type, so we can put anything into a collection of objects.
    object o1 = 5;
    object o2 = true;
    object o3 = "Martin"; 
*/

// The ArrayList stores elements of the type object, so it can store any type of elements.
ArrayList arryListInts = new ArrayList{ 2, 3, 4, 5 };
ArrayList arryListStrings = new ArrayList{ "a", "b", "c" };

// It's possible because everything is consider an object
ArrayList arryListMixTypes = new ArrayList{ "Martin", 23, true }; 
// OR
object[] objects = new object[] { "Martin", 23, true  };

int sum = 0;
foreach (var item in arryListInts)
{
    //sum += item; // variable 'item' is an object so we cant add-up the values'
    sum += (int)item; // not recommended as casting is risky and casts are performance-heavy operations
}

/* 
    ISSSUE with ARRAYLIST:
    * Performance is quite poor when it stores types like int, DateTimes or bool.
    * If we use ArrayLists all over the place, our code will become filled with never-ending cast expressions and try-catch blocks, crowding the true meaning of the code.
*/

/* GENERICS METHODS - ONE TYPE PARAMETER */
var genericMethods = new List<int> { 1, 2, 3 };

genericMethods.AddToFront<int>(55); // creating extension AddToFront method

//genericMethods.AddToFront<int>(55); // We could add <int> to the method, but we don't need to specify it because the C# compiler infers that the type T is an int from the type of parameters.
/*
    Explanation Code above: genericMethods.AddToFront(55); 
    * We're not really calling a method on the genericMethods object directly. 
    * What the compiler actually does is rewrite this call into something:
    
        GenericMethodListExtension.AddToFront(genericMethods, 55);
    
    * The extension method is just a static method that the compiler makes it look like it's part of the type (List<T> in this case).
    
    No Instantiation?
    * The method is declared static, it belongs to the class itself, not an instance.
    * Static classes cannot be instantiated — that’s by design.
    * Extension methods must live in static classes because they’re really just syntax sugar for calling static methods in a neat, readable way.
    
    Requirements for Extension Methods:
    * The method must be in a static class.
    * The method itself must be static.
    * The first parameter must have the this keyword, e.g., this List<T> list.
    
    Extension methods let you:
    * Add functionality to classes you don’t control (like built-in types).
    * Keep code clean and readable.
    * Make generic utilities reusable.
*/

/* GENERIC METHODS - MULTIPLE TYPE PARAMETERS */
var genericMethods2 = new List<decimal> { 1.1m, 0.5m, 22.5m, 12m };

// convert each decimal to int
var multiInts = genericMethods2.ConvertTo<decimal, int>(); // extension method with multi type params and we either explicitly specify all the type parameters or none of them. The compiler cannot infer the target type. 

Console.ReadLine();

// SLIMPLIFIED LIST
class SimpliedListOfIns
{
    private int[] _items = new int[4]; // initial size of the array
    private int _size = 0; // current size of the array

    public void Add(int item)
    {
        // if array is full we need increase the size of the array, copy existing elements to new array 
        if (_size >= _items.Length)
        {
            var newItems = new int[_items.Length * 2];

            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems; // replace old array with new one
        }

        _items[_size] = item;
        ++_size; // increment the size of the array for the next added element
    }

    public void RemoveAt(int index)
    {

        if (index < 0 || index >= _items.Length)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside of the list.");
        }

        --_size; // reduce the size by 1

        for (int i = index; i < _size; i++) // works as long as the new size of the list
        {
            _items[i] = _items[i + 1];
        }

        /*
            After the above loop finish we have two copies of the last number aka. 50 in this example in the array. ==> 10 20 40 50 50

            This is not a big deal since the list size is 4.

            So this element is not within the bounds of the list.

            It occupies the empty spot in the array.

            And if we add a new item to the list now, it would simply overwrite last number 50.

            But just to keep the array tidy, we can set this element to zero after the loop is finished.         
         */

        _items[_size] = 0; // reset the last index to 0
    }

    public int GetAtIndex(int index)
    {
        if (index < 0 || index >= _items.Length)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside of the list.");
        }

        return _items[index];
    }

    public void ShowArray()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            Console.Write(_items[i] + " ");
        }
    }
}

// GENERIC TYPES
//class GenericType<TValu, TOtherValue> // we can have as many parameters (any names, but by convention we use T) as we want
class GenericType<T>
{
    private T[] _items = new T[4]; // generic type
    private int _size = 0; // current size of the array

    public void Add(T item)
    {
        // if array is full we need increase the size of the array, copy existing elements to new array 
        if (_size >= _items.Length)
        {
            var newItems = new T[_items.Length * 2];

            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems; // replace old array with new one
        }

        _items[_size] = item;
        ++_size; // increment the size of the array for the next added element
    }

    public void RemoveAt(int index)
    {

        if (index < 0 || index >= _items.Length)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside of the list.");
        }

        --_size; // reduce the size by 1

        for (int i = index; i < _size; i++) // works as long as the new size of the list
        {
            _items[i] = _items[i + 1];
        }

        _items[_size] = default(T); // or just write default: which will reset the last index to default value, where default value is depend of the used type

        // DEFAULT TYPE
        /*
            Default keyword in the following contexts:
            * To specify the default case in the switch statement: 
                ...
                default: 
                    code; 
                    break;

            * As the default operator or literal to produce the default value of a type: 
                var name = default(string);
                
                or 

                int number = default;

            * As the default type constraint on a generic method override or explicit interface implementation.
                var val = default(T);
         */
    }

    public T GetAtIndex(int index)
    {
        if (index < 0 || index >= _items.Length)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside of the list.");
        }

        return _items[index];
    }

    public void ShowArray()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            Console.Write(_items[i] + " ");
        }
    }
}

// TUPLES - which represents a set of values
public class SimpleTuple<T1, T2> // as generic witch two types
{
    public T1 Value1 { get; }
    public T2 Value2 { get; }

    public SimpleTuple(T1 value1, T2 value2)
    {
        Value1 = value1;
        Value2 = value2;
    }
}

// GENERIC METHODS - ONE TYPE PARAMETER
static class GenericMethodListExtension
{

    // Extension method can only be defined in static classes
    public static void AddToFront<T>(this List<T> list, T item) // uses the 'this' keyword before its first parameter: this List<T> list, which tells the compiler it's an extension method for List<T>
    {
        list.Insert(0, item);
    }
}

// GENERIC METHODS - MULTIPLE TYPE PARAMETERS
static class GenericExtension
{
    public static List<TTarget> ConvertTo<TSource, TTarget>(this List<TSource> input)
    {
        var result = new List<TTarget>();

        foreach (var item in input)
        {
            /*
                TYPE class:
                * Is a class representing types. It contains properties like the type's name, namespace it belongs to, the base type or even the list of the type's constructors. 
                * We can get the type object for any type by using the "typeof" keyword.

                    Type dateTimeType = typeof(DateTime);    

                * If we wanted to get the type object for some instance, not a specific class, we could do it like this.
                
                    var decimals = new List<decimal> { 1.1m, 0.5m, 22.5m, 12m };
                    Type listOfDecimalsType = decimals.GetType();
             
            */

            // this will throw exception if it's not possible to convert to other type
            TTarget itemAfterCasting = 
                (TTarget)Convert.ChangeType(item, typeof(TTarget));
            result.Add(itemAfterCasting);
        }
        return result;
    }
}

