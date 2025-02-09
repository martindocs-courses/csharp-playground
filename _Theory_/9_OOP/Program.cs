/* Navigation Notes
    
    OOP theory                                                                      : line 51
    - Inheritance                                                                   : line 60
    - Encapsulation                                                                 : line 96
    - Polymorphism                                                                  : line 169
    - Abstraction                                                                   : line 211
    - Interface                                                                     : line 228

    Example of OOP with DataTime                                                    : line 251
    Create a class                                                                  : line 274 & 397
    - field/attribute                                                               : line 399
    - constructor                                                                   : line 403 
    - data hiding                                                                   : line 406
    - field initialization                                                          : line 430
    - Constructor initialization                                                    : line 280 & 452
         
    Overloading                                                                     : line 463
    - create constructor with shortcut                                              : line 469
    - methods                                                                       : line 489
    - constructor                                                                   : line 476

    Expression-bodied (shorter) methods                                             : line 506
    THIS keyword                                                                    : line 293 & 540
    Optional parameter                                                              : line 297 & 568

    Validate the constructor parameters                                             : line 302 & 593
    Readonly and const                                                              : line 307 & 622
    Limitation of fields and use of properties                                      : line 312 & 585
    Getters and Setters properties                                                  : line 316 & 679
    - shorter syntax (auto-properties)                                              : line 735
    - difference between auto-properties and custom properties with backing field   : line 745
    
    Object initializers                                                             : line 322 & 813
    Computed properties                                                             : line 336 & 833
    - computed properties key points                                                : line 841
    - benefits of computed properties                                               : line 856

    Static class and methods                                                        : line 349 & 881
    - good practice                                                                 : line 913

    Static fields, properties and constructors                                      : line 383 & 920

    Top-level statements                                                            : line 959

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
using System.Runtime.Intrinsics.X86;
using System;
using System.Threading.Channels;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Reflection.Emit;

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

// CONSTRUCTOR INITIALIZATION 
Console.WriteLine("\nCreate a constructor");

var createConstructor1 = new CreateConstructor(10, 10);
Console.Write(createConstructor1.Width + " ");
Console.Write(createConstructor1.Height);

Console.WriteLine();

var createConstructor2 = new CreateConstructor(30, 30);
Console.Write(createConstructor2.Width + " ");
Console.Write(createConstructor2.Height);

/* THIS keyword */
var someRandomClass = new SomeRandomClass(new DateTime(2025, 2, 3));
someRandomClass.Reschedule(new DateTime(2025, 5, 21));

/* OPTIONSL PARAMS */
var optionalParams = new OptionalParam();
optionalParams.OptionalParams("Martin"); // if we have the same methods name the method with no optional parameters will be used first, otherwise used default value of 7
optionalParams.OptionalParams("Martin", 14); // override the optional parameter

/* VALIDATE CONSTRUCTOR */
Console.WriteLine("\nValidate a constructor");
var validateConstructor = new ValidateConstructor(-1, 3);
validateConstructor.DisplayValues();

/* READONLY AND CONST */
var readOnlyConst = new ReadOnlyConst(2, 3);
//readOnlyConst.Width = -10; // is not possible to reassign
readOnlyConst.DisplayData();

/* LIMITATION OF FIELDS */
var fieldLimitation = new FieldsLimitation(5, 6);
Console.WriteLine($"\nField Limitations: {fieldLimitation.GetHeight()}");

/* GETTERS AND SETTERS PROPERTIES */
var getterSetter = new GettersSettersProp(4, 5);
Console.WriteLine($"\nGetter: {getterSetter.Width}");
//getterSetter.Width = 20; // we can't use outside the class as setter is private
Console.WriteLine($"\nSetter: {getterSetter.Width}");

/* OBJECT INITIALIZERS */
//var objectInit = new ObjectInitalizer("Martin", 1986); // Normally we use constructor for creating new object

// but we could use object initializer, which gave the same result as creating constructor with values as above
var objectInit = new ObjectInitalizer(1986)
{
    Name = "Martin",
    //YearOfBirth = 1986 // if not set the value of YearOfBirth will be zero (0) or we could use in the creating new object with constructor and mix it 

    YearOfBirth = 2000 // if we set prop in both places (constructor and object initializer) the value that is used is in object initializer as first constructor is called and then object initializer 
};

Console.WriteLine($"\nObject initializer: {objectInit.YearOfBirth}");

/* COMPUTED PROPERIES */
Console.WriteLine("\nComputed properties");
var computedProp = new ComputedProperties("Martin", 25)
// use object initializer if no constructor
{
    Weight = 72,
    Height = 1.82
};
//computedProp.Weight = 72;
//computedProp.Height = 1.82;
Console.WriteLine(computedProp.GetAge());
Console.WriteLine(computedProp.BMI.ToString("N2"));

/* STATIC CLASS AND METHODS */
// Without data in the class the objects we creating will be no different from each other. 
// As class is static we can't instantiate new object wit it. 

//var staticClassMethods = new StaticClassMethod();
//var staticClassMethods2 = new StaticClassMethod(); // the object is still the same as above

/*
    As there is no really a point to create new object if there is no data in the class, we could use methods of the class without creating new object.
    To do that we make method as STATIC which means:
    * methods belong to a class as a whole, not to specific instance.
    * methods can't use the instance data (values and fields or returned by properties)  
 */

//Console.WriteLine($"1 + 2 is: {staticClassMethods.Add(1, 2)}");
//Console.WriteLine($"1 - 2 is: {staticClassMethods.Substract(1, 2)}");
//Console.WriteLine($"1 * 2 is: {staticClassMethods.Multiply(1, 2)}");

// Instead of using object to access the methods, we use class name itself
Console.WriteLine($"Static class and methods: 1 + 2 is: {StaticClassMethod.Add(1, 2)}");
Console.WriteLine($"Static class and methods:1 - 2 is: {StaticClassMethod.Substract(1, 2)}");
Console.WriteLine($"Static class and methods:1 * 2 is: {StaticClassMethod.Multiply(1, 2)}");
Console.WriteLine();

// If we have non-static class we can have static and non-static methods.
var nonStaticClassStaticMethod = new NonStaticClassStaticMethod();
Console.WriteLine($"Non-static class and method: 1 + 2 is: {nonStaticClassStaticMethod.Add(1, 2)}");
Console.WriteLine($"Non-static class and method:1 - 2 is: {nonStaticClassStaticMethod.Substract(1, 2)}");
Console.WriteLine($"Non-static class and static method:1 * 2 is: {NonStaticClassStaticMethod.Multiply(1, 2)}");

// All CONST fields in the class are implicit STATIC
//Console.WriteLine(nonStaticClassStaticMethod.SomeVariable); // can't do that way
Console.WriteLine(NonStaticClassStaticMethod.SomeVariable);

/* STATIC FILEDS, PROPERTIES AND CONSTRUCTORS */
var staticFieldPropConstructor1 = new StaticFieldsPropConstructor("Martin", 25);
Console.WriteLine(staticFieldPropConstructor1.DisplayName());

var staticFieldPropConstructor2 = new StaticFieldsPropConstructor("Alan", 37);
Console.WriteLine(staticFieldPropConstructor2.DisplayName());

Console.WriteLine(StaticFieldsPropConstructor.Counter);

Console.ReadKey();

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// CREATE A CLASS
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

class CreateConstructor
{

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

// OVERLOADING
class OverLoadingTypes
{
    private string _someText; // to add parameters to constructor, highlight fields and right click -> Add Actions..
    private DateTime _date;

    // SHORTCUT TO CREATE CONTRUCTOR - ctor + TAB
    public OverLoadingTypes(string someText, DateTime date)
    {
        _someText = someText;
        _date = date;
    }

    // CONSTRUCTOR OVERLOADING - we can have as many as we want, but as with methods they need to be distinguishable by parameters.
    public OverLoadingTypes(string someText): this(someText, 7) // 'THIS' keyword using in this context means to refer to another constructor (1) which first the code executed an then this one, because the value match used above: this(someText, 7) match (string someText, int days). Doing that allow code duplication
    {
        //_someText = someText;
        //_date = DateTime.Now.AddDays(7); // gets current date
    }

    public OverLoadingTypes(string someText, int days) // (1)
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

/* 
 * EXPRESSION-BODIED METHODS - use when methods has only single statement or expression 
    expression - evaluate to a value, example: if(1 > 2)
    statement - do not evaluate to a value, example: Console.WriteLine("Hi");
*/
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

    // Switch to expression-bodied methods when there is only one statement
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

/* THIS keyword - is referring to the current instance of a class */
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

/* OPTIONAL PARAMETER */
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

/* VALIDATE THE CONSTRUCTOR PARAMETERS */
class ValidateConstructor{
    public int Height;
    public int Width;

    public ValidateConstructor(int height, int width)
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

/* READONLY AND CONST */
class ReadOnlyConst{

    /*
        READONLY:
        * Readonly field can only be assigned (NOT REQUIRED) at the declaration or in constructor. If not assigned the default values will be assigned.        
        * When making all fields READ ONLY will make whole object IMMUTABLE, so once object created it will never be modified.
        * It's a good practice to make fields readonly if possible if we do not plan to modify after it set in the constructor.
        
        CONST:
        * const modifier can be applied to both variables and fields. 
        * Those variables and fields must be assigned (REQUIRED) at declaration and can never be modified afterward. 
        * They must be given a compile-time constant value, so a value that can be evaluated during the compilation, before the application is run, so not result of a method: const int number = GetNumber(); or Math.Random() as those are evaluated at run time. 
        * const should always start with capital letter, const int SomeField = 10; and we shouldn't use for fields underscore for private fields.
     */
    const int NumberOfSides = 4;
    public int Height;
    readonly int Width;
        
    public ReadOnlyConst(int height, int width)
    {
        Height = height;
        Width = width;
    }

    public void DisplayData(){
        Console.WriteLine($"\nRead only and const, values: {Height} and {Width}");
    }
}

/* LIMITATION OF FIELDS AND USE OF PROPERTIES */
class FieldsLimitation{
    /*
        Make the fields public for reading, but private for writing using methods.     
     */
    public readonly int Width;
    private int _height; // as private

    public FieldsLimitation(int width, int height)
    {
        Width = width;
        _height = height;
    }

    // using public method to get private field
    public int GetHeight() => _height;

    // adding extra logic if the fields are set or get
    public void SetHeight(int number){
        if(number < 0)
        {
            _height = number;
        }
    }

}

/* GETTERS AND SETTERS PROPERTIES */
class GettersSettersProp{

    private int _height;
    private int _width;

    /*
        * Properties:
        - should always start with capital letter. 
        - it has accessors: getter & setter
        - properties are differ from fields as we can use access modifiers, for example: public getter and private setter

        * Backing field - is the field that property is wrapping          
        
        * Difference between fields and properties:
        - Fields
        * they are like variables
        * single access modifier
        * no separate getter and setter
        * they should always be private
        
        - Properties
        * they are like methods
        * separate access modifier: getter & setter
        * getter and setter may be removed
        * can safely be public
        
        When 
     */

    // properties for getting & setting width
    //public int Width{
    //    get{
    //        return _width;
    //    }   

    //    private set{ // we can use private setter inside the class
    //        if(value > 0){
    //          _width = value; // 'value' is special variable that is assign to the property            
    //        }
    //    }
    //}

    // properties for getting & setting height
    //public int Height{        
    //    get
    //    {
    //        return _height;
    //    }

    //    set
    //    {
    //        _height = value;
    //    }
    //}

    // GETTER & SETTER SHORTER SYNTAX (AUTO-PROPERTIES) - we can use if the only thing we doing is setting and getting without complicated validation
    public int Width { get; } // we could remove setter, so we can only read value but not setting it outside, only in constructor or at declaration, like this: public int Width { get; } = 12;
    public int Height { get; set; }

    public GettersSettersProp(int height, int width)
    {
        Height = height;
        Width = width;
    }

    // DIFFRENCE BETWEEN AUTO-PROPERTIES aka: private int _width { get; set; } and CUSTOM PROPERTIES WITH BACKING FIELDS aka: private int _width 
    /*
        AUTO-PROPERTIES:
        * When we use auto-properties, C# automatically generates the backing field for us. 
        * We can access and modify the property directly, without needing to refer to a backing field manually in the constructor or methods.
   
        Example using auto-properties:                
            public class Person
            {
                public int Age { get; set; }  // Auto-property, no backing field declared manually

                public Person(int age)
                {
                    Age = age;  // We use the property directly
                }

                public void UpdateAge(int newAge)
                {
                    Age = newAge;  // We use the property directly
                }
            }
        
        - Constructor: We can use the property (Age) directly to set the value.
        - Methods: Similarly, we can use the property directly (e.g., Age = newAge).
        - The backing field is automatically managed by C#.
        

       CUSTOM PROPERTIES WITH BACKING FIELDS:
        * When we write custom properties with backing fields, we're responsible for the backing field, the getter, and the setter.
        * We must refer to the backing field when setting and getting values in the property, but we can use the property in the constructor or class methods.

        Example with backing field and custom logic:       
            public class Person
            {
                private int _age;  // Backing field

                public int Age
                {
                    get { return _age; }
                    set
                    {
                        if (value < 0)
                        {
                            throw new ArgumentException("Age cannot be negative");
                        }
                        _age = value;  // We assign to the backing field
                    }
                }

                public Person(int age)
                {
                    Age = age;  // We use the property, not the backing field, in the constructor
                }

                public void UpdateAge(int newAge)
                {
                    Age = newAge;  // We use the property, not the backing field, in methods
                }
            }
        
        - Constructor: In the constructor, we use the property (Age = age) to set the value. We do not need to access the backing field directly. The setter will handle the logic for us (e.g., validation).

        - Methods: In methods, we use the property as well (Age = newAge). The setter will again run the validation and update the backing field (_age) when we assign a value to the property.

        - Backing Field: The backing field (_age) is used only inside the setter to store the value. We don't manually access or modify the backing field from other parts of the class unless we’re directly working with it.
    */
}

/* OBJECT INITIALIZERS */
class ObjectInitalizer{

    public string Name { get; set; }
    public int YearOfBirth { get; set; }

    /*
        * If the properties of a class are publicly settable, we can use object initializers when creating new objects.
        * Instead of using constructor to create an object with object initializers 
        * We do not have to initialize all values as not-initialized value will get default value for their type
        * Object initializer only works if fields are public and have setters
     */

    public ObjectInitalizer(int yearOfBirth)
    {
        //Name = name;
        YearOfBirth = yearOfBirth;
    }
}

/* COMPUTED PROPERIES */
class ComputedProperties{

    public string Name { get; set; }
    public int Weight { get; set; }
    public double Height { get; set; }
    private int _age;

    // COMPUTED PROPERTY (key points)
    /*
        * No Backing Field: Computed properties don't store data directly. Instead, they compute their value each time they are accessed.
        * Getters with Logic: We can define custom logic inside the get accessor to calculate the value dynamically.
        * Read-Only: Computed properties are usually read-only, meaning you typically don't provide a set accessor, because the value is derived from other properties or fields.     
     */
    public double BMI
    {
        get
        {            
            return Weight / (Height * Height);
        }
    }

    /*
        BENEFITS OF COMPUTED PROPERTIES:
        * Encapsulation: You can hide complex calculations or data transformations from the user of the class.
        * Dynamic Calculation: Computed properties always return up-to-date values without requiring manual updates.
        * Readability: They make your code easier to read by providing meaningful names for calculated values.
        
        Note:
         Properties should never be performance heavy.
     */

    // Constructor
    public ComputedProperties(string name, int age)
    {
        Name = name;
        _age = age;
    }

    // Parameter-less method
    public int GetAge() => _age;

    /*
        When use should use parameterless methods and when computed properties:
        * methods represent actions while properties represent data.
     */
}

/* STATIC CLASS AND METHODS - the class is stateless */
// Usually objects are containers for data and methods. This class contains only methods and no data
// If all methods of the class are static we can make class as static too, which mean that it CANNOT be instantiated. It works as a container for methods.
static class StaticClassMethod{

    //public int Add(int x, int y) => x + y;
    //public int Substract(int x, int y) => x - y;
    //public int Multiply(int x, int y) => x * y;
    
    public static int Add(int x, int y) => x + y;
    public static int Substract(int x, int y) => x - y;
    public static int Multiply(int x, int y) => x * y;

}

// Static class can't have any other methods that are not static, but non static class can have static methods.
class NonStaticClassStaticMethod
{
    // All CONST fields are inexplicit STATIC
    public const int SomeVariable = 5;

    public int Add(int x, int y) => x + y;
    public int Substract(int x, int y) => x - y;

    // We can mix non-static methods with non-static
    public int Substract2(int x, int y) => Add(x, y) + (x - y); 

    // but we can't mix static methods with non-static
    //public static int Multiply2(int x, int y) => Substract(x, y) + x * y;
    public static int Multiply(int x, int y) => x * y;

    /*
       GOOD PRACTICE:
       * If a private method doesn't use instance of data, make it static. This way we clearly show that those methods do not use or change any state of the object.
       * Another benefit of making methods static is that they work slightly faster.     
     */
}


/* STATIC FILEDS, PROPERTIES AND CONSTRUCTORS */
// Both static and non-static classes can contain static fields and properties.
// Such a field or property belongs to a class as a whole, not to any specific instance.
class StaticFieldsPropConstructor{

    /* 
        * If this field was not static, the value would be incremented only once when the object was created and then it would always be one.
        * Static fields and properties are used when we need to share a single member between all class instances.
        * If we don't initialize a static field or property, it will be automatically initialized to the default value, just like its non-static counterpart.
     */
    public static int Counter { get; private set; } // static prop do not belong to any of instance
    
    // If we want to have a static field that will store the date and time of the first usage of this class.
    private static DateTime _firstUsed;
    // We can either assign it at declaration: private static DateTime _firstUsed = DateTime.Now;
    // or in static constructor which is just like a regular constructor, but it doesn't have any access   modifier. Instead it has the static modifier.
    static StaticFieldsPropConstructor(){
        _firstUsed = DateTime.Now; // the value of _firstUsed may be not precise as initialization of the static fields is ontrolled by very low-level mechanisms of.NET.
    }
    // Which one we use does not really matter.
    // Both the initialization of the static fields and the calling of the static constructor happen before the first instance of the containing class is created.
    // Unfortunately, we don't have any certainty when exactly that will be, as it is controlled by very low-level mechanisms of.NET.

    //  NOTE: Having static fields and properties is a risky and it should be avoided as much as possible.
  
    private string _name;
    private int _age;

    public StaticFieldsPropConstructor(string name, int age)
    {
        _name = name;
        _age = age;
        ++Counter; // it increments whatever instance of the object is created
    }

    public string DisplayName() => $"My name is {_name} and I'm {_age} years old.";
}

/* 
    * Top-level statements can only appear before any class or namespace declaration. Once you declare a class (or namespace), the compiler expects that all executable code should be inside methods, constructors, or other members of those classes.
   
    * When defining a class we can't put any executable (top-level statements) code below class declaration, as it won't work:
        Console.WriteLine("Hello"); // that wont work it needs to before the class definition
*/
