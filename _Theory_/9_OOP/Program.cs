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


var rectangle = new Rectangle();

Console.WriteLine(rectangle.width);


Console.ReadKey();
class Rectangle{
    // declare a FIELD/ATTRIBUTE, which is a variable that belongs to an object of a class
    public int width; // if we dont initialize the field it will be automatically set to the default value for its type, in our case int is '0' (zero)
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

// when defining a class we cant put any code below as it wont work
//Console.WriteLine("Hello"); // that wont work it needs to before the class definition