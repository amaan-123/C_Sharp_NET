//Rearrange Tasks for Minimum Cooling Time
//You are given a string T of task types (uppercase A–Z). Each task takes 1 unit time to execute.

//Between two identical tasks, there must be at least C units of cooldown (idle or other tasks).
//Compute the minimum total cooling time required to execute all tasks.

//Example: 
//T = "AAABBB", C = 2 → one optimal schedule is A _ _ A _ _ A B _ _ B _ _ B (where '_' may be idle or other tasks).

//Rearrange Tasks such as T = “ABABAB” , as there are no two identical tasks consecutively, the cooling time required in this case is 0
//Input Format
//First line: string T(1 ≤ |T| ≤ 2×10^5), uppercase letters only.
//Second line: integer C(0 ≤ C ≤ 10^9).
//Output Format
//Print a rearranged tasks and minimal cooling time required.
//Examples
//Example 1
//Input:
//AAABBB
//2
//Output:
//ABABAB
//0

// Also see: https://leetcode.com/problems/task-scheduler/

//EXTERNAL HELP TAKEN
Console.WriteLine("Enter task string (letters only):");
string T = Console.ReadLine().ToUpper().Trim();
Console.WriteLine("Enter cooldown units you want b/w consecutive tasks (natural number only):");
int C = int.Parse(Console.ReadLine().Trim());

var freq = new Dictionary<char, int>();
foreach (var ch in T)
    freq[ch] = freq.GetValueOrDefault(ch, 0) + 1;

int maxFreq = freq.Values.Max();
int maxCount = freq.Values.Count(v => v == maxFreq);

// Calculate minimal total time (including idle slots)
int minTime = Math.Max(T.Length, (maxFreq - 1) * (C + 1) + maxCount);
int cooldownUnits = minTime - T.Length;

// Rearranged output (greedy, not always lexicographically minimal)
var pq = new PriorityQueue<char, int>();
foreach (var kv in freq)
    pq.Enqueue(kv.Key, -kv.Value); // max-heap

var result = new List<char>();
var waitQueue = new Queue<(char, int)>(); // (task, availableTime)
int time = 0;

while (pq.Count > 0 || waitQueue.Count > 0)
{
    if (pq.Count > 0)
    {
        var task = pq.Dequeue();
        result.Add(task);
        freq[task]--;
        if (freq[task] > 0)
            waitQueue.Enqueue((task, time + C));
    }
    else
    {
        result.Add('_'); // idle
    }
    time++;

    if (waitQueue.Count > 0 && waitQueue.Peek().Item2 == time)
    {
        var (readyTask, _) = waitQueue.Dequeue();
        pq.Enqueue(readyTask, -freq[readyTask]);
    }
}

// Output rearranged tasks (without idle slots)
string rearranged = new string(result.Where(c => c != '_').ToArray());
Console.WriteLine(rearranged);
Console.WriteLine(cooldownUnits);

//string T = "";
//int C;

//Console.WriteLine("Enter task string(letters only)");
//T = Console.ReadLine().ToUpper().Trim();
//Console.WriteLine("Enter cooldown units you want b/w consecutive tasks(natural number only)");
//C = int.Parse(Console.ReadLine().Trim());

//char[] tasks = T.ToCharArray();
//int cooldownUnits = 0;
//for (int i = 1; i < tasks.Length; i++)
//{
//    if (tasks[i - 1] == tasks[i])
//    {
//        //search char array for next distinct task
//        int j = i + 1;
//        char temp = '~';
//        while (j < tasks.Length)
//        {
//            if (tasks[i - 1] != tasks[j])
//            {
//                //if distinct found, swap values
//                temp = tasks[j];
//                tasks[j] = tasks[i - 1];
//                tasks[i - 1] = temp;
//                break;
//            }
//            j++;
//        }
//        //else introduce cooldown if temp didn't change

//        if (temp == '~')
//        {
//            cooldownUnits += C;
//        }
//    }
//}

//string outputTasks = "";
//foreach (var task in tasks)
//{
//    outputTasks += task;
//}
//Console.WriteLine(outputTasks);
//Console.WriteLine(cooldownUnits);

