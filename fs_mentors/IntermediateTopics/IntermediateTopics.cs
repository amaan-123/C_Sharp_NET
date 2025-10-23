////This project will contain many code topics that are not common with the MS_Learn freecodecamp
////Topics included: Arrays, StringBuilder(using System.Text), Collections:Generic(List<T>, LinkedList<T>, Dictionary)/Non-generic(ArrayList, Hashtable), Both(SortedList, Queue, Stack,...)

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

////Generic collections: 
////Non-generic collections:ArrayList(using System.Collections)
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

//using System.Collections;
//class GFG
//{

//    //    Main Method
//    static public void Main()
//    {

//        //Creating ArrayList
//        ArrayList My_array = new ArrayList();

//        //Adding elements in the
//        //My_array ArrayList
//        //This ArrayList contains elements
//        //of different types
//        My_array.Add(12.56);
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

//        //   Accessing the elements
//        //   of My_array ArrayList
//        //Using foreach loop
//        foreach (var elements in My_array)
//        {
//            Console.WriteLine(elements);
//        }

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
//        //My_array.Clear();
//        //Console.WriteLine("After Clear() method the " +
//        //    "number of elements: " + My_array.Count);

//        //ArrayList before sorting
//        Console.WriteLine("ArrayList before using Sort() method: ");

//        foreach (var elements in My_array)
//        {
//            Console.WriteLine(elements);
//        }

//        // Sort the elements of the ArrayList
//        // Using sort() method
//        My_array.Sort();

//        // ArrayList after sorting
//        Console.WriteLine("ArrayList after using Sort() method: ");
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



////List
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
//using System.Collections;
//class GFG
//{
//    //// Driver code
//    public static void Main()
//    {
//        //// Creating a Queue
//        Queue myQueue = new Queue();
//        //// Inserting the elements into the Queue
//        myQueue.Enqueue("C#");
//        myQueue.Enqueue(1);
//        myQueue.Enqueue(1.01);
//        myQueue.Enqueue(true);
//        myQueue.Enqueue(Math.Pow(10.01, 31));
//        //// Displaying the count of elements
//        //// contained in the Queue
//        Console.Write("Total number of elements present in the Queue are: ");
//        Console.WriteLine(myQueue.Count);
//        //// Displaying the beginning element of Queue
//        Console.WriteLine("Beginning Item is: " + myQueue.Peek());
//        foreach (var item in myQueue)
//        {
//            Console.WriteLine($"{item} is of type:\r\n\t{item.GetType()}");
//        }
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

////food.Clear();

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


//// SortedList
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


////Queue
////C# program to demonstrates how to use Queue
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


//C# Program to remove
//  elements from a queue
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


// C# Program to get the
// front element of the Queue
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

//// C# Program to check the
//// availability of elements in the queue
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

//        // Check if the element 20 is present in the queue
//        Console.WriteLine(
//            "The element 20 is present in the queue: "
//            + q.Contains(20));

//        Console.WriteLine(
//            "The element 100 is present in the queue: "
//            + q.Contains(100));
//    }
//}


////Stack
//// C# Program Implementing Stack Class 
//class Geeks
//{
//    public static void Main(string[] args)
//    {
//        // Create a new stack
//        Stack<int> s = new Stack<int>();

//        // Push elements onto the stack
//        s.Push(1);
//        s.Push(2);
//        s.Push(3);
//        s.Push(4);

//        // Pop elements from the stack
//        while (s.Count > 0)
//        {
//            Console.WriteLine(s.Pop());
//        }
//    }
//}

//// C# program to demonstrates how to
//// create and add elements into a stack
//using System.Collections;

//class Geeks
//{

//    static public void Main()
//    {

//        // Create a stack
//        // Using Stack class
//        Stack s = new Stack();

//        // Adding elements in the Stack
//        // Using Push method
//        s.Push("Geek");
//        s.Push("geeksforgeeks");
//        s.Push(null);
//        s.Push(1);
//        s.Push(10.0);

//        // Accessing the elements
//        // of s Stack
//        // Using foreach loop
//        foreach (var elem in s)
//        {
//            if (elem != null)
//            {
//                Console.WriteLine($"{elem} is of type: \r\n\t {elem.GetType()}");
//            }
//            else
//            {
//                Console.WriteLine("null");
//            }
//        }
//    }
//}


//// C# Program to remove elements
//// from a stack
//class Geeks
//{
//    public static void Main(string[] args)
//    {
//        // Initialize a stack
//        Stack<string> s = new Stack<string>();

//        // Inserting elements into the s using Push()
//        s.Push("Geeks");
//        s.Push("For");
//        s.Push("Geeks");
//        s.Push("For");

//        // Initial stack
//        Console.WriteLine("Initial stack: ");
//        foreach (var item in s)
//        {
//            Console.WriteLine(item);
//        }

//        // Removing the top element 
//        // from the stack
//        s.Pop();

//        // Final s after removal
//        Console.WriteLine("\nUpdated stack after Pop:");
//        foreach (var item in s)
//        {
//            Console.WriteLine(item);
//        }
//    }
//}


////LinkedList<T>
//class Geeks
//{
//    static void Main()
//    {
//        LinkedList<int> l = new LinkedList<int>();

//        // Adds at the end
//        l.AddLast(10);
//        // Adds at the beginning
//        l.AddFirst(20);
//        // Adds at the end
//        l.AddLast(30);
//        // Adds at the end
//        l.AddLast(40);

//        // Display the elements in the LinkedList
//        Console.WriteLine("Elements in the LinkedList:");
//        foreach (var i in l)
//        {
//            Console.WriteLine(i);
//        }
//    }
//}

//class Geeks
//{

//    static void Main()
//    {
//        // Creating a LinkedList of integers
//        LinkedList<int> l = new LinkedList<int>();

//        // Adding elements to the LinkedList using AddLast()
//        l.AddLast(10);
//        l.AddLast(20);
//        l.AddLast(30);
//        l.AddLast(40);
//        l.AddLast(50);
//        l.AddLast(60);

//        // Initial list of numbers
//        Console.WriteLine("Initial List of Numbers: " + string.Join(" ", l));

//        // Removing the first element using Remove(LinkedListNode)
//        l.Remove(l.First);
//        Console.WriteLine("\nAfter Removing the First Element: " + string.Join(" ", l));

//        // Removing a specific element (20) using Remove(T)
//        l.Remove(20);
//        Console.WriteLine("\nAfter Removing Number 20: " + string.Join(" ", l));

//        // Removing the first element using RemoveFirst()
//        l.RemoveFirst();
//        Console.WriteLine("\nAfter Removing the First Element Again: " + string.Join(" ", l));

//        // Removing the last element using RemoveLast()
//        l.RemoveLast();
//        Console.WriteLine("\nAfter Removing the Last Element: " + string.Join(" ", l));

//        // Clearing the entire linkedlist
//        l.Clear();
//        Console.WriteLine("\nNumber of elements in the list after clearing: " + l.Count);
//    }
//}

//class Geeks
//{
//    public static void Main(string[] args)
//    {

//        // Create a new LinkedList of integers
//        LinkedList<int> l = new LinkedList<int>();

//        // Add elements to the LinkedList using AddLast()
//        l.AddLast(10);
//        l.AddLast(20);
//        l.AddLast(30);

//        // Check if the element 20 is present in the LinkedList
//        Console.WriteLine("The element 20 is present in the LinkedList: " + l.Contains(20));

//        // Check if the element 100 is present in the LinkedList
//        Console.WriteLine("The element 100 is present in the LinkedList: " + l.Contains(100));
//    }
//}

//class Geeks
//{
//    static void Main()
//    {
//        LinkedList<string> l = new LinkedList<string>();
//        l.AddLast("A");
//        l.AddLast("C");

//        // Get a reference to the node containing "A"
//        LinkedListNode<string> nodeA = l.Find("A");

//        // Insert "B" after nodeA
//        l.AddAfter(nodeA, "B");

//        // Insert "Start" before the first node
//        l.AddBefore(l.First, "Start");

//        Console.WriteLine("LinkedList after AddAfter and AddBefore:");
//        foreach (string s in l) Console.WriteLine(s);
//    }
//}


////Dictionary
//class Geeks
//{
//    public static void Main()
//    {
//        // Creating a dictionary
//        Dictionary<int, string> sub = new Dictionary<int, string>();

//        // Adding elements
//        sub.Add(1, "C#");
//        sub.Add(2, "Javascript");
//        sub.Add(3, "Dart");

//        // Displaying dictionary
//        foreach (var ele in sub)
//        {
//            Console.WriteLine($"Key: {ele.Key}, Value: {ele.Value}");
//        }
//    }
//}

//class Geeks
//{
//    static public void Main()
//    {
//        // Creating a dictionary
//        Dictionary<int, string> dict = new Dictionary<int, string>();

//        // Adding key-value pairs
//        dict.Add(1, "Welcome");
//        dict.Add(2, "to");
//        dict.Add(3, "GeeksforGeeks");

//        // Before Remove() method
//        foreach (KeyValuePair<int, string> ele in dict)
//        {
//            Console.WriteLine("key: {0}, Value: {1}", ele.Key, ele.Value);
//        }

//        // Remove a key-value pair
//        dict.Remove(1);

//        Console.WriteLine("\nAfter Remove() method:");
//        foreach (KeyValuePair<int, string> ele in dict)
//        {
//            Console.WriteLine("key: {0}, Value: {1}", ele.Key, ele.Value);
//        }
//    }
//}


////Hashtable(non-generic only)
//// C# program to add elements to the hashtable
//using System.Collections;

//class Geeks
//{
//    static void Main()
//    {
//        // Create a new Hashtable
//        Hashtable ht = new Hashtable();

//        // Add key-value pairs to the Hashtable
//        ht.Add("One", 1);
//        ht.Add("Two", 2);
//        ht.Add("Three", 3);

//        Console.WriteLine("Hashtable elements:");
//        foreach (DictionaryEntry e in ht)
//        {
//            Console.WriteLine($"{e.Key}: {e.Value}");
//        }
//    }
//}


//// Add Elements in Hashtable
//using System.Collections;

//class Geeks
//{

//    // Main Method
//    static public void Main()
//    {
//        // Create a hashtable using the Hashtable class
//        Hashtable h1 = new Hashtable();

//        // Adding key/value pairs using Add() method
//        h1.Add("1", "Welcome");
//        h1.Add("2", "to");
//        h1.Add("3", "GeeksforGeeks");

//        Console.WriteLine("Key and Value pairs from h1:");

//        // Iterating through the hashtable using
//        // DictionaryEntry
//        foreach (DictionaryEntry ele1 in h1)
//        {
//            Console.WriteLine("{0} and {1}", ele1.Key,
//                              ele1.Value);
//        }

//        // Create another hashtable using the Hashtable
//        // class and a collection initializer
//        Hashtable h2 = new Hashtable() {
//            { 1, "hello" }, { 2, 234 }, { 3, 230.45 },
//            {
//                4, null
//            }
//        };

//        Console.WriteLine(
//            "Key and Value pairs from h2:");

//        // Iterating through the hashtable using the Keys
//        // collection
//        foreach (var ele2 in h2.Keys)
//        {
//            Console.WriteLine("{0} and {1}", ele2,
//                              h2[ele2]);
//        }
//    }
//}

//// Remove Elements from Hashtable
//using System.Collections;

//class Geeks
//{

//    // Main Method
//    static public void Main()
//    {

//        // Create a hashtable
//        // Using Hashtable class
//        Hashtable h1 = new Hashtable();

//        // Adding key/value pair
//        // in the hashtable
//        // Using Add() method
//        h1.Add("1", "Welcome");
//        h1.Add("2", "to");
//        h1.Add("3", "GeeksforGeeks");

//        // Using remove method
//        // remove A2 key/value pair
//        h1.Remove("2");

//        Console.WriteLine("Key and Value pairs :");

//        foreach (DictionaryEntry e1 in h1)
//        {
//            Console.WriteLine("{0} and {1} ", e1.Key,
//                              e1.Value);
//        }

//        // Before using Clear method
//        Console.WriteLine("Total number of elements present"
//                              + " in h1:{0}",
//                          h1.Count);

//        h1.Clear();

//        // After using Clear method
//        Console.WriteLine(
//            "Total number of elements present in"
//                + " h1:{0}",
//            h1.Count);
//    }
//}

//// C# program to illustrate how
//// to check key/value present
//// in the hashtable or not
//using System.Collections;

//class Geeks
//{

//    // Main Method
//    static public void Main()
//    {

//        // Create a hashtable
//        // Using Hashtable class
//        Hashtable ht = new Hashtable();

//        // Adding key/value pair in the hashtable
//        // Using Add() method
//        ht.Add("1", "Welcome");
//        ht.Add("2", "to");
//        ht.Add("3", "GeeksforGeeks");

//        // Determine whether the given
//        // key present or not
//        // using Contains method
//        Console.WriteLine(ht.Contains("3"));
//        Console.WriteLine(ht.Contains(12));
//        Console.WriteLine();

//        // Determine whether the given
//        // key present or not
//        // using ContainsKey method
//        Console.WriteLine(ht.ContainsKey("1"));
//        Console.WriteLine(ht.ContainsKey(1));
//        Console.WriteLine();

//        // Determine whether the given
//        // value present or not
//        // using ContainsValue method
//        Console.WriteLine(ht.ContainsValue("geeks"));
//        Console.WriteLine(ht.ContainsValue("to"));
//    }
//}

//// C# Program to demonstrates how to update the hashtable
//using System.Collections;

//class Geeks
//{
//    static void Main()
//    {
//        // Create a new Hashtable
//        Hashtable ht = new Hashtable();

//        // Add some key-value pairs
//        ht.Add("key1", "value1");
//        ht.Add("key2", "value2");

//        // Updating the value of an existing key
//        string s = "key1";
//        if (ht.ContainsKey(s))
//        {
//            ht[s] = "s1";
//        }

//        // Accessing the updated value
//        string s1 = (string)ht[s];
//        Console.WriteLine("Updated value: " + s1);

//        // Print all key-value pairs in the ht
//        foreach (DictionaryEntry e in ht)
//        {
//            Console.WriteLine("Key: " + e.Key
//                              + ", Value: " + e.Value);
//        }
//    }
//}


////HashSet
//class Geeks
//{
//    public static void Main()
//    {
//        // Create a HashSet 
//        HashSet<int> hs = new HashSet<int>();

//        // Add elements to the HashSet
//        hs.Add(10);
//        hs.Add(20);
//        hs.Add(30);
//        hs.Add(10);

//        // Display elements in the HashSet
//        Console.WriteLine("Elements in the HashSet: ");
//        foreach (int number in hs)
//            Console.WriteLine(number);
//    }
//}

//class Geeks
//{

//    static public void Main()
//    {
//        // Creating HashSet Using HashSet class
//        HashSet<string> set1 = new HashSet<string>();

//        // Add the elements in HashSet Using Add method
//        set1.Add("C");
//        set1.Add("C++");
//        set1.Add("C#");
//        set1.Add("Java");
//        set1.Add("Ruby");
//        Console.WriteLine("Elements of set1:");

//        // Accessing elements of HashSet Using foreach loop
//        foreach (var val in set1)
//        {
//            Console.WriteLine(val);
//        }

//        // Creating another HashSet using collection initializer to initialize HashSet
//        HashSet<int> set2 = new HashSet<int>() { 1, 2, 3 };

//        // Display elements of set2
//        Console.WriteLine("Elements of set2:");
//        foreach (var value in set2)
//        {
//            Console.WriteLine(value);
//        }
//    }
//}

