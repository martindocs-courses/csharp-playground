
using System.Threading.Channels;

namespace OOP_Abstraction.Notification_System
{
    public abstract class Notifier{
        public abstract void Send();
    }

    public class EmailNotifier : Notifier{
        public override void Send() => Console.WriteLine("Email send.");
    }

    public class SMSNotifier : Notifier {
        public override void Send() => Console.WriteLine("SMS send.");
    }

    public class PushNotifier : Notifier {
        public override void Send() => Console.WriteLine("Push message send.");
    }
}
