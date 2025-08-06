/*
    * Composition means a class "has-a" another class. Example: A Car has an Engine.
    * It favors reusability and modularity.  
    * Composition supports looser coupling than inheritance.
    * Better Flexibility & Extensibility
    * Composition is preferred over inheritance in modern OOP because:
       - Inheritance creates tight coupling and rigid hierarchies.
       -  Composition allows behavioral variation without altering class structure.
    * Composition works naturally with constructor injection, enabling:
        - Testability
        - Mocking
        - Swapping at runtime
    * Unlike inheritance, changes to composed objects don't break subclasses. You don’t inherit unwanted behavior — you only use what you compose.
*/

using project1 = OOP_Composition.Stopwatch_TimeTracker;
using project2 = OOP_Composition.ChatApp_MessageFormatter;

// PROJECT 1
//var stopwatch = new project1.StopWatch(new project1.TimeTracker());
//stopwatch.TimingInfo();

// PROJECT 2
var message = new project2.ChatApp(new project2.MessageFormatter());
message.SendingMessage("Martin");