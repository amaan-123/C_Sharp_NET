class Test
{
    static void Main()
    {
        var obj = new InternalClass(); // ✅ works — same assembly
        obj.Show();                    // ✅ works — same assembly
        Console.ReadLine();
    }
}