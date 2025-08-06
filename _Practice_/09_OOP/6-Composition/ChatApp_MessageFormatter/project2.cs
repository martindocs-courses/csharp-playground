
namespace OOP_Composition.ChatApp_MessageFormatter
{
    public class MessageFormatter
    {
        public string StringFormat(string user) => user.ToUpper();
    }

    public class ChatApp {
        
        private readonly MessageFormatter _messageFormatter;
    
        public ChatApp(MessageFormatter messageFormatter)
        {
            _messageFormatter = messageFormatter;
        }

        public void SendingMessage(string userName){
            string name = _messageFormatter.StringFormat(userName);

            Console.WriteLine($"Sending message to: {name}");
        }

    }
}
