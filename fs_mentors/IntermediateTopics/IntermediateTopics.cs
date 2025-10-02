////Topics included: Arrays, StringBuilder(using System.Text), Collections:Generic/Non-generic
////Generic collections: 
////Non-generic collections:ArrayList(using System.Collections), 
////This project will contain many code topics that are not common with the MS_Learn freecodecamp

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
//        //int[][] arr = { new int[] { 1, 3, 5, 7, 9 },
//        //                new int[] { 2, 4, 6, 8 } };


//        //int[][] arr = new int[2][];   // Declare jagged array with 2 rows
//        //arr[0] = new int[] { 1, 3, 5, 7, 9 }; // Assign first inner array
//        //arr[1] = new int[] { 2, 4, 6, 8 };    // Assign second inner array

//        //Since C# 9, you can also use target-typed new if the compiler already knows the type:
//        int[][] arr = new int[2][];
//        arr[0] = new[] { 1, 3, 5, 7, 9 }; // compiler infers int[]
//        arr[1] = new[] { 2, 4, 6, 8 };

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

//        Console.WriteLine(s.Length);
//        Console.WriteLine(s.Capacity);
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

////Insert, similarly, remove & replace
//class Geeks
//{
//    public static void Main()
//    {
//        StringBuilder s = new StringBuilder("HELLO ", 20);
//        s.Insert(6, "GEEKS"); // insert at index 6
//        Console.WriteLine(s);
//    }
//}


//// C# program to illustrate the concept 
//// of generic collection using List<T>

//class Geeks
//{

//    // Main Method
//    public static void Main(String[] args)
//    {

//        // Creating a List of integers
//        List<int> mylist = new List<int>();

//        // adding items in mylist
//        for (int j = 5; j < 10; j++)
//        {
//            mylist.Add(j * 3);
//        }

//        // Displaying items of mylist
//        // by using foreach loop
//        foreach (int items in mylist)
//        {
//            Console.WriteLine(items);
//        }
//    }
//}

////C# to illustrate the concept
//// of non-generic collection using Queue
//class GFG
//{
//    //// Driver code
//    public static void Main()
//    {
//        //// Creating a Queue
//        Queue myQueue = new Queue();
//        //// Inserting the elements into the Queue
//        myQueue.Enqueue("C#");
//        myQueue.Enqueue("PHP");
//        myQueue.Enqueue("Perl");
//        myQueue.Enqueue("Java");
//        myQueue.Enqueue("C");
//        //// Displaying the count of elements
//        //// contained in the Queue
//        Console.Write("Total number of elements present in the Queue are: ");
//        Console.WriteLine(myQueue.Count);
//        //// Displaying the beginning element of Queue
//        Console.WriteLine("Beginning Item is: " + myQueue.Peek());
//    }
//}


////List<T>:
////Creating and printing  a List
//class Geeks
//{
//    public static void Main()
//    {
//        List<string> l = new List<string> { "C#", "Java", "Javascript" };

//        foreach (string name in l)
//        {
//            Console.WriteLine(name);
//        }
//    }
//}

//// Creating List using Constructors
//class Geeks
//{
//    public static void Main()
//    {
//        // default constructor creates an empty list
//        List<int> list = new List<int>();
//        list.Add(10);
//        list.Add(20);
//        Console.WriteLine("Default Constructor: ");
//        foreach (var item in list)
//        {
//            Console.WriteLine(item);
//        }

//        // Construnctors from IEnumerable
//        int[] num = { 10, 20 };
//        List<int> enumerableList = new List<int>(num);
//        Console.WriteLine("Constructor with IEnumerable: ");
//        foreach (var item in enumerableList)
//        {
//            Console.WriteLine(item);
//        }

//        // Constructor with Initial Capacity 
//        List<int> Clist = new List<int>(2);
//        Clist.Add(10);
//        Clist.Add(20);
//        Console.WriteLine("Constructor with Initial Capacity: ");
//        foreach (var item in Clist)
//        {
//            Console.WriteLine(item);
//        }
//    }
//}


////Insert(), Sort(), Reverse(), ToArray():
//List<string> food = new List<string>();
//food.Add("pizza"); //0th index
//food.Add("onion"); //1
//food.Add("semi"); //2
//food.Add("full"); //3

//food.Remove("semi");
//food.Remove("full");
//food.Insert(2, "semolina"); //2 
//food.Insert(3, "full biryani"); //3
//food.Insert(0, "pataka burger"); //0th index, +1 to rest ahead of it
//food.Add("pizza"); //5th index

//Console.WriteLine("List in index-based order is:\n");
//foreach (var item in food)
//{
//    Console.WriteLine(item);

//}
//Console.WriteLine();

//Console.WriteLine(food.Count); // number of elements in list, length not used here
//Console.WriteLine(food.IndexOf("pizza")); // 1st index
//Console.WriteLine(food.LastIndexOf("pizza")); // 5th index
//Console.WriteLine(food.Contains("pataka burger")); //returns boolean
//Console.WriteLine();

//food.Sort(); //changes the food list
//Console.WriteLine("Sorted list is:");

//foreach (var item in food)
//{
//    Console.WriteLine(item);

//}
//Console.WriteLine();

//food.Reverse(); //reverses the sorted list
//Console.WriteLine("Reversed list(previously sorted) is:");

//foreach (var item in food)
//{
//    Console.WriteLine(item);

//}

//food.Clear();

//// Converting the list to an array:
//Console.WriteLine("Converting the list to an array:\n");
//string[] foodArray = food.ToArray();
//foreach (var item in foodArray)
//{
//    Console.WriteLine(item);
//}


//// C# program to illustrate the
//// List.AddRange Method
//class Geeks
//{

//    // Main Method
//    public static void Main(String[] args)
//    {

//        // Creating a List of Strings
//        List<String> firstlist = new List<String>();

//        // adding elements in firstlist
//        firstlist.Add("Geeks");
//        firstlist.Add("GFG");
//        firstlist.Add("C#");
//        firstlist.Add("Tutorials");

//        Console.WriteLine("Before AddRange Method");
//        Console.WriteLine();

//        // displaying the item of List
//        foreach (String str in firstlist)
//        {
//            Console.WriteLine(str);
//        }

//        Console.WriteLine("\nAfter AddRange Method\n");

//        // taking array of String
//        string[] str_add = { "Collections",
//                             "Generic",
//                             "List" };

//        // here we are adding the elements
//        // of the str_add to the end of
//        // the List<T>.
//        firstlist.AddRange(str_add);

//        // displaying the item of List
//        foreach (String str in firstlist)
//        {
//            Console.WriteLine(str);
//        }
//    }
//}

//// C# program to remove elements from the list
//// interesting: RemoveRange(startIndex, count)
//class Geeks

//{

//    static public void Main()

//    {

//        // Creating list using List class

//        // and List<T>() Constructor

//        List < int\> l \= new List<int\>();
//        // Adding elements to List

//        // Using Add() method

//        l.Add(1);

//        l.Add(2);

//        l.Add(3);

//        l.Add(4);

//        l.Add(5);
//        // Initial count

//        Console.WriteLine("Initial count:{0}", l.Count);

//        l.Remove(3);

//        Console.WriteLine("after removing 3");

//        Console.WriteLine("2nd count:{0}", l.Count);
//        l.RemoveAt(3);

//        Console.WriteLine("after removing at 4th index");

//        Console.WriteLine("3rd count:{0}", l.Count);
//        l.RemoveRange(0, 2);

//        Console.WriteLine("after removing range from index 0 for 2 counts");

//        Console.WriteLine("4th count:{0}", l.Count);
//        l.Clear();

//        Console.WriteLine("after removing all elements");

//        Console.WriteLine("5th count:{0}", l.Count);

//    }

//}


//// Creating and adding key, values to the sorted list(generic)
//class Geeks
//{
//    public static void Main()
//    {
//        // Creating a SortedList
//        SortedList<int, string> sl = new SortedList<int, string>();

//        // Adding key-value pairs
//        sl.Add(3, "Three");
//        sl.Add(1, "One");
//        sl.Add(2, "Two");

//        // Displaying elements in sorted by key
//        foreach (var item in sl)
//        {
//            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
//        }
//    }
//}


//// C# program to illustrate how
//// to create a sortedlist
//using System.Collections;

//class Geeks
//{
//    static public void Main()
//    {

//        // Creating a sortedlist
//        // Using SortedList class
//        SortedList sl = new SortedList();

//        // Adding key-value pairs in 
//        // SortedList using Add() method
//        sl.Add(1.02, "This");
//        sl.Add(1.07, "Is");
//        sl.Add(1.04, "SortedList");

//        foreach (DictionaryEntry pair in sl)
//        {
//            Console.WriteLine("{0}(type:{2}) and {1}(type:{3})",
//            pair.Key, pair.Value, pair.Key.GetType(), pair.Value.GetType());
//        }
//        Console.WriteLine();

//        // Creating another SortedList
//        // using Object Initializer Syntax
//        // to initialize sortedlist
//        SortedList my_slist2 = new SortedList() {
//                                { "b.09", 234 },
//                                { "b.11", 395 },
//                                { "b.01", 405 },
//                                { "b.67", 100 }};

//        foreach (DictionaryEntry pair in my_slist2)
//        {
//            Console.WriteLine("{0}(type:{2}) and {1}(type:{3})",
//            pair.Key, pair.Value, pair.Key.GetType(), pair.Value.GetType());
//        }
//    }
//}

//// Creating a SortedList and
//// accessing its elements .GetKey(i), .GetByIndex(i)
//using System.Collections;

//class Geeks
//{
//    static void Main()
//    {
//        SortedList sl = new SortedList {
//        { 1, "Geek1" }, { 2, "Geek2" }, { 3, "Geek3" }
//        };

//        // Using for loop
//        Console.WriteLine("Access using for loop");
//        for (int i = 0; i < sl.Count; i++)
//            Console.WriteLine($"{sl.GetKey(i)}: {sl.GetByIndex(i)}");


//        // Using foreach loop
//        Console.WriteLine("Access using foreach loop");

//        foreach (DictionaryEntry entry in sl)
//            Console.WriteLine($"{entry.Key}: {entry.Value}");

//        // Using indexer
//        Console.WriteLine("Access using indexer");
//        Console.WriteLine($"Key 2: {sl[2]}");
//    }
//}

//// Removing key-value pairs from 
//// the sortedlist
//using System.Collections;

//class Geeks
//{
//    static public void Main()
//    {
//        // Creating a sortedlist
//        // Using SortedList class
//        SortedList sl = new SortedList();

//        // Adding key/value pairs in SortedList
//        // Using Add() method
//        sl.Add(1, "one");
//        sl.Add(2, "two");
//        sl.Add(3, "three");

//        foreach (DictionaryEntry pair in sl)
//        {
//            Console.WriteLine("{0} and {1}",
//                    pair.Key, pair.Value);
//        }
//        Console.WriteLine();

//        // Remove value having 1.07 key
//        // Using Remove() method
//        sl.Remove(1);

//        // After Remove() method
//        foreach (DictionaryEntry pair in sl)
//        {
//            Console.WriteLine("{0} and {1}",
//            pair.Key, pair.Value);
//        }
//        Console.WriteLine();

//        // Remove element at index 2
//        // Using RemoveAt() method
//        sl.RemoveAt(1);

//        // After RemoveAt() method
//        foreach (DictionaryEntry pair in sl)
//        {
//            Console.WriteLine("{0} and {1}",
//            pair.Key, pair.Value);
//        }
//        Console.WriteLine();

//        // Remove all key/value pairs
//        // Using Clear method
//        sl.Clear();
//        Console.WriteLine("Total pairs" +
//        " present in sorted list is: {0}", sl.Count);
//    }
//}

//// C# program to demonstrates how to use Queue
//class Geeks
//{
//    public static void Main(string[] args)
//    {
//        // Create a new queue
//        Queue<int> q = new Queue<int>();

//        // Enqueue elements into the queue
//        q.Enqueue(1);
//        q.Enqueue(2);
//        q.Enqueue(3);
//        q.Enqueue(4);

//        // Dequeue elements from the queue
//        while (q.Count > 0)
//        {
//            Console.WriteLine(q.Dequeue());
//        }
//    }
//}


////C# Program to remove
////  elements from a queue
//class Geeks
//{
//    public static void Main(string[] args)
//    {
//        // Initialize a queue
//        Queue<string> q = new Queue<string>();

//        // Inserting elements into the 
//        // queue using Enqueue()
//        q.Enqueue("Geeks");
//        q.Enqueue("For");
//        q.Enqueue("Geeks");
//        q.Enqueue("For");

//        // Initial queue
//        Console.WriteLine("Initial queue: ");
//        foreach (var item in q)
//        {
//            Console.WriteLine(item);
//        }

//        // Removing the front element
//        q.Dequeue();

//        // Final queue after removal
//        Console.WriteLine("\nUpdated queue after Dequeue:");
//        foreach (var item in q)
//        {
//            Console.WriteLine(item);
//        }
//    }
//}


//// C# Program to get the
//// front element of the Queue
//class Geeks
//{
//    public static void Main(string[] args)
//    {
//        // Create a new queue of integers
//        Queue<int> q = new Queue<int>();

//        // Enqueue elements into the queue
//        q.Enqueue(10);
//        q.Enqueue(20);
//        q.Enqueue(30);

//        // Checking if the queue is not empty before
//        // accessing the front element
//        if (q.Count > 0)
//        {

//            // Peek() returns the frontmost element without
//            // removing it
//            int f = q.Peek();
//            Console.WriteLine(
//                "The frontmost element in the queue is: "
//                + f);
//        }
//        else
//        {
//            Console.WriteLine("The queue is empty.");
//        }
//    }
//}

// C# Program to check the
// availability of elements in the queue
class Geeks
{
    public static void Main(string[] args)
    {
        // Create a new queue of integers
        Queue<int> q = new Queue<int>();

        // Enqueue elements into the queue
        q.Enqueue(10);
        q.Enqueue(20);
        q.Enqueue(30);

        // Check if the element 20 is present in the queue
        Console.WriteLine(
            "The element 20 is present in the queue: "
            + q.Contains(20));

        Console.WriteLine(
            "The element 100 is present in the queue: "
            + q.Contains(100));
    }
}