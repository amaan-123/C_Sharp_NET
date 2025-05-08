# C# Notes

> Source: Code With Harry <https://www.youtube.com/watch?v=SuLiu5AK9Ps>

## C# Tutorial: Starting from Scratch

This video provides a comprehensive introduction to the C# programming language and the .NET Framework. The goal is to become comfortable with the .NET Framework and learn C# programming.

### What is C# and .NET Framework?

- C# is a programming language used for creating games, console applications, and Windows desktop applications.
- C# runs on the .NET Framework.
- This means that **C# is a part of .NET**.
- **.NET Framework is an open-source developer platform**.
- Open source means that community contributions are possible, and the source code is available on GitHub for contribution.
- .NET Framework is also **cross-platform**, meaning it runs on Linux, macOS, and Windows.
- Originally, .NET was built to run on Windows, but over time, Microsoft made it compatible with Linux and macOS.
- With the .NET Framework, you can build **mobile apps, desktop applications, and games**.
- You can use multiple languages and compile them into a single project, then leverage the APIs and libraries exposed by the .NET Framework.
- It's recommended to learn one language, like C#, first to understand the framework.

### Setting up the Development Environment

- The first step is to set up the development environment.
- This involves installing **Visual Studio**.
- Visual Studio is recommended for running C# applications.
- There might be different versions of Visual Studio (e.g., 2019, 2021) depending on the current year, but the latest version available should be downloaded.
- **Don't confuse Visual Studio with Visual Studio Code**.
- Visual Studio Code is a lightweight, open-source code editor.
- An **IDE (Integrated Development Environment)** like Visual Studio provides a complete environment, including a compiler and other tools needed to compile a programming language into machine code.
- A code editor like Visual Studio Code is lightweight and provides a simple debugger but lacks many features of an IDE.
- Visual Studio is a powerful tool.
- When installing Visual Studio, it's recommended to download the **Community version**, which is free, rather than the Enterprise version which requires payment.

### Installing Visual Studio

- After downloading the installer, you need to configure and install.
- The installation process may take some time.
- You need to choose workloads.
- **.NET desktop environment** is the required workload for this tutorial.
- Click on ".NET desktop environment" and select "Install while downloading".
- The installation size can be around 5 GB, but the actual size might vary depending on pre-installed components like Windows updates.
- Don't worry too much about the size or complexities presented in the installer; just select the required components.
- An SSD can help with performance if your computer is slow, but that's a separate topic.

### C# Program Basics

- C# is a programming language created by Microsoft that runs on the .NET Framework.
- It's used for building **web apps, desktop apps, mobile apps, and games**.
- Console applications are a basic type of application used for learning C#.
- The video will start with a "Hello World" program to build confidence.

### .NET Framework Architecture

- The architecture of the .NET Framework can be viewed on Microsoft's official documentation website.
- There are two major components in the .NET Framework: **CLR (Common Language Runtime)** and the **.NET Framework Class Library**.
- The **CLR is the execution engine** that handles .NET applications.
- A .NET application can be written using multiple programming languages (e.g., C#, Visual Basic, F#).
- The code written in these languages is compiled by their respective compilers into a **Common Intermediate Language (CIL)**.
- CIL is not machine code; it's an intermediate language that is the same for code written in different .NET languages.
- The compiled code in CIL is stored in **.dll or .exe files**.
- Once the compiled code exists, the **CLR uses a Just-In-Time (JIT) compiler** to compile the CIL code into machine code that can be executed on the specific architecture of the computer it's running on (e.g., 32-bit, 64-bit).
- The CLR also provides services like **memory management**.
- **Garbage Collection** is a form of automatic memory management where the system reclaims memory that is no longer being used by the program. This is unlike languages like C or C++ where manual memory management is required.
- The **.NET Framework Class Library** is a set of APIs that provide common functionalities like reading files or connecting to databases.

### Creating the First C# Project

- After Visual Studio is installed and updated, you will see a start screen.
- Click on **"Create a new project"**.
- Filter by language (C#) and platform if needed.
- Select the **"Console App (.NET Framework)"** template. This creates a console application that runs on the .NET Framework.
- Give the project a name (e.g., "Hello") and click "Create".
- Visual Studio will create and import the necessary files for the project.
- Patience might be required if your computer has low RAM.

### Writing the First C# Program

- The main code area is where you will write your instructions.
- Program execution in C# starts from the `Main` function.
- To print output to the console, use `Console.WriteLine()`.
- Example: `Console.WriteLine("Hello World");`.
- To prevent the console window from closing immediately after execution, use `Console.ReadLine()`. This waits for the user to press Enter.
- Example: `Console.ReadLine();`.
- The complete basic program looks like this:

```csharp
using System;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.ReadLine();
        }
    }
}
```

- To run the program, click the "Start" button in Visual Studio.

### Structure of a C# Program

- The structure includes:
  - **`using System;`**: This statement allows you to use classes from the `System` namespace, such as `Console`.
  - **`namespace Hello`**: A namespace acts as a container for classes and other namespaces, helping to organize code. It helps avoid naming conflicts.
  - **`class Program`**: A class is a container for data (data members) and methods (member functions) that give your program "life".
  - **`static void Main(string[] args)`**: This is the **entry point of the program execution**. The program starts running from here.
    - `static`: Means the method belongs to the `Program` class, not a specific instance of the class.
    - `void`: Means the method does not return any value.
    - `Main`: The name of the main method.
    - `string[] args`: Command-line arguments (not discussed in detail yet).
  - Curly braces `{}` define the start and end of blocks of code for namespaces, classes, and methods.
  - **Instructions end with a semicolon `;`**.

- `Console.WriteLine()` prints text to the console followed by a new line.
- `Console.Write()` prints text without adding a new line.

### Comments

- Comments are used to add notes to the code that are ignored by the compiler.
- They help explain the code to other developers (or yourself later).
- **Single-line comments** start with `//`. Everything after `//` on that line is a comment.
- Example:

```csharp
// This is a single-line comment
Console.WriteLine("Hello World"); // Print Hello World
```

- **Multi-line comments** start with `/*` and end with `*/`. Everything between these markers is a comment.
- Example:

```csharp
/*
This is a multi-line comment.
It can span multiple lines.
*/
Console.WriteLine("Hello World");
```

### Variables and Data Types

- **Variables are containers** that store values of a specific type.
- Analogy: A container in the kitchen stores things like salt or sugar; a bucket stores water. The container's name is the variable name, and the content is the value.
- When you declare a variable like `int age = 34;`, you are telling C# to create a container named `age` in memory and store the value 34 in it.
- **Data Types** define the type of value a variable can hold and how much memory it occupies.

- Common Data Types in C#:
  - `int`: Stores whole numbers (integers), both positive and negative. Takes **4 bytes** of memory.
  - `float`: Stores single-precision floating-point numbers (numbers with decimals). Takes **4 bytes** of memory. Requires an `f` or `F` suffix for literal values.
  - `char`: Stores a single character (e.g., 'A', 'b', '7'). Character literals are enclosed in single quotes. Takes **2 bytes** of memory.
  - `bool`: Stores boolean values: `true` or `false`. Used for conditions. Takes **1 byte** of memory.
  - `string`: Stores a sequence of characters (text). String literals are enclosed in double quotes. Takes **2 bytes per character**.
  - `long`: Stores large whole numbers. Takes **8 bytes** of memory. Can be positive or negative.
  - `double`: Stores double-precision floating-point numbers. Takes **8 bytes** of memory. Provides more precision than `float` (up to 15 decimal digits). Decimal numbers in C# are **by default `double`**. You can use a `d` or `D` suffix for clarity but it's not strictly required.

- Example variable declarations:

```csharp
int integerVariable = 10;
float floatVariable = 3.14f;
char characterVariable = 'A';
bool booleanVariable = true;
string stringVariable = "Hello";
long longVariable = 1234567890L; // Optional L suffix for clarity
double doubleVariable = 9.87654321; // Optional D suffix for clarity
```

### User Input

- To get input from the user in a console application, use `Console.ReadLine()`.
- `Console.ReadLine()` reads a line of text from the console and **returns it as a `string`**.
- Example:

```csharp
Console.WriteLine("Enter your name:");
string name = Console.ReadLine();
Console.WriteLine("Hello, " + name);
```

### Type Casting (Conversion)

- **Type casting** or **conversion** is the process of converting a variable from one data type to another.
- There are multiple ways to do this in C#:

1. **Implicit Casting (Automatic Conversion)**:
    - Occurs automatically when converting a smaller type to a larger type where no data loss is possible.
    - Example: converting an `int` to a `double`. An `int` can fit inside a `double`.
    - The automatic promotion hierarchy is generally: `char` -> `int` -> `long` -> `float` -> `double`.
    - Example:

    ```csharp
    int myInt = 3;
    double myDouble = myInt; // Implicit casting from int to double
    Console.WriteLine(myDouble); // Output: 3
    ```

    - If you try to implicitly cast a larger type to a smaller type (e.g., `double` to `int`), it will result in a compile-time error because data loss is possible.

2. **Explicit Casting (Manual Conversion)**:
    - Done manually using parentheses `(type)` before the value to convert.
    - Required when converting a larger type to a smaller type where data loss might occur.
    - Example: converting a `double` to an `int`. The decimal part will be truncated.
    - Example:

    ```csharp
    double myDouble = 3.14;
    int myInt = (int)myDouble; // Explicit casting from double to int
    Console.WriteLine(myInt); // Output: 3
    ```

    - **Note:** Casting a `char` to an `int` explicitly or implicitly results in the integer value of the character's ASCII code.

3. **Conversion using Built-in Methods**:
    - The `Convert` class provides various methods to convert between types.
    - This is useful when converting between types that cannot be implicitly or explicitly cast directly, such as converting a `string` to a number.
    - Example methods: `Convert.ToInt32()`, `Convert.ToSingle()` (for float), `Convert.ToDouble()`, `Convert.ToString()`.
    - Example converting a string input to an integer:

    ```csharp
    Console.WriteLine("Enter a number:");
    string userInput = Console.ReadLine();
    int number = Convert.ToInt32(userInput); // Convert string to int
    Console.WriteLine("You entered: " + number);
    ```

- When performing operations with mixed data types, C# follows rules of type promotion. If any operand in a `+` operation is a `string`, all other operands are converted to `string`s, and the operation becomes string concatenation.
- To perform arithmetic operations correctly when dealing with string input that needs to be treated as a number, you must **convert the string to a numeric type *before* the operation**.
- Use **parentheses `()`** to ensure that conversions and arithmetic operations happen in the desired order due to operator precedence.
- Example: Converting input string to int and adding 4.

```csharp
Console.WriteLine("How many candies do you want?");
string candyInput = Console.ReadLine();
// Incorrect: string concatenation
// Console.WriteLine("You will get " + candyInput + 4 + " more candies"); // Might output "44" if input is "4"

// Correct: Convert to int and then add
int candyCount = Convert.ToInt32(candyInput);
Console.WriteLine("You will get " + (candyCount + 4) + " more candies"); // Output will be "You will get 8 more candies" if input is "4"
```

### Operators

- Operators perform operations on variables and values.
- Types of operators in C#:

1. **Arithmetic Operators**: Perform mathematical operations.
    - `+` (Addition)
    - `-` (Subtraction)
    - `*` (Multiplication)
    - `/` (Division)

2. **Assignment Operators**: Assign values to variables.
    - `=` (Assign)
    - `+=`, `-=`, `*=`, `/=` (Combine arithmetic and assignment)

3. **Logical Operators**: Combine boolean values or expressions.
    - `&&` (Logical AND): Returns `true` if both operands are `true`.
    - `||` (Logical OR): Returns `true` if at least one operand is `true`.
    - `!` (Logical NOT): Reverses the boolean state ( `!true` is `false`, `!false` is `true`).

4. **Comparison Operators**: Compare two values and return a boolean result (`true` or `false`).
    - `>` (Greater than)
    - `<` (Less than)
    - `>=` (Greater than or equal to)
    - `<=` (Less than or equal to)
    - `==` (Equal to)
    - `!=` (Not equal to)

### Math Class

- The `System.Math` class provides static methods for mathematical operations.
- It includes functions like finding the maximum or minimum of two numbers, rounding, etc..
- Example:

```csharp
int maxNumber = Math.Max(34, 39); // Finds the maximum value
Console.WriteLine(maxNumber); // Output: 39
```

- You can find documentation for all `Math` class functions on Microsoft's website or by searching online.

### String Methods and Properties

- Strings have built-in members (properties and methods) for manipulating text.
- **`.Length`**: A property that returns the number of characters in the string.
- Example:

```csharp
string greeting = "Hello World";
Console.WriteLine(greeting.Length); // Output: 11
```

- **`.ToUpper()`**: A method that returns a new string with all characters converted to uppercase.
- **`.ToLower()`**: A method that returns a new string with all characters converted to lowercase.
- Example:

```csharp
string message = "Hello";
Console.WriteLine(message.ToUpper()); // Output: HELLO
Console.WriteLine(message.ToLower()); // Output: hello
```

- **String Concatenation**: Joining strings using the `+` operator.
- Example:

```csharp
string part1 = "Hello";
string part2 = "World";
string fullMessage = part1 + " " + part2;
Console.WriteLine(fullMessage); // Output: Hello World
```

- **String Interpolation**: A more readable way to embed variables inside strings using the `$` prefix and curly braces `{}`.
- Example:

```csharp
string name = "Harry";
Console.WriteLine($"Hello {name}, you are learning C#.");
```

- **Accessing Characters**: Individual characters in a string can be accessed using square brackets `[]` and their index.
- **String indexing starts at 0** in C#. The first character is at index 0, the second at index 1, and so on.
- Example:

```csharp
string word = "C#";
Console.WriteLine(word); // Output: C
Console.WriteLine(word); // Output: #
```

- **`.IndexOf()`**: A method that returns the index of the first occurrence of a specified substring within the string.
- Example:

```csharp
string sentence = "This is a test";
Console.WriteLine(sentence.IndexOf("is")); // Output: 2 (index of the first 'i' in "is")
```

- **`.Substring()`**: A method that returns a new string starting from a specified index. You can also specify the length of the substring.
- Example:

```csharp
string data = "abcdefgh";
Console.WriteLine(data.Substring(3)); // Output: defgh (starts from index 3 to the end)
Console.WriteLine(data.Substring(3, 2)); // Output: de (starts from index 3, takes 2 characters)
```

- **Escape Sequences**: Special character combinations used within strings to represent characters that are difficult to type or have special meaning. They start with a backslash `\`.
  - `\"`: Double quote
  - `\'`: Single quote (more relevant for characters)
  - `\\`: Backslash
  - `\n`: Newline
  - `\t`: Tab
- Example:

```csharp
Console.WriteLine("He said, \"Hello!\""); // Output: He said, "Hello!"
Console.WriteLine("Line 1\nLine 2"); // Output: Line 1 followed by Line 2 on a new line
```

- **Important**: Most string methods return a *new* string; they do not modify the original string.

### Decision Control (If-Else and Switch)

- Decision control statements allow your program to execute different blocks of code based on conditions.

1. **If-Else If-Else**:
    - The `if` statement executes a block of code if a condition is `true`.
    - An optional `else if` statement can be used to check another condition if the previous `if` or `else if` conditions were `false`. You can have multiple `else if` blocks.
    - An optional `else` statement executes a block of code if all preceding `if` and `else if` conditions were `false`.
    - **Only one** of the `if`, `else if`, or `else` blocks will execute.

- Example:

```csharp
int age = 16;

if (age >= 18)
{
    Console.WriteLine("You can drive.");
}
else if (age >= 16) // This condition is checked only if age is NOT >= 18
{
    Console.WriteLine("Almost there, please wait.");
}
else // This block executes if age is NOT >= 18 AND NOT >= 16
{
    Console.WriteLine("You cannot drive yet.");
}
```

2. **Switch Case**:
    - An alternative to multiple `else if` statements, used to execute different code blocks based on the **value of a single variable**.
    - The variable's value is compared against multiple `case` labels.
    - If a match is found, the code in that `case` block is executed.
    - A `break` statement is required after each `case` block to exit the `switch` statement.
    - The optional `default` case executes if none of the `case` labels match the variable's value.

- Example:

```csharp
int day = 3;

switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    default:
        Console.WriteLine("Another day");
        break;
}
```

### Loops

- Loops allow you to repeat a block of code multiple times.
- Using loops is a **better alternative for repetitive statements** than writing the same code manually multiple times.

1. **While Loop**:
    - Executes a block of code **as long as a condition is `true`**.
    - The condition is checked *before* each iteration. If the condition is initially `false`, the loop body will not execute at all.

- Example:

```csharp
int i = 0;
while (i < 5)
{
    Console.WriteLine(i);
    i++; // Increment i to eventually make the condition false
}
// Output: 0, 1, 2, 3, 4
```

2. **Do-While Loop**:
    - Executes a block of code **at least once**, and then continues to execute as long as a condition is `true`.
    - The condition is checked *after* the first iteration.

- Example:

```csharp
int i = 0;
do
{
    Console.WriteLine(i);
    i++; // Increment i
} while (i < 5); // Condition checked after the first run
// Output: 0, 1, 2, 3, 4 (Same output as while in this case, but runs at least once)

// If condition is initially false:
int j = 5;
do
{
    Console.WriteLine(j); // Executes once
    j++;
} while (j < 5); // Condition is false, loop exits after the first iteration
// Output: 5
```

3. **For Loop**:
    - Provides a more structured way to loop, especially when you know the number of iterations or need an index.
    - It has three parts separated by semicolons:
        - **Initialization**: Executed once at the beginning of the loop (e.g., `int i = 0;`).
        - **Condition**: Checked *before* each iteration. If `true`, the loop continues; if `false`, the loop exits (e.g., `i < 5;`).
        - **Update Statement**: Executed *after* each iteration (e.g., `i++`).

- Example:

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}
// Output: 0, 1, 2, 3, 4
```

### Loop Control Statements

- **`break`**:
  - Used inside a loop (or `switch`) to **exit the loop immediately and permanently**.
  - The program continues execution at the first statement *after* the loop.
- Example:

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i); // This will print only once
    break; // Exits the loop immediately
}
// Output: 0
```

- **`continue`**:
  - Used inside a loop to **skip the rest of the current iteration** and proceed to the next iteration.
  - The loop's update statement (in a `for` loop) or condition check (in `while`/`do-while`) is performed after `continue`.
- Example:

```csharp
for (int i = 0; i < 5; i++)
{
    if (i == 2)
    {
        continue; // Skip the rest of the code for this iteration when i is 2
    }
    Console.WriteLine(i);
}
// Output: 0, 1, 3, 4 (2 is skipped)
```

### Methods (Functions)

- **Methods (or functions)** are blocks of code that perform a specific task and can be reused.
- They help to avoid repeating code (DRY principle - Don't Repeat Yourself).
- The `Main` method is an example of a method.
- **Structure of a Method**:
  - `Access Modifier` (e.g., `public`, `private`, `static`)
  - `Return Type` (e.g., `void`, `int`, `string`, `float`)
  - `Method Name` (e.g., `Greet`, `Average`)
  - `Parameters` (inputs to the method, defined in parentheses `()`)
  - `Method Body` (code executed when the method is called, in curly braces `{}`)

- **`static` Keyword**:
  - Indicates that the method belongs to the class itself rather than a specific instance (object) of the class.
  - You can call a static method directly using the class name (e.g., `Program.Main()`, `Console.WriteLine()`).

- **`void` Keyword**:
  - Means the method **does not return any value** after it finishes execution.

- **Return Type**:
  - If a method is not `void`, it must specify the type of value it will return.
  - The `return` keyword is used to send a value back from the method.
  - Example:

    ```csharp
    static int AddNumbers(int num1, int num2) // Returns an int
    {
        int sum = num1 + num2;
        return sum; // Returns the calculated sum
    }

    // Calling the method and storing the returned value
    int result = AddNumbers(5, 3); // result will be 8
    ```

- **Method Overloading**:
  - Defining multiple methods in the same class with the **same name but different parameter lists** (different number or types of parameters).
  - The compiler determines which method to call based on the arguments provided.
- Example:

```csharp
static double Average(double a, double b) // Average of two doubles
{
    return (a + b) / 2;
}

static double Average(double a, double b, double c) // Average of three doubles
{
    return (a + b + c) / 3;
}

// The compiler knows which Average method to call based on the number of arguments
double avg1 = Average(10.0, 20.0);
double avg2 = Average(10.0, 20.0, 30.0);
```

### Object-Oriented Programming (OOP): Classes and Objects

- OOP is a programming paradigm based on the concept of "objects", which can contain data and code.
- The key concepts are **Classes and Objects**.
- **Class**:
  - A **blueprint or template** for creating objects.
  - It defines the properties (data members) and methods (member functions) that objects of that class will have.
  - Think of a class like a custom data type you create. For example, just like `int` is a type, you can create a `Player` class as a type.
  - Classes help model real-world entities. For example, a `Player` class in a game might have properties like `Name`, `Health`, `Position` and methods like `Run()`, `Shoot()`.

- **Object**:
  - An **instance** of a class.
  - When you create an object from a class, you are creating a specific instance of that blueprint.
  - Example: Creating a `Player` object named `tommy` from the `Player` class.
  - Objects have their own unique set of property values (e.g., `tommy` might have `Name = "Tommy"` and `Health = 100`).

- To create a new class in Visual Studio, right-click on your project in the Solution Explorer, go to "Add", then "New Item", select "Class", give it a name (e.g., "Player.cs"), and click "Add".

- Example Class Definition (`Player.cs`):

```csharp
using System;

public class Player
{
    // Properties (Data Members)
    public string Name;
    private int Health; // Marked as private

    // Methods (Member Functions)
    public void SetHealth(int newHealth)
    {
        Health = newHealth;
    }

    public int GetHealth() // Method to access the private Health property
    {
        return Health;
    }
}
```

- **Access Modifiers**:
  - Keywords that control the accessibility of classes and their members (properties, methods).
  - **`public`**: The member is accessible from anywhere, both inside and outside the class.
  - **`private`**: The member is accessible **only within the same class**.
  - **`protected`**: The member is accessible within the same class and by derived classes (classes that inherit from this class).

- **Creating an Object**:
  - Use the `new` keyword followed by the class name.
  - Example (in `Main` method):

    ```csharp
    // Creating an object (instance) of the Player class
    Player tommy = new Player();
    ```

- **Accessing Members**:
  - Use the object name followed by the dot operator (`.`) to access its public properties and methods.
  - Example:

    ```csharp
    tommy.Name = "Tommy Vercetti"; // Accessing and setting a public property
    tommy.SetHealth(100); // Calling a public method

    // Cannot access private members directly:
    // Console.WriteLine(tommy.Health); // Error! Health is private

    // Access private member using a public method:
    Console.WriteLine(tommy.GetHealth()); // Output: 100
    ```

- **OOP Benefits**: Makes complex programs easier to manage by organizing code into objects that model real-world concepts. Promotes code reusability.
- **Caution**: Don't overuse classes for simple tasks. Use classes when they help structure and manage complexity. Follow the DRY principle (Do Not Repeat Yourself).

- **Inheritance**: (Briefly mentioned as a concept for a future course). Inheritance allows a new class (derived class) to inherit properties and methods from an existing class (base class).

### Conclusion

- The video covered C# basics, .NET Framework, development environment setup, data types, operators, decision control, loops, methods, and an introduction to OOP with classes and objects.
- Practice is essential after watching the video.
- The source code from the video will be made available.
- The channel contains other tutorials on various programming languages and technologies.
