Console.WriteLine("Enter the task string(letters only, ensure no space/other characters in between): ");
string T = Console.ReadLine().Trim().ToUpper();
Console.WriteLine("Enter the no. of cooldown units to separate identical tasks(a number only): ");
int C = int.Parse(Console.ReadLine().Trim());

int cooldownCount = 0;
int taskCount = 0;

for (int i = 1; i < T.Length; i++)
{
    if (T[i - 1] == T[i])
    {
        cooldownCount += C;
        taskCount++;
    }
    else
    {
        taskCount++;
    }
}

Console.WriteLine($"Cooldown count: {cooldownCount}\t Actual Tasks count: {taskCount}\t Total Count:{cooldownCount + taskCount}");
