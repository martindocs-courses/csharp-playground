/* Navigation Notes
    
    Enum                                                            : line 20
    Up-casting & Down-casting                                       : line 27
    IS operator                                                     : line 38
    NULL value                                                      : line 53
    AS operator                                                     : line 80        

    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

using System.Data;
using UpcastingDowncasting;
using casingConversion = UpcastingDowncasting;
using nullValue = NullValue;
using asOperator = AsOperator;
/* 
    ENUM:
    * An enum is a special "class" that represents a group of constants (unchangeable/read-only variables).
    * Cannot contain any fields, properties or methods in the enum's body.
    * Under the hood, each value of an enum is represented as an integer. By default, the first value is zero, the second is one, and so on.
 
 */

/* UPCASTING & DOWNCASTING */
Console.WriteLine("Up-casting & Down-casting");

// this is UP-casting (convert derived class to base class) as conversion is safe and lossless, so is implicit
casingConversion.Ingredient ingredient = new Cheddar(); 
Console.WriteLine(ingredient.Name);

// DOWN-casting it happens when we assign base class to derived class and need to be set explicit
casingConversion.Cheddar cheddar = (Cheddar)ingredient;
Console.WriteLine(cheddar.Name);

/* IS OPERATOR */
Console.WriteLine("\nIS operator");
Random random = new Random();
var randomObjects = new List<object> { "hi", 23, true, 56, "Martin" };
int type = random.Next(randomObjects.Count);
var pickObject = randomObjects[type];
Console.WriteLine($"{pickObject} is {(randomObjects[type] is string ? "string object": "not a string object")}");

// EXAMPLE - Assign a value if is given type
if(pickObject is String name){
    Console.WriteLine($"The object assign is {name}");
}else{
    Console.WriteLine($"The object assign is not a string");
}

/* NULL value */
Console.WriteLine("\nNULL value");
nullValue.Pizza pizza = new nullValue.Pizza();

nullValue.Ingredient ingredientNull = null; // need to be explicit typed
//var ingredientNull = null; // wont work in this example as implicit typed, as compiler wont know the value

/*
    The null value is common for all classes. For all of them it means the same: that a variable does not store any instance.       
 */

Console.WriteLine(ingredientNull);

// Null exception is one of the most common in C# and we should prevent it / check before using any member of the object
Console.WriteLine("Please type any number: ");
string userInput = Console.ReadLine();
//if(userInput != null){
if(userInput is not null) // better solution
{
    Console.WriteLine($"The value is {userInput}");
}

/*The second solution is more certain because operators can be overloaded, which means a type may redefine what a given operator does.*/

// We cannot assign Null to int
//int age = null;

/* AS operator */
//asOperator.Ingredient asIngredient = 
asOperator.Cheddar asCheddar = new asOperator.Cheddar(); // cast expression

// Alternatively, instead of converting the type with the cast expression, we can do it with the "as" operator.
asOperator.Ingredient asIngredient2 = new asOperator.Cheddar(); // cast expression
/*
    The difference between using cast expression and the "as" operator is that in the case of the unsuccessful cast, an exception will be thrown for the cast expression, but it works with any type.
    For the "as" operator, the result will simply be null. Because the result may be null it means we can only use this operator to cast to those types that can be assigned null. For example not use "as" on int type as int can't be assign null value.
 */
// if we want to do any operations on this object, like printing its name, we should first check if it is not null, because if it is, we will get a NullReferenceException.


Console.ReadKey();

namespace Enum
{
    public enum WeekDays{
        //Monday, // default is 0 
        Monday = 1, 
        Tuesday, 
        Wednesday, 
        Friday, 
        Saturday,
        Sunday
    }


    class Program {

        static void Main(string[] args)
        {
            // Declaring a variable 'monday' of type WeekDays and setting it equal to WeekDays.Monday
            WeekDays monday = WeekDays.Monday;

            Console.WriteLine(monday); // Monday

            // To see int of the enum we need cast to integer
            Console.WriteLine((int)monday);

            Console.ReadKey();

        }
       
    }
}

namespace UpcastingDowncasting{
    public class Pizza
    {       
        private List<Ingredient> _ingridients = new List<Ingredient>();

        public void AddIngredients(Ingredient ingredient) => _ingridients.Add(ingredient);
                
        public string Describe() => $"This pizza is with a {string.Join(',', _ingridients)}";
    }

    // base class
    public class Ingredient
    {
        public string Name => "Some ingredient";

    }

    // derived class
    public class Cheddar : Ingredient
    {
        public string Name => "Cheddar cheese";
        public int AgedForMonths { get; }
    }

    // derived class
    public class TomatoSauce : Ingredient
    {
        public string Name => "Tomato sauce";
        public int TomatoIn100Grams { get; }
    }

    // derived class
    public class Mozzarella : Ingredient
    {
        public string Name => "Mozzarella";
        public bool IsLight { get; }
    }
}

namespace NullValue{
    public class Pizza
    {
        public Ingredient ingredient;
        private List<Ingredient> _ingridients = new List<Ingredient>();

        public void AddIngredients(Ingredient ingredient) => _ingridients.Add(ingredient);

        public string Describe() => $"This pizza is with a {string.Join(',', _ingridients)}";
    }

    // base class
    public class Ingredient
    {
        public string Name => "Some ingredient";

    }

    // derived class
    public class Cheddar : Ingredient
    {
        public string Name => "Cheddar cheese";
        public int AgedForMonths { get; }
    }

    // derived class
    public class TomatoSauce : Ingredient
    {
        public string Name => "Tomato sauce";
        public int TomatoIn100Grams { get; }
    }

    // derived class
    public class Mozzarella : Ingredient
    {
        public string Name => "Mozzarella";
        public bool IsLight { get; }
    }
}

namespace AsOperator {
    
    public class Pizza
    {
        private List<Ingredient> _ingridients = new List<Ingredient>();

        public void AddIngredients(Ingredient ingredient) => _ingridients.Add(ingredient);

        public string Describe() => $"This pizza is with a {string.Join(',', _ingridients)}";
    }

    // base class
    public class Ingredient
    {
        public string Name => "Some ingredient";

    }

    // derived class
    public class Cheddar : Ingredient
    {
        public string Name => "Cheddar cheese";
        public int AgedForMonths { get; }
    }

    // derived class
    public class TomatoSauce : Ingredient
    {
        public string Name => "Tomato sauce";
        public int TomatoIn100Grams { get; }
    }

    // derived class
    public class Mozzarella : Ingredient
    {
        public string Name => "Mozzarella";
        public bool IsLight { get; }
    }
}


