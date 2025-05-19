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