// MS_Learn + FreeCodeCamp Cert
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

            // string studentName = "Sophia Johnson";
            // string course1Name = "English 101";
            // string course2Name = "Algebra 101";
            // string course3Name = "Biology 101";
            // string course4Name = "Computer Science I";
            // string course5Name = "Psychology 101";

            // int gradeA = 4;
            // int gradeB = 3;

            // int course1Credit = 3;
            // int course2Credit = 3;
            // int course3Credit = 4;
            // int course4Credit = 4;
            // int course5Credit = 3;

            // int course1Grade = gradeA;
            // int course2Grade = gradeB;
            // int course3Grade = gradeB;
            // int course4Grade = gradeB;
            // int course5Grade = gradeA;

            // int prod1 = (course1Grade * course1Credit);
            // int prod2 = (course2Grade * course2Credit);
            // int prod3 = (course3Grade * course3Credit);
            // int prod4 = (course4Grade * course4Credit);
            // int prod5 = (course5Grade * course5Credit);

            // int creditHoursTotal = course1Credit + course2Credit + course3Credit + course4Credit + course5Credit;

            // float initialGPA = (prod1 + prod2 + prod3 + prod4 + prod5) / (float)creditHoursTotal; 
            // float finalGPA = (float)Math.Round(initialGPA, 2);


            // Console.WriteLine($"Student: {studentName}");

            // Console.WriteLine("Course".PadRight(24) + "Grade".PadRight(8) + "Credit Hours");

            // Console.WriteLine($"{course1Name}".PadRight(24) + $"{course1Grade}".PadRight(8) + $"{course1Credit}");
            // Console.WriteLine($"{course2Name}".PadRight(24) + $"{course2Grade}".PadRight(8) + $"{course2Credit}");
            // Console.WriteLine($"{course3Name}".PadRight(24) + $"{course3Grade}".PadRight(8) + $"{course3Credit}");
            // Console.WriteLine($"{course4Name}".PadRight(24) + $"{course4Grade}".PadRight(8) + $"{course4Credit}");
            // Console.WriteLine($"{course5Name}".PadRight(24) + $"{course5Grade}".PadRight(8) + $"{course5Credit}");

            // Console.WriteLine("Final GPA:".PadRight(24) + $"{finalGPA}");

            //// .NET 6 and later templates:
            //// See https://aka.ms/new-console-template for more information
            // Random dice = new Random();
            // int roll = dice.Next(1, 7);
            // Console.WriteLine(roll); // you include a reference to the Console class and call the Console.WriteLine() method directly.

            //// However, you use a different technique for calling the Random.Next() method. The reason why you're using two different techniques is because some methods are "stateful" and others are "stateless". 
            //// see error if you only do: 
            //int result = Random.Next();

            // Random dice = new Random();
            // int roll = dice.Next();
            // Console.WriteLine(roll);


            //// Exercise - Return values and parameters of methods
            //// Overloaded methods
            //Random dice = new Random();
            //int roll1 = dice.Next();// return values ranging from 0 to 2,147,483,647, which is the maximum value an int can store.
            //int roll2 = dice.Next(101);// a random value between 0 and 100
            //int roll3 = dice.Next(50, 101);// random value between 50 and 100
            //Console.WriteLine($"First roll: {roll1}");
            //Console.WriteLine($"Second roll: {roll2}");
            //Console.WriteLine($"Third roll: {roll3}");

            //int firstValue = -600;
            //int secondValue = -700;
            //int largerValue = Math.Max(firstValue, secondValue);
            //Console.WriteLine(largerValue);

            ////Exercise - Create decision logic with if statements
            ////Write code that generates three random numbers and displays them in output

            //Random dice = new Random();
            //int roll1 = dice.Next(1, 7);
            //int roll2 = dice.Next(1, 7);
            //int roll3 = dice.Next(1, 7);

            //////Hard-coding the values to test for cases:
            ////roll1 = 1;
            ////roll2 = 1;
            ////roll3 = 3;
            //int total = roll1 + roll2 + roll3;
            //Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");

            //////Commented code bug: both doubles & triples awarded bonus
            //////Add an if statement to implement the doubles bonus
            ////if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
            ////{
            ////    Console.WriteLine("You rolled doubles! +2 bonus to total!");
            ////    total += 2;
            ////}
            //////Add another if statement to implement the triples bonus
            ////if ((roll1 == roll2) && (roll2 == roll3))
            ////{
            ////    Console.WriteLine("You rolled triples! +6 bonus to total!");
            ////    total += 6;
            ////}

            //////Modify the commented code above to remove the stacking bonus for doubles and triples using nesting
            //if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
            //{
            //    if ((roll1 == roll2) && (roll2 == roll3))
            //    {
            //        Console.WriteLine("You rolled triples!  +6 bonus to total!");
            //        total += 6;
            //    }
            //    else
            //    {
            //        Console.WriteLine("You rolled doubles!  +2 bonus to total!");
            //        total += 2;
            //    }
            //}

            //////Add an if else statement to display different messages based on the value of the total variable
            ////if (total >= 15)
            ////{
            ////    Console.WriteLine("You win!");
            ////}
            ////else
            ////{
            ////    Console.WriteLine("Sorry, you lose.");
            ////}

            //////Use if, else, and else if statements to give a prize instead of a win-lose message like commented code above
            //////You can nest if statements to narrow down a possible condition. However, you should consider using the if, else if, and else statements instead.
            //if (total >= 16)
            //{
            //    Console.WriteLine("You win a new car!");
            //}
            //else if (total >= 10)
            //{
            //    Console.WriteLine("You win a new laptop!");
            //}
            //else if (total == 7)
            //{
            //    Console.WriteLine("You win a trip for two!");
            //}
            //else
            //{
            //    Console.WriteLine("You win a kitten!");
            //}

            ////Exercise - Complete a challenge activity to apply business rules
            ////Challenge: Improve renewal rate of subscriptions
            //// Rule 1: Your code should only display one message.

            //Random random = new Random();
            //int daysUntilExpiration = random.Next(12);
            //int discountPercentage = 0;
            //Console.WriteLine($"Days till expiry: {daysUntilExpiration}");

            //if (daysUntilExpiration == 0)
            //{
            //    Console.WriteLine("Your subscription has expired.");
            //}
            //else if (daysUntilExpiration == 1)
            //{
            //    Console.WriteLine("Your subscription expires within a day!");
            //    discountPercentage = 20;
            //}
            //else if (daysUntilExpiration <= 5)
            //{
            //    Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.");
            //    discountPercentage = 10;
            //}
            //else if (daysUntilExpiration <= 10)
            //{
            //    Console.WriteLine("Your subscription will expire soon. Renew now!");
            //}
            //else
            //{
            //    ////Rule 6: If the user's subscription doesn't expire in 10 days or less, display nothing
            //    Console.WriteLine();
            //}

            //if (discountPercentage > 0)
            //{
            //    Console.WriteLine($"Renew now and save {discountPercentage}%.");
            //}

            ////Exercise - Get started with array basics
            /*
            //Declaring an array
            string[] fraudulentOrderIDs = new string[3];

            //assigning values
            fraudulentOrderIDs[0] = "A123";
            fraudulentOrderIDs[1] = "B456";
            fraudulentOrderIDs[2] = "C789";
            fraudulentOrderIDs[3] = "D000";// Error message: System.IndexOutOfRangeException: Index was outside the bounds of the array
            */

            //// Initialize an array
            //// Replace the collection expression(C# 12) with older syntax uses curly braces {} to enclose the values of the array.
            //string[] fraudulentOrderIDs = ["A123", "B456", "C789"];
            //Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
            //Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
            //Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");
            //Console.ReadLine();

            //fraudulentOrderIDs[0] = "F000";
            //Console.WriteLine($"Reassign First: {fraudulentOrderIDs[0]}");

            //Console.WriteLine($"There are {fraudulentOrderIDs.Length} fraudulent orders to process.");

            ////Exercise - Implement the foreach statement
            //string[] names = { "Rowena", "Robin", "Bao" };
            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}

            //int[] inventory = { 200, 450, 700, 175, 250 };
            //int sum = 0;
            //int bin = 0;
            //foreach (int items in inventory)
            //{
            //    sum += items;
            //    bin++;
            //    Console.WriteLine($"Bin {bin} = {items} items (Running total: {sum})");
            //}
            //Console.WriteLine($"We have {sum} items in inventory.");

            //// Challenge - declare an array & get the orders with orderId starting from "B"
            //string[] orders = { "B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179" };
            //foreach (string orderId in orders)
            //{
            //    if (orderId.StartsWith("B"))
            //    {
            //        Console.WriteLine(orderId);
            //    }
            //}


            ////Comments:

            //Notice that there are two main problems with the comments in code below:
            //The code comments unnecessarily explain the obvious functionality of individual lines of code.
            //These are considered low -quality comments because they merely explain how C# or methods of the.NET Class Library work.If the reader is unfamiliar with these ideas, they can look them up using learn.microsoft.com or IntelliSense.
            //The code comments don't provide any context to the problem being solved by the code. These are considered low-quality comments because the reader doesn't gain any insight into the purpose of this code, especially as it relates to the larger system.
            //Random random = new Random();
            //string[] orderIDs = new string[5];
            //// Loop through each blank orderID
            //for (int i = 0; i < orderIDs.Length; i++)
            //{
            // Get a random value that equates to ASCII letters A through E
            //int prefixValue = random.Next(65, 70);
            //// Convert the random value into a char, then a string
            //string prefix = Convert.ToChar(prefixValue).ToString();
            //// Create a random number, pad with zeroes
            //string suffix = random.Next(1, 1000).ToString("000");
            //// Combine the prefix and suffix together, then assign to current OrderID
            //orderIDs[i] = prefix + suffix;
            //}
            //// Print out each orderID
            //foreach (var orderID in orderIDs)
            //{
            //    Console.WriteLine(orderID);
            //}

            //// Useful if at top, we had put:
            ///*
            //  The following code creates five random OrderIDs
            //  to test the fraud detection process.  OrderIDs
            //  consist of a letter from A to E, and a three
            //  digit number. Ex. A123.
            //*/

            ////Whitespaces:
            //// Code to get individual characters from a string in an array & then reverse the character array. Also, count the number of times a particular character appears in the character array. Print the reversed message string and display count of times a char appears.
            //string str = "The quick brown fox jumps over the lazy dog.";

            //char[] charMessage = str.ToCharArray();
            //Array.Reverse(charMessage);

            //int x = 0;
            //foreach (char i in charMessage)
            //{
            //    if (i == 'o')
            //    {
            //        x++;
            //    }
            //}

            //string newMessage = new String(charMessage);
            //Console.WriteLine(newMessage);

            //Console.WriteLine($"'o' appears {x} times.");

            //If you realize you have only one line of code listed within the code blocks of an if-elseif -else statement, you can remove the curly braces of the code block and white space.Microsoft recommends that curly braces be used consistently for all of the code blocks of an if-elseif -else statement(either present or removed consistently).
            //Only remove the curly braces of a code block when it makes the code more readable.It's always acceptable to include curly braces.
            //Only remove the line feed if it makes the code more readable.Microsoft suggests that your code will be more readable when each statement is placed on its own code line.

            //// Add logic to C# console applications (Get started with C#, Part 3)
            //// Evaluate Boolean expressions to make decisions in C#
            //Console.WriteLine("a" == "a");// True
            //Console.WriteLine("a" == "A");// False
            //Console.WriteLine("a" == "a ");// False
            //Console.WriteLine(1 == 2);// False
            //string myValue = "a";
            //Console.WriteLine(myValue == "a");// True

            ////Improve the check for string equality using the string's built-in helper methods
            //string value1 = " a";
            //string value2 = "A ";
            //Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());

            ////Inequality operator
            //Console.WriteLine("a" != "a");
            //Console.WriteLine("a" != "A");
            //Console.WriteLine(1 != 2);
            //string myValue = "a";
            //Console.WriteLine(myValue != "a");

            //string pangram = "The quick brown fox jumps over the lazy dog.";
            //Console.WriteLine(pangram.Contains("jum"));
            //Console.WriteLine(pangram.Contains("cow"));

            ////Logical negation
            //// These two lines of code will create the same output
            //Console.WriteLine(pangram.Contains("fox") == false);
            //Console.WriteLine(!pangram.Contains("fox"));

            ////Conditional Ternary Operator
            //int saleAmount = 1001;
            //int discount = saleAmount > 1000 ? 100 : 50;
            //Console.WriteLine($"Discount: {discount}");

            ////Code challenge: write code to display the result of a coin flip
            //Random coin = new Random();
            //int flip = coin.Next(0, 2);
            //Console.WriteLine((flip == 0) ? "heads" : "tails");

            ////Decision logic challenge
            ////Initialize permission and level values
            //string permission = "Admin|Manager";
            //int level = 53;

            //if (permission.Contains("Admin"))
            //{
            //    if (level > 55)
            //    {
            //        Console.WriteLine("Welcome, Super Admin user.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Welcome, Admin user.");
            //    }
            //}
            //else if (permission.Contains("Manager"))
            //{
            //    if (level >= 20)
            //    {
            //        Console.WriteLine("Contact an Admin for access.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("You do not have sufficient privileges.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("You do not have sufficient privileges.");


            ////Code blocks impact the scope of a variable declaration
            ////Create a variable inside of a code block
            //bool flag = true;
            //if (flag)
            //{
            //    int value = 10;
            //    Console.WriteLine($"Inside the code block: {value}");
            //}

            ////Attempt to access a variable outside the code block in which it's declared
            //Console.WriteLine($"Outside the code block: {value}");
            ////A variable that's declared in a method code block is referred to as a local variable. You may see the term local variable used when reviewing articles that discuss variable scope.

            ////Move the variable declaration above the code block
            //bool flag = true;
            //int value;

            //if (flag)
            //{
            //    Console.WriteLine($"Inside the code block: {value}");
            //}

            //value = 10;
            //Console.WriteLine($"Outside the code block: {value}");

            ////Initialize a variable as part of variable declaration
            //bool flag = true;
            //int value = 0;

            //if (flag)
            //{
            //    Console.WriteLine($"Inside the code block: {value}");
            //}

            //value = 10;
            //Console.WriteLine($"Outside the code block: {value}");


            ////Examine the compiler's interpretation of your code
            ////You may feel that these two samples should always produce the same result, but the C# compiler interprets these two code samples differently.
            //// For the first code sample, the compiler interprets flag as a Boolean variable that could be assigned a value of either true or false. The compiler concludes that if flag is false, value will not be initialized when the second Console.WriteLine() is executed.
            ////Since the compiler considers the `flag = false` path a possibility (for code sample 1), it generates an error message during the build process.
            //// Code sample 1
            //bool flag = true;
            //int value;
            //if (flag)
            //{
            //    value = 10;
            //    Console.WriteLine($"Inside the code block: {value}");
            //}
            //Console.WriteLine($"Outside the code block: {value}");

            //// Code sample 2
            //int value;
            //if (true)
            //{
            //    value = 10; // can be accessed outside
            //    Console.WriteLine($"Inside the code block: {value}");
            //}
            //Console.WriteLine($"Outside the code block: {value}");

            //Since the first integer is initialized above the if statement code, it's still in-scope after the code block. Also, since both integers are in-scope and initialized with values inside the code block, the addition of the values executes correctly. Finally, even though the second integer doesn't exist outside of the code block, the first integer retains any changes to its value that occurred inside the code block.
            //int first = 5;
            //if (first > 0)
            //{
            //    int second = 6;
            //    first = first + second;
            //}
            //Console.WriteLine(first);

            ////Notice sum line having "second" variable after code block. Result: build error
            //int first = 5;
            //if (first > 0)
            //{
            //    int second = 6;
            //}
            //first = first + second;
            //Console.WriteLine(first);

            ////Code challenge: update problematic code in the code editor
            ////The biggest changes to the problematic code included:
            //// Moving the declaration of the total and found variables outside of the foreach statement.
            //// Initializing both the total and found variables with sensible default values.
            //// Removing the code blocks (curly braces) from the if statements.
            //int[] numbers = { 4, 8, 15, 16, 23, 42 };

            //int total = 0;
            //bool found = false;

            //foreach (int number in numbers)
            //{
            //    total += number;

            //    if (number == 42)
            //        found = true;
            //}

            //if (found)
            //    Console.WriteLine("Set contains 42");

            //Console.WriteLine($"Total: {total}");
            //Console.ReadLine();


            //// Add logic to C# console applications (Get started with C#, Part 3)
            //// Branch the flow of code using the switch-case construct in C#
            //// Exercise - Implement a switch statement
            //// The switch is best used when:
            //// You have a single value (variable or expression) that you want to match against many possible values.
            //// For any given match, you need to execute a couple of lines of code at most.

            //int employeeLevel = 100;
            //string employeeName = "John Smith";

            //string title = "";

            //switch (employeeLevel)
            //{
            //    case 100:
            //        title = "Junior Associate";
            //        break;
            //    case 200:
            //        title = "Senior Associate";
            //        break;
            //    case 300:
            //        title = "Manager";
            //        break;
            //    case 400:
            //        title = "Senior Manager";
            //        break;
            //    default:
            //        title = "Associate";
            //        break;
            //}

            //Console.WriteLine($"{employeeName}, {title}");

            ////The switch expression is evaluated against the case labels from top to bottom until a value that is equal to the switch expression is found. If none of the labels are a match, the statement list for the default case will be executed. If no default is included, control is transferred to the end point of the switch statement. Each label must provide a value type that matches the type specified in the switch expression.
            ////The optional default label can appear at any position within the list of switch sections. However, most developers choose to put it last because it makes more sense (logically) to position default as the final option. Regardless of the position, the default section will be evaluated last.
            ////The break keyword is one of several ways to end a switch section before it gets to the next section. If you forget the break keyword (or, optionally, the return keyword) the compiler will generate an error.

            //switch (employeeLevel)
            //{
            //    case 100:
            //    case 200:
            //        title = "Senior Associate";
            //        break;
            //    case 300:
            //        title = "Manager";
            //        break;
            //    case 400:
            //        title = "Senior Manager";
            //        break;
            //    default:
            //        title = "Associate";
            //        break;
            //}

            //Console.WriteLine($"{employeeName}, {title}");


            //// SKU = Stock Keeping Unit. 
            //// SKU value format: <product #>-<2-letter color code>-<size code>
            //string sku = "01-MN-L";

            //string[] product = sku.Split('-');

            //string type = "";
            //string color = "";
            //string size = "";

            //switch (product[0])
            //{
            //    case "01":
            //        type = "Sweat shirt";
            //        break;
            //    case "02":
            //        type = "T-Shirt";
            //        break;
            //    case "03":
            //        type = "Sweat pants";
            //        break;
            //    default:
            //        type = "Other";
            //        break;
            //}
            //switch (product[1])
            //{
            //    case "BL":
            //        color = "Black";
            //        break;
            //    case "MN":
            //        color = "Maroon";
            //        break;
            //    default:
            //        color = "White";
            //        break;
            //}

            //switch (product[2])
            //{
            //    case "S":
            //        size = "Small";
            //        break;
            //    case "M":
            //        size = "Medium";
            //        break;
            //    case "L":
            //        size = "Large";
            //        break;
            //    default:
            //        size = "One Size Fits All";
            //        break;
            //}

            //Console.WriteLine($"Product: {size} {color} {type}");

            ////Exercise - Create and configure "for" iteration loops
            //// All three sections (initializer, condition, and iterator) are optional. However, in practice, typically all three sections are used.
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //    if (i == 7) break;
            //}
            //string[] names = { "Alex", "Eddie", "David", "Michael" };
            //for (int i = names.Length - 1; i >= 0; i--)
            //{
            //    Console.WriteLine(names[i]);
            //}
            //string[] names = { "Alex", "Eddie", "David", "Michael" };
            //foreach (var name in names)
            //{
            //    // Can't do this because error: Cannot assign to name because it is a 'foreach iteration variable':
            //    if (name == "David")
            //          name = "Sammy";
            //}
            ////Overcoming the limitation of the foreach statement using the for statement
            //string[] names = { "Alex", "Eddie", "David", "Michael" };

            //for (int i = 0; i < names.Length; i++)
            //    if (names[i] == "David")
            //        names[i] = "Sammy";

            //foreach (var name in names)
            //    Console.WriteLine(name);
            ////Code challenge - implement the FizzBuzz challenge rules
            ////Output values from 1 to 100, one number per line, inside the code block of an iteration statement.
            //// When the current value is divisible by 3, print the term Fizz next to the number.
            //// When the current value is divisible by 5, print the term Buzz next to the number.
            //// When the current value is divisible by both 3 and 5, print the term FizzBuzz next to the number.
            //for (int i = 1; i <= 100; i++)
            //{
            //    if ((i % 3) == 0)
            //    {
            //        if ((i % 5) == 0)
            //        {
            //            Console.WriteLine($"{i} - FizzBuzz");
            //        }
            //        Console.WriteLine($"{i} - Fizz");
            //    }
            //    else if ((i % 5) == 0)
            //    {
            //        Console.WriteLine($"{i} - Buzz");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{i}");
            //    }
            //}
            ////The for statement allows us to iterate a pre-determined number of times, and control the process of iteration.
            //// Both the foreach and for rely on factors that are external to the code block to determine the number of code block iterations.
            //// The do-while and while statements allow us to iterate through a block of code with the intent that the logic inside of the code block will affect when we can stop iterating.A code block that influences the exit criteria is a primary reason to select a do-while or while statements rather than one of the other iteration statements.
            ////use the continue statement to skip processing the remainder of code in the code block and go directly to the Boolean evaluation of the while statement.
            ////Write a do -while statement to break when a certain random number is generated
            //Random numbers = new Random();
            //int testNumber = 0;
            //do
            //{
            //    testNumber = numbers.Next(1, 11);
            //    Console.WriteLine($"Randomly selected number is {testNumber}");

            //} while (testNumber != 7);

            ////////Write a while statement that iterates only while a random number is greater than some value
            //Random random = new Random();
            //int current = random.Next(1, 11);
            //while (current >= 3)
            //{
            //    Console.WriteLine(current);
            //    current = random.Next(1, 11);
            //}
            //Console.WriteLine($"Last number: {current}");

            ////Use the continue statement to step directly to the Boolean expression
            //Random random = new Random();
            //int current = random.Next(1, 11);

            //do
            //{
            //    current = random.Next(1, 11);

            //    if (current >= 8) continue;

            //    Console.WriteLine(current);
            //} while (current != 7);

            ///*
            //while (current >= 3)
            //{
            //    Console.WriteLine(current);
            //    current = random.Next(1, 11);
            //}
            //Console.WriteLine($"Last number: {current}");
            //*/


            ////Role playing game battle challenge using do and while iteration statements
            ////write code to implement the game rules as below:

            ////You must use either the do-while statement or the while statement as an outer game loop.
            //// The hero and the monster start with 10 health points.
            //// All attacks are a value between 1 and 10.
            //// The hero attacks first.
            //// Print the amount of health the monster lost and their remaining health.
            //// If the monster's health is greater than 0, it can attack the hero.
            //// Print the amount of health the hero lost and their remaining health.
            //// Continue this sequence of attacking until either the monster's health or hero's health is zero or less.
            //// Print the winner.

            ////My way(website way below this better!):
            //int monsterHP = 10;
            //int heroHP = 10;
            //int attackValue = 0;
            //Random attack = new Random();

            //do
            //{
            //    attackValue = attack.Next(1, 11);
            //    monsterHP -= attackValue;
            //    Console.WriteLine($"Monster was damaged and lost {attackValue} health and now has {monsterHP} health.");

            //    if (monsterHP > 0)
            //    {
            //        attackValue = attack.Next(1, 11);
            //        heroHP -= attackValue;
            //        Console.WriteLine($"Hero was damaged and lost {attackValue} health and now has {heroHP} health.");
            //        if (heroHP <= 0)
            //        {
            //            Console.WriteLine($"Monster wins!");
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Hero wins!");
            //        break;
            //    }

            //} while (heroHP > 0);

            ////Sample output:
            ////Monster was damaged and lost 1 health and now has 9 health.
            //// Hero was damaged and lost 1 health and now has 9 health.
            //// Monster was damaged and lost 7 health and now has 2 health.
            //// Hero was damaged and lost 6 health and now has 3 health.
            //// Monster was damaged and lost 9 health and now has -7 health.
            //// Hero wins!

            ////MS Learn website method
            //int hero = 10;
            //int monster = 10;

            //Random dice = new Random();

            //do
            //{
            //    int roll = dice.Next(1, 11);
            //    monster -= roll;
            //    Console.WriteLine($"Monster was damaged and lost {roll} health and now has {monster} health.");

            //    if (monster <= 0) continue;

            //    roll = dice.Next(1, 11);
            //    hero -= roll;
            //    Console.WriteLine($"Hero was damaged and lost {roll} health and now has {hero} health.");

            //} while (hero > 0 && monster > 0);

            //Console.WriteLine(hero > monster ? "Hero wins!" : "Monster wins!");

            ////What you know, or don't know, about the Boolean expression that will be evaluated can sometimes help you to select between the do-while and while statements. You can switch after you start if your first choice isn't working out as well as you had hoped.

            ////The following code sample uses a nullable type string to capture user input. The iteration continues while the user-supplied value is null:
            //string? readResult;
            //do
            //{
            //    Console.WriteLine("Enter a string:");
            //    readResult = Console.ReadLine();// Ctrl + Z keeps it null
            //} while (readResult == null);

            ////The Boolean expression evaluated by the while statement can be used to ensure user input meets a specified requirement. For example, if a prompt asks the user to enter a string that includes at least three characters, the following code could be used:
            //string? readResult;
            //bool validEntry = false;
            //Console.WriteLine("Enter a string containing at least three characters:");
            //do
            //{
            //    readResult = Console.ReadLine();
            //    if (readResult != null)
            //    {
            //        if (readResult.Length >= 3)
            //        {
            //            validEntry = true;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Your input is invalid, please try again.");
            //        }
            //    }
            //} while (validEntry == false);

            ////Code project 1 - write code that validates integer input
            ////If you want to use Console.ReadLine() input for numeric values, you need to convert the string value to a numeric type.
            //// The int.TryParse() method can be used to convert a string value to an integer. The method uses two parameters, a string that will be evaluated and the name of an integer variable that will be assigned a value. The method returns a Boolean value. The following code sample demonstrates using the int.TryParse() method:
            // capture user input in a string variable named readResult

            //string? readResult;
            //int numericValue = 0;
            //bool validNumber = false;


            //Console.WriteLine("Enter an integer b/w 5 & 10:");
            //do
            //{
            //    readResult = Console.ReadLine();
            //    validNumber = int.TryParse(readResult, out numericValue);

            //    if (readResult != null)
            //    {
            //        if (validNumber)
            //        {

            //            if ((numericValue >= 5) && (numericValue <= 10))
            //            {
            //                Console.WriteLine(numericValue);
            //                break;
            //            }
            //            else
            //            {
            //                Console.WriteLine(numericValue);
            //                Console.WriteLine($"You entered {numericValue}. Please enter number b/w 5 & 10.");
            //                validNumber = false;
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine(readResult);
            //            Console.WriteLine("Sorry, you entered an invalid number, please try again.");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Please enter number b/w 5 & 10.");
            //    }
            //} while (validNumber == false);

            //Console.WriteLine($"Your input value ({numericValue}) has been accepted.");
            //Console.ReadLine();

            ////Code project 2 - write code that validates string input
            //string[] role = ["administrator","manager", "user"];
            //string userInput = "";
            //string refinedUserInput = "";
            //bool roleMatch = false;

            //Console.WriteLine("Enter only one role name from the following three options:");
            //Console.WriteLine("administrator, manager, or user");

            //do
            //{
            //    userInput = Console.ReadLine().Trim();
            //    refinedUserInput = userInput.ToLower();
            //    if ((refinedUserInput == role[0]) || (refinedUserInput == role[1]) || (refinedUserInput == role[2]))
            //    {
            //        roleMatch = true;
            //    }
            //    else
            //    {   Console.WriteLine(
            //        $"The role name that you entered, {userInput} is not valid.\nEnter your role name (Administrator, Manager, or User)");
            //    }


            //} while (!roleMatch);
            //Console.WriteLine($"Your input value({userInput}) has been accepted.\nPress enter to exit.");
            //Console.ReadLine();

            ////Code project 3 - Write code that processes the contents of a string array
            string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
            int periodLocation = 0;

            foreach (var myString in myStrings)
            {
                periodLocation = myString.IndexOf(".");
                Console.WriteLine(periodLocation);
                Console.ReadLine();
                do
                {
                    Console.WriteLine(myString);
                
                    
                } while (expression);

            }
        }
    }
}

