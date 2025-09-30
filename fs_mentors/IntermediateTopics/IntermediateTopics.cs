//Topics included: Collections & Generics 
//This project contains code that is further than the MS_Learn freecodecamp

using System;

////Arrays:
//Arrays can be initialized after the declaration. It is not necessary to declare and initialize at the same time using the new keyword.

//Example:

//// Declaration of the array 
//string[] str1, str2;

//// Initialization of array 
//str1 = new string[5] { “Element 1”, “Element 2”, “Element 3”, “Element 4”, “Element 5” };
//str2 = new string[5] { “Element 1”, “Element 2”, “Element 3”, “Element 4”, “Element 5” };

//Note:

//Initialization without giving size is not valid in C#. It will give a compile-time error. 

//Example: Wrong Declaration for initializing an array

//// Compile-time error: must give size of an array 
//int[] intArray = new int[];

//// Error : wrong initialization of an array 
//string[] str1;
//str1 = {“Element 1”, “Element 2”, “Element 3”, “Element 4” };

//Multi-dim array:
class Geeks
{
    public static void Main()
    {
        // The same array with dimensions specified 2, 2 and 3.
        int[,,] arr = new int[2, 2, 3] { { { 1, 2, 3 },
                                            { 4, 5, 6 } },
                                            { { 7, 8, 9 },
                                            { 10, 11, 12 } } };

        // Checking elements at particular index
        Console.WriteLine("arr[1][0][1] : " + arr[1, 0, 1]);

        Console.WriteLine("arr[1][1][2] : " + arr[1, 1, 2]);

        Console.ReadKey();
    }
}