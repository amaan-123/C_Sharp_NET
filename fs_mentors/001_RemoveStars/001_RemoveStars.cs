
Console.WriteLine("Type the string to remove stars from(characters preferably lowercase)");

string S = Console.ReadLine();
char[] sChars = S.ToCharArray();

if (ConstraintCheck(S))
{
    Console.WriteLine("correct input");
    StarRemoval(S);
}
else Console.WriteLine("incorrect input");


bool ConstraintCheck(string S)
{
    if ((S.Length >= 1) && (S.Length <= 100))
    {
        //check ascii of char
        //97-122 || 42
        foreach (char c in sChars)
        {
            if ((((int)c >= 97 && (int)c <= 122) || ((int)c == 42)) == false)
            {
                return false;
            }
        }
        return true;
    }
    else return false;
}

string StarRemoval(string S)
{
    //ifstarpresentcompute
    for (int i = 1; i < S.Length; i++)
    {

        if ((S[i] == '*') && (S[i - 1] != '*'))
        {
            S = S.Remove(i - 1, 2);
            Console.WriteLine(S);
            i = i - 2;
        }
    }

    //elsemessagenostar

    return S;
}


