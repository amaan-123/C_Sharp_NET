using System;

namespace MS_Learn
{
    internal class Program
    {
        static void Main()
        {
            ////Note the single quotes in the char
            //Console.WriteLine('a'); // char

            ////For int and float, no quotes
            //Console.WriteLine(123);
            //Console.WriteLine(0.25F);
            //Console.WriteLine(2.625);
            //Console.WriteLine(12.39816m);
            //Console.WriteLine(true);
            //Console.WriteLine(false);
            ////Console.ReadLine(); // Wait for user input before closing the console window

            //string firstName = "Bob";
            //int num = 3;
            //float temperature = 34.4f;
            //Console.WriteLine($"Hello {firstName}! You have {num} messages in inbox at {temperature} celsius");

            //var message = "Hello World!";
            //message = 10.703m; // error: can't implicitly convert decimal to string

            //Console.WriteLine("Hello \"World\"!");
            //Console.WriteLine("C:\new\folder");
            //Console.WriteLine("c:\\source\\repos");//you use the \\ to display a single backslash.
            //Console.WriteLine("Generating invoices for customer \"Contoso Corp\" ... \n");
            //Console.WriteLine("Invoice: 1021\t\tComplete!");
            //Console.WriteLine("Invoice: 1022\t\tComplete!");
            //Console.WriteLine("\nOutput Directory:\t");

            ////A verbatim string literal will keep all whitespace and characters without the need to escape the backslash. To create a verbatim string, use the @ directive before the literal string.
            //Console.WriteLine(@"    c:\source\repos
            //        (this is where your code goes)");
            //Console.Write(@"c:\invoices");

            ////You can also add encoded characters in literal strings using the \u escape sequence, then a four-character code representing some character in Unicode(UTF - 16).
            //// Kon'nichiwa World
            //Console.WriteLine("\u3053\u3093\u306B\u3061\u306F World!");
            ////Unicode characters may not print correctly depending on the application.
            //// To generate Japanese invoices:
            //// Nihon no seikyū-sho o seisei suru ni wa:
            //Console.Write("\n\n\u65e5\u672c\u306e\u8acb\u6c42\u66f8\u3092\u751f\u6210\u3059\u308b\u306b\u306f\uff1a\n\t");
            //// User command to run an application
            //Console.WriteLine(@"c:\invoices\app.exe -j");

            //string firstName = "Bob";
            //string greeting = "Hello";

            //// string concatenation
            //Console.WriteLine(greeting + " " + firstName + "!");

            ////string interpolation
            //string message = $"{greeting} {firstName}!";

            ////In this example, the $ symbol allows you to reference the projectName variable inside the braces, while the @ symbol allows you to use the unescaped \ character.
            //string projectName = "First-Project";
            //Console.WriteLine($@"C:\Output\{projectName}\Data");

            //string projectName = "ACME";
            //string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0443\u0441\u0441\u043a\u0438\u0439 \u0432\u044b\u0432\u043e\u0434";

            //Console.WriteLine($"View English Output:\n\t\tc:\\Exercise\\{projectName}\\data.txt");

            //Console.WriteLine($"{russianMessage}: \n\t\tc:\\Exercise\\{projectName}\\ru-RU\\data.txt");

            //int firstNumber = 12;
            //int secondNumber = 7;
            //Console.WriteLine(firstNumber + secondNumber);

            ////Instead of adding the int variable widgetsSold to the literal int 7, the compiler treats everything as a string and concatenates it all together.
            //string firstName = "Bob";
            //int widgetsSold = 7;
            //Console.WriteLine(firstName + " sold " + widgetsSold + 7 + " widgets.");
            //// to add first as int:
            //Console.WriteLine(firstName + " sold " + (widgetsSold + 7) + " widgets.");

            //int sum = 7 + 5;
            //int difference = 7 - 5;
            //int product = 7 * 5;
            //int quotient = 7 / 5;

            //Console.WriteLine("Sum: " + sum);
            //Console.WriteLine("Difference: " + difference);
            //Console.WriteLine("Product: " + product);
            //// The values after the decimal are truncated from the quotient since it is defined as an int, and int cannot contain values after the decimal.
            //Console.WriteLine("Quotient: " + quotient)

            // To get decimal quotient:
            // For this to work, the quotient(left of the assignment operator) must be of type decimal and at least one of numbers being divided must also be of type decimal(both numbers can also be a decimal type).
            //decimal decimalQuotient1 = 7.0m / 5;
            //decimal decimalQuotient2 = 7 / 5.0m;
            //decimal decimalQuotient3 = 7.0m / 5.0m;
            //Console.WriteLine($"Decimal quotient: \n{decimalQuotient1}\n{decimalQuotient2}\n{decimalQuotient3}");

            //// cast result of int division to decimal
            //int first = 7;
            //int second = 5;
            //decimal quotient = (decimal)first / (decimal)second;
            //Console.WriteLine(quotient);

            ////In math, PEMDAS is an acronym that helps students remember the order of operations. The order is:
            ////Parentheses(whatever is inside the parenthesis is performed first)
            ////Exponents //no exponent operator in C#, you can use the System.Math.Pow method
            ////Multiplication and Division(from left to right)
            ////Addition and Subtraction(from left to right)

            //// if you use the operator before the value as in ++value, then the increment will happen before the value is retrieved.Likewise, value++ will increment the value after the value has been retrieved.
            //int value = 1;
            //value++;
            //Console.WriteLine("First: " + value);
            //Console.WriteLine($"Second: {value++}");
            //Console.WriteLine("Third: " + value);
            //Console.WriteLine("Fourth: " + (++value));
            //Console.WriteLine("Fifth: " + value);

            //int fahrenheit = 94;
            //decimal temperature = (fahrenheit - 32) * (5m / 9m);
            //Console.WriteLine($"The temperature is {temperature}");

            //// initialize variables - graded assignments 
            //int currentAssignments = 5;

            //int sophia1 = 93;
            //int sophia2 = 87;
            //int sophia3 = 98;
            //int sophia4 = 95;
            //int sophia5 = 100;

            //int nicolas1 = 80;
            //int nicolas2 = 83;
            //int nicolas3 = 82;
            //int nicolas4 = 88;
            //int nicolas5 = 85;

            //int zahirah1 = 84;
            //int zahirah2 = 96;
            //int zahirah3 = 73;
            //int zahirah4 = 85;
            //int zahirah5 = 79;

            //int jeong1 = 90;
            //int jeong2 = 92;
            //int jeong3 = 98;
            //int jeong4 = 100;
            //int jeong5 = 97;

            //int sophiaSum = sophia1 + sophia2 + sophia3 + sophia4 + sophia5;
            //int nicolasSum = nicolas1 + nicolas2 + nicolas3 + nicolas4 + nicolas5;
            //int zahirahSum = zahirah1 + zahirah2 + zahirah3 + zahirah4 + zahirah5;
            //int jeongSum = jeong1 + jeong2 + jeong3 + jeong4 + jeong5;

            //decimal sophiaScore = (decimal)sophiaSum / currentAssignments;
            //decimal nicolasScore = (decimal)nicolasSum / currentAssignments;
            //decimal zahirahScore = (decimal)zahirahSum / currentAssignments;
            //decimal jeongScore = (decimal)jeongSum / currentAssignments;

            ////// \t is the tab character. It doesn’t insert a fixed number of spaces — instead, it jumps the cursor to the next "tab stop".
            ////// Tab stops are usually set every 8 characters
            
            ////Console.WriteLine("Student\t\tGrade\n");
            ////Console.WriteLine("Sophia:\t\t" + sophiaScore + "\tA");
            ////Console.WriteLine("Nicolas:\t" + nicolasScore + "\tB");
            ////Console.WriteLine("Zahirah:\t" + zahirahScore + "\tB");
            ////Console.WriteLine("Jeong:\t\t" + jeongScore + "\tA");

            string studentName = "Sophia Johnson";
            string course1Name = "English 101";
            string course2Name = "Algebra 101";
            string course3Name = "Biology 101";
            string course4Name = "Computer Science I";
            string course5Name = "Psychology 101";

            int gradeA = 4;
            int gradeB = 3;

            int course1Credit = 3;
            int course2Credit = 3;
            int course3Credit = 4;
            int course4Credit = 4;
            int course5Credit = 3;

            int course1Grade = gradeA;
            int course2Grade = gradeB;
            int course3Grade = gradeB;
            int course4Grade = gradeB;
            int course5Grade = gradeA;

            int prod1 = (course1Grade * course1Credit);
            int prod2 = (course2Grade * course2Credit);
            int prod3 = (course3Grade * course3Credit);
            int prod4 = (course4Grade * course4Credit);
            int prod5 = (course5Grade * course5Credit);

            int creditHoursTotal = course1Credit + course2Credit + course3Credit + course4Credit + course5Credit;

            float initialGPA = (prod1 + prod2 + prod3 + prod4 + prod5) / (float)creditHoursTotal; 
            float finalGPA = (float)Math.Round(initialGPA, 2);


            Console.WriteLine($"Student: {studentName}");

            Console.WriteLine("Course".PadRight(24) + "Grade".PadRight(8) + "Credit Hours");

            Console.WriteLine($"{course1Name}".PadRight(24) + $"{course1Grade}".PadRight(8) + $"{course1Credit}");
            Console.WriteLine($"{course2Name}".PadRight(24) + $"{course2Grade}".PadRight(8) + $"{course2Credit}");
            Console.WriteLine($"{course3Name}".PadRight(24) + $"{course3Grade}".PadRight(8) + $"{course3Credit}");
            Console.WriteLine($"{course4Name}".PadRight(24) + $"{course4Grade}".PadRight(8) + $"{course4Credit}");
            Console.WriteLine($"{course5Name}".PadRight(24) + $"{course5Grade}".PadRight(8) + $"{course5Credit}");
            
            Console.WriteLine("Final GPA:".PadRight(24) + $"{finalGPA}");


        }
    }
}
