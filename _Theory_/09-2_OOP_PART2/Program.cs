/* Navigation Notes
    
    OOP PART 2                                                                  : line 18           
    Polymorphism                                                                : line 20
    - one object for different types                                            : line 104 & 140
    Inheritance                                                                 : line 65 & 183
    - Access to methods                                                         : line 112
    - Access to fields                                                          : line 120

    Abstraction                                                                 : line 251
    Interface                                                                   : line 268
        

    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/
/*
    * Object-oriented programming heavily relies on four fundamental concepts: 
    
    POLYMORPHISM - means "many forms", and it occurs when we have many classes that are related to each other by inheritance. Polymorphism uses those methods to perform different tasks. This allows us to perform a single action in different ways.
        
        The base class method overrides the derived class method, when they share the same name. But we can override the base class method, by adding the virtual keyword to the method inside the base class, and by using the override keyword for each derived class methods
    
        There are many way to achieve Polymorphism, one of is using Inheritance.

        class Animal  // Base class (parent) 
        {
          public virtual void animalSound() 
          {
            Console.WriteLine("The animal makes a sound");
          }
        }

        class Pig : Animal  // Derived class (child) 
        {
          public override void animalSound() 
          {
            Console.WriteLine("The pig says: wee wee");
          }
        }

        class Dog : Animal  // Derived class (child) 
        {
          public override void animalSound() 
          {
            Console.WriteLine("The dog says: bow wow");
          }
        }

        class Program 
        {
          static void Main(string[] args) 
          {
            Animal myAnimal = new Animal();  // Create a Animal object
            Animal myPig = new Pig();  // Create a Pig object
            Animal myDog = new Dog();  // Create a Dog object

            myAnimal.animalSound(); => The animal makes a sound
            myPig.animalSound(); => The pig says: wee wee
            myDog.animalSound(); => The dog says: bow wow
          }
        }


    INHERITANCE (: symbol) - inherit fields and methods from one class to another. Inheritance enables us to create new classes that reuse, extend and modify the behavior defined in other classes. The class whose members are inherited is called the base class, and the class that inherits those members is called the derived class.
        
        Derived Class (child) - the class that inherits from another class
        Base Class (parent) - the class being inherited from
            
        class Vehicle  // base class (parent) 
        {
          public string brand = "Ford";  // Vehicle field
          public void honk()             // Vehicle method 
          {                    
            Console.WriteLine("Tuut, tuut!");
          }
        }

        class Car : Vehicle  // derived class (child)
        {
          public string modelName = "Mustang";  // Car field
        }

        class Program
        {
          static void Main(string[] args)
          {
            // Create a myCar object
            Car myCar = new Car();

            // Call the honk() method (From the Vehicle class) on the myCar object
            myCar.honk();

            // Display the value of the brand field (from the Vehicle class) and the value of the modelName from the Car class
            Console.WriteLine(myCar.brand + " " + myCar.modelName);
          }
        }

        Note: If you don't want other classes to inherit from a class, use the 'sealed' keyword
 */
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Xml.Linq; 

using inherit = Inheritance;
using inheritMemberProp = InheritanceMembersProps;
using overridingMembers = OverridingBaseMembers;
using InheritanceHierarchy;

/* INHERITANCE */
// ONE OBJECT (interface) to entities of different types 
Console.WriteLine("Polymorphism: One object (interface) to entities of different types:");
var pizza = new inherit.Pizza();
pizza.AddIngredients(new inherit.Cheddar());
pizza.AddIngredients(new inherit.Mozzarella());
var showUs = pizza.Describe(); 
Console.WriteLine(showUs); // Cheddar

// ACCESS TO METHODS - Derived class have access to base class public and protected methods, but not private ones.
Console.WriteLine("\nAccess to Methods");
var cheddar = new inheritMemberProp.Cheddar();
Console.WriteLine(cheddar.PublicMethod()); // Even if this method is not defined directly in the general class, we can still call it on a cheddar object because it is inherited from the base Ingredient class.
cheddar.UseMethodFromBaseClass(); // or we could also use it directly within the cheddar class.

// PRIVATE & PROTECTED METHODS - not inherited
//cheddar.PrivateMethod(); // not accessible
//cheddar.ProtectedMethod(); // not accessible outside only within derived class

// ACCESS to FIELDS - Inherited fields have independent values from base class
Console.WriteLine("\nAccess to Fields");
var ingridient = new inheritMemberProp.Ingredient();
ingridient.PublicField = 10;
cheddar.PublicField = 2;

Console.WriteLine("Value of ingredient: " + ingridient.PublicField);
Console.WriteLine("Value of cheddar: " + cheddar.PublicField);

Console.WriteLine("\nAccess to public fields form derived class");
var newCheddar1 = new inheritMemberProp.Cheddar(); // implicit type of Cheddar
inheritMemberProp.Cheddar newCheddar2 = new inheritMemberProp.Cheddar(); // explicit type of Cheddar
Console.WriteLine(newCheddar1.Name);

/* OVERRIDING BASE CLASS MEMBERS */
Console.WriteLine("\nOverriding base class members");

// Since Cheddar is an Ingredient , we should be able to assign an object of type Cheddar to a variable of type Ingredient
// ingredient is of type of Ingredient, but he can store object of type Cheddar, this works because Cheddar is an ingredient.
var nonVirtual1 = new overridingMembers.Cheddar();
Console.WriteLine($"Cheddar type non virtual: {nonVirtual1.Name}"); // => Cheddar cheddar

// if we want to be able to use the Name property on any Ingredient object, we must have this property in the Ingredient class.
overridingMembers.Ingredient nonVirtual2 = new overridingMembers.Cheddar(); 
Console.WriteLine($"Ingredient type non virtual: {nonVirtual2.Name}"); // => "Some ingredient"

/*
    Ingredient ingredient = new Cheddar();
    Console.WriteLine(ingredient.Name);

    We're getting diffrent result above because when we have a variable of a specific type, and we call some method or property on it, the internal engine of C# does this:

    * Checks if the method/prop is virtual
    * 
        ingredient.Name => in our example is not virtual

    * If not, it simply calls the method it finds in the type of the variable in our example is Ingredient type
    * 
        ingredient.Name => "Some ingredient"

    * If the method is virtual, it checks the actual type of the object stored in the variable. In this case the type of object stored in the variable is Cheddar type derived from Ingredient type.
      The C# engine will call SomeMethod/prop defined in this Cheddar type if it overrides the base type method. If not, the implementation from the base class (Ingredient) will be used.

        ingredient.Name => Cheddar cheddar    

    VIRTUAL - means that this method or property may be modified in the inheriting types.
 */
Console.WriteLine();

var virtual1 = new overridingMembers.Cheddar();
Console.WriteLine($"Cheddar type virtual: {virtual1.Name2}"); // => Cheddar cheddar

// if we want to be able to use the Name property on any Ingredient object, we must have this property in the Ingredient class.
overridingMembers.Ingredient virtual2 = new overridingMembers.Cheddar();
Console.WriteLine($"Ingredient type virtual: {virtual2.Name2}"); // => Cheddar cheddar

// Base class that store diffrent types, where we want diffrent behavior for each types it stores
var ingredients = new List<overridingMembers.Ingredient>{ // A List must store objects of uniform type.
    new overridingMembers.Cheddar(),
    new overridingMembers.Mozzarella(),
    new overridingMembers.TomatoSauce(),
    // Each of them has the Name2 property. The Name2 property is declared as public in the Ingredient class. So every type we have that is an Ingredient also exposes this property as part of its interface.
};

Console.WriteLine();
// We want the C# engine to check the actual type of the object assigned to the loop variable in each iteration and call the method from the specific type.
foreach (overridingMembers.Ingredient ingredient in ingredients) // loop of Ingredient type
{
    Console.WriteLine(ingredient.Name2);
}

/* INHERITANCE HIERARCHY */
Console.WriteLine("\nInheritance hierarchy");
var inheritHierarchy = new Pizza();

/*
We can still pass Mozzarella and Cheddar to the AddIngredient method, taking an Ingredient as a parameter. This is because both Mozzarella and Cheddar still inherit from the Ingredient class. So they are ingredients.

The only difference is that the inheritance is no longer direct. 
    Now goes through:   Cheddar => Cheese => Ingredient
    Before:             Cheddar => Ingredient

*/
inheritHierarchy.AddIngredients(new Cheddar()); 
inheritHierarchy.AddIngredients(new Mozzarella()); 

//inheritHierarchy.AddIngredients(new TomatoSauce());

Console.WriteLine(inheritHierarchy.Describe());

Console.ReadKey();

namespace Inheritance
{
    public class Pizza
    {
        // Each instance of this class will hold a list of ingredients it is composed of
        private List<Ingredient> _ingridients = new List<Ingredient>();

        // A method that adds a new ingredient to a pizza.
        public void AddIngredients(Ingredient ingredient) =>
            _ingridients.Add(ingredient);
        
        // Describe method listing all the ingredients.
        public string Describe() => $"This pizza is with a {string.Join(',', _ingridients)}";
    }

    // base class
    public class Ingredient
    {
        
    }

    // derived class
    public class Cheddar : Ingredient
    {        
        // read only (getter) prop Name using Expression-Bodied Property
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

namespace InheritanceMembersProps
{
    public class Pizza
    {
        // Each instance of this class will hold a list of ingredients it is composed of
        private List<Ingredient> _ingredients = new List<Ingredient>();

        // A method that adds a new ingredient to a pizza.
        public void AddIngredients(Ingredient ingredient) => _ingredients.Add(ingredient);

        // Describe method listing all the ingredients.
        public string Describe() => $"This pizza is with a {string.Join(',', _ingredients)}";
    }

    // base class
    public class Ingredient
    {     
        public int PublicField; // derived class have access to base public fields

        // Sould include data and methods common for any ingredient 
        // Usually contains basic implementation

        // accessible for any derived class
        public string PublicMethod() => "This method is PUBLIC in the Ingredient class.";

        // Unlike public methods, private ones are not inherited.
        private string PrivateMethod() => "This method is PRIVATE in the Ingredient class.";

        // Protected members can be used in the derived classes, but they can't be used outside.
        protected string ProtectedMethod() => "This method is PROTECTED in the Ingredient class.";
    }

    // derived class
    public class Cheddar : Ingredient
    {
        // The base type contains the data and methods common to the related types.         Still, each derived type can have its own members, which the base type and other derived types do not contain.

        // Then Derived class may contain more specific implementation instead of using the one from the base class.

        // Fields that are public or protected also get inherited by derived classes.
        /*
            It is not like the value of this field is shared. If we have an object of the Ingredient type, and it will have its own field. At the same time objects of classes derived from this base class will also have such fields, but the values will be independent.     
         */
        public string Name => "Cheddar cheese";
        public int AgedForMonths { get; }

        // We can also use Ingredient method directly within the cheddar class.
        public void UseMethodFromBaseClass()
        {
            Console.WriteLine(PublicMethod());
            //Console.WriteLine(PrivateMethod()); // wont work, the merhods are not inherited
            Console.WriteLine(ProtectedMethod()); // will work, but only withwin Derived class, not outside

        }
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

namespace OverridingBaseMembers{
    public class Pizza
    {        
        private List<Ingredient> _ingredients = new List<Ingredient>();
        
        public void AddIngredients(Ingredient ingredient) => _ingredients.Add(ingredient);
               
        public string Describe() => $"This pizza is with a {string.Join(',', _ingredients)}";
    }

    // base class
    public class Ingredient
    {

        public string Name { get; } = "Some ingredient";
        public virtual string Name2 { get; } = "Some ingredient";
        public string PublicMethod() => "This method is PUBLIC in the Ingredient class.";
    }

    // derived class
    public class Cheddar : Ingredient
    {
        
        public string Name => "Cheddar cheese";

        // his prop hides the base type property when not override word is used
        public override string Name2 => "Cheddar cheese"; 
        public int AgedForMonths { get; }

       
        public void UseMethodFromBaseClass()
        {
            Console.WriteLine(PublicMethod());         
          
        }
    }

    // derived class
    public class TomatoSauce : Ingredient
    {
        public string Name => "Tomato sauce";
        public string Name2 => "Tomato sauce";
        public int TomatoIn100Grams { get; }
    }

    // derived class
    public class Mozzarella : Ingredient
    {
        public string Name => "Mozzarella";
        public override string Name2 => "Mozzarella";
        public bool IsLight { get; }
    }
}

namespace InheritanceHierarchy{
    public class Pizza
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();

        public void AddIngredients(Cheese ingredient) => _ingredients.Add(ingredient);

        public string Describe() => $"This pizza is with a {string.Join(',', _ingredients)}";
    }

    // base class
    public class Ingredient
    {
                
        public virtual string Name { get; } = "Some ingredient";
        public string PublicMethod() => "This method is PUBLIC in the Ingredient class.";
    }

    // Sometimes we want the inheritance hierarchy to contain more than two types.
    // Both cheddar and mozzarella are types of cheese. Instead of making them inherit from the Ingredient class, we can derive them from the Cheese class.
    public class Cheese: Ingredient
    {

    }

    // derived class
    public class Cheddar : Cheese
    {
                     
        public override string Name => "Cheddar cheese";
        public int AgedForMonths { get; }


        public void UseMethodFromBaseClass()
        {
            Console.WriteLine(PublicMethod());

        }
    }
      

    // derived class
    public class Mozzarella : Cheese
    {
        public override string Name => "Mozzarella";
        public bool IsLight { get; }
    }

    // derived class
    public class TomatoSauce : Ingredient
    {
        public override string Name => "Tomato sauce";
        public int TomatoIn100Grams { get; }
    }

   
}
/* 
    - ABSTRACTION - classes only exposes essential data and methods and hide the underlying details,

        The abstract keyword is used for classes and methods: 
         Abstract class: is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
         Abstract method: can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from).
    
        abstract class Animal 
        {
          public abstract void animalSound();
          public void sleep() 
          {
            Console.WriteLine("Zzz");
          }
        }

        From the example above, it is not possible to create an object of the Animal class. To access the abstract class, it must be inherited from another class.

    - INTERFACE - is a completely "abstract class", which can only contain abstract methods and properties (with empty bodies). 

        It is considered good practice to start with the letter "I" at the beginning of an interface, as it makes it easier for yourself and others to remember that it is an interface and not a class.

        By default, members of an interface are abstract and public.

        // interface
        interface IAnimal 
        {
          void animalSound(); // interface method (does not have a body)
          void run(); // interface method (does not have a body)
        }

        Note: 
        * Interfaces can contain properties and methods, but not fields.            
        * Like abstract classes, interfaces cannot be used to create objects (in the example above, it is not possible to create an "IAnimal" object in the Program class)
        * Interface methods do not have a body - the body is provided by the "implement" class
        * On implementation of an interface, you must override all of its methods
        * Interfaces can contain properties and methods, but not fields/variables
        * Interface members are by default abstract and public
        * An interface cannot contain a constructor (as it cannot be used to create objects) 
 
 
 
 */

