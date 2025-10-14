/*
    * Interface: A contract — "these methods must be implemented."
    * By default, members of an interface are abstract and public.
    * Interfaces can contain properties and methods, but not fields.
    * An interface cannot contain a constructor.
    * To implement multiple interfaces, separate them with a comma.
    
    Use an interface when:
    * You want to define a capability (e.g., ILogger, IShape, IDisposable)
    * You want loose coupling
    * You need multiple inheritance
    * You’re working with dependency injection or testing
 */

using project1 = OOP_Interface.Payment_Processor;
using project2 = OOP_Interface.Notification_System;

// PROJECT 1
var payment = new project1.PaymentProcess();
payment.MakePayment(new project1.CreditCard());
payment.MakePayment(new project1.PayPal());

// PROJECT 2
//var sendMessage = new project2.Notification();
//sendMessage.SendMessage(new project2.EmailNotification(), project2.NotificationPriority.Normal);
//sendMessage.SendMessage(new project2.SMSNotification(), project2.NotificationPriority.High);