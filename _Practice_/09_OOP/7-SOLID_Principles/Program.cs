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
using OOP_SOLID_Principles.OCP_Invoice_Tax_Calculator;

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
var invoiceTax = new ocp_project1.TaxService(new VatTaxCalculator());
var invoice = new Invoice { Total = 10000m };
Console.WriteLine(invoiceTax.GetTax(invoice));
