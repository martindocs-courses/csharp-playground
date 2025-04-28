using game_data_parser;

/*
     Abstract Class:

        Use when you want to share code between classes.

        Can have both code and abstract methods (methods without code).

        Can have constructors and fields.

    Interface:

        Use when you just want to define a behavior (what the class can do) without worrying about how it does it.

        Can only have method signatures, properties, and events (no code).

        A class can implement multiple interfaces but only inherit from one abstract class.

Feature	                    Abstract Class	                        Interface
Can contain implementation	   Yes (can have implemented methods)      No (only method signatures)
Can contain fields	            Yes                                     No
Can have constructors	        Yes	                                  No
Access Modifiers	            Yes (e.g., public, protected)	       No (everything is implicitly public)
Inheritance	                 Single inheritance (can only inherit from one abstract class)	Multiple inheritance (can implement multiple interfaces)
Use case	                    Common functionality to share, default behavior	Defining capabilities or behaviors
 
 */

var startGame = new ConsoleUI();
startGame.AskUser();

Console.ReadLine();



