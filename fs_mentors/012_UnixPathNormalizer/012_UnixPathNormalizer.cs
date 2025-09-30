//Unix Path Normalizer — Resolve '.' and '..'
//Given an absolute Unix-style path P, simplify it to its canonical form:
//• A single slash '/' is the root.
//• Collapsing multiple slashes '//' into one.
//• Resolve '.' (current directory) and '..' (parent directory) without going above root.
//• Keep path components case-sensitive; no symlinks.

//Return the canonical path as a string.

//Input Format
//A single line string P with 1 ≤ |P| ≤ 10^5, consisting of ASCII letters, digits, '_', '-', '.', and '/'. P is absolute (starts with '/').
//Output Format
//Print the canonical path.
//Examples
//Example 1
//Input:
/// usr//local/./bin/../share///
//Output:
/// usr / local / share

//Example 2
//Input:
/// .. / .. / a /./ b / .. / c
//Output:
/// a / c

//Example 3
//Input:
///
//Output:
///
//Constraints & Notes
//• Use a stack to process components in O(n).
//• Ignore empty components produced by consecutive slashes.

Console.WriteLine("Enter an absolute path(starts with '/') consisting of ASCII letters, digits, '_', '-', '.', and '/' only.");

string? userInput = Console.ReadLine().Trim();

if (userInput != null && (userInput.Length <= 100000))
{
    string P = userInput;
    //TODO: alternatively check characters later

    string canonicalPath = pathMaker(P);
    Console.WriteLine(canonicalPath);

    string pathMaker(string path)
    {
        List<string> parts = new List<string>();
        parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries).ToList();

        parts.Insert(0, "/");
        for (int i = 1; i < parts.Count; i++)
        {
            switch (parts[i])
            {
                case ".":
                    //stay in current directory
                    //remove "." from list
                    parts.RemoveAt(i);
                    i = i - 1;//to check at this index again as next item shifts -1 in index
                    break;
                case "..":
                    //if parent is not "/"
                    //change directory to parent

                    if (parts[i - 1] != "/")
                    {
                        parts.RemoveRange(i - 1, 2);
                        i = i - 2;//to check at this index again as next item shifts -2 in index
                    }
                    else
                    {
                        parts.RemoveAt(i);
                        i = i - 1;//to check at this index again as next item shifts -1 in index
                    }
                    break;

                default:
                    break;
            }
        }

        parts.Remove("/");
        return "/" + string.Join("/", parts);
    }
}
