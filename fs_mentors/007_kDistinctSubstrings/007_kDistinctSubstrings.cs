Console.WriteLine("enter a lowercase string:");
string S = Console.ReadLine().ToLower();
if (S.Length >= 1 && S.Length <= 200000)
{
    Console.WriteLine("enter an integer:");
    int K = int.Parse(Console.ReadLine());
    if (K >= 1 && K <= 26)
    {
        Console.WriteLine(DistinctCharSubstringCount(S));
    }
    else
    {
        Console.WriteLine("Out of bounds number of letters of language");
    }

    int DistinctCharSubstringCount(string S)
    {
        int count = 0;
        string substring = "";
        bool letterRepeats = false;
        for (int i = 0; i + K <= S.Length; i++)
        {
            substring = S.Substring(i, K);
            foreach (char letter in substring)
            {
                if (substring.IndexOf((letter)) != substring.LastIndexOf((letter)))
                {
                    letterRepeats = true;
                    break;
                }
            }
            if (letterRepeats == false)
            {
                count++;
            }
        }
        return count;
    }

}
