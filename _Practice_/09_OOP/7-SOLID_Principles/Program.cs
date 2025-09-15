/*
    S - Single Responsibility Principle (SRP)
    O - Open-Close Principle (OCP)
    L - Liskov Substitution Principle (LSP)
    I - Interface Segregation Principle (ISP)
    D - Dependency Inversion Principle (DIP))
*/
using srp_project1 = OOP_SOLID_Principles.SRP_Invoice_Generator;
using srp_project2 = OOP_SOLID_Principles.SRP_Logger;

using ocp_project1 = OOP_SOLID_Principles.OCP_Invoice_Tax_Calculator;
using ocp_project2 = OOP_SOLID_Principles.OCP_AreaOfShape;

using lsp_project1 = OOP_SOLID_Principles.LSP_Flaying_Birds;

using isp_project1 = OOP_SOLID_Principles.ISP_Printer;
using isp_project2 = OOP_SOLID_Principles.ISP_Vehicle;

using dip_project1 = OOP_SOLID_Principles.DIP_Sender;
using dip_project2 = OOP_SOLID_Principles.DIP_Quiz_Engine;

/*
    S - Single Responsibility Principle (SRP):
    * A class should have only one reason to change. Which means that a class should have only one job or responsibility
*/

// PROJECT (SRP) 1
//var invoiceGenerator = new srp_project1.PrintInvoice();
//var invoiceCalculator = new srp_project1.InvoiceCalculator();
//var sellerInfo = new srp_project1.SellerInvoiceInfo();
//var buyerInfo = new srp_project1.BuyerInvoiceInfo();
//var invoiceData = new srp_project1.InvoiceData(sellerInfo, buyerInfo);

//invoiceGenerator.Print(invoiceData);
//invoiceCalculator.CalculateTotals(invoiceData);
//Console.WriteLine(new string('-', 20)); // new string(char, int)
//Console.WriteLine($"Total {invoiceCalculator.GetTotal}");

// PROJECT (SRP) 2
//var logs = new srp_project2.WriteToFile(new srp_project2.FormatLogMessage());
//logs.SaveLog("This is first log\n");

//var sendMessage = new srp_project2.SendMessage();
//sendMessage.Sent(new srp_project2.ViaEmail());

/*
    O - Open-Close Principle (OCP)
    * You should be able to add new behavior to a class without changing its source code.
    * This is usually achieved through abstraction (interfaces or base classes) and polymorphism.
*/

// PROJECT (OCP) 1
//var invoiceTax = new ocp_project1.TaxService(new ocp_project1.VatTaxCalculator());
//var invoice = new ocp_project1.Invoice { Total = 10000m };
//Console.WriteLine(invoiceTax.GetTax(invoice));

// PROJECT (OCP) 2
//var circle = new ocp_project2.Circle(100);
//var shapeCalculator = new ocp_project2.GetShape(circle);
//shapeCalculator.CalculateArea();

/*
    L - Liskov Substitution Principle (LSP):
    * If class B is a subclass of class A, then objects of type A should be replaceable with objects of type B without altering the correctness of the program. OR Object of a superclass should be replaceable with objects of its subclass without affecting the correctness of the program.
*/

// PROJECT (LSP) 1
//var salary = new lsp_project1.Calculate();
//salary.Process(new lsp_project1.FullTimeEmployee());

/*
    I - Interface Segregation Principle:
    * Clients should not be forced to depend on interfaces they do not use.
*/

// PROJECT (ISP) 1
//var printer = new isp_project1.OldPrinter();
//printer.Print();

// PROJECT (ISP) 2
//var car = new isp_project2.Car();
//car.Drive();

/*
    D - Dependency Inversion Principle:
    * High-level modules should not depend on low-level modules. Both should depend on abstractions.
*/

// PROJECT (DIP) 1
//var message= new dip_project1.UserService(new dip_project1.Message(), "Hello");
//message.StmpMessage();

// PROJECT (DIP) 2
var xmlRepository = new dip_project2.XmlQuizRepository();
var repository = new dip_project2.QuizEngine(xmlRepository);
repository.Connect();