//Problem 3: Consecutive Ranges Formatter
//You are given N distinct integers (not necessarily sorted). Sort them and compress consecutive runs into ranges.

//Formatting rule:
//• A single isolated number x stays as "x".
//• A consecutive run a, a+1, ..., b (with b ≥ a+1) becomes "a-b".
//Join all parts with commas in ascending order.

//Return the formatted string.

//Input Format
//First line: integer N (1 ≤ N ≤ 2×10^5).
//Second line: N space-separated distinct integers in the range [-10^9, 10^9].
//Output Format
//Print the compressed representation as specified.
//Examples
//Example 1
//Input:
//7
//1 2 3 5 7 8 9
//Output:
//1-3,5,7-9

//Example 2
//Input:
//5
//10 8 6 7 9
//Output:
//6-10

//Example 3
//Input:
//4
//-3 0 2 4
//Output:
//-3,0,2,4
//Constraints & Notes
//• Sorting dominates time: O(N log N).
//• Build ranges in one linear pass after sorting.
//Problem 3: Consecutive Ranges Formatter
//You are given N distinct integers (not necessarily sorted). Sort them and compress consecutive runs into ranges.

//Formatting rule:
//• A single isolated number x stays as "x".
//• A consecutive run a, a+1, ..., b (with b ≥ a+1) becomes "a-b".
//Join all parts with commas in ascending order.

//Return the formatted string.

//Input Format
//First line: integer N (1 ≤ N ≤ 2×10^5).
//Second line: N space-separated distinct integers in the range [-10^9, 10^9].
//Output Format
//Print the compressed representation as specified.
//Examples
//Example 1
//Input:
//7
//1 2 3 5 7 8 9
//Output:
//1-3,5,7-9

//Example 2
//Input:
//5
//10 8 6 7 9
//Output:
//6-10

//Example 3
//Input:
//4
//-3 0 2 4
//Output:
//-3,0,2,4
//Constraints & Notes
//• Sorting dominates time: O(N log N).
//• Build ranges in one linear pass after sorting.


int N = int.Parse(Console.ReadLine());
string input = Console.ReadLine();
string[] integerStrings = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
int[] integers = new int[integerStrings.Length];


for (int k = 0; k < integerStrings.Length; k++)
{
    integers[k] = int.Parse(integerStrings[k]);
}
Array.Sort(integers);

List<string> outputList = new List<string>();

int i = 0;
while (i < integers.Length)
{
    int rangeStart = integers[i];
    int j = i + 1;
    // Move j forward as long as numbers are consecutive
    while (j < integers.Length && integers[j] == integers[j - 1] + 1)
    {
        j++;
    }
    int rangeEnd = integers[j - 1];
    if (rangeEnd == rangeStart)
    {
        outputList.Add(rangeStart.ToString());
    }
    else
    {
        outputList.Add($"{rangeStart}-{rangeEnd}");
    }
    i = j; // Move to the next unprocessed number
}

Console.WriteLine(string.Join(",", outputList));