using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Two stacks for the queue simulation
        var inStack = new Stack<int>();   // push ENQ items here
        var outStack = new Stack<int>();  // pop/peek DEQ/PEEK from here
        // Buffered output: collect results and print once at the end
        var outputBuffer = new StringBuilder();


        int Q = int.Parse(Console.ReadLine()); // safe because input guarantees first line is an integer

        for (int i = 0; i < Q; i++)
        {
            string line = Console.ReadLine();
            if (line == null)
            {
                // defensive: if input ended unexpectedly, stop reading further
                break;
            }

            line = line.Trim();
            if (line.Length == 0)
            {
                // skip empty lines (if any); don't count them against Q
                i--;
                continue;
            }

            // split into command and optional argument (max 2 parts)
            string[] parts = line.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            string cmd = parts[0];
            string arg = parts.Length > 1 ? parts[1] : null;

            if (cmd == "ENQ")
            {
                // parse argument and push onto inStack
                // input guarantees an integer follows ENQ, so simple parse is fine
                int x = int.Parse(arg);
                inStack.Push(x);
            }
            else if (cmd == "DEQ")
            {
                TransferIfNeeded();
                if (outStack.Count == 0)
                {
                    outputBuffer.AppendLine("EMPTY");
                }
                else
                {
                    int val = outStack.Pop();
                    outputBuffer.AppendLine(val.ToString());
                }
            }
            else if (cmd == "PEEK")
            {
                TransferIfNeeded();
                if (outStack.Count == 0)
                {
                    outputBuffer.AppendLine("EMPTY");
                }
                else
                {
                    int val = outStack.Peek();
                    outputBuffer.AppendLine(val.ToString());
                }
            }
            else
            {
                // optional: ignore or handle unexpected commands
                // skip empty lines (if any); don't count them against Q
                i--;
                continue;
            }

        }

        // When done, flush the buffered output:
        Console.Write(outputBuffer.ToString());
        
        
        // local helper: move everything from inStack to outStack if outStack is empty
        void TransferIfNeeded()
        {
            if (outStack.Count == 0)
            {
                while (inStack.Count > 0)
                {
                    outStack.Push(inStack.Pop());
                }
            }
        }
    }
}


//pseudocode
//initialize:
//inStack = empty stack
//outStack = empty stack
//    outputs = empty list of strings    // buffer outputs

//function ENQ(x):
//    inStack.push(x)

//function TRANSFER_IF_NEEDED():
//    if outStack.isEmpty():
//        while not inStack.isEmpty():
//            value = inStack.pop()
//            outStack.push(value)

//function DEQ():
//    TRANSFER_IF_NEEDED()
//    if outStack.isEmpty():
//        outputs.add("EMPTY")
//    else:
//        val = outStack.pop()
//        outputs.add(string_of(val))

//function PEEK():
//    TRANSFER_IF_NEEDED()
//    if outStack.isEmpty():
//        outputs.add("EMPTY")
//    else:
//        val = outStack.peek()
//        outputs.add(string_of(val))

//main:
//read integer Q
//repeat Q times:
//        read the next command (either "ENQ x", "DEQ", or "PEEK")
//        if command starts with "ENQ":
//            parse x
//            ENQ(x)
//        else if command is "DEQ":
//            DEQ()
//        else if command is "PEEK":
//            PEEK()

//    // After processing all commands, print each element of outputs on its own line
//    // (this is the buffered output step)
