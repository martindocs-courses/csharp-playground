/* Navigation Notes
 
     There are three main groups of design patterns:
    * Creational: the different way to create object
    * Structural: the relationship between those objects
    * Behavioral: the interaction or communication between those objects
        
    Behavioral patterns                                                    : line 18
    - memento pattern                                                      : line 
    

    Tips:
    - press ctr + g in Visual Studio to jump to specific line.
*/

/* Behavioral patterns */
// MEMENTO PATTERN - allows to capture and store an object’s internal state so it can be restored later, without violating encapsulation. This is useful when we want to implement undo/redo functionality or time-travel-type features.

/*
    The Memento pattern involves three main components:
    - Originator – The object whose state needs to be saved.
    - Memento – A value object that holds the state of the Originator.
    - Caretaker – The object that requests saves and restores from the Memento but doesn't access the contents. 
 */