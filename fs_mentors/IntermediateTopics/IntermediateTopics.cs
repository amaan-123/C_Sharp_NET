////Topics included: Arrays, ArrayList(using System.Collections), StringBuilder(using System.Text), Collections & Generics 
////This project will contain many code topics that are not common with the MS_Learn freecodecamp

using System;
using System.Collections;
using System.Text;

////Arrays:
////Arrays can be initialized after the declaration. It is not necessary to declare and initialize at the same time using the new keyword.
////Example:
//// Declaration of the array 
//string[] str1, str2;
//// Initialization of array 
//str1 = new string[5] { “Element 1”, “Element 2”, “Element 3”, “Element 4”, “Element 5” };
//str2 = new string[5] { “Element 1”, “Element 2”, “Element 3”, “Element 4”, “Element 5” };

////Note:
////Initialization without giving size is not valid in C#. It will give a compile-time error. 
////Example: Wrong Declaration for initializing an array
//// Compile-time error: must give size of an array 
//int[] intArray = new int[];
//// Error : wrong initialization of an array 
//string[] str1;
//str1 = {“Element 1”, “Element 2”, “Element 3”, “Element 4” }
//;


////Multi-dim array:
//class Geeks
//{
//    public static void Main()
//    {
//        // The same array with dimensions specified 2, 2 and 3.
//        int[,,] arr = new int[2, 2, 3] { { { 1, 2, 3 },
//                                            { 4, 5, 6 } },
//                                            { { 7, 8, 9 },
//                                            { 10, 11, 12 } } };

//        // Checking elements at particular index
//        Console.WriteLine("arr[1][0][1] : " + arr[1, 0, 1]);

//        Console.WriteLine("arr[1][1][2] : " + arr[1, 1, 2]);

//        Console.ReadKey();
//    }
//}


////Jagged Arrays:An array whose elements are arrays is known as Jagged arrays it means “array of arrays“. The jagged array elements may be of different dimensions and sizes.
////Example: Showing how to declare, initialize and access the jagged arrays
//class Geeks
//{
//    public static void Main()
//    {
//        // Declaring Jagged Array
//        int[][] arr = { new int[] { 1, 3, 5, 7, 9 },
//                        new int[] { 2, 4, 6, 8 } };

//        Console.WriteLine("Arrays :");

//        // Display the array elements:
//        for (int i = 0; i < arr.Length; i++)
//        {
//            System.Console.Write("Elements[" + i + "] Array: ");

//            // Printing the elements of array
//            for (int j = 0; j < arr[i].Length; j++)
//            {
//                Console.Write(arr[i][j] + " ");
//            }

//            Console.WriteLine();
//        }
//        Console.ReadKey();
//    }
//}


////ArrayList
////Let's see how to create an ArrayList using ArrayList() constructor:
////Step 1: Include System.Collections namespace in your program with the help of using keyword.
////Syntax: 
////using System.Collections;
////Step 2: Create an ArrayList using ArrayList class as shown below:
//ArrayList list_name = new ArrayList();
////Step 3: If you want to add elements in your ArrayList then use Add() method to add elements in your ArrayList.As shown in the below example.
////Step 4: The elements of the ArrayList is accessed by using a foreach loop, or by for loop, or by indexer.As shown in the below example we access the ArrayList using a foreach loop.

////Example: Below program show how to create an ArrayList, adding elements to the ArrayList, and how to:
////access the elements of the ArrayList.
////find the Capacity and Count of elements of the ArrayList
////remove elements from the ArrayList
////sort the elements of the ArrayList
//class GFG
//{

//    Main Method
//static public void Main()
//    {

//        Creating ArrayList
//ArrayList My_array = new ArrayList();

//        Adding elements in the
//        My_array ArrayList
//        This ArrayList contains elements
//        of different types
//My_array.Add(12.56);
//        My_array.Add("GeeksforGeeks");
//        My_array.Add(null);
//        My_array.Add('G');
//        My_array.Add(1234);

//        My_array.Add('G');
//        My_array.Add('E');
//        My_array.Add('E');
//        My_array.Add('K');
//        My_array.Add('S');
//        My_array.Add('F');
//        My_array.Add('O');
//        My_array.Add('R');
//        My_array.Add('G');
//        My_array.Add('E');
//        My_array.Add('E');
//        My_array.Add('K');
//        My_array.Add('S');

//        My_array.Add(1);
//        My_array.Add(6);
//        My_array.Add(40);
//        My_array.Add(10);
//        My_array.Add(5);
//        My_array.Add(3);
//        My_array.Add(2);
//        My_array.Add(4);

//        Accessing the elements
//        of My_array ArrayList
// Using foreach loop
//foreach (var elements in My_array)
//            {
//                Console.WriteLine(elements);
//            }

//        Console.WriteLine("---------------------------------");
//        // Displaying count of elements of ArrayList 
//        Console.WriteLine("Number of elements: " + My_array.Count);
//        // Displaying Current capacity of ArrayList 
//        Console.WriteLine("Current capacity: " + My_array.Capacity);

//        // Remove the 'G' element 
//        // from the ArrayList
//        // Using Remove() method
//        My_array.Remove('G');
//        Console.WriteLine("After Remove() method the " +
//              "number of elements: " + My_array.Count);

//        // Remove the element present at index 8
//        // Using RemoveAt() method
//        My_array.RemoveAt(8);
//        Console.WriteLine("After RemoveAt() method the " +
//                "number of elements: " + My_array.Count);

//        // Remove 3 elements starting from index 1
//        // using RemoveRange() method
//        My_array.RemoveRange(1, 3);
//        Console.WriteLine("After RemoveRange() method the " +
//                 "number of elements: " + My_array.Count);

//        // Remove the all element 
//        // present in ArrayList
//        // Using Clear() method
//        My_array.Clear();
//        Console.WriteLine("After Clear() method the " +
//            "number of elements: " + My_array.Count);

//        //ArrayList before sorting
//        Console.WriteLine(" ArrayList before using Sort() method: ");

//        foreach (var elements in My_array)
//        {
//            Console.WriteLine(elements);
//        }

//        // Sort the elements of the ArrayList
//        // Using sort() method
//        My_array.Sort();

//        // ArrayList after sorting
//        Console.WriteLine(" ArrayList after using Sort() method: ");
//        foreach (var elements in My_array)
//        {
//            Console.WriteLine(elements);
//        }

//        Console.ReadKey();
//    }
//}


////StringBuilder
//// Adding element in StringBuilder Object
//class Geeks
//{
//    // Main Method
//    public static void Main()
//    {
//        // "20" is capacity 
//        StringBuilder s = new StringBuilder("HELLO ", 20);

//        s.Append("GFG");

//        // after printing "GEEKS" 
//        // a new line append 
//        s.AppendLine("GEEKS");

//        s.Append("GeeksForGeeks");
//        Console.WriteLine(s);
//        Console.ReadKey();

//    }
//}

//// Adding the Formatted String in
//// StringBuilder Object
//class Geeks
//{
//    // Main Method 
//    public static void Main()
//    {
//        StringBuilder s = new StringBuilder("Your total amount is ");

//        // using the method 
//        s.AppendFormat("{0:C} ", 50);

//        Console.WriteLine(s);
//        Console.ReadKey();

//    }
//}


