/* Navigation Notes
    
    OOP theory                                          : line 15
    Example of OOP with DataTime                        : line 29
    Create a class                                      : line 45
    - field/attibute                                    : line 56
    - contructor (theory)                               : line 60 
    - data hiding                                       : line 63
         
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
    - encapsulation, 
    - polymorphism
    - abstraction - classes only exposes essential data and methods and hide the underlying details,
    - inheritance.       
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
