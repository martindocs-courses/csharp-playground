using introduction1 = Linq_introduction1;
using introduction2 = Linq_introduction2;
using introduction3 = Linq_introduction3;
using introduction4 = Linq_introduction4;
using practiceAny = Linq_practice_Any;
using practiceAll = Linq_practice_All;
using practiceCount = Linq_practice_Count;
using practiceContains = Linq_practice_Contains;
using practiceOrderBy = Linq_practice_OrderBy;
using practiceFirstLast = Linq_practice_FirstLast;
using practiceWhere = Linq_practice_Where;
using practiceDistinct = Linq_practice_Distinct;
using practiceSelect = Linq_practice_Select;
using practiceAnonymousTypes = Linq_practice_AnonymousTypes;

// INTRODUCTION EXAMPLE 1
var wordsLowerCase = new string[] { "quick", "brown", "fox" };
var wordsUpperCase = new string[] { "quick", "brown", "FOX" };

Console.WriteLine(
    $"non linq to find any upper cases: {string.Join(",", wordsLowerCase)}: " + introduction1.Introduction1.IsAnyWordUppercase_NonLinq(wordsLowerCase));
Console.WriteLine(
    $"with linq to find any upper cases: {string.Join(",", wordsLowerCase)}: " + introduction1.Introduction1.IsAnyWordUppercase_Linq(wordsLowerCase));
Console.WriteLine();

// INTRODUCTION EXAMPLE 2
introduction2.Introduction2.ModifyNumbers();
Console.WriteLine();

// INTRODUCTION EXAMPLE 3
introduction3.Introduction3.OddNumbers();
Console.WriteLine();

// INTRODUCTION EXAMPLE 4
introduction4.Introduction4.ShortWords();
Console.WriteLine();

// ANY method
Console.WriteLine("ANY method");
// any number is 10
Console.Write("There is a number in the collection that is ten (10): ");
var word = new practiceAny.CheckAnyNumber().CheckIfTen();
bool isTen = word.Any(word => word == 10);
Console.WriteLine(isTen + "\n");

var anyPets = practiceAny.Pet.Pets();

// When working with static methods you can reference it without invoking it — but only if you're intentionally working with a delegate (i.e., treating the method as a "function pointer").
/*
    var func = Pet.Pets; // valid as func is now of type Func<bool>. You can call it later: func()
 
    var result = Pet.Pets(); // This also valid if we need calls the method and gets the return value
 */

foreach (var pet in anyPets)
{
    Console.WriteLine($"{pet.Key} : {pet.Value}");
}
Console.WriteLine();

// ALL method
Console.WriteLine("ALL method");
Console.Write("Check if numbers in collection are larger than zero: ");
var numbers = new practiceAll.CheckAllNumbers().Numbers();
var checkNumbers = numbers.All(number => number > 0);
Console.WriteLine(checkNumbers);
Console.WriteLine();

var allPets = practiceAll.Pet.Pets();
foreach (var pet in allPets)
{
    Console.WriteLine($"{pet.Key} : {pet.Value}");
}
Console.WriteLine();

// COUNT & LONGCOUNT
Console.WriteLine("Count & LongCount methods");
var allDogs = practiceCount.Pet.Pets();
foreach (var pet in allDogs){
    Console.WriteLine($"{pet.Key} : {pet.Value}");
}
Console.WriteLine();

// CONTAINS
Console.WriteLine("Contains method");
var containsLists = new practiceContains.ContainsLists();
var contsinsNumber7 = containsLists.Numbers();

Console.WriteLine("Is 7 is in the collection: " + contsinsNumber7.Contains(7));

var containsTiger = containsLists.Words();
Console.WriteLine("Is there tiger in the collection: " + containsTiger.Contains("tiger"));
Console.WriteLine();

// ORDER BY
Console.WriteLine("Order by method");
//var orderPetsNames = practiceOrderBy.Pet.Pets();
//foreach (var pet in orderPetsNames)
//{
//    Console.WriteLine(pet.PetName);
//}

//var orderPetsIDs = practiceOrderBy.Pet.Pets();
//foreach (var pet in orderPetsIDs)
//{
//    Console.WriteLine(pet.PetID);
//}

var orderPetsIDsAndNames = practiceOrderBy.Pet.Pets();
foreach (var pet in orderPetsIDsAndNames)
{
    Console.WriteLine(pet.PetName);
}
Console.WriteLine();

// Ordering key for simpler types like int or strings, we can simply use the element of the collection itself.
var orderByCollectionParam = new practiceOrderBy.OrderCollection();
var orderedNumbers = orderByCollectionParam.Numbers().OrderBy(number => number);

foreach (var number in orderedNumbers)
{
    Console.WriteLine(number);
}
Console.WriteLine();

var orderedWords = orderByCollectionParam.Words().OrderByDescending(word => word);
foreach (var words in orderedWords)
{
    Console.WriteLine(words);
}
Console.WriteLine();

// Ordering by multiple criteria
var orderbyMultipleCriteria = orderByCollectionParam.Numbers().OrderByDescending(word => word).ThenBy(word => word);

foreach (var pet in orderbyMultipleCriteria)
{
    Console.WriteLine(pet);
}
Console.WriteLine();

// FIRST & LAST 
Console.WriteLine("First & Last Number");
var firstLastNumber = new practiceFirstLast.ContainsNumbers();
var firstNumber = firstLastNumber.Numbers().First(); // use parameter less version to fid first number in a collection
Console.WriteLine(firstNumber);

var findOddNumbers = firstLastNumber.Numbers().First(number => number % 2 == 1); // using predicate param to find odd numbers
Console.WriteLine(findOddNumbers);

// find last dog in the collection of pets
//var lastDog = practiceFirstLast.Pet.Pets();
//Console.WriteLine(lastDog.PetName);

// if not match or collection empty it will throw error
//var petWeight = practiceFirstLast.Pet.Pets();

//if(petWeight != null){
//    Console.WriteLine(petWeight.PetWeight);
//}else{
//    Console.WriteLine("No pets heavier that 100");
//}

// no throwing exception, but we still need to check if returned value is null or empty
//var dogWeight = practiceFirstLast.Pet.Pets();
//if(dogWeight != null){
//    Console.WriteLine(dogWeight.PetWeight);
//}else{
//    Console.WriteLine("No pets heavier that 100");
//}

// Combine OrderBy and Last method
var combineOrderAndLast = practiceFirstLast.Pet.Pets();

if(combineOrderAndLast != null){
    Console.WriteLine(combineOrderAndLast.PetName);
}
Console.WriteLine();

// WHERE
Console.WriteLine("Where method");
var whereNumbers = new practiceWhere.ContainsNumbers();
// Below is a new collection and original collection wasn't affected
var oddNumbers = whereNumbers.Numbers().Where(number => number % 2 == 1);
foreach (var number in oddNumbers)
{
    Console.WriteLine(number);
}

var heavyPet = practiceWhere.Pet.Pets();

foreach (var pet in heavyPet)
{
    Console.WriteLine(pet.PetName);
}
Console.WriteLine();

// DISTINCT
Console.WriteLine("Distinct method");
var uniqueNumbers = new practiceDistinct.ContainsNumbers();
var uniqueNum = uniqueNumbers.Numbers().Distinct();

foreach (var number in uniqueNum)
{
    Console.WriteLine(number);
}
Console.WriteLine();

// SELECT
Console.WriteLine("Select method");
var newCollection1 = new practiceSelect.ContainsNumbers();

// Multiply collection by 2
var multiplyByTwo = newCollection1.Numbers().Select(number => number * 2);
Console.WriteLine(string.Join(", ", multiplyByTwo));

// Transform to upper case
var newCollection2 = new practiceSelect.ContainsWords();
var workToUpperCase = newCollection2.Words().Select(word => word.ToUpper());
Console.WriteLine(string.Join(", ", workToUpperCase));

// Transform numbers to strings
IEnumerable<string> numbersToString = newCollection1.Numbers().Select(number => number.ToString());
Console.WriteLine(string.Join(", ", numbersToString));
Console.WriteLine();

// Create numbered list
var numberedList = newCollection2.Words().Select((word, index) => index+1 + "." + word);
foreach (var item in numberedList)
{
    Console.WriteLine(item);
}
Console.WriteLine();

// Extract data from the object
var weightsOfPets = practiceSelect.Pet.Pets();
Console.WriteLine(string.Join(Environment.NewLine, weightsOfPets));
Console.WriteLine();

// ANONYMOUS TYPES
var anonymousTypes = new practiceAnonymousTypes.ListOfNumbers().Numbers();

// Print information about the count of its items and the average value. And messages to be ordered from the largest average to the smallest.

// 1) using anonymous types - types without names
var calcAverage = anonymousTypes.Select(listOfNumbers => new
{
    Count = listOfNumbers.Count(),
    Average = listOfNumbers.Average()
})
    .OrderByDescending(countAndAverage => countAndAverage.Average)
    .Select(countAndAverage => $"Count is: {countAndAverage.Count}" + " " + $"Average is: {countAndAverage.Average}");

// 2) using Tuples
//var calcAverage = anonymousTypes.Select(listOfNumbers => new Tuple<int, double> (
//    listOfNumbers.Count(),
//    listOfNumbers.Average()
//))
//    .OrderByDescending(countAndAverage => countAndAverage.Item2)
//    .Select(countAndAverage => $"Count is: {countAndAverage.Item1}" + " " + $"Average is: {countAndAverage.Item2}");

// 3) Using object
//var calcAverage = anonymousTypes.Select(listOfNumbers => new CountaAndAverage
//{
//    Count = listOfNumbers.Count(),
//    Average = listOfNumbers.Average()
//})
//    .OrderByDescending(countAndAverage => countAndAverage.Average)
//    .Select(countAndAverage => $"Count is: {countAndAverage.Count}" + " " + $"Average is: {countAndAverage.Average}");

Console.WriteLine(string.Join(Environment.NewLine, calcAverage));

Console.ReadKey();

// 3) If we use only once the object we could replace with Tuples
//public class CountaAndAverage{
//    public int Count { get; set; }
//    public double Average { get; set; }
//}
