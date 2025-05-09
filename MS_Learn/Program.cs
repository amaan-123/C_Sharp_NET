using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}
