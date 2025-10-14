
namespace OOP_Interface.Payment_Processor
{
    
    public interface IPayment{
        public void ProcessPayment();
    }

    public class CreditCard : IPayment 
    {
        public void ProcessPayment() => Console.WriteLine("Pay by Credit Card");
    }

    public class PayPal : IPayment
    {
        public void ProcessPayment() => Console.WriteLine("Pay by Paypal");
    }

    public class PaymentProcess {
        public void MakePayment(IPayment payment){
            payment.ProcessPayment();
        }
    }
}
