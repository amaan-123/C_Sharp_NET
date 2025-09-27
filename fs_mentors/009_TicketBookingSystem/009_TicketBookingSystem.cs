Console.WriteLine("Enter no. of seats & no. of booking requests: ");
string? input = Console.ReadLine().Trim();
int L = int.Parse(input.Split(" ", 2, StringSplitOptions.RemoveEmptyEntries)[0]);
int Q = int.Parse(input.Split(" ", 2, StringSplitOptions.RemoveEmptyEntries)[1]);

int requestedSeatNum;
int[] assignedSeatNums = new int[L];
//create seats array
for (int i = 0; i < L; i++)
{
    assignedSeatNums[i] = 0;
    //Console.Write($"{assignedSeatNums[i]} ");
}

string[] outputs = new string[Q];
for (int i = 0; i < Q; i++)
{
    requestedSeatNum = int.Parse(Console.ReadLine());

    if ((requestedSeatNum <= L) && assignedSeatNums[requestedSeatNum - 1] == 0)
    {
        assignedSeatNums[requestedSeatNum - 1] = requestedSeatNum;
        outputs[i] = "ACCEPTED";
    }
    else
    {
        outputs[i] = "REJECTED";
    }
}

foreach (var output in outputs)
{
    Console.WriteLine(output);
}