# 🧱 C# OOP Cheatsheet

<!-- [← Back](./README.md) | [Exceptions](./exceptions.md) | [LINQ](./linq.md) -->
[← Back](./README.md) 

## Table of Contents

- [1. Classes and Objects](#1-classes-and-objects)
- [2. Fields and Properties](#2-fields-and-properties)
- [3. Constructors](#3-constructors)
- [4. Inheritance](#4-inheritance)
- [5. Polymorphism](#5-polymorphism)
- [6. Abstraction](#6-abstraction)
- [7. Encapsulation](#7-encapsulation)
- [8. Interfaces](#8-interfaces)
- [9. Access Modifiers](#9-access-modifiers)
- [10. Static Members](#10-static-members)
- [11. Abstract Classes vs Interfaces](#11-abstract-classes-vs-interfaces)
- [12. Other Concepts](#12-other-concepts)


## 1. Classes and Objects
[← Back to TOP](#table-of-contents)
- [1.1. Basic Class Structure](#11-basic-class-structure)
- [1.2. With Constructor with Fields](#12-with-constructor-with-fields)
- [1.3. With Properties](#13-with-properties)
- [1.4. With Method Overloading](#14-with-method-overloading)
- [1.5. With Encapsulation (Private Fields, Public Methods)](#15-with-encapsulation-private-fields-public-methods)
- [1.6. With Static Members](#16-with-static-members)
- [1.7. With Object Initializers](#17-with-object-initializers)
- [1.8. With Multiple Constructors (Constructor Overloading)](#18-with-multiple-constructors-constructor-overloading)
- [1.9. With Optional Parameters](#19-with-optional-parameters)
- [1.10. Anonymous Object (Quick Struct-Like Usage)](#110-anonymous-object-quick-struct-like-usage)

### 1.1. Basic Class Structure
```csharp
    // A class is a blueprint for creating objects
    public class Car
    {
        public string Make;
        public string Model;

        // Method
        public void Honk()
        {
            Console.WriteLine("Beep!");
        }
    }

    // Creating an object
    Car myCar = new Car();
    myCar.Make = "Toyota";
    myCar.Model = "Corolla";
    myCar.Honk();
```

### 1.2. With Constructor with Fields
```csharp
    public class Person
    {
        private string name;

        public Person(string name)
        {
            this.name = name;
        }

        public void SayHello() => Console.WriteLine($"Hi, I'm {name}");
    }
```

### 1.3. With Properties
```csharp
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Speak() => Console.WriteLine($"{Name} says hello");
    }
```

### 1.4. With Method Overloading
```csharp
    public class Printer
    {
        public void Print(string message) => Console.WriteLine(message);
        public void Print(int number) => Console.WriteLine(number);
    }
```

### 1.5. With Encapsulation (Private Fields, Public Methods)
```csharp
    public class BankAccount
    {
        private decimal balance;

        public void Deposit(decimal amount)
        {
            if (amount > 0) balance += amount;
        }

        public decimal GetBalance() => balance;
    }
```

### 1.6. With Static Members
```csharp
    public class MathUtils
    {
        public static double Pi = 3.14159;

        public static double Square(double x) => x * x;
    }

    // Usage
    var area = MathUtils.Pi * MathUtils.Square(5);
```

### 1.7. With Object Initializers
```csharp
    public class User
    {
        public string Username { get; set; }
        public string Role { get; set; }
    }

    var user = new User { Username = "admin", Role = "superuser" };
```

### 1.8. With Multiple Constructors (Constructor Overloading)
```csharp
    public class Product
    {
        public string Name;
        public double Price;

        public Product() { }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
```

### 1.9. With Optional Parameters
```csharp
    public class Logger
    {
        public void Log(string message, string level = "INFO")
        {
            Console.WriteLine($"[{level}] {message}");
        }
    }
```

### 1.10. Anonymous Object (Quick Struct-Like Usage)
```csharp
    var person = new { Name = "Alice", Age = 30 };
    Console.WriteLine(person.Name);
```

### 1.11. Summary: Most Common Class Patterns
```bash
    Pattern	                        Use Case

    Constructor Initialization	    Required data when creating objects

    Properties Only	                Simple data containers / models

    Method Overloading	            Flexible APIs with same method name

    Static Class / Members	        Shared logic like utilities or constants

    Object Initializers	            Clean syntax for setting values

    Anonymous Objects	            Quick temporary group of data (read-only)
```

## 2. Fields and Properties
[← Back to TOP](#table-of-contents)
- [2.1. Fields](#21-fields)
- [2.2. Auto-Implemented Properties](#22-auto-implemented-properties)
- [2.3. Properties with Private Setters](#23-properties-with-private-setters)
- [2.4. Full Property with Logic](#24-full-property-with-logic)
- [2.5. Expression-Bodied Properties](#25-expression-bodied-properties)
- [2.6. Read-Only Properties](#26-read-only-properties)
- [2.7. Properties Set Only Internally (Default, internal use)](#27-properties-set-only-internally-default-internal-use)
- [2.8. Fields vs Properties Summary](#28-fields-vs-properties-summary)
- [2.9. Real-World Usage](#29-real-world-usage)
- [2.10. Constructor vs Property Initialization](#210-constructor-vs-property-initialization)

### 2.1. Fields
```csharp
    public class User
    {
        // Public field (not recommended)
        public string Name;

        // Private field (preferred)
        private int age;
    }

```
🔸 Good practice: Keep fields private, expose access via properties.

### 2.2. Auto-Implemented Properties
```csharp
    public class Book
    {
        public string Title { get; set; } // auto-property
    }
```
🔹 When to use:
* No special logic needed in getter/setter.

* Used a lot in data models, DTOs, or MVC ViewModels.

### 2.3. Properties with Private Setters
```csharp
    public class Order
    {
        public int Id { get; private set; }

        public Order(int id)
        {
            Id = id;
        }
    }
```
🔹 When to use:

* Property can be read externally, but only set internally (e.g. in constructor).

* Good for immutable patterns.

### 2.4. Properies with get-only setter
```csharp
    public class Person
    {
        public string Name { get; init; }
    }

    // Allowed:
    var p = new Person { Name = "Alice" };

    // Not allowed later:
    p.Name = "Bob"; // ❌ Compile-time error
```
🔹 What it does:
* You can set the property only during object initialization (i.e., when the object is being created).

* After that, the property becomes `read-only` — just like a get-only property.

🔹 Why use it?
* It allows for immutability with flexibility

* You can set properties easily when constructing the object.

* But you prevent accidental changes later in the code.

### 2.4. Full Property with Logic
```csharp
    public class Account
    {
        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                    balance = value;
            }
        }
    }
```
🔹 When to use:

* Validation or logic needed when setting/getting values.

### 2.5. Expression-Bodied Properties
```csharp
    public class Circle
    {
        public double Radius { get; set; }

        public double Area => Math.PI * Radius * Radius;
    }
```
🔹 When to use:

* Read-only property with logic in a single line.

* Clean and expressive.

### 2.6. Read-Only Properties
```csharp
    public class Config
    {
        public string AppVersion => "1.0.0";
    }
```
🔹 When to use:

* You want to expose constants or derived data.

* No setter needed at all.

### 2.7. Properties Set Only Internally (Default, internal use)
```csharp
    public class UserProfile
    {
        public string Username { get; private set; } = "guest";
    }
```
🔹 When to use:

* You want to expose a default value and only change it internally.

### 2.8. Fields vs Properties Summary
```bash
Feature             Field                       Property

Access              Direct (usually private)    Via get/set accessors

Encapsulation       ❌ Minimal                 ✅ Full control

Flexibility         ❌ Fixed logic             ✅ Custom logic/validation

Serialization       ❌ (Not always visible)    ✅ Used in many frameworks (e.g., JSON.NET, EF)
```

### 2.9. Real-World Usage
🔹 Use fields when:

* Internal data used only within the class.

* For performance-sensitive structures (rare).

🔹 Use properties when:

* Exposing data to outside code (clean API).

* You need to add validation, change behavior later.

* Frameworks rely on reflection/serialization.

### 2.10. Constructor vs Property Initialization
Via Constructor
```csharp
var car = new Car("Ford", "Mustang");
```

Via Object Initializer
```csharp
var car = new Car { Make = "Ford", Model = "Mustang" };
```
* Constructor: Better for required values.

* Object Initializer: Cleaner for setting optional/config values.


## 3. Constructors
[← Back to TOP](#table-of-contents)
- [3.1. Default Constructor](#31-default-constructor)
- [3.2. Parameterized Constructor](#32-parameterized-constructor)
- [3.3. Overloaded Constructors](#33-overloaded-constructors)
- [3.4. Constructor Chaining :this](#34-constructor-chaining-this)
- [3.5. Static Constructor](#35-static-constructor)
- [3.6. Private Constructor and Factory Pattern](#36-private-constructor-and-factory-pattern)
- [3.7. Constructor Injection (Dependency Injection)](#37-constructor-injection-dependency-injection)
- [3.8. Optional Parameters in Constructors](#38-optional-parameters-in-constructors)
- [3.9. Object Initializers vs Constructors](#39-object-initializers-vs-constructors)
- [3.10. Real-World Constructor Patterns](#310-real-world-constructor-patterns)
- [3.11. Common Mistakes](#311-common-mistakes)

### 3.1 Default Constructor

```csharp
    public class Player
    {
        public string Name;

        public Player()
        {
            Name = "Anonymous";
        }
    }

    var p = new Player(); // Name = "Anonymous"
```
💡 Used when: You want a safe fallback or a quick test version of the object.

### 3.2 Parameterized Constructor
```csharp
    public class Product
    {
        public string Name;
        public double Price;

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
```
💡 Used when: You want to enforce required values at creation.

### 3.3 Overloaded Constructors
```csharp
    public class ApiClient
    {
        public string Endpoint;
        public int Timeout;

        public ApiClient(string endpoint) : this(endpoint, 30) { }

        public ApiClient(string endpoint, int timeout)
        {
            Endpoint = endpoint;
            Timeout = timeout;
        }
    }
```
💡 Used when: You want to provide multiple ways to create the same object (like with or without defaults).

### 3.4 Constructor Chaining :this
```csharp
    public class User
    {
        public string Name;
        public int Age;

        public User() : this("Guest", 0) { }

        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
```
💡 Used when: You want one constructor to call another, reducing repetition.

### 3.5 Static Constructor
```csharp
    public class Config
    {
        public static string AppVersion;

        static Config()
        {
            AppVersion = "1.0.0";
        }
    }
```
💡 Used when:

* You need to initialize static fields.

* Runs only once, before any access.

### 3.6 Private Constructor and Factory Pattern
```csharp
    public class Logger
    {
        private Logger() { }

        public static Logger Create() => new Logger();
    }
```
💡 Used when: You want to prevent direct instantiation (common in factories, singletons).

### 3.7 Constructor Injection (Dependency Injection)
```csharp
    public class ReportService
    {
        private readonly IReportGenerator _generator;

        public ReportService(IReportGenerator generator)
        {
            _generator = generator;
        }
    }
```
💡 Used when: You want to inject dependencies (e.g., for testability, configuration).

### 3.8 Optional Parameters in Constructors
```csharp
    public class Button
    {
        public string Label;

        public Button(string label = "Click me")
        {
            Label = label;
        }
    }
```
💡 Used when: You want to avoid overloading just for one default value.

### 3.9 Object Initializers vs Constructors
🔸 With Constructor
```csharp
    var p = new Player("Alice");
```

🔸 With Object Initializer
```csharp
    var p = new Player { Name = "Alice" };
```

```bash
    Constructor                     Object Initializer

    Enforces required fields            Optional, flexible

    Can include logic                   Can't include logic

    Good for validation/injection       Good for config/data models
```

### 3.10. Real-World Constructor Patterns
```bash
    Pattern                     Usage Example                       Why It's Useful

    Default + parameterized     Most service classes                Ease of use + flexibility

    Static constructor          Config, constants, logging setup    One-time setup

    Private constructor         Singleton, factory                  Controlled instantiation

    Chained constructors        Form input models, data DTOs        Reduce repeated logic

    Dependency injection        Repositories, services, controllers Testability, decoupling
```

### 3.11. Common Mistakes
❌ Forgetting this() leads to duplicated logic.

❌ Doing too much work in a constructor (e.g., DB calls).

❌ Not validating parameters in constructors (leading to bad state).

## 4. Inheritance
[← Back to TOP](#table-of-contents)
- [4.1. Basic Inheritance](#41-basic-inheritance)
- [4.2. Protected Access](#42-protected-access)
- [4.3. Constructor Chaining with base](#43-constructor-chaining-with-base)
- [4.4. Method Overriding with Virtual](#44-method-overriding-with-virtual)
- [4.5. Sealed Method or Class](#45-sealed-method-or-class)
- [4.6. Hiding Methods](#46-hiding-methods)
- [4.7. When NOT to Use Inheritance](#47-when-not-to-use-inheritance)
- [4.8. Real-World Examples](#48-real-world-examples)

### 4.1. Basic Inheritance
```csharp
    public class Animal
    {
        public void Eat() => Console.WriteLine("Eating...");
    }

    public class Dog : Animal
    {
        public void Bark() => Console.WriteLine("Bark!");
    }
```
💡 Used when: You want to reuse common logic across multiple classes.

### 4.2. Protected Access
```csharp
    public class Vehicle
    {
        protected int speed;

        public void Accelerate() => speed += 10;
    }

    public class Car : Vehicle
    {
        public void ShowSpeed() => Console.WriteLine($"Speed: {speed}");
    }
```
💡 Protected = visible to child classes, but not outside.

### 4.3. Constructor Chaining with base
```csharp
    public class Person
    {
        public Person(string name)
        {
            Console.WriteLine($"Person: {name}");
        }
    }

    public class Employee : Person
    {
        public Employee(string name) : base(name)
        {
            Console.WriteLine($"Employee: {name}");
        }
    }
```
💡 Use base(...) to call parent constructor.

### 4.4. Method Overriding with Virtual
```csharp
    public class Animal
    {
        public virtual void Speak() => Console.WriteLine("Animal speaks");
    }

    public class Cat : Animal
    {
        public override void Speak() => Console.WriteLine("Meow");
    }
```

### 4.5. Sealed Method or Class
```csharp
    public sealed class FinalClass { }

    public class Base
    {
        public virtual void DoSomething() { }
    }

    public class Sub : Base
    {
        public sealed override void DoSomething() { }
    }
```
💡 Sealed = no further inheritance or overriding.

### 4.6. Hiding Methods
```csharp
    public class Base
    {
        public void Print() => Console.WriteLine("Base");
    }

    public class Derived : Base
    {
        public new void Print() => Console.WriteLine("Derived");
    }
```
⚠️ Not polymorphic – calling through base ref will call base method.

### 4.7. When NOT to Use Inheritance
* If the relationship is not "is-a".

* If it causes tight coupling.

* Prefer composition when behavior varies at runtime.

### 4.8. Real-World Examples
```bash
    Base Class      Derived Class                   Context Example

    Controller      HomeController                  ASP.NET MVC/WebAPI

    Animal          Dog, Cat                        Game or Simulation

    Stream          FileStream, MemoryStream        System.IO namespace
```

## 5. Polymorphism
[← Back to TOP](#table-of-contents)
- [5.1. Method Overriding (Runtime Polymorphism)](#51-method-oOverriding-runtime-polymorphism)
- [5.2. Method Overloading (Compile-time Polymorphism)](#52-method-overloading-compile-time-polymorphism)
- [5.3. Polymorphic Behavior with Base References](#53-polymorphic-behavior-with-base-references)
- [5.4. Covariance and Contravariance (Generics)](#54-covariance-and-contravariance-generics)
- [5.5. When to Use Polymorphism](#55-when-to-use-polymorphism)

### 5.1. Method Overriding (Runtime Polymorphism)
```csharp
    public class Animal
    {
        public virtual void Speak() => Console.WriteLine("Animal sound");
    }

    public class Dog : Animal
    {
        public override void Speak() => Console.WriteLine("Woof");
    }
```
💡 Use virtual and override to change behavior based on object type at runtime.

### 5.2. Method Overloading (Compile-time Polymorphism)
```csharp
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public double Add(double a, double b) => a + b;
    }
```
💡 Use when you want the same method name, but different parameter types.

### 5.3. Polymorphic Behavior with Base References
```csharp
    Animal myAnimal = new Dog();
    myAnimal.Speak(); // Calls Dog's Speak (runtime polymorphism)
```
💡 When an object is treated as its base type, but the runtime behavior is determined by the actual object type.

### 5.4. Covariance and Contravariance (Generics)
```csharp
    public class Animal { }
    public class Dog : Animal { }

    public class AnimalShelter<T>
    {
        public void AddAnimal(T animal) { }
    }

    public class DogShelter : AnimalShelter<Dog> { }

    AnimalShelter<Animal> shelter = new DogShelter(); // Covariant
```
💡 Covariance allows you to use derived types where base types are expected. Contravariance allows reverse.

### 5.5. When to Use Polymorphism
* Method overriding is for runtime behavior changes.

* Method overloading for same action with different input types.

## 6. Abstraction
[← Back to TOP](#table-of-contents)
- [6.1. Abstract Class](#61-abstract-class)
- [6.2. Abstract Methods](#62-abstract-methods)
- [6.3. Interface vs Abstract Class](#63-interface-vs-abstract-class)
- [6.4. When NOT to Use Abstraction](#64-when-not-to-use-abstraction)

### 6.1. Abstract Class

```csharp
    public abstract class Shape
    {
        public abstract void Draw(); // No implementation
    }

    public class Circle : Shape
    {
        public override void Draw() => Console.WriteLine("Drawing Circle");
    }
```
💡 Use for shared base class with common behavior.

### 6.2 Abstract Methods
```csharp
    public abstract class Vehicle
    {
        public abstract void Start();
    }

    public class Car : Vehicle
    {
        public override void Start() => Console.WriteLine("Car started");
    }
```
💡 Abstract methods define a contract but defer implementation.

### 6.3. Interface vs Abstract Class
```bash
    Feature                 Abstract Class                  Interface

    Methods                 Can have implementation         No implementation

    Fields                  Can have fields                 Cannot have fields

    Constructors            Yes                             No

    Multiple Inheritance    No                              Yes
```
💡 Use abstract class for shared logic, interface for contracts that can be implemented by any class.

### 6.4. When NOT to Use Abstraction
* Don't overuse when simple implementation suffices.

* Prefer interfaces when dealing with external contracts.

## 7. Encapsulation
[← Back to TOP](#table-of-contents)
- [7.1. Private Fields with Getter or Setter Methods](#71-private-fields-with-getter-or-setter-methods)
- [7.2. Using Properties (Auto-implemented)](#72-using-properties-auto-implemented)
- [7.3. Read-Only Properties](#73-read-only-properties)
- [7.4. Encapsulation with Access Modifiers](#74-encapsulation-with-access-modifiers)
- [7.5. Benefits of Encapsulation](#75-benefits-of-encapsulation)

### 7.1 Private Fields with Getter or Setter Methods
```csharp
    public class Account
    {
        private double balance;

        public void Deposit(double amount)
        {
            if (amount > 0) balance += amount;
        }

        public double GetBalance() => balance;
    }
```
💡 Encapsulating data ensures controlled access, preventing invalid state changes.

### 7.2. Using Properties (Auto-implemented)
```csharp
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
```
💡 Use properties to simplify data encapsulation.

### 7.3. Read-Only Properties
```csharp
    public class Person
    {
        public string Name { get; private set; }
        
        public Person(string name)
        {
            Name = name;
        }
    }
```
💡 Use when you want controlled access for initialization-only.

### 7.4. Encapsulation with Access Modifiers
```csharp
    public class User
    {
        private string password;

        public void SetPassword(string value)
        {
            if (value.Length >= 8) password = value;
        }

        public bool CheckPassword(string input) => password == input;
    }
```
💡 Use access modifiers (private, public, protected) to enforce visibility rules.

### 7.5. Benefits of Encapsulation
* Protects object state.

* Controls how data is accessed.

* Provides a single point of modification.

## 8. Interfaces
[← Back to TOP](#table-of-contents)
- [8.1. Defining an Interface](#81-defining-an-interface)
- [8.2. Multiple Interface Inheritance](#82-multiple-interface-inheritance)
- [8.3. Interface Segregation Principle](#83-interface-segregation-principle)
- [8.4. When to Use Interfaces](#84-when-to-use-interfaces)

### 8.1. Defining an Interface
```csharp
    public interface IWalkable
    {
        void Walk();
    }

    public class Dog : IWalkable
    {
        public void Walk() => Console.WriteLine("Dog is walking");
    }
```
💡 Use interfaces to define behavior contracts that multiple classes can implement.

### 8.2. Multiple Interface Inheritance
```csharp
    public interface IDriveable { void Drive(); }
    public interface IFlyable { void Fly(); }

    public class Drone : IDriveable, IFlyable
    {
        public void Drive() => Console.WriteLine("Driving");
        public void Fly() => Console.WriteLine("Flying");
    }
```
💡 Interfaces allow multiple inheritance of behavior.

### 8.3. Interface Segregation Principle
```csharp
    public interface IPrint { void Print(); }
    public interface IScan { void Scan(); }

    public class Printer : IPrint
    {
        public void Print() => Console.WriteLine("Printing...");
    }

    public class Scanner : IScan
    {
        public void Scan() => Console.WriteLine("Scanning...");
    }
```
💡 Split interfaces when you have too many responsibilities in one.

### 8.4. When to Use Interfaces
* When you want multiple classes to share a contract.

* When the implementation may vary but behavior stays consistent.

## 9. Access Modifiers
[← Back to TOP](#table-of-contents)
- [9.1. public Modifier](#91-public-modifier)
- [9.2. private Modifier](#92-private-modifier)
- [9.3. protected Modifier](#93-protected-modifier)
- [9.4. internal Modifier](#94-internal-modifier)
- [9.5. protected internal Modifier](#95-protected-internal-modifier)
- [9.6. When to Use Access Modifiers](#96-when-to-use-access-modifiers)
- [9.7. Real-World Example](#97-real-world-example)

### 9.1. public Modifier
```csharp
    public class User { public string Name; }
```
💡 Accessible anywhere within the program.

### 9.2. private Modifier
```csharp
    public class Car
    {
        private int speed;

        public void SetSpeed(int s) { speed = s; }
    }
```
💡 Only accessible within the same class.

### 9.3. protected Modifier
```csharp
    public class Base
    {
        protected string Name;
    }

    public class Derived : Base
    {
        public void SetName(string name) => Name = name;
    }
```
💡 Accessible within the class and its derived classes.

### 9.4. internal Modifier
```csharp
    internal class Configuration { }
```
💡 Accessible only within the same assembly.

### 9.5. protected internal Modifier
```csharp
    public class Base
    {
        protected internal string Info;
    }
```
💡 Accessible within the same assembly or from derived classes.

### 9.6. When to Use Access Modifiers
*Private: Hide internal details.

* Public: When you want something widely available.

* Protected: When derived classes need access but external code shouldn’t.

* Internal: For assemblies or libraries that shouldn't expose internal logic outside.

### 9.7. Real-World Example
```bash
    Modifier            Class           Use Case

    private             BankAccount     Encapsulating balance

    public              Logger          Accessing log methods from anywhere

    protected           BaseEntity      Derived class uses internal methods
```

## 10. Static Members
[← Back to TOP](#table-of-contents)
- [10.1. Static Fields](#101-static-fields)
- [10.2. Static Methods](#102-static-methods)
- [10.3. Static Constructors](#103-static-constructors)
- [10.4. When to Use Static Members](#104-when-to-use-static-members)

### 10.1. Static Fields
```csharp
    public class MathUtils
    {
        public static double Pi = 3.14;
    }
```
💡 Static members are shared across all instances of a class.

### 10.2. Static Methods
```csharp
    public class Calculator
    {
        public static int Add(int a, int b) => a + b;
    }
```
💡 Use static methods for utility functions or shared logic.

### 10.3. Static Constructors
```csharp
    public class Config
    {
        public static string AppVersion;

        static Config() => AppVersion = "1.0.0";
    }
```
💡 Use for initialization of static fields. Runs once.

### 10.4. When to Use Static Members
* Utility methods (Math, Logger).

* Shared resources (Configuration).

## 11. Abstract Classes vs Interfaces
[← Back to TOP](#table-of-contents)
- [11.1. Abstract Class](#111-abstract-class)
- [11.2. Interface](#112-interface)
- [11.3. When to Use What](#113-when-to-use-what)
- [11.4. Real-World Example](#114-real-world-example)

### 11.1. Abstract Class
```csharp
    public abstract class Vehicle
    {
        public void Start() => Console.WriteLine("Starting engine...");
        public abstract void Move();
    }
```
💡 Use when you need shared functionality (default implementations).

### 11.2 Interface
```csharp
    public interface IDriveable
    {
        void Drive();
    }
```
💡 Use for contract-based design (no implementation).

### 11.3. When to Use What
* Abstract Class: Use for shared logic and behavior.

* Interface: Use for defining multiple contracts.

### 11.4. Real-World Example
```bash
    Type	            Class/Interface	        Example

    Abstract Class	    Vehicle	                Shared methods like Start

    Interface	        IDriveable	            Behavior shared across different classes
```

## 12. Other Concepts
[← Back to TOP](#table-of-contents)
- [12.1. sealed Keyword](#121-sealed-keyword)
- [12.2. new Keyword (Hiding Members)](#122-new-keyword-hiding-members)
- [12.3. override Keyword](#123-override-keyword)
- [12.4. When to Use sealed, new, override](#124-when-to-use-sealed-new-override)
- [12.5. Expression-bodied members (=>)](#125-expression-bodied-members)

### 12.1. sealed Keyword
```csharp
    public sealed class FinalClass { }
```
💡 Prevents inheritance from this class. Use for complete final implementations.

### 12.2. new Keyword (Hiding Members)
```csharp
    public class Base
    {
        public void Print() => Console.WriteLine("Base Print");
    }

    public class Derived : Base
    {
        public new void Print() => Console.WriteLine("Derived Print");
    }
```
💡 Hides a base member. Not recommended unless necessary.

### 12.3. override Keyword
```csharp
    public class Base
    {
        public virtual void Speak() => Console.WriteLine("Base speaks");
    }

    public class Derived : Base
    {
        public override void Speak() => Console.WriteLine("Derived speaks");
    }
```
💡 Used to change behavior in derived classes.

### 12.4. When to Use sealed, new, override
* sealed: Final class or method (no inheritance).

* new: When deliberately hiding a member.

* override: Polymorphic method replacement.

### 12.5. Expression-bodied members (=>)
💡What Are Expression-Bodied Members?
In C#, you can use => (lambda-style syntax) to write concise one-liner members, like:

* Methods

* Properties

* Constructors

* Finalizers

* Indexers

* Getters / Setters

Use Cases of Expression-Bodied Members
Here are all the places where expression bodies can be used:

#### 12.5.1. Methods
```csharp  
    public string GetGreeting() => "Hello!";
    
    Equivalent to:
    public string GetGreeting()
    {
        return "Hello!";
    }
```
#### 12.5.2. Properties (read-only)
```csharp

    public int Age => 30;
    Or:


    public List<MenuItem> MenuItems => _menuItem;
```
#### 12.5.3. Property Getters / Setters
```csharp
    private int _value;
    public int Value
    {
        get => _value;
        set => _value = value;
    }
```
#### 12.5.4. Constructors
```csharp
    public MyClass(string name) => Name = name;

    Equivalent to:
    public MyClass(string name)
    {
        Name = name;
    }
```
#### 12.5.5. Finalizers (rare)
```csharp
    ~MyClass() => Console.WriteLine("Destroyed");
```
#### 12.5.6. Indexers
```csharp
    public string this[int index] => _names[index];
```
#### 12.5.7. Local functions
Even inside a method, you can do this:
```csharp
    void Greet() => Console.WriteLine("Hi!");
```
