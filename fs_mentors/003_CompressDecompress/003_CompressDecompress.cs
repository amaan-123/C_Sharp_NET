string O = "";
string? userInput = "";
string S = "";

// Take operation from user
Console.WriteLine("Type Operation: compress/decompress");
userInput = Console.ReadLine();
if (userInput != null && userInput.Trim() != "")
{
    if (userInput.ToLower() == "compress")
    {
        O = "compress";
    }
    else if (userInput.ToLower() == "decompress")
    {
        O = "decompress";
    }
    else
    {
        Console.WriteLine("Invalid selection");
        return;
    }
}

if (O == "compress")
{
    Console.WriteLine("Enter words to compress:");
    userInput = Console.ReadLine();
    if (userInput != null && userInput.Trim() != "")
    {
        S = userInput.Trim();
        S = Compress(S);
        Console.WriteLine(S);
    }
    Console.ReadLine();
}
else if (O == "decompress")
{
    Console.WriteLine("Enter words to decompress:");
    userInput = Console.ReadLine();
    if (userInput != null && userInput.Trim() != "")
    {
        S = userInput.Trim();
        S = Decompress(S);
        Console.WriteLine(S);
    }
    Console.ReadLine();
}

string Compress(string S)
{
    string[] splitS = S.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string compressed = "";
    int i = 0;
    while (i < splitS.Length)
    {
        int count = 1;
        int j = i + 1;
        while (j < splitS.Length && splitS[j] == splitS[i])
        {
            count++;
            j++;
        }
        if (count > 1)
        {
            compressed += splitS[i] + count + " ";
        }
        else
        {
            compressed += splitS[i] + " ";
        }
        i += count;
    }
    return compressed.TrimEnd();
}

//my decompress method
string Decompress(string S)
{
    string[] splitS = S.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    foreach (var word in splitS)
    {
        //if (word contains number){
        //    extract number;
        //    search for word in string;
        //    replace strings word with multiples;
        //    restart process with next word of splits;
        //}

        //else if (word doesnt contain number){
        //    restart process with next word of splits;
        //}
        if (word.IndexOfAny(digits) >= 0)
        {
            int startIndex = word.IndexOfAny(digits);
            int lastIndex = word.LastIndexOfAny(digits);
            int repetitionCount = 0;
            string repeatedWords = "";
            if (lastIndex >= startIndex)
            {
                repetitionCount = int.Parse(word.Substring(startIndex, (lastIndex - startIndex) + 1));
                for (int i = 0; i < repetitionCount; i++)
                {
                    repeatedWords += $"{word.Substring(0, startIndex)} ";
                }
            }
            if (word != splitS[splitS.Length - 1])
            {
                S = S.Replace($"{word} ", repeatedWords);
            }
            else
            {
                S = S.Replace(word, repeatedWords);
            }

        }
    }
    return S.TrimEnd();
}

////copilot compress method
//string Compress(string S)
//{
//    var words = S.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//    var result = new List<string>();
//    int i = 0;
//    while (i < words.Length)
//    {
//        int count = 1;
//        while (i + count < words.Length && words[i] == words[i + count])
//        {
//            count++;
//        }
//        if (count > 1)
//            result.Add($"{words[i]}{count}");
//        else
//            result.Add(words[i]);
//        i += count;
//    }
//    return string.Join(" ", result);
//}

//copilot decompress method
//string Decompress(string S)
//{
//    var words = S.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//    var result = new List<string>();
//    var regex = new Regex(@"^([A-Za-z]+)(\d+)?$");
//    foreach (var word in words)
//    {
//        var match = regex.Match(word);
//        if (match.Success)
//        {
//            string baseWord = match.Groups[1].Value;
//            int count = match.Groups[2].Success ? int.Parse(match.Groups[2].Value) : 1;
//            for (int i = 0; i < count; i++)
//                result.Add(baseWord);
//        }
//    }
//    return string.Join(" ", result);
//}

//my first compress method attempt
//string Compress(string S)
//{
//    string[] splitS = S.Split(' ');
//    int count = 1;
//    int startIndex = 0;
//    string word = "";
//    for (int i = 0; i < splitS.Length; i++)
//    {
//        startIndex = i;
//        word = splitS[startIndex];
//        for (int j = i + 1; j < splitS.Length; j++)
//        {
//            if (splitS[j] == splitS[i])
//            {
//                if (j == i + 1)
//                {
//                    i++;
//                    count++;
//                }
//                else
//                {
//                    if (count > 1)
//                    {
//                        splitS[startIndex] += $"{count}";
//                        for (int k = startIndex + 1; k <= startIndex + (count - 1); k++)
//                        {
//                            splitS[k] = "";
//                        }
//                    }
//                    break;
//                }
//            }

//        }
//    }
//    S = String.Join(" ", splitS);
//    return S;
//}