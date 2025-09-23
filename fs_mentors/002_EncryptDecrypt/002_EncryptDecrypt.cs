
string O = "";
string K = "qwertyuiopasdfghjklzxcvbnm";
string letters = "abcdefghijklmnopqrstuvwxyz";

Console.WriteLine("Choose Operation: type \"encrypt\" or \"decrypt\"");
string? userInput = Console.ReadLine();
string S = "";

if (userInput.ToLower().Trim() == "encrypt")
{
    Console.WriteLine("Enter words to encrypt:");
    userInput = Console.ReadLine();
    S = EncryptInput(userInput);
    Console.WriteLine("Encryption Output: \t" + S);
}
else if (userInput.ToLower().Trim() == "decrypt")
{
    Console.WriteLine("Enter words to decrypt:");
    userInput = Console.ReadLine();
    S = DecryptInput(userInput);
    Console.WriteLine("Decryption Output: \t" + S);
}


string EncryptInput(string S)
{
    char[] chars = S.ToCharArray();
    for (int i = 0; i < chars.Length; i++)
    {
        if (letters.Contains(char.ToLower(chars[i])))
        {
            int position = letters.IndexOf(char.ToLower(chars[i]));
            //check its case
            if (char.IsLower(chars[i]))
            {
                chars[i] = char.ToLower(K[position]);
            }
            else
            {
                chars[i] = char.ToUpper(K[position]);
            }
        }
    }
    return new string(chars);
}

string DecryptInput(string S)
{
    char[] chars = S.ToCharArray();
    for (int i = 0; i < chars.Length; i++)
    {
        if (letters.Contains(char.ToLower(chars[i])))
        {
            int position = K.IndexOf(char.ToLower(chars[i]));
            //check its case
            if (char.IsLower(chars[i]))
            {
                chars[i] = char.ToLower(letters[position]);
            }
            else
            {
                chars[i] = char.ToUpper(letters[position]);
            }
        }
    }
    return new string(chars);
}
