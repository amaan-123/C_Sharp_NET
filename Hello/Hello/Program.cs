using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Hello
{
    internal class Program
    {
        static double Average(double a, double b) // Average of two doubles
        {
            return (a + b) / 2;
        }

        static double Average(double a, double b, double c) // Average of three doubles
        {
            return (a + b + c) / 3;
        }
        static void Main()
        {
            //Note the double quotes in the string
            //Console.Write("Hello World by amaan-123. ");
            //Console.WriteLine("Console.Write() writes next line in same line!");
            //Console.Write("Console.WriteLine() writes next line to new line!");

            // user-input
            //Console.WriteLine("Enter your name:");
            //string name = Console.ReadLine();
            //Console.WriteLine("Hello, " + name);

            // Data Types
            //int integerVariable = 10;
            //float floatVariable = 3.14f; // Required f or F
            //char characterVariable = 'a';
            //bool booleanVariable = true;
            //string stringVariable = "Hello amaan-123";
            //long longVariable = 1234567890L; // Optional L suffix for clarity
            //double doubleVariable = 9.87654321; // Optional D suffix for clarity
            //Console.WriteLine(integerVariable);
            //Console.WriteLine(floatVariable);
            //Console.WriteLine(characterVariable);
            //Console.WriteLine(booleanVariable);
            //Console.WriteLine(stringVariable);
            //Console.WriteLine(longVariable);
            //Console.WriteLine(doubleVariable);

            //int myInt = 3;
            //double myDouble = myInt; // Implicit casting from int to double
            //Console.WriteLine(myDouble); // Output: 3

            //double myDouble = 3.14;
            //int myInt = (int)myDouble; // Explicit casting from double to int
            //Console.WriteLine(myInt); // Output: 3
            //int valASCII = characterVariable;
            //Console.WriteLine(valASCII);

            //Console.WriteLine("Enter a number:");
            //string userInput = Console.ReadLine();
            //int number = Convert.ToInt32(userInput); // Convert string to int
            //Console.WriteLine("You entered: " + number);
            //int myInt = 10;
            //double myDouble = 5.25;
            //bool myBool = true;

            //Console.WriteLine(Convert.ToString(myInt));    // Convert int to string
            //Console.WriteLine(Convert.ToDouble(myInt));    // Convert int to double
            //Console.WriteLine(Convert.ToInt32(myDouble));  // Convert double to int
            //Console.WriteLine(Convert.ToString(myBool));   // Convert bool to string
            //Console.WriteLine("How many candies do you want?");
            //string candyInput = Console.ReadLine();
            //// Incorrect: string concatenation
            ////Console.WriteLine("You will get 4 more. So, you get " + candyInput + 4 + " candies"); // Might output "44" if input is "4"

            //// Correct: Convert to int and then add
            //int candyCount = Convert.ToInt32(candyInput);
            //Console.WriteLine("You will get 4 more. So, you get " + (candyCount + 4) + " candies"); // Output will be "You will get 4 more. So, you get 8 candies" if input is "4"

            //System.Math class provides static methods for mathematical operations
            //int maxNumber = Math.Max(34, 39); // Finds the maximum value
            //Console.WriteLine(maxNumber); // Output: 39

            //string greeting = "Hello World";
            //Console.WriteLine(greeting.Length); // Output: 11

            //string word = "C#";
            //Console.WriteLine(word[1]); // Output: #
            //Console.WriteLine(word[0]); // Output: C
            //string sentence = "This is a test";
            //Console.WriteLine(sentence.IndexOf("is")); // Output: 2 (index of the first 'i' in "is")
            //string data = "abcdefgh";
            //Console.WriteLine(data.Substring(3)); // Output: defgh (starts from index 3 to the end)
            //Console.WriteLine(data.Substring(3, 2)); // Output: de (starts from index 3, takes 2 characters)
            //Console.WriteLine("He said,\t \"Hello!\""); // Output: He said,     "Hello!"
            //Console.WriteLine("Line 1\nLine 2"); // Output: Line 1 followed by Line 2 on a new line
            //int age = 16;

            //if (age >= 18)
            //{
            //    Console.WriteLine("You can drive.");
            //}
            //else if (age >= 16) // This condition is checked only if age is NOT >= 18
            //{
            //    Console.WriteLine("Almost there, please wait.");
            //}
            //else // This block executes if age is NOT >= 18 AND NOT >= 16
            //{
            //    Console.WriteLine("You cannot drive yet.");
            //}
            //int i = 0;
            //while (i < 5)
            //{
            //    Console.WriteLine(i);
            //    i++; // Increment i to eventually make the condition false
            //}
            //// Output: 0, 1, 2, 3, 4
            //int i = 0;
            //do
            //{
            //    Console.WriteLine(i);
            //    i++; // Increment i
            //} while (i < 5); // Condition checked after the first run
            //                 // Output: 0, 1, 2, 3, 4 (Same output as while in this case, but runs at least once)
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //// Output: 0, 1, 2, 3, 4
            //for (int i = 0; i < 10; i++)
            //{
            //    if (i == 2)
            //    {
            //        continue; // Skip the rest of the code for this iteration when i is 2
            //    }
            //    else if (i == 5)
            //    {
            //        break; // Exits the loop immediately
            //    }
            //    Console.WriteLine(i);
            //}
            //// Output: 0, 1, 3, 4 (2 & 5 onwards skipped)

            // Methods:
            // The compiler knows which Average method to call based on the number of arguments
            double avg1 = Average(10.0, 20.0);
            double avg2 = Average(10.0, 20.0, 30.0);
            //Console.WriteLine(avg2);
        }

    }
}
