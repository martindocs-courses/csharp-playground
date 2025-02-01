/* Navigation Notes
    
    OOP theory                                          : line 23
    - Inheritance                                       : line 32
    - Encapsulation                                     : line 68
    - Polymorphism                                      : line 141
    - Abstraction                                       : line 183
    - Interface                                         : line 200

    Example of OOP with DataTime                        : line 223
    Create a class                                      : line 239
    - field/attibute                                    : line 262
    - contructor (theory)                               : line 266 
    - data hiding                                       : line 269
    - field initalization                               : line 292
    - Constructor initalization                         : line 314
         
    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

/*
    OOP in short:
    * Object Oriented Programming, containing data and methods
    * We define data and methods objects of some type will contain by defining classes. Class is a blueprint for objects of the same type, which can be used to create many objects as instance
    * Class 
    * We can have many objects (instances) of the same class
    * Code is modular, which is easier to mantain, reuse and modify and is more flexible
    * Code is easier to understand and easy to control and less error-prone
    * Object-oriented programming heavily relies on four fundamental concepts: 
    * 
    - INHERITANCE (: symbol) - inherit fields and methods from one class to another
        
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

    - ENCAPSULATION - bundling data with methods that operate on this data in single class,
        Two Ways to Encapsulate Data:
        * Using Methods - More control, but longer.
        * Using Properties (get and set) → Cleaner and recommended for most cases.
        
        - Use properties (get and set) when data should be easily accessible.
        - Use methods when you need more control (e.g., extra logic before modifying the value).
        - In real-world applications, properties are preferred because they keep the code cleaner.
        
       * Encapsulation Using Methods: This approach hides the field and allows access only through methods.
            class BankAccount
            {
                private double _balance; // Private field (hidden from outside)

                public void Deposit(double amount) // Method to modify
                {
                    if (amount > 0)
                    {
                        _balance += amount;
                    }
                }

                public double GetBalance() // Method to read
                {
                    return _balance;
                }
            }

            class Program
            {
                static void Main()
                {
                    BankAccount account = new BankAccount();
                    account.Deposit(100); // ✅ Allowed
                    Console.WriteLine(account.GetBalance()); // ✅ Allowed
                }
            }

        ✅ Good when you need more control (e.g., complex calculations inside Deposit()).
        ❌ Longer and not ideal for simple data access.            


        * Encapsulation Using Properties (get and set):
            class BankAccount
            {
                private double _balance; // Private field

                public double Balance // Property with get and set
                {
                    get { return _balance; } // Allows reading
                    set
                    {
                        if (value >= 0) // Only allow positive values
                            _balance = value;
                    }
                }
            }

            class Program
            {
                static void Main()
                {
                    BankAccount account = new BankAccount();
                    account.Balance = 100; // ✅ Allowed (calls set)
                    Console.WriteLine(account.Balance); // ✅ Allowed (calls get)
                }
            }

        ✅ Shorter and cleaner than using methods
        ✅ Better for simple read/write access
        ❌ Less control if complex logic is needed


    - POLYMORPHISM - means "many forms", and it occurs when we have many classes that are related to each other by inheritance. Polymorphism uses those methods to perform different tasks. This allows us to perform a single action in different ways.
        
        The base class method overrides the derived class method, when they share the same name. But we can override the base class method, by adding the virtual keyword to the method inside the base class, and by using the override keyword for each derived class methods

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

/* EXAMPLE OF OOP WITH DATATIME CLASS */
Console.WriteLine("Example of OOP with DataTime class");

// Create an object (instance) of data type
var pizzaDay = new DateTime(2025, 1, 29); // DataTime method has constructor to create new class instances with 3 params YY-MM-DD

Console.WriteLine($"The year is: {pizzaDay.Year}");
Console.WriteLine($"The month is: {pizzaDay.Month}");
Console.WriteLine($"The day is: {pizzaDay.Day}");
Console.WriteLine($"The day of the week: {pizzaDay.DayOfWeek}");

// using methods of DataTime
var pizzaDay2025 = pizzaDay.AddYears(1);

Console.WriteLine(pizzaDay2025);

/* CREATE A CLASS */
Console.WriteLine("\nCreate a class");

var rectangle1 = new Rectangle1();
Console.WriteLine(rectangle1.Width);

/* CREATE A NEW CONSTRUCTOR */
Console.WriteLine("\nCreate a constructor");

var rectangle2 = new Rectangle2(10, 10);
Console.Write(rectangle2.Width + " ");
Console.Write(rectangle2.Height);

Console.WriteLine();

var rectangle3 = new Rectangle2(30, 30);
Console.Write(rectangle3.Width + " ");
Console.Write(rectangle3.Height);

Console.ReadKey();

// declare a class
class Rectangle1{
    // declare a FIELD/ATTRIBUTE, which is a variable that belongs to an object of a class
    public int Width; // if we dont initialize the field it will be automatically set to the default value for its type, in our case int is '0' (zero). For normal variables that are not belong to class they still be not initialize.
    int height;

    // CONSTRUCTOR is a method for instantiate object of the class. It needs have the same name as class and it cannot have return type 
    // If we dont define any constructor we only can use default parametrless constructor, which is automatically created when crate a class and you are not able to set initial values for fields.

    /* DATA HIDING - making the members of a class non-public. 
     * Class 'members' are anything thta a class contains, especially fields and methods. 
     * We should only make a member public if it is necessery.    
     * To control who can access componets of a class, we use the access modifiers (public, privite or protected)
       - 'privite' method can only be acess within class not avialble outside. They are deault modifier for any new fileds.
       - 'public' can be access outside
    */

    // class method that can use privite fields
    void SomeMethod(){
        Console.WriteLine($"The height is: {height}");
    }
}

class Rectangle2{

    // Declare fields with as public. it should start with capital letter
    public int Width;
    public int Height;

    // privite variable should start with underscore and folow by small letter
    private int _length;

    /* FIELD INITIALIZATION. We could also declare and initialize values without constractor, but in this case we can only crate new object with already defined (DEFAULT) values;
        public int Width = 15;
        public int Height = 15;

      Use when:
        - The field has a default value that doesn’t change.
        - You don’t need to perform any validation or complex logic when creating the object.
        - You want to avoid the need for a constructor when there are no special requirements.
    */

    /* 
        Define a constructor:
        * which need to be named the same as the class
        * no void or any returning type 
        * constructor canr only be declared in the class and can't called in the method
     */
    public Rectangle2(int width, int height)
    {
        // Most of the time that all we do in the constructor is to assign field to parameters.
        // You can pass values to the constructor, perform validation, or even have different ways of initializing the object based on conditions.

        /*
            CONSTRUCTOR INITIALIZATION (preferred in most cases). 
            - You need to pass values to the object upon creation and want to ensure they are valid.
            - The object’s fields need to be set at the time of creation and don’t have a sensible default value.
            - You need to perform validation or additional logic before setting the values.
            - You want to ensure the object is in a valid state when it is created.         
         */
        Width = width;
        Height = height;
    }
}

/* 
    * When defining a class we can't put any executable (top-level statements) code below class declaration, as it won't work:
        Console.WriteLine("Hello"); // that wont work it needs to before the class definition

    * Top-level statements can only appear before any class or namespace declaration. Once you declare a class (or namespace), the compiler expects that all executable code should be inside methods, constructors, or other members of those classes.
*/
