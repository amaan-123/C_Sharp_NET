public class Database
{
    private static Database? _instance;

    private Database()
    {
        Console.WriteLine("Database connection established.");
    }

    public static Database GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Database();
        }
        return _instance;
    }
}

public class Program
{
    public static void Main(string[] args)
    {

        Random rnd = new Random();
        rnd.Next(0, 2);
        if (rnd == 0)
        {

        }

        Console.ReadLine();
    }
}

