namespace OOPS
{
    // a class that is in a different file
    // for Hello() to work in Program.cs, minimum requirement is `public static` before the `void Hello(){...}` below
    // `static` before `class Messages` restricts class to being a utility class, can't instantiate objects from a static class
    static class Messages
    {
        public static void Hello()
        {
            Console.WriteLine("Hello! Welcome to the program!");
        }
        public static void Waiting()
        {
            Console.WriteLine("Waiting for input!");
        }
        public static void Bye()
        {
            Console.WriteLine("Bye!...Thanks for visiting!");
        }
    }
}
