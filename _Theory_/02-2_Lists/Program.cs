/* Navigation Notes
    
    Features of the List                : line 17 
    Properties and methods              : line 25 
    Examples                            : line 38
    - create list                       : line 40
    - replace elements                  : line 53
    - looping through                   : line 58
    - Add or Remove                     : line 82 & 73
    - IndexOf and Clear                 : line 96 & 100
    
    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

/*
    Few features of the List:
    * List is a generic type
    * For dynamic collension can be resized dynamically where arrays cannot. 
    * List class can accept null as a valid value for reference types and it also allows duplicate elements.
    * If the Count property becomes equals to Capacity property, then the capacity of the List increased automatically by reallocating the internal array. The existing elements will be copied to the new array before the addition of the new element.
 */

/*
    Properties of the List:   
    * Capacity - gets or sets the total number of elements the internal data structure can hold without resizing.
    * Count - gets the number of elements contained in the List
    
    Some methods of the List:
    * Add - adds an object to the end of the List 
    * AddRange - Adds the elements of the specified collection to the end of the List.
    * Clear - Removes all elements from the List
    * Remove - Removes the first occurrence of a specific object from the List. If the removed element do not exist the Remove method will do nothing.
    * Contains - Determines whether an element is in the List
    * IndexOf - Returns the zero-based index of the first occurrence of a value in the List or in a portion of it.
 */

// EXAMPLES

// CREATE empty List of strings
List<string> words = new List<string>();

// CREATE List with implicit data type
var numbers = new List<int>()
{
    1, 2, 3, 2, 5
};

Console.WriteLine($"Count is - {words.Count}"); // is 0 / empty list

words.Add("First");

// Replace element at index 0
words[0] = "Next";

Console.WriteLine($"Count after adding element - {words.Count}"); // is 1 

// LOPPING THROUGH LIST
Console.WriteLine("\nLooping through the list");

for (var i = 0; i < numbers.Count; i++)
{
    Console.WriteLine($"Number - {numbers[i]}");
}

// OR 

foreach (var word in words)
{
    //Console.WriteLine(word);
}

// REMOVE ELEMENT from List
Console.WriteLine("\nRemove element (2) from the list");
numbers.Remove(2);

for (var i = 0; i < numbers.Count; i++)
{
    Console.WriteLine($"Number - {numbers[i]}");
}

// ADD COLLECTION of elements to List
Console.WriteLine("\nAdd colections of elements to existing list");
var newNumbers = new int[]
{
    25, 35, 45
};

numbers.AddRange(newNumbers);

for (var i = 0; i < numbers.Count; i++)
{
    Console.WriteLine($"Number - {numbers[i]}");
}

// INDEX OF elements in List
Console.WriteLine("\nIndex of element in the list");
Console.WriteLine(numbers.IndexOf(35));

// CLEAR ALL ELEMENTS in List
Console.WriteLine("\nClear all elements in list");
numbers.Clear();

Console.WriteLine($"Number of elements in the list is {numbers.Count}");

Console.ReadLine();