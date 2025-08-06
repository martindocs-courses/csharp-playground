/*
    * A special type of class that cannot be instantiated and is meant to be inherited only
    * Abstract Class: A base with optional shared logic and partial implementation.
    * An abstract class can have both abstract and regular methods.
    * We use the override keyword to override the base class method.
    * Can have fields, props and constructors.
    
    Use an abstract class when:
    * You want to share common behavior and/or state
    * You expect future classes to extend and customize base functionality
    * You need to partially implement behavior, leaving some details to subclasses.
    * You only need single inheritance
 */

using OOP_Abstraction.Notification_System;
using project1 = OOP_Abstraction.Shipping_Calculator;
using project2 = OOP_Abstraction.Report_Generator;
using project3 = OOP_Abstraction.Notification_System;

// PROJECT 1
var standardShippingCost = new project1.StandardShipping();
Console.WriteLine($"Standard shipping cost: {standardShippingCost.ShippingCost(100)}");

//var expressShippingCost = new project1.ExpressShipping();
//Console.WriteLine($"Express shipping cost: {expressShippingCost.ShippingCost(100)}");

// PROJECT 2
//var reportGenerator = new project2.Report();
//reportGenerator.Generate();

// PROJECT 3
//var emailMessage = new project3.EmailNotifier();
//var smsMessage = new project3.SMSNotifier();
//var pushMessage = new project3.PushNotifier();

//emailMessage.Send();
//smsMessage.Send();
//pushMessage.Send();
