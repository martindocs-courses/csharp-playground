/*
    * Polymorphism means "many forms." In OOP, it allows different classes to be treated through a common interface or base class, but each can behave differently.
    * The base class method overrides the derived class method, when they share the same name. And we actually using method hiding, not overriding.
    * To override the base class method and get true Polymorphism, we add the virtual keyword to the method inside the base class, and by using the override keyword for each derived class methods
    * Two Main Types of Polymorphism:
        Type1 : Compile-time (Static)   

        Description: Method overloading, operator overloading 
    
        Example: Add(int a, int b) vs Add(double a, double b)                
        
        --------------------------------------------------------        

        Type2: Run-time (Dynamic)
        
        Description: Inheritance + method overriding          

        Example: Base class reference calling overridden method in derived class 

    * Abstract classes enforce overriding, so all derived classes must provide their own implementation
    * Favor composition + interfaces over deep inheritance trees
    * Keep base classes abstract if they’re not meant to be instantiated
*/

using System.Reflection.Metadata;
using project1 = OOP_Polymorphism.Document_Renderer;
using project2 = OOP_Polymorphism.Shape_Area_Calculator;

// PROJECT 1 - ver1
//var documentRender = new project1.Document();

// Base Class References Can Point to Derived Objects
//project1.Document documentPdf = new project1.PDFDocument();  // call PDFDocument.Render() if overridden properly
//project1.Document documentWord = new project1.WordDocument();
//documentRender.Render();
//documentPdf.Render();
//documentWord.Render();

// PROJECT 1 - ver2
//var docRender = new project1.DocumentRender();
//docRender.Render();

// PROJECT 2
var shapeCircleArea = new project2.Circle(5);
Console.WriteLine(shapeCircleArea.CalculateArea());

var shapeRectangleArea = new project2.Rectangle(15, 20);
Console.WriteLine(shapeRectangleArea.CalculateArea());
