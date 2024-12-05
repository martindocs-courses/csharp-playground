/* Navigation Notes  
    
    Array helper methods                : line 15
    - sort() & reverse()                : line 18
    - clear() & resize()                : line 34
    - ToCharArray()                     : line 104
    - join()                            : line 115
    - split()                           : line 119
       
    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/


/* ARRAY HELPER METHODS */
Console.WriteLine("\nArray methods");

// SORT() & REVERSE()
string[] pallets = ["B14", "A11", "B12", "A13"];

Console.WriteLine("Sorted..."); // sort in ASC order
Array.Sort(pallets);
//Console.WriteLine(string.Join(" ", pallets));
foreach (var pallet in pallets)
{
    Console.WriteLine(pallet);
}

Console.WriteLine();
Console.WriteLine("Reversed..."); // reverse the array order
Array.Reverse(pallets);
Console.WriteLine(string.Join(" ", pallets));

// CLEAR() & RESIZE()
Console.WriteLine("\nClear array");

/* 
  Clear() method

  Enables you to eliminate the contents of specific elements in your array, replacing them with the array's default value. if you clear an element in a string array, the cleared value is replaced with null. Similarly, when you clear an element in an int array, the replacement is 0 

  Clear values in array has no longer reference a string in memory and it point to nothing. Accesing cleared values will give null value. When displaying null values C# Compiler implicitly converts the null value to an empty string for presentation.
*/
Array.Clear(pallets, 0, 2); // start from 0 index and clear two elements
foreach (var pallet in pallets)
{
    Console.WriteLine($"values: {pallet}");

}

// You can't use toLower() string meyhod as this give error, bc pallets[0] value is null and not empty string
// so to avoid error we need add if statement
if (pallets[0] != null)
    Console.WriteLine("\nAccessing cleared value: " + pallets[0].ToLower());
else
    Console.WriteLine("You can't use ToLower() method on null value.");

// Resize(), allows you to add or remove elements from your array.
Console.WriteLine("\nResize array");

// Add elements 
Array.Resize(ref pallets, 3); // we passing reference value
Console.WriteLine(string.Join(" ", pallets));

pallets[0] = "C01";
pallets[1] = "C02";

Console.WriteLine(string.Join(" ", pallets));

// Remove elements.
// We can't just remove null values from array. We need use two steps aproach
Array.Resize(ref pallets, 7);

// cont non-null values
int count = 0;
foreach (var pallet in pallets)
{
    if (pallet != null)
        count++;
}

Console.WriteLine($"old pallets: {string.Join("-", pallets)}");

// create new array
string[] newPallets = new string[count];

int index = 0;
// and copy non-null values to newwly array
foreach (var pallet in pallets)
{
    if (pallet != null)
        newPallets[index] = pallet;
    index++;
}

Console.WriteLine($"new pallets: {string.Join("-", newPallets)}");

/*
    To perform data transformation, you need to accept incoming data as a string, parse it into smaller data elements, then manipulate it to match different format required.  
*/

string letters = "abcd123";

// We use ToCharArray() method used to create an array of char, where each element of the array represents one character of the original string.
char[] lettersArray = letters.ToCharArray();
Array.Reverse(lettersArray);

/*
    For non-primitive (reference) types like string, List<T>, or your own classes, casting is not possible unless the types are explicitly compatible (e.g., via inheritance or interfaces). Instead, you typically use constructors or helper methods to convert between types. 
 */
string resultArray = new string(lettersArray);

Console.WriteLine(resultArray);

// JOIN()
string resultArray2 = String.Join(",", lettersArray);
Console.WriteLine(resultArray2);

// SPLIT() -  designed for variables of type string and creates an array of strings
string[] items = resultArray2.Split(',');
foreach (string item in items)
{
    Console.WriteLine(item);
}
