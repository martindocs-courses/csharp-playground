
namespace OOP_SOLID_Principles.DIP_Sender
{
    public interface ISend{
        public void SendMessage(string message);
    }

    public class Message : ISend
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class UserService{
        private readonly ISend _sender;
        private string messagBody;

        /*
            - Interfaces define what methods a class should have.
            - Classes implement those interfaces and provide the actual behavior.
            - You can pass any class that implements an interface or abstraction classes into a constructor expecting the interface.
            - This enables flexible, testable, and decoupled code.         
         */
        public UserService(ISend sender, string messageBody)
        {
            _sender = sender;
            this.messagBody = messageBody;
        }

        public void StmpMessage(){
            _sender.SendMessage($"STMP msg: {this.messagBody}");
        }

        public void EmailMessage(){
            _sender.SendMessage($"Email msg: {this.messagBody}");        
        }

    }
}
