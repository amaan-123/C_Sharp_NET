//int first = 2;
//string second = "4";
//int result = first + second;
//Console.WriteLine(result);


//int myInt = 3;
//Console.WriteLine($"int: {myInt}");
//decimal myDecimal = myInt;
//Console.WriteLine($"decimal: {myDecimal}");


//decimal myDecimal = 3.14m;
//Console.WriteLine($"decimal: {myDecimal}");
//int myInt = (int)myDecimal;
//Console.WriteLine($"int: {myInt}");


//decimal myDecimal = 1.23456789m;
//float myFloat = (float)myDecimal;
//Console.WriteLine($"Decimal: {myDecimal}");
//Console.WriteLine($"Float  : {myFloat}");


//int first = 5;
//int second = 7;
//string message = first.ToString() + second.ToString();
//Console.WriteLine(message);

// string value1 = "5";
// string value2 = "7";
// int result = Convert.ToInt32(value1) * Convert.ToInt32(value2);
// Console.WriteLine(result);

// int value = (int)1.5m; // casting truncates
// Console.WriteLine(value);
// int value2 = Convert.ToInt32(1.5m); // converting rounds up
// Console.WriteLine(value2);

//// 2/9 - Exercise - Complete a challenge to combine string array values as strings and as integers
//// Output: 
////Message: ABCDEF
////Total: 68.3
//string[] values = ["12.3", "45", "ABC", "11", "DEF"];
//float total = 0.0f;
//float currentNumber = 0.0f;
//string message = "";
////Console.WriteLine(total);
////Console.WriteLine(currentNumber);
//foreach (string value in values)
//{
//    if (Single.TryParse(value, out currentNumber))
//    {
//        total += currentNumber;
//    }
//    else
//    {
//        message += value;
//    }

//}
//Console.WriteLine($"Message: {message}");
//Console.WriteLine($"Total: {total}");

//int value1 = 11;
//decimal value2 = 6.2m;
//float value3 = 4.3f;

//// The Convert class is best for converting the fractional decimal numbers into whole integer numbers
//// Convert.ToInt32() rounds up the way you would expect.
//int result1 = Convert.ToInt32(value1 / value2);
//Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");

//// Your code here to set result2
//decimal result2 = (value2 / (decimal)value3);
//Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");

//// Your code here to set result3
//float result3 = (value3 / value1);
//Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");


//// Perform operations on arrays using helper methods in C#
//// Array.Sort() and Array.Reverse() to sort and reverse elements of an array.
//string[] pallets = ["B14", "A11", "B12", "A13"];

//Console.WriteLine("Sorted...");
//Array.Sort(pallets);
//foreach (var pallet in pallets)
//{
//    Console.WriteLine($"-- {pallet}");
//}

//Console.WriteLine("");
//Console.WriteLine("Reversed...");
//Array.Reverse(pallets);
//foreach (var pallet in pallets)
//{
//    Console.WriteLine($"-- {pallet}");
//}

////Explore Array.Clear() and Array.Resize() array methods to clear and resize an array
//string[] pallets = ["B14", "A11", "B12", "A13"];
//Console.WriteLine("");

//Console.WriteLine($"Before: {pallets[0]}");
//Array.Clear(pallets, 0, 2);
////Access the value of a cleared element
//Console.WriteLine($"After: {pallets[0]}");
////If you focus on the line of output After: , you might think that the value stored in pallets[0] is an empty string.
////However, the C# Compiler implicitly converts the null value to an empty string for presentation.
//Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
//foreach (var pallet in pallets)
//{
//    Console.WriteLine($"-- {pallet}");
//}

//string[] pallets = ["B14", "A11", "B12", "A13"];
//Console.WriteLine("");

//Console.WriteLine($"Before: {pallets[0].ToLower()}");
//Array.Clear(pallets, 0, 2);
//if (pallets[0] != null)
//    Console.WriteLine($"After: {pallets[0].ToLower()}");

//Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
//foreach (var pallet in pallets)
//{
//    Console.WriteLine($"-- {pallet}");
//}

//string[] pallets = ["B14", "A11", "B12", "A13"];
//Console.WriteLine("");

//Array.Clear(pallets, 0, 2);
//Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
//foreach (var pallet in pallets)
//{
//    Console.WriteLine($"-- {pallet}");
//}

//Console.WriteLine("");
//Array.Resize(ref pallets, 6);

////focus on the line Array.Resize(ref pallets, 6);.
////Here, you're calling the Resize() method passing in the pallets array by reference, using the ref keyword. In some cases, methods require you pass arguments by value (the default) or by reference (using the ref keyword). The reasons why this is necessary requires a long and complicated explanation about of how objects are managed in .NET.

//Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");

//pallets[4] = "C01";
//pallets[5] = "C02";

//foreach (var pallet in pallets)
//{
//    Console.WriteLine($"-- {pallet}");
//}

//Console.WriteLine("");
//Array.Resize(ref pallets, 3);
//Console.WriteLine($"Resizing 3 ... count: {pallets.Length}");

//foreach (var pallet in pallets)
//{
//    Console.WriteLine($"-- {pallet}");
//}
////Notice that calling Array.Resize() didn't eliminate the first two null elements. Rather, it removed the last three elements. Notably, last three elements were removed even though they contained string values.
////Can you remove null elements from an array?
////If the Array.Resize() method doesn't remove empty elements from an array, is there another helper method that does the job automatically? No. The best way to empty elements from an array would be to count the number of non-null elements by iterating through each item and increment a variable (a counter). Next, you would create a second array that is the size of the counter variable. Finally, you would loop through each element in the original array and copy non-null values into the new array.


//Exercise - Discover Split() and Join()
//String data type's Array methods
//The variables of type string have many built-in methods that convert a single string into either an array of smaller strings, or an array of individual characters.
// When you process data from other computer systems, sometimes it formats or encodes in a way that's not useful for your purposes. In these cases, you use the string data type's Array methods to parse a string into an array.

////Use the ToCharArray() to reverse a string
//string value = "abc123";

//char[] valueArray = value.ToCharArray();
////Array.ForEach(valueArray, Console.WriteLine);

//Array.Reverse(valueArray);
////Array.ForEach(valueArray, Console.WriteLine);

////Reversed, and then combined the char array into a new string
////string result = new string(valueArray);

////Combine all of the chars into a new comma-separated-value string using Join()
//string result = String.Join(",", valueArray);
//Console.WriteLine(result);

////Split() the comma-separated-value string into an array of strings
////To complete the code, the Split() method is used. This method is designed for variables of type string and creates an array of strings.
//string[] items = result.Split(',');
//foreach (string item in items)
//{
//    Console.WriteLine(item);
//}

////a solution to the reverse words in a sentence challenge
//string pangram = "The quick brown fox jumps over the lazy dog";

//// Step 1
//string[] message = pangram.Split(' ');

////Step 2
//string[] newMessage = new string[message.Length];

//// Step 3
//for (int i = 0; i < message.Length; i++)
//{
//    char[] letters = message[i].ToCharArray();
//    Array.Reverse(letters);
//    newMessage[i] = new string(letters);
//}

////Step 4
//string result = String.Join(" ", newMessage);
//Console.WriteLine(result);


////my solution:
////split into words - an array of type string
////split each word into an array of char
////reverse char array for each word
////join chars to form each reversedWord string?
////join reversedWord strings to form reversedPhrase

//string[] words = pangram.Split(' ');
//string reversedPhrase = "";

//foreach (string word in words)
//{
//    char[] letters = word.ToCharArray();
//    //foreach (char letter in letters)
//    //{
//    //    Console.WriteLine($"before: {letter}");
//    //}
//    Array.Reverse(letters);
//    //foreach (char letter in letters)
//    //{
//    //    Console.WriteLine($"after: {letter}");
//    //}
//    //Console.WriteLine(word);
//    string reversedWord = string.Join("", letters);
//    //Console.WriteLine(reversedWord);
//    reversedPhrase = reversedPhrase + $" {reversedWord}";
//}
//Console.WriteLine(reversedPhrase);

////Complete a challenge to parse a string of orders, sort the orders and tag possible errors
//// In this challenge you have to parse the individual "Order IDs", and output the "OrderIDs" sorted and tagged as "Error" if they aren't exactly four characters in length.
//// Add code below the orderStream variable initialization to parse the "Order IDs" from the string of incoming orders and store the "Order IDs" in an array.
//// Add code to output each "Order ID" in sorted order and tag orders that aren't exactly four characters in length as "- Error".

//// Your code must produce the following output:
//// Output
//// 
//// A345
//// B123
//// B177
//// B179
//// C15     - Error
//// C234
//// C235
//// G3003   - Error
//string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
//string[] orderIDs = orderStream.Split(',');
//Array.Sort(orderIDs);
//foreach (string order in orderIDs)
//{
//    if (order.Length == 4)
//    {
//        Console.WriteLine(order);
//    }
//    else
//    {
//        Console.WriteLine($"{order}\t- Error");

//    }
//}



//// Format alphanumeric data for presentation in C#
//// If you look at code examples in books and online, you're likely to see both composite formatting and string interpolation used, but generally you should choose string interpolation.
/// 
////What is Composite Formatting?
//string first = "Hello";
//string second = "World";
//Console.WriteLine("{1} {0}!", first, second);
//Console.WriteLine("{0} {0} {0}!", first, second);

////Formatting currency
////In the following example, the :C currency format specifier is used to present the price and discount variables as currency. 
//decimal price = 123.45m;
//int discount = 50;
//Console.WriteLine($"Price: {price:C} (Save {discount:C})");

////Formatting numbers
////When working with numeric data, you might want to format the number for readability by including commas to delineate thousands, millions, billions, and so on.
//// The N numeric format specifier makes numbers more readable.
//decimal measurement = 123456.78912m;
//Console.WriteLine($"Measurement: {measurement:N} units");

////By default, the N numeric format specifier displays only two digits after the decimal point.
////    If you want to display more precision, you can do that by adding a number after the specifier. The following code will display four digits after the decimal point using the N4 specifier.
//decimal measurement = 123456.78912m;
//Console.WriteLine($"Measurement: {measurement:N4} units");

////Formatting percentages
////Use the P format specifier to format percentages and rounds to 2 decimal places. Add a number afterwards to control the number of values displayed after the decimal point.
//decimal tax = .36785m;
//Console.WriteLine($"Tax rate: {tax:P2}");

////Combining formatting approaches
////String variables can store strings created using formatting techniques. In the following example, decimals and decimal math results are formatted and stored in the yourDiscount string using composite formatting.
//decimal price = 67.55m;
//decimal salePrice = 59.99m;

//string yourDiscount = String.Format("You saved {0:C2} off the regular {1:C2} price. ", (price - salePrice), price);

////concatenating the calculated percentage using the string interpolation instead of string concatenation
////You don't need to use String.Format() with this string interpolation approach.
//yourDiscount += $"A discount of {((price - salePrice) / price):P2}!"; //inserted
//Console.WriteLine(yourDiscount);

//int invoiceNumber = 1201;
//decimal productShares = 25.4568m;
//decimal subtotal = 2750.00m;
//decimal taxPercentage = .15825m;
//decimal total = 3185.19m;

//Console.WriteLine($"Invoice Number: {invoiceNumber}");

////Display the product shares with one thousandth of a share (0.001) precision
//Console.WriteLine($"   Shares: {productShares:N3} Product");
////Display the subtotal that you charge the customer formatted as currency
//Console.WriteLine($"     Sub Total: {subtotal:C}");
////Display the tax charged on the sale formatted as a percentage
//Console.WriteLine($"           Tax: {taxPercentage:P2}");
////Finalize the receipt with the total amount due formatted as currency
//Console.WriteLine($"     Total Billed: {total:C}");


////Discover padding and alignment


////Formatting strings by adding whitespace before or after
////The PadLeft() method adds blank spaces to the left-hand side of the string so that the total number of characters equals the argument you send it. In this case, you want the total length of the string to be 12 characters.
//string input = "Pad this";
//Console.WriteLine(input.PadLeft(12));
//Console.WriteLine(input.PadRight(12));
////can also call a second overloaded version of the method and pass in whatever character you want to use instead of a space
//Console.WriteLine(input.PadLeft(12, '-'));
//Console.WriteLine(input.PadRight(12, '-'));

////Working with padded strings
////payment processing company that still supports legacy mainframe systems. Often, those systems require data to be input in specific columns. For example, store the Payment ID in columns 1 through 6, the payee's name in columns 7 through 30, and the Payment Amount in columns 31 through 40. Also, importantly, the Payment Amount is right-aligned.

//string paymentId = "769C";
//string payeeName = "Mr. Stephen Ortega";
//string paymentAmount = "$5,000.00";

//var formattedLine = paymentId.PadRight(6);
//formattedLine += payeeName.PadRight(24);
////Next, add a fictitious Payment Amount and make sure to use PadLeft() to right-align the output.
//formattedLine += paymentAmount.PadLeft(10);

//Console.WriteLine("1234567890123456789012345678901234567890");//to count column number
//Console.WriteLine(formattedLine);


////Complete a challenge to apply string interpolation to a form letter
//Dear Ms. Barros,
//As a customer of our Magic Yield offering we are excited to tell you about a new financial product that would dramatically increase your return.

//Currently, you own 2,975,000.00 shares at a return of 12.75%.

//Our new product, Glorious Future offers a return of 13.13%.  Given your current volume, your potential profit would be ¤63,000,000.00.

//Here's a quick comparison:

//Magic Yield         12.75%   $55,000,000.00      
//Glorious Future     13.13%   $63,000,000.00 

//my solution:
//string customerName = "Ms. Barros";

//string currentProduct = "Magic Yield";
//int currentShares = 2975000;
//decimal currentReturn = 0.1275m;
//decimal currentProfit = 55000000.0m;

//string newProduct = "Glorious Future";
//decimal newReturn = 0.13125m;
//decimal newProfit = 63000000.0m;

//Console.WriteLine($"Dear {customerName},\n");
//Console.WriteLine($"As a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.\n");
//Console.WriteLine($"Currently, you own {currentShares:N2} at a return of {currentReturn:P2}.\n");
//Console.WriteLine($"Our new product, {newProduct} offers a return of {newReturn:P2}. Given your current volume, your potential profit would be {newProfit:C2}.\n");

//Console.WriteLine("Here's a quick comparison:\n");
////string test = "Magic Yield         12.75%   $55,000,000.00";
////Console.WriteLine(test.IndexOf("1"));//20
////Console.WriteLine(test.IndexOf("$"));//29

//string comparisonMessage = "";

//comparisonMessage += currentProduct.PadRight(20) + $"{currentReturn:P2}".PadRight(8) + $"{currentProfit:C2}".PadLeft(15);
//Console.WriteLine(comparisonMessage);
//comparisonMessage = "";
//comparisonMessage += newProduct.PadRight(20) + $"{newReturn:P2}".PadRight(8) + $"{newProfit:C2}".PadLeft(15);
//Console.WriteLine(comparisonMessage);

////MS Learn solution:
//string customerName = "Ms. Barros";

//string currentProduct = "Magic Yield";
//int currentShares = 2975000;
//decimal currentReturn = 0.1275m;
//decimal currentProfit = 55000000.0m;

//string newProduct = "Glorious Future";
//decimal newReturn = 0.13125m;
//decimal newProfit = 63000000.0m;

//Console.WriteLine($"Dear {customerName},");
//Console.WriteLine($"As a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.\n");
//Console.WriteLine($"Currently, you own {currentShares:N} shares at a return of {currentReturn:P}.\n");
//Console.WriteLine($"Our new product, {newProduct} offers a return of {newReturn:P}.  Given your current volume, your potential profit would be {newProfit:C}.\n");

//Console.WriteLine("Here's a quick comparison:\n");

//string comparisonMessage = "";

//comparisonMessage = currentProduct.PadRight(20);
//comparisonMessage += String.Format("{0:P}", currentReturn).PadRight(10);
//comparisonMessage += String.Format("{0:C}", currentProfit).PadRight(20);

//comparisonMessage += "\n";
//comparisonMessage += newProduct.PadRight(20);
//comparisonMessage += String.Format("{0:P}", newReturn).PadRight(10);
//comparisonMessage += String.Format("{0:C}", newProfit).PadRight(20);

//Console.WriteLine(comparisonMessage);

////Use the string's IndexOf() and Substring() helper methods
//string message = "Find what is (inside the parentheses)";

//int openingPosition = message.IndexOf('(');
//int closingPosition = message.IndexOf(')');

//openingPosition += 1;
//// Console.WriteLine(openingPosition);
//// Console.WriteLine(closingPosition);

////Add code to retrieve the value between parenthesis
//int length = closingPosition - openingPosition;
//Console.WriteLine(message.Substring(openingPosition, length));

//string message = "What is the value <span>between the tags</span>?";

//int openingPosition = message.IndexOf("<span>");
//int closingPosition = message.IndexOf("</span>");

//openingPosition += 6;
//int length = closingPosition - openingPosition;
//Console.WriteLine(message.Substring(openingPosition, length));

////Avoid magic values
//// Hardcoded strings like "<span>" in the previous code listing are known as "magic strings" and hardcoded numeric values like 6 are known as "magic numbers". These "Magic" values are undesirable for many reasons and you should try to avoid them if possible.
//string message = "What is the value <span>between the tags</span>?";

//const string openSpan = "<span>";
//const string closeSpan = "</span>";

//int openingPosition = message.IndexOf(openSpan);
//int closingPosition = message.IndexOf(closeSpan);

//openingPosition += openSpan.Length;
//int length = closingPosition - openingPosition;
//Console.WriteLine(message.Substring(openingPosition, length));
////Take a minute to examine the updated code and the use of the keyword `const` as used in `const string openSpan = "<span>";`.

////The code uses a constant with the `const` keyword. A constant allows you to define and initialize a variable whose value can never be changed. You would then use that constant in the rest of the code whenever you needed that value. This ensures that the value is only defined once and misspelling the `const` variable is caught by the compiler.

////The previous code listing is a safer way to write the same code you examined in the previous section. Now, if the value of `openSpan` changes to `<div>`, the line of code that uses the `Length` property continues to be valid.


//string message = "hello there!";

//int first_h = message.IndexOf('h');
//int last_h = message.LastIndexOf('h');

//Console.WriteLine($"For the message: '{message}', the first 'h' is at position {first_h} and the last 'h' is at position {last_h}.");

//string message = "(What if) I am (only interested) in the last (set of parentheses)?";
//int openingPosition = message.LastIndexOf('(');

//openingPosition += 1;
//int closingPosition = message.LastIndexOf(')');
//int length = closingPosition - openingPosition;
//Console.WriteLine(message.Substring(openingPosition, length));


////Retrieve all instances of substrings inside parentheses
////This time, update the message to have three sets of parentheses, and write code to extract any text inside of the parentheses. You're able to reuse portions of the previous work, but you need to add a while statement to iterate through the string until all sets of parentheses are discovered, extracted, and displayed.
//string message = "(What if) there are (more than) one (set of parentheses)?";
//while (true)
//{
//    int openingPosition = message.IndexOf('(');
//    if (openingPosition == -1) break;

//    openingPosition += 1;
//    int closingPosition = message.IndexOf(')');
//    int length = closingPosition - openingPosition;
//    Console.WriteLine(message.Substring(openingPosition, length));

//    // Note the overload of the Substring to return only the remaining 
//    // unprocessed message:
//    message = message.Substring(closingPosition + 1);
//}

//// Replace one substring with another with String.Replace.

//string source = "The mountains are behind the clouds today.";
//// Only exact matches are supported.
//var replacement = source.Replace("mountains", "peaks");
//Console.WriteLine($"The source string is <{source}>");
//Console.WriteLine($"The updated string is <{replacement}>");

////The preceding code demonstrates this _immutable_ property of strings. You can see in the preceding example that the original string, `source`, isn't modified. The [String.Replace](/en-us/dotnet/api/system.string.replace) method creates a new `string` containing the modifications.


//string source = "Many mountains are behind many clouds today.";
//// Remove a substring from the middle of the string.
//string toRemove = "many ";
//string result = string.Empty;
//int i = source.IndexOf(toRemove);
//if (i >= 0)
//{
//    result = source.Remove(i, toRemove.Length);
//}
//Console.WriteLine(source);
//Console.WriteLine(result);


//Work with different types of symbol sets with IndexOfAny()
// This time, search for several different character symbols, not just a set of parentheses by using .IndexOfAny().
// 
// .IndexOfAny() reports the index of the first occurrence of any character in a supplied array of characters. The method returns -1 if all characters in the array of characters are not found.
//string message = "Hello, world!";
//char[] charsToFind = { 'a', 'e', 'i' };

//int index = message.IndexOfAny(charsToFind);

//Console.WriteLine($"Found '{message[index]}' in '{message}' at index: {index}.");

////Work with different types of symbol sets with IndexOfAny()
////The variable closingPosition is used to find the length passed into the Substring() method, and to find the next openingPosition value:
////For this reason, the closingPosition variable is defined outside of the while loop scope and initialized to 0 for the first iteration.

string message = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";

// The IndexOfAny() helper method requires a char array of characters. 
// You want to look for:

char[] openSymbols = { '[', '{', '(' };

// You'll use a slightly different technique for iterating through 
// the characters in the string. This time, use the closing 
// position of the previous iteration as the starting index for the 
//next open symbol. So, you need to initialize the closingPosition 
// variable to zero:

int closingPosition = 0;

while (true)
{
    int openingPosition = message.IndexOfAny(openSymbols, closingPosition);

    if (openingPosition == -1) break;

    string currentSymbol = message.Substring(openingPosition, 1);

    // Now  find the matching closing symbol
    char matchingSymbol = ' ';

    switch (currentSymbol)
    {
        case "[":
            matchingSymbol = ']';
            break;
        case "{":
            matchingSymbol = '}';
            break;
        case "(":
            matchingSymbol = ')';
            break;
    }

    // To find the closingPosition, use an overload of the IndexOf method to specify 
    // that the search for the matchingSymbol should start at the openingPosition in the string. 

    openingPosition += 1;
    closingPosition = message.IndexOf(matchingSymbol, openingPosition);

    // Finally, use the techniques you've already learned to display the sub-string:

    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length));
}

////LastIndexOf() returns the last position of a character or string inside of another string.
////IndexOfAny() returns the first position of an array of char that occurs inside of another string.
