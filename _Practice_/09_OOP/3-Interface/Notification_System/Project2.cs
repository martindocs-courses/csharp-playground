
namespace OOP_Interface.Notification_System
{
    public interface INotification{
        public void Send(string message, NotificationPriority priority);
    }

    public class EmailNotification : INotification {
        public void Send(string message, NotificationPriority priority) => Console.WriteLine($"Send: {message}, {priority} priority Email notification.");
    }

    public class SMSNotification : INotification {
        public void Send(string message, NotificationPriority priority) => Console.WriteLine($"Send: {message}, {priority} priority SMS notification.");
    }

    public class Notification{
        public void SendMessage(INotification notification, NotificationPriority priority){
            notification.Send("Message", priority);
        }
    }

    public enum NotificationPriority { 
        High, Low, Normal
    }
}
