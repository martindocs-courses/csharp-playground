/* Navigation Notes
    
    Generic type                                                    : line 
    List - data structure                                           : line 

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

/* LIST - DATA STRUCTURE */
/*
   DATA STRUCTURES - are types meant for storing and organizing data so that it can be accessed and modified efficiently.

    Different types of data structures are suited to different kinds of applications, and some are highly specialized for specific tasks.

    Some common examples of data structures include arrays, stacks, queues, or dictionaries.   
*/

using System.Linq.Expressions;
Console.WriteLine("Data structure - LIST");
var newArry = new List<int>(3);

Console.WriteLine("Empty list: new List<int>(3)");
Console.WriteLine($"Number of elements - {newArry.Count}"); // 0
Console.WriteLine($"Total size of list - {newArry.Capacity}\n"); // 3

newArry.Add(1);
newArry.Add(5);

Console.WriteLine("Adding two numbers");
Console.WriteLine($"Number of elements - {newArry.Count}"); // 2
Console.WriteLine($"Total size of list - {newArry.Capacity}\n"); // 3

newArry.Add(3);
newArry.Add(6);

Console.WriteLine("Adding another two numbers, list expanding");
Console.WriteLine($"Number of elements - {newArry.Count}"); // 4
Console.WriteLine($"Total size of list (double) - {newArry.Capacity}\n"); // 6

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

var newList = new ListOfIns();
newList.Add(10);
newList.Add(20);
newList.Add(30);
newList.Add(40);
newList.Add(50);

Console.WriteLine(newList);

Console.ReadLine();

class ListOfIns
{
    private int[] _items = new int[4]; // initial size of the array
    private int _size = 0; // curent size of the array

    public void Add(int item)
    {
        // if array is full we need increase the size of the array, copy existing elements to new array 
        if(_size >= _items.Length)
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
}

