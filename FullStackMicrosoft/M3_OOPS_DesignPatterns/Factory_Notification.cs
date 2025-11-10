////Factory Pattern Example: Interface
//public interface INotification
//{
//    void Send(string message);
//}


////Factory Pattern Example: Derived classes
//public class EmailNotification : INotification
//{
//    public void Send(string message)
//    {
//        Console.WriteLine("Sending Email: " + message);
//    }
//}

//public class SMSNotification : INotification
//{
//    public void Send(string message)
//    {
//        Console.WriteLine("Sending SMS: " + message);
//    }
//}

//public class NoNotification : INotification
//{
//    public void Send(string message)
//    {
//        Console.WriteLine("Nothing to notify." + message);
//    }
//}


////Factory Pattern Example: Factory
//public class NotificationFactory
//{
//    public INotification CreateNotification(string channel)
//    {
//        if (channel == "Email")
//        {
//            return new EmailNotification();
//        }
//        else if (channel == "SMS")
//        {
//            return new SMSNotification();
//        }
//        else { return new NoNotification(); }
//    }
//}
