/* Navigation Notes
    
    OOP PART 2                                                                  : line 17           
    Polymorphism                                                                : line 19
    * one object for different types
    Inheritance                                                                 : line 56

    Abstraction                                                                 : line 171
    Interface                                                                   : line 188
    - Access to methods                                                         : line 218
    - Access to fields                                                          : line 226
        

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
using polyMorphism = PolymorphismTheory;
using inheritAnce = InheritanceTheory;

// ONE OBJECT (interface) to entities of different types 
Console.WriteLine("Polymorphism: One object (interface) to entities of different types:");
var pizza = new polyMorphism.Pizza();
pizza.AddIngredients(new polyMorphism.Cheddar());
pizza.AddIngredients(new polyMorphism.Mozzarella());
var showUs = pizza.Describe(); 
Console.WriteLine(showUs); // Cheddar

// ACCESS TO METHODS - Derived class have access to base class public and protected methods, but not private ones.
Console.WriteLine("\nAccess to Methods");
var cheddar = new inheritAnce.Cheddar();
Console.WriteLine(cheddar.PublicMethod()); // Even if this method is not defined directly in the general class, we can still call it on a cheddar object because it is inherited from the base Ingredient class.
cheddar.UseMethodFromBaseClass(); // or we could also use it directly within the cheddar class.
//cheddar.PrivateMethod(); // not accessible
//cheddar.ProtectedMethod(); // not accessible

// ACCESS to FIELDS - Inherited fields have independent values from base class
Console.WriteLine("\nAccess to Fields");
var ingridient = new inheritAnce.Ingredient();
ingridient.PublicField = 10;
cheddar.PublicField = 2;

Console.WriteLine("Value of ingredient: " + ingridient.PublicField);
Console.WriteLine("Value of cheddar: " + cheddar.PublicField);

Console.WriteLine("\nAccess to public fields form derived class");
var newCheddar1 = new inheritAnce.Cheddar(); // implicit type of Cheddar
inheritAnce.Cheddar newCheddar2 = new inheritAnce.Cheddar(); // explicit type of Cheddar
Console.WriteLine(newCheddar1.Name);

// We can assign an object of type Cheddar to a variable of type Ingredient
inheritAnce.Ingredient cheddarIngredient = new inheritAnce.Cheddar();
Console.WriteLine(cheddarIngredient.Name); // if we want to be able to use the Name property on any Ingredient object, we must have this property in the Ingredient class.

Console.ReadKey();

namespace PolymorphismTheory
{
    public class Pizza
    {
        // Each instance of this class will hold a list of ingredients it is composed of
        private List<Ingredient> _ingridients = new List<Ingredient>();

        // A method that adds a new ingredient to a pizza.
        public void AddIngredients(Ingredient ingredient) => _ingridients.Add(ingredient);

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

namespace InheritanceTheory
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

        public string Name { get; } = "Some ingredient";

        public int PublicField; // derived class have access to base public fields

        public string PublicMethod() => "This method is PUBLIC in the Ingredient class.";

        // Unlike public methods, private ones are not inherited.
        private string PrivateMethod() => "This method is PRIVATE in the Ingredient class.";

        // Protected members can be used in the derived classes, but they can't be used outside.
        protected string ProtectedMethod() => "This method is PROTECTED in the Ingredient class.";
    }

    // derived class
    public class Cheddar : Ingredient
    {

        // Fields that are public or protected also get inherited by derived classes.
        /*
            It is not like the value of this field is shared. If we have an object of the Ingredient type, and it will have its own field. At the same time objects of classes derived from this base class will also have such fields, but the values will be independent.     
         */
        public string Name => "Cheddar cheese";
        public int AgedForMonths { get; }

        // use Ingredient method directly within the cheddar class.
        public void UseMethodFromBaseClass()
        {
            Console.WriteLine(PublicMethod());
            //Console.WriteLine(PrivateMethod()); // wont work
            Console.WriteLine(ProtectedMethod());

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

