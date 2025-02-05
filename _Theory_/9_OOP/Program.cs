﻿/* Navigation Notes
    
    OOP theory                                          : line 32
    - Inheritance                                       : line 41
    - Encapsulation                                     : line 77
    - Polymorphism                                      : line 150
    - Abstraction                                       : line 192
    - Interface                                         : line 209

    Example of OOP with DataTime                        : line 232
    Create a class                                      : line 250
    - field/attribute                                   : line 285
    - constructor (theory)                              : line 289 
    - data hiding                                       : line 292
    - field initialization                              : line 315
    - Constructor initialization                        : line 337
         
    Overloading                                         
    - create constructor with shortcut                  : line 353
    - methods                                           : line 375
    - constructor                                       : line 361

    Expression bodied (shorter) methods                 : line 391
    THIS keyword                                        : line 425
    Optional parameter                                  : line 453

    Validate the constructor parameters                 : line 

    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

/*
    OOP in short:
    * Object Oriented Programming, containing data and methods
    * We define data and methods objects of some type will contain by defining classes. Class is a blueprint for objects of the same type, which can be used to create many objects as instance
    * Class 
    * We can have many objects (instances) of the same class
    * Code is modular, which is easier to maintain, reuse and modify and is more flexible
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

                public void SetDeposit(double amount) // Method to modify
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
using System.Threading.Channels;

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

var oopTheory = new OOPTheory();
Console.WriteLine(oopTheory.Width);

/* CREATE A NEW CONSTRUCTOR */
Console.WriteLine("\nCreate a constructor");

var createConstructor1 = new CreateConstructor(10, 10);
Console.Write(createConstructor1.Width + " ");
Console.Write(createConstructor1.Height);

Console.WriteLine();

var createConstructor2 = new CreateConstructor(30, 30);
Console.Write(createConstructor2.Width + " ");
Console.Write(createConstructor2.Height);

/* USE THIS keyword in a class */
var someRandomClass = new SomeRandomClass(new DateTime(2025, 2, 3));
someRandomClass.Reschedule(new DateTime(2025, 5, 21));

/* OPTIONSL PARAMS */
var optionalParams = new OptionalParam();
optionalParams.OptionalParams("Martin"); // if we have the same methods name the method with no optional parameters will be used first, otherwise used default value of 7
optionalParams.OptionalParams("Martin", 14); // override the optional parameter

/* VALIDATE CONSTRUCTOR */
Console.WriteLine("\nValidate a constructor");
var validateConstructor = new ValidateContructor(-1, 3);
validateConstructor.DisplayValues();

Console.ReadKey();

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// declare a class
class OOPTheory{
    // declare a FIELD/ATTRIBUTE, which is a variable that belongs to an object of a class
    public int Width; // if we don't initialize the field it will be automatically set to the default value for its type, in our case int is '0' (zero). For normal variables that are not belong to class they still be not initialize.
    int height;

    // CONSTRUCTOR is a method for instantiate object of the class. It needs have the same name as class and it cannot have return type 
    // If we don't define any constructor we only can use default parameterless constructor, which is automatically created when crate a class and you are not able to set initial values for fields.

    /* DATA HIDING - making the members of a class non-public. 
     * Class 'members' are anything that a class contains, especially fields and methods. 
     * We should only make a member public if it is necessary.    
     * To control who can access components of a class, we use the access modifiers (public, private or protected)
       - 'private' method can only be access within class not available outside. They are default modifier for any new fields.
       - 'public' can be access outside
    */

    // class method that can use private fields
    void SomeMethod(){
        Console.WriteLine($"The height is: {height}");
    }
}

class CreateConstructor{

    // Declare fields with as public. it should start with capital letter
    public int Width;
    public int Height;

    // private variable should start with underscore and follow by small letter
    private int _length;

    /* FIELD INITIALIZATION. We could also declare and initialize values without constructors, but in this case we can only crate new object with already defined (DEFAULT) values;
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
        * constructor can only be declared in the class and can't called in the method
     */
    public CreateConstructor(int width, int height)
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

class MethodsOverLoading
{
    private string _someText; // to add parameters to constructor, highlight fields and right click -> Add Actions..
    private DateTime _date;

    // SHORTCUT TO CREATE CONTRUCTOR
    // ctor + TAB
    public MethodsOverLoading(string someText, DateTime date)
    {
        _someText = someText;
        _date = date;
    }

    // CONSTRUCTOR OVERLOADING - we can have as many as we want, but as with methods they need to be distinguishable by parameters.
    public MethodsOverLoading(string someText): this(someText, 7) // 'THIS' keyword using in this context means to refer to another constructor (1) which first the code executed an then this one, because the value match used above: this(someText, 7) match (string someText, int days). Doing that allow code duplication
    {
        //_someText = someText;
        //_date = DateTime.Now.AddDays(7); // gets current date
    }


    public MethodsOverLoading(string someText, int days) // (1)
    {
        _someText = someText;
        _date = DateTime.Now.AddDays(days); // gets current date
    }

    // METHOS OVERLOADING - named methods with the same name, but they have different type, order of parameters
    public void SomeMethod(DateTime date)
    {
        _date = date;
    }

    public void SomeMethod(int month, int day) { 
        _date = new DateTime(_date.Year, month, day);
    }

    // It won't compile as the method has identical name, type and parameters
    //public void SomeMethod(int monthsInAYear, int daysInAMonth) {

    //}
}

// EXPRESSION-BODIED METHODS - use when methods has only single statement or expression 
// expression - evaluate to a value, example: if(1 > 2)
// statement - do not evaluate to a value, example: Console.WriteLine("Hi");
class ExpressionBodiedMethod
{
    public int Width;
    public int Height;
    public ExpressionBodiedMethod()
    {
        
    }

    public ExpressionBodiedMethod(int height, int width)
    {
        Height = height;
        Width = width;
    }

    // Turn to method to expression-bodied methods 
    //public int CalculateValue()
    //{
    //    return 2 * Height * Width;
    //}

    public int CalculateValue() => 2 * Height * Width;

    //public int CalculateArea()
    //{
    //    return Width * Height;
    //}

    public int CalculateArea() => Height * Width;
}

// THIS - keyword is referring to the current instance of a class 
class THISKeyword
{
    public void Print(SomeRandomClass someRandomClass)
    {
        Console.WriteLine($"\n\nUsing the THIS keyword in a class {someRandomClass.GetDate()}");
    }
}

class SomeRandomClass
{    
    private DateTime _date;

    public SomeRandomClass(DateTime date)
    {        
        _date = date;
    }

    public DateTime GetDate() => _date; 

    public void Reschedule(DateTime date)
    {
        _date = date;
        var printer = new THISKeyword();
        printer.Print(this); // we need to use THIS keyword to refer to instance
    }
}

// OPTIONAL PARAMETER
class OptionalParam
{
    public string name;
    public int days;

    /*
        * the default values of optional parameters must be compile-time constant (must evaluate before compilation before program is run) aka. need to be a simple type like: string, int or bool 
        * optional parameters must appear after all required parameters aka: '(string name, int days = 7)' NOT=> '(int days = 7, string name)'
        * in case of ambiguity, the methods with no optional parameters are used first
        * when using multiple optional parameters, we must remember that if we provide some of them, we must also provide all preceding optional parameters, so if we have optionalParams.OptionalParams(string name = "Martin", int days = 7) we cant use new OptionalParams(12) as we need also include preceding optional parameter
     */

    // this method will be used when called: 'optionalParams.OptionalParams("Martin")', as it has precedence over method with optional parameters
    public void OptionalParams(string name)
    {
        Console.WriteLine("Optional params: " + name);
    }

    public void OptionalParams(string name, int days = 7)
    {
        Console.WriteLine("Optional params: " + name + " " + days);
    }
}

class ValidateContructor{
    public int Height;
    public int Width;

    public ValidateContructor(int height, int width)
    {
        Height = CheckValue(height, nameof(height)); // nameof will return string equal to height
        Width = CheckValue(width, nameof(width)); // nameof will return string equal to width       
    }

    // only used in this class
    private int CheckValue(int number, string name){

        int defaultValue = 1;
        if (number > 0) {
            return number;
        }

        Console.WriteLine($"The {name} need to be bigger that 0");
        return defaultValue;
    }


    public void DisplayValues(){
        Console.WriteLine($"Height: {Height}, Width: {Width}");
    }
}

/* 
    * When defining a class we can't put any executable (top-level statements) code below class declaration, as it won't work:
        Console.WriteLine("Hello"); // that wont work it needs to before the class definition

    * Top-level statements can only appear before any class or namespace declaration. Once you declare a class (or namespace), the compiler expects that all executable code should be inside methods, constructors, or other members of those classes.
*/
