////Observer Pattern Example: Interface
//public interface IObserver
//{
//    void Update(float temperature);
//}

////Observer Pattern Example: Subject Class
//public class WeatherStation
//{
//    private List<IObserver> observers = new List<IObserver>();
//    private float temperature;

//    public void RegisterObserver(IObserver observer)
//    {
//        observers.Add(observer);
//    }

//    internal void RemoveObserver(IObserver observer)
//    {
//        observers.Remove(observer);
//        Console.WriteLine($"{observer} removed.");
//    }
//    public void NotifyObservers()
//    {
//        foreach (var observer in observers)
//        {
//            observer.Update(temperature);
//        }
//    }

//    public void SetTemperature(float newTemperature)
//    {
//        temperature = newTemperature;
//        NotifyObservers();
//    }
//}
////Observer Pattern Example: Derived classes
//public class PhoneDisplay : IObserver
//{
//    public void Update(float temperature)
//    {
//        Console.WriteLine("Phone display: Temperature updated to " + temperature + " degrees.");
//    }
//}

//public class DesktopDisplay : IObserver
//{
//    public void Update(float temperature)
//    {
//        Console.WriteLine("Desktop display: Temperature updated to " + temperature + " degrees.");
//    }
//}
////Observer Pattern Example: Instances
//public class Program
//{
//    public static void Main(string[] args)
//    {
//        WeatherStation weatherStation = new WeatherStation();

//        PhoneDisplay phoneDisplay = new PhoneDisplay();

//        DesktopDisplay desktopDisplay = new DesktopDisplay();

//        weatherStation.RegisterObserver(phoneDisplay);
//        weatherStation.RegisterObserver(desktopDisplay);

//        weatherStation.SetTemperature(25.0f);
//        weatherStation.RemoveObserver(phoneDisplay);
//        weatherStation.SetTemperature(22.0f);


//        Console.ReadLine();
//    }
//}

