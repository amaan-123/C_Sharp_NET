
Console.WriteLine("Type the string to edit (only use alphabets a-z and symbols: * and ~)");

string S = Console.ReadLine();
char[] sChars = S.Trim().ToCharArray();

if (ConstraintCheck(S))
{
    Console.WriteLine("correct input");
    Console.WriteLine("Edited output is:");
    Console.WriteLine(SmartEdit(S));
}
else Console.WriteLine("incorrect input");


bool ConstraintCheck(string S)
{
    if ((S.Length >= 1) && (S.Length <= Math.Pow(10, 5)))
    {
        //check ascii of char
        //97-122 || 42
        foreach (char c in sChars)
        {
            if ((((int)c >= 97 && (int)c <= 122) || ((int)c == 42) || ((int)c == 126)) == false)
            {
                return false;
            }
        }
        return true;
    }
    else return false;
}

string SmartEdit(string S)
{
    for (int i = 0; i < S.Length; i++)
    {

        //star present compute
        if (S[i] == '*')
        {
            if (i == 0)
            {
                S = S.Remove(i, 1);
                i = -1;
            }
            else if (i >= 1)
            {
                S = S.Remove(i - 1, 2);
                i = i - 2;
            }
        }

        //tilde present compute
        else if (S[i] == '~')
        {
            if (i == 0)
            {
                S = S.Remove(i, 1);
                i = -1;
            }
            else if (i == 1)
            {
                S = S.Remove(i - 1, 2);
                i = i - 2;
            }
            else if (i >= 2)
            {
                sChars = S.ToCharArray();
                char temp = sChars[i - 2];
                sChars[i - 2] = S[i - 1];
                sChars[i - 1] = temp;
                S = new string(sChars);
                S = S.Remove(i, 1);
                i = i - 1;
            }
        }
    }

    //elsemessagenostar

    return S;
}


