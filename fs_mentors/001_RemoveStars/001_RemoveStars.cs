//Console.WriteLine("Type the string to remove stars from(characters preferably lowercase)");

//string S = Console.ReadLine();
//char[] sChars = S.ToCharArray();

//if (ConstraintCheck(S))
//{
//    Console.WriteLine("correct input");
//    Console.WriteLine(StarRemoval(S));
//}
//else Console.WriteLine("incorrect input");


//bool ConstraintCheck(string S)
//{
//    if ((S.Length >= 1) && (S.Length <= 100))
//    {
//        //check ascii of char
//        //97-122 || 42
//        foreach (char c in sChars)
//        {
//            if ((((int)c >= 97 && (int)c <= 122) || ((int)c == 42)) == false)
//            {
//                return false;
//            }
//        }
//        return true;
//    }
//    else return false;
//}

//string StarRemoval(string S)
//{
//    //ifstarpresentcompute
//    for (int i = 1; i < S.Length; i++)
//    {

//        if ((S[i] == '*') && (S[i - 1] != '*'))
//        {
//            S = S.Remove(i - 1, 2);
//            Console.WriteLine(S);
//            i = i - 2;
//        }
//    }

//    //elsemessagenostar

//    return S;
//}




//Copilot

using System.Text;

Console.WriteLine("Type the string to remove stars from (characters preferably lowercase):");

string S = Console.ReadLine() ?? string.Empty;

if (IsValidInput(S))
{
    Console.WriteLine("correct input");
    Console.WriteLine(RemoveStars(S));
}
else
{
    Console.WriteLine("incorrect input");
}

bool IsValidInput(string s)
{
    if (s.Length < 1 || s.Length > 100) return false;
    // allow only lowercase a-z and '*' (ASCII)
    return s.All(c => c == '*' || (c >= 'a' && c <= 'z'));
}

string RemoveStars(string s)
{
    // Use a StringBuilder as a stack: push letters, pop on '*'
    var sb = new StringBuilder(s.Length);
    foreach (var c in s)
    {
        if (c == '*')
        {
            if (sb.Length > 0) sb.Length--; // remove previous character
        }
        else
        {
            sb.Append(c);
        }
    }
    return sb.ToString();
}

//Deep breath — step-by-step answers.

//1) How `StringBuilder` is used in `RemoveStars`
//- Concept: the `StringBuilder` is being used like a stack: `Append` pushes a character; decreasing `sb.Length` by one pops the last character.
//- Behavior in the loop:
//  -For a normal character: `sb.Append(c)` adds it to the end.
//  - For `'*'`: `if (sb.Length > 0) sb.Length--;` removes the most recent appended character (if any).
//- Why this is good:
//  -O(n) single pass: each input char is processed once.
//  - Avoids repeated allocation and copying that would occur using repeated `string.Remove` (strings are immutable).
//  - Simple, predictable semantics for "remove the character immediately before a `*`".
//- Edge cases handled: when there is a `*` but `sb` is empty, nothing happens (no exception).
//- Complexity: O(n) time, O(n) additional space in worst-case (for the builder).

//Minimal example (compiles and illustrates the approach):
//```csharp
//csharp
//string RemoveStars(string s)
//{
//    var sb = new System.Text.StringBuilder(s.Length);
//foreach (var c in s)
//{
//    if (c == '*')
//    {
//        if (sb.Length > 0) sb.Length--; // pop
//    }
//    else
//    {
//        sb.Append(c); // push
//    }
//}
//return sb.ToString();
//}
//```

//2) What `.All()` is and how it works
//- What it is: `.All(...)` is a LINQ extension method that tests whether every element in a sequence satisfies a predicate. It returns `true` if the sequence is empty or every element matches the predicate; otherwise `false`.
//- Where it comes from: defined as `Enumerable.All<TSource>(IEnumerable<TSource>, Func<TSource, bool>)` in the `System.Linq` namespace (assembly mscorlib/System.Linq).
//- Key behaviors:
//  - Short-circuits: stops as soon as one element fails the predicate.
//  - Works on any `IEnumerable<T>` (arrays, lists, strings via `IEnumerable<char>`, etc.).
//- Example usages:
//```csharp
//csharp
//using System.Linq;

//bool allLower = "abc*xyz".All(c => c == '*' || (c >= 'a' && c <= 'z')); // true if only lowercase letters and '*'
//bool allEven = new[] { 2, 4, 6 }.All(n => n % 2 == 0); // true
//bool noneEmpty = new[] { "a", "b" }.All(s => !string.IsNullOrEmpty(s)); // true
//```
//- Note: if you don't have `using System.Linq;`, call the static method directly: `System.Linq.Enumerable.All(sequence, predicate)`.

//3) What `System.Linq` is
//- Purpose: `System.Linq` provides LINQ(Language-Integrated Query) extension methods to query and transform sequences in a fluent, composable way.
//- Main contents:
//  - `Enumerable` (extension methods for `IEnumerable<T>`): `Where`, `Select`, `All`, `Any`, `First`, `Aggregate`, `OrderBy`, etc.
//  - `Queryable` (methods for `IQueryable<T>`): used for expression-tree based providers(e.g., Entity Framework) to translate queries to SQL.
//- Typical uses: filtering, projection, aggregation, sorting, and set operations on sequences.
//- Example:
//```csharp
//using System.Linq;
//var names = new[] { "anna", "bob", "eve" };
//var shortNames = names.Where(n => n.Length <= 3).Select(n => n.ToUpper()).ToList();
//foreach (var name in shortNames)
//{
//    Console.WriteLine(name);
//}
//```

//Quick note about your file: `IsValidInput` uses `.All(...)`, so you need `using System.Linq;` at the top for the extension method to be available(or call `System.Linq.Enumerable.All(...)`).

//using System.Text;

//string s = Console.ReadLine() ?? string.Empty;
//Console.WriteLine(RemoveStars(s));

//string RemoveStars(string s)
//{
//    if (!InputValid(s))
//        return string.Empty;

//    var sb = new StringBuilder();
//    foreach (var ch in s)
//    {
//        if (ch != '*')
//            sb.Append(ch);
//        else if (sb.Length > 0)
//            sb.Length--; // pop last character
//    }

//    return sb.ToString();
//}

//bool InputValid(string s)
//{
//    if (s.Length < 1 || s.Length > 100_000) return false;

//    foreach (var ch in s)
//    {
//        if (ch != '*' && (ch < 'a' || ch > 'z')) return false;
//    }

//    return true;
//}


