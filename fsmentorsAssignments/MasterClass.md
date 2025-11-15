# C# Programming for Beginners



### Course Structure

**Session 1: Introduction to Programming and C# Basics**
- What is programming and why learn C#?
- Setting up your development environment
- Variables, data types, and basic operations
- User input and output

**Session 2: Control Flow and Program Logic**
- Decision making with conditional statements
- Repetition with loops
- Organizing code with methods
- Working with arrays

**Session 3: Introduction to Object-Oriented Programming**
- Understanding classes and objects
- Creating and using methods
- Introduction to properties and encapsulation
- Building a simple console application project

Let's begin with our first session!

---

# Session 1: Introduction to Programming and C# Basics

## Learning Goals
By the end of this session, you will:
- Understand what programming is and why C# is valuable to learn
- Set up Visual Studio for C# development
- Create and run your first C# program
- Work with variables, data types, and basic operations
- Get input from users and display output

## What is Programming?

### Programming: Giving Instructions to Computers

Programming is the process of providing instructions to a computer to perform specific tasks. Think of it like writing a detailed recipe:

- **Recipe for a cake:** Mix flour, sugar, and eggs; bake at 350°F for 30 minutes
- **Recipe for a computer:** Get two numbers from the user; add them together; display the result

Just as a chef follows a recipe step-by-step, a computer follows programming instructions precisely.

### Why Learn Programming?
- **Problem-solving:** Break down complex problems into manageable steps
- **Automation:** Make computers handle repetitive tasks
- **Creation:** Build useful applications, websites, games, and tools
- **Career opportunities:** Software development is one of the fastest-growing fields

### What is C#?

C# (pronounced "C-sharp") is a modern, versatile programming language developed by Microsoft. It's like the English of programming languages—widely used, well-structured, and versatile.

**Key facts about C#:**
- Created in 2000 as part of Microsoft's .NET initiative
- General-purpose language used for various applications:
  - Desktop applications
  - Web applications
  - Mobile apps
  - Games (especially with Unity game engine)
  - Enterprise software
- Object-oriented programming language (we'll explore this in Session 3)
- Strongly-typed language (you declare what type of data you're working with)

### Why Learn C#?
- **Industry demand:** Widely used in enterprise and business applications
- **Versatility:** Used across many platforms and application types
- **Modern features:** Regular updates keep it current with programming trends
- **Strong community:** Large community means plenty of resources and help
- **Transferable skills:** Learning C# makes learning other languages like Java easier

## Setting Up Your Development Environment

To write C# code, we need an Integrated Development Environment (IDE). Think of this as a workshop with all the tools you need in one place.

### Installing Visual Studio
Visual Studio is the most popular IDE for C# development. The Community Edition is free and powerful.

1. Go to [Visual Studio downloads](https://visualstudio.microsoft.com/downloads/)
2. Download Visual Studio Community Edition
3. Run the installer
4. Select the ".NET Desktop Development" workload
5. Complete the installation

### Creating Your First C# Project

1. Open Visual Studio
2. Select "Create a new project"
3. Choose "Console App (.NET Core)" or "Console App (.NET)"
4. Name your project "HelloWorld"
5. Click "Create"

Visual Studio will create a new project with this basic structure:

```csharp
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

### Understanding Your First Program

Let's break down this code:

- `using System;` - Tells C# we want to use functionality from the System namespace
- `namespace HelloWorld` - Organizes our code (like a folder)
- `class Program` - A container for our code (we'll learn more about classes in Session 3)
- `static void Main(string[] args)` - The entry point of our program
- `Console.WriteLine("Hello World!");` - Prints "Hello World!" to the console window

### Running Your Program

1. Press F5 or click the green "Start" button
2. You should see a console window appear with "Hello World!" displayed
3. The window will close automatically when the program finishes

Congratulations! You've written and run your first C# program.

## Variables and Data Types

### What are Variables?

Variables are containers for storing data values. Think of them as labeled boxes where you can put different types of information.

```csharp
string name = "Maria";  // A box labeled "name" containing the text "Maria"
int age = 25;          // A box labeled "age" containing the number 25
```

### Declaring Variables

In C#, you need to specify the type of data a variable will store:

```csharp
// Syntax: dataType variableName = value;

string cityName = "New York";
int population = 8400000;
double averageTemperature = 54.6;
bool isCapital = false;
```

### Common Data Types

C# has several built-in data types:

| Data Type | Description | Example |
|-----------|-------------|---------|
| `int` | Whole numbers | `int count = 42;` |
| `double` | Decimal numbers | `double price = 19.99;` |
| `string` | Text | `string message = "Hello!";` |
| `bool` | True/false values | `bool isActive = true;` |
| `char` | Single characters | `char grade = 'A';` |

### Naming Variables

Good variable names make your code easier to understand:

- Use descriptive names: `firstName` is better than `fn`
- Start with a lowercase letter
- Don't use spaces (use camelCase: `firstName`, `totalAmount`)
- Avoid special characters
- Don't use reserved keywords like `int` or `class`

### Variable Exercise

Let's write a program that uses different types of variables:

```csharp
using System;

namespace VariablesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string courseName = "C# Programming for Beginners";
            int numberOfStudents = 25;
            double courseRating = 4.8;
            bool courseIsActive = true;
            
            Console.WriteLine("Course: " + courseName);
            Console.WriteLine("Students: " + numberOfStudents);
            Console.WriteLine("Rating: " + courseRating + " / 5.0");
            Console.WriteLine("Active: " + courseIsActive);
            
            // Wait for user to press a key
            Console.ReadKey();
        }
    }
}
```

## Basic Operations and Expressions

### Arithmetic Operations

C# supports standard mathematical operations:

| Operation | Symbol | Example | Result |
|-----------|--------|---------|--------|
| Addition | `+` | `5 + 3` | `8` |
| Subtraction | `-` | `5 - 3` | `2` |
| Multiplication | `*` | `5 * 3` | `15` |
| Division | `/` | `5 / 3` | `1` (integer division) |
| Division | `/` | `5.0 / 3.0` | `1.6666...` (floating-point division) |
| Modulus (remainder) | `%` | `5 % 3` | `2` |

### Examples of Arithmetic Operations

```csharp
int a = 10;
int b = 3;

int sum = a + b;        // 13
int difference = a - b; // 7
int product = a * b;    // 30
int quotient = a / b;   // 3 (integer division truncates decimals)
int remainder = a % b;  // 1 (10 = 3 × 3 + 1)

double c = 10.0;
double d = 3.0;
double decimalQuotient = c / d;  // 3.3333...
```

### Assignment Operators

C# provides shorthand operators for updating variables:

| Operator | Example | Equivalent |
|----------|---------|------------|
| `=` | `x = 5;` | Assigns 5 to x |
| `+=` | `x += 3;` | `x = x + 3;` |
| `-=` | `x -= 3;` | `x = x - 3;` |
| `*=` | `x *= 3;` | `x = x * 3;` |
| `/=` | `x /= 3;` | `x = x / 3;` |
| `%=` | `x %= 3;` | `x = x % 3;` |

### Increment and Decrement Operators

```csharp
int counter = 5;

counter++;  // Increases counter by 1 (now 6)
counter--;  // Decreases counter by 1 (back to 5)

// Pre-increment and post-increment have different behaviors
int a = 5;
int b = ++a;  // a is incremented to 6, then b is set to 6

int c = 5;
int d = c++;  // d is set to 5, then c is incremented to 6
```

### String Operations

Strings can be combined using the `+` operator:

```csharp
string firstName = "John";
string lastName = "Doe";
string fullName = firstName + " " + lastName;  // "John Doe"

// String interpolation (modern approach)
string greeting = $"Hello, {firstName} {lastName}!";  // "Hello, John Doe!"
```

## User Input and Output

### Displaying Output

We've already seen `Console.WriteLine()` which prints text and adds a new line:

```csharp
Console.WriteLine("Hello, world!");  // Prints and adds a new line
Console.Write("Hello, ");            // Prints without a new line
Console.Write("world!");             // Continues on the same line

// Output: Hello, world!
```

### Getting User Input

```csharp
Console.Write("Enter your name: ");
string userName = Console.ReadLine();  // Reads a line of text

Console.WriteLine($"Hello, {userName}!");
```

### Parsing Input to Numbers

`Console.ReadLine()` always returns a string. To convert to other types:

```csharp
Console.Write("Enter your age: ");
string ageInput = Console.ReadLine();
int age = int.Parse(ageInput);  // Converts string to integer

Console.Write("Enter your height in meters: ");
double height = double.Parse(Console.ReadLine());
```

### Using TryParse for Safety

```csharp
Console.Write("Enter a number: ");
string input = Console.ReadLine();

if (int.TryParse(input, out int number))
{
    Console.WriteLine($"Number entered: {number}");
}
else
{
    Console.WriteLine("That's not a valid number!");
}
```

## Putting It All Together: Simple Calculator Program

Let's combine what we've learned to create a simple calculator:

```csharp
using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display welcome message
            Console.WriteLine("===== Simple Calculator =====");
            
            // Get first number
            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());
            
            // Get second number
            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());
            
            // Perform calculations
            double sum = num1 + num2;
            double difference = num1 - num2;
            double product = num1 * num2;
            double quotient = num1 / num2;
            
            // Display results
            Console.WriteLine("===== Results =====");
            Console.WriteLine($"{num1} + {num2} = {sum}");
            Console.WriteLine($"{num1} - {num2} = {difference}");
            Console.WriteLine($"{num1} × {num2} = {product}");
            Console.WriteLine($"{num1} ÷ {num2} = {quotient}");
            
            // Wait for user input before closing
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
```

## Session 1 Mini Quiz

Let's test your understanding with a short quiz:

1. What is the correct way to declare a variable that stores a person's age?
   a) `age = 25;`
   b) `int 25 = age;`
   c) `int age = 25;`
   d) `age int = 25;`

2. Which of these is NOT a valid variable name in C#?
   a) `firstName`
   b) `first_name`
   c) `1stName`
   d) `_name`

3. What will be the value of `result` after this code runs?
   ```csharp
   int a = 10;
   int b = 3;
   int result = a % b;
   ```
   a) 3
   b) 1
   c) 3.33...
   d) 0

4. How do you get input from a user in a console application?
   a) `Console.Write()`
   b) `Console.ReadKey()`
   c) `Console.ReadLine()`
   d) `Console.Input()`

5. What's the correct way to convert a string to an integer in C#?
   a) `Convert.ToInt(str)`
   b) `int.Parse(str)`
   c) `(int)str`
   d) `str.toInteger()`

Answers: 1-c, 2-c, 3-b, 4-c, 5-b

## Session 1 Practice Exercises

### Exercise 1: Personal Information Program
Create a program that asks for the user's name, age, and favorite color, then displays them back in a formatted message.

### Exercise 2: Temperature Converter
Create a program that converts temperature from Fahrenheit to Celsius using the formula: C = (F - 32) × 5/9.

### Exercise 3: Area Calculator
Create a program that calculates the area of a rectangle by asking for its length and width.

## Session 1 Summary

Congratulations on completing the first session! You've learned:
- What programming is and why C# is valuable
- How to set up Visual Studio and create your first program
- How to work with variables and different data types
- How to perform basic operations and calculations
- How to get input from users and display output

In our next session, we'll build on these fundamentals by learning about decision-making with conditional statements and repetition with loops.

---

# Session 2: Control Flow and Program Logic

## Learning Goals
By the end of this session, you will:
- Make decisions in your code using conditional statements
- Repeat code efficiently using loops
- Organize code into reusable methods
- Work with collections of data using arrays

## Conditional Statements

### Making Decisions with `if` Statements

Conditional statements allow your program to make decisions based on whether certain conditions are true or false.

Think of them like forks in the road:

```
If it's raining:
    Take an umbrella
Otherwise:
    Wear sunglasses
```

#### Basic if Statement

```csharp
int age = 20;

if (age >= 18)
{
    Console.WriteLine("You are an adult!");
}
```

#### if-else Statement

```csharp
int age = 15;

if (age >= 18)
{
    Console.WriteLine("You are an adult!");
}
else
{
    Console.WriteLine("You are not an adult yet.");
}
```

#### if-else-if Statement

```csharp
int score = 85;

if (score >= 90)
{
    Console.WriteLine("Grade: A");
}
else if (score >= 80)
{
    Console.WriteLine("Grade: B");
}
else if (score >= 70)
{
    Console.WriteLine("Grade: C");
}
else if (score >= 60)
{
    Console.WriteLine("Grade: D");
}
else
{
    Console.WriteLine("Grade: F");
}
```

### Comparison Operators

| Operator | Description | Example |
|----------|-------------|---------|
| `==` | Equal to | `if (x == 5)` |
| `!=` | Not equal to | `if (x != 5)` |
| `>` | Greater than | `if (x > 5)` |
| `<` | Less than | `if (x < 5)` |
| `>=` | Greater than or equal to | `if (x >= 5)` |
| `<=` | Less than or equal to | `if (x <= 5)` |

### Logical Operators

Combine conditions using logical operators:

| Operator | Description | Example |
|----------|-------------|---------|
| `&&` | AND (both must be true) | `if (age >= 18 && hasID)` |
| `||` | OR (at least one must be true) | `if (isMember || hasVoucher)` |
| `!` | NOT (inverses a condition) | `if (!isLocked)` |

### Nested if Statements

You can place if statements inside other if statements:

```csharp
bool isLoggedIn = true;
bool isAdmin = true;

if (isLoggedIn)
{
    Console.WriteLine("Welcome to the system!");
    
    if (isAdmin)
    {
        Console.WriteLine("You have administrator privileges.");
    }
    else
    {
        Console.WriteLine("You have regular user privileges.");
    }
}
else
{
    Console.WriteLine("Please log in first.");
}
```

### The switch Statement

When you have multiple cases to check for a single variable, `switch` can be cleaner than multiple `if-else` statements:

```csharp
char grade = 'B';

switch (grade)
{
    case 'A':
        Console.WriteLine("Excellent!");
        break;
    case 'B':
        Console.WriteLine("Good job!");
        break;
    case 'C':
        Console.WriteLine("Satisfactory");
        break;
    case 'D':
        Console.WriteLine("Passed");
        break;
    case 'F':
        Console.WriteLine("Failed");
        break;
    default:
        Console.WriteLine("Invalid grade");
        break;
}
```

The `break` statement is required after each case (except for special cases) to exit the switch block.

### Exercise: Simple Menu System

```csharp
using System;

namespace MenuSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Simple Calculator ===");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.Write("Select an option (1-4): ");
            
            int choice = int.Parse(Console.ReadLine());
            
            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());
            
            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());
            
            double result = 0;
            bool validChoice = true;
            
            switch (choice)
            {
                case 1:
                    result = num1 + num2;
                    Console.WriteLine($"Result: {num1} + {num2} = {result}");
                    break;
                case 2:
                    result = num1 - num2;
                    Console.WriteLine($"Result: {num1} - {num2} = {result}");
                    break;
                case 3:
                    result = num1 * num2;
                    Console.WriteLine($"Result: {num1} * {num2} = {result}");
                    break;
                case 4:
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        Console.WriteLine($"Result: {num1} / {num2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Cannot divide by zero!");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option selected!");
                    validChoice = false;
                    break;
            }
            
            if (validChoice)
            {
                Console.WriteLine("Calculation completed!");
            }
            
            Console.ReadKey();
        }
    }
}
```

## Loops

### What are Loops?

Loops allow you to repeat sections of code multiple times. Instead of writing the same code over and over, you can use a loop.

Consider a task like printing numbers from 1 to 5:

Without loops:
```csharp
Console.WriteLine(1);
Console.WriteLine(2);
Console.WriteLine(3);
Console.WriteLine(4);
Console.WriteLine(5);
```

With a loop:
```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}
```

### The `for` Loop

The `for` loop is useful when you know exactly how many times you want to repeat something.

Syntax:
```csharp
for (initialization; condition; update)
{
    // Code to repeat
}
```

Example:
```csharp
// Print numbers 1 through 10
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine(i);
}
```

Components:
- **Initialization**: Runs once at the beginning (`int i = 1`)
- **Condition**: Checked before each iteration (`i <= 10`)
- **Update**: Runs after each iteration (`i++`)

### The `while` Loop

The `while` loop repeats as long as a condition is true.

Syntax:
```csharp
while (condition)
{
    // Code to repeat
}
```

Example:
```csharp
int count = 1;
while (count <= 5)
{
    Console.WriteLine(count);
    count++;
}
```

### The `do-while` Loop

Similar to the `while` loop, but guarantees the code runs at least once.

Syntax:
```csharp
do
{
    // Code to repeat
} while (condition);
```

Example:
```csharp
int num;
do
{
    Console.Write("Enter a positive number: ");
    num = int.Parse(Console.ReadLine());
} while (num <= 0);

Console.WriteLine($"You entered: {num}");
```

### The `foreach` Loop

The `foreach` loop is designed specifically for iterating through collections like arrays (which we'll learn about soon).

Syntax:
```csharp
foreach (type item in collection)
{
    // Code to process item
}
```

Example:
```csharp
string[] fruits = { "Apple", "Banana", "Cherry" };
foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}
```

### Loop Control Statements

- **break**: Exits the loop immediately
- **continue**: Skips the current iteration and moves to the next one

Example with `break`:
```csharp
for (int i = 1; i <= 10; i++)
{
    if (i == 5)
    {
        break; // Exit the loop when i equals 5
    }
    Console.WriteLine(i);
}
// Output: 1 2 3 4
```

Example with `continue`:
```csharp
for (int i = 1; i <= 5; i++)
{
    if (i == 3)
    {
        continue; // Skip 3
    }
    Console.WriteLine(i);
}
// Output: 1 2 4 5
```

### Exercise: Sum of Numbers

```csharp
using System;

namespace SumOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a positive number: ");
            int number = int.Parse(Console.ReadLine());
            
            int sum = 0;
            
            // Calculate sum of numbers from 1 to the input number
            for (int i = 1; i <= number; i++)
            {
                sum += i;
            }
            
            Console.WriteLine($"The sum of numbers from 1 to {number} is: {sum}");
            Console.ReadKey();
        }
    }
}
```

### Common Loop Patterns

#### Counting backwards
```csharp
for (int i = 10; i >= 1; i--)
{
    Console.WriteLine(i);
}
// Output: 10 9 8 7 6 5 4 3 2 1
```

#### Skipping values
```csharp
// Print even numbers from 2 to 10
for (int i = 2; i <= 10; i += 2)
{
    Console.WriteLine(i);
}
// Output: 2 4 6 8 10
```

#### Nested loops
```csharp
// Print a multiplication table
for (int i = 1; i <= 5; i++)
{
    for (int j = 1; j <= 5; j++)
    {
        Console.Write($"{i * j}\t");
    }
    Console.WriteLine();
}
```

Output:
```
1   2   3   4   5
2   4   6   8   10
3   6   9   12  15
4   8   12  16  20
5   10  15  20  25
```

## Methods

### What are Methods?

Methods are reusable blocks of code that perform specific tasks. They help organize your code and reduce repetition.

Think of methods as recipes:
- They have a name
- They might need ingredients (parameters)
- They might produce something (return value)
- They contain steps (code to execute)

### Defining and Calling Methods

```csharp
// Method definition
static void SayHello(string name)
{
    Console.WriteLine($"Hello, {name}!");
}

// Calling the method
SayHello("John");  // Output: Hello, John!
SayHello("Sarah"); // Output: Hello, Sarah!
```

### Method Anatomy

```csharp
static returnType MethodName(parameterType parameterName)
{
    // Method body
    // Code to execute
    
    return someValue;  // Only needed if returnType is not void
}
```

Components:
- **access modifier** (we'll use `static` for now)
- **return type** (`void` means nothing is returned)
- **method name** (use descriptive names like `CalculateTotal`)
- **parameters** (input data the method needs)
- **method body** (the code that runs when the method is called)

### Methods with Return Values

Methods can send a value back to the code that called them:

```csharp
static int Add(int a, int b)
{
    int sum = a + b;
    return sum;
}

// Using the method
int result = Add(5, 3);  // result = 8
Console.WriteLine(result);
```

### Method Overloading

C# allows multiple methods with the same name but different parameters:

```csharp
static int Add(int a, int b)
{
    return a + b;
}

static double Add(double a, double b)
{
    return a + b;
}

// Using the methods
int sum1 = Add(5, 3);          // Calls the int version
double sum2 = Add(2.5, 3.7);   // Calls the double version
```

### Variable Scope

Variables declared inside a method only exist within that method:

```csharp
static void Main(string[] args)
{
    int x = 10;  // x is accessible in Main
    
    SomeMethod();
    
    // y is not accessible here - would cause a compile error
    // Console.WriteLine(y);
}

static void SomeMethod()
{
    // x is not accessible here - would cause a compile error
    // Console.WriteLine(x);
    
    int y = 20;  // y is only accessible in SomeMethod
}
```

### Exercise: Calculator Methods

```csharp
using System;

namespace CalculatorMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Calculator using Methods ===");
            
            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());
            
            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());
            
            Console.WriteLine($"Addition: {num1} + {num2} = {Add(num1, num2)}");
            Console.WriteLine($"Subtraction: {num1} - {num2} = {Subtract(num1, num2)}");
            Console.WriteLine($"Multiplication: {num1} * {num2} = {Multiply(num1, num2)}");
            
            // Check for division by zero
            if (num2 != 0)
            {
                Console.WriteLine($"Division: {num1} / {num2} = {Divide(num1, num2)}");
            }
            else
            {
                Console.WriteLine("Division: Cannot divide by zero!");
            }
            
            Console.ReadKey();
        }
        
        static double Add(double a, double b)
        {
            return a + b;
        }
        
        static double Subtract(double a, double b)
        {
            return a - b;
        }
        
        static double Multiply(double a, double b)
        {
            return a * b;
        }
        
        static double Divide(double a, double b)
        {
            return a / b;
        }
    }
}
```

## Arrays

### What are Arrays?

Arrays are collections that store multiple values of the same type. Think of an array as a numbered shelf of boxes, where each box holds one item.

### Declaring and Initializing Arrays

```csharp
// Declaration with size
int[] numbers = new int[5];  // Creates an array with 5 slots for integers

// Setting values individually
numbers[0] = 10;  // First element (index 0)
numbers[1] = 20;  // Second element (index 1)
numbers[2] = 30;  // Third element (index 2)
numbers[3] = 40;  // Fourth element (index 3)
numbers[4] = 50;  // Fifth element (index 4)

// Declaration with initialization
string[] fruits = { "Apple", "Banana", "Cherry", "Date", "Elderberry" };
```

### Array Indices

Array elements are accessed by index, which starts at 0:

```
┌───────┬───────┬───────┬───────┬───────┐
│ "Apple"│"Banana"│"Cherry"│ "Date" │"Elder."│
└───────┴───────┴───────┴───────┴───────┘
    0       1       2       3       4
```

### Accessing Array Elements

```csharp
string[] fruits = { "Apple", "Banana", "Cherry", "Date", "Elderberry" };

// Accessing elements
Console.WriteLine(fruits[0]);  // Output: Apple
Console.WriteLine(fruits[2]);  // Output: Cherry

// Modifying elements
fruits[1] = "Blueberry";
Console.WriteLine(fruits[1]);  // Output: Blueberry
```

### Array Length

The `Length` property tells you how many elements an array can hold:

```csharp
int[] numbers = { 10, 20, 30, 40, 50 };
Console.WriteLine($"The array contains {numbers.Length} elements.");  // Output: 5
```

### Iterating Through Arrays

```csharp
int[] scores = { 85, 92, 78, 95, 88 };

// Using a for loop
for (int i = 0; i < scores.Length; i++)
{
    Console.WriteLine($"Score {i+1}: {scores[i]}");
}

// Using a foreach loop (cleaner but doesn't give index)
foreach (int score in scores)
{
    Console.WriteLine($"Score: {score}");
}
```

### Common Array Operations

#### Finding sum and average
```csharp
int[] numbers = { 10, 20, 30, 40, 50 };
int sum = 0;

foreach (int num in numbers)
{
    sum += num;
}

double average = (double)sum / numbers.Length;
Console.WriteLine($"Sum: {sum}, Average: {average}");
```

#### Finding maximum and minimum values
```csharp
int[] numbers = { 32, 17, 49, 23, 8, 56 };
int max = numbers[0];  // Start with first element
int min = numbers[0];  // Start with first element

foreach (int num in numbers)
{
    if (num > max)
    {
        max = num;  // New maximum found
    }
    
    if (num < min)
    {
        min = num;  // New minimum found
    }
}

Console.WriteLine($"Maximum: {max}, Minimum: {min}");
```

### Multi-dimensional Arrays

C# supports arrays with multiple dimensions. A 2D array is like a table with rows and columns:

```csharp
// Declaring a 2D array (3 rows, 4 columns)
int[,] matrix = new int[3, 4];

// Initializing a 2D array
int[,] grid = {
    { 1, 2, 3, 4 },
    { 5, 6, 7, 8 },
    { 9, 10, 11, 12 }
};

// Accessing elements
Console.WriteLine(grid[0, 0]);  // Output: 1 (first row, first column)
Console.WriteLine(grid[1, 2]);  // Output: 7 (second row, third column)

// Iterating through a 2D array
for (int row = 0; row < 3; row++)
{
    for (int col = 0; col < 4; col++)
    {
        Console.Write($"{grid[row, col]}\t");
    }
    Console.WriteLine();  // New line after each row
}
```

### Exercise: Student Grades

```csharp
using System;

namespace StudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Student Grade Analyzer ===");
            
            // Ask for the number of students
            Console.Write("How many students? ");
            int studentCount = int.Parse(Console.ReadLine());
            
            // Create arrays to store names and grades
            string[] names = new string[studentCount];
            int[] grades = new int[studentCount];
            
            // Get data for each student
            for (int i = 0; i < studentCount; i++)
            {
                Console.Write($"Enter name for student {i+1}: ");
                names[i] = Console.ReadLine();
                
                Console.Write($"Enter grade for {names[i]}: ");
                grades[i] = int.Parse(Console.ReadLine());
            }
            
            // Calculate average grade
            double averageGrade = CalculateAverage(grades);
            
            // Find highest and lowest grades
            int highestGrade = FindMax(grades);
            int lowestGrade = FindMin(grades);
            
            // Display results
            Console.WriteLine("\n=== Results ===");
            Console.WriteLine($"Class average: {averageGrade:F1}");
            Console.WriteLine($"Highest grade: {highestGrade}");
            Console.WriteLine($"Lowest grade: {lowestGrade}");
            
            // List all students and grades
            Console.WriteLine("\n=== Student Grades ===");
            for (int i = 0; i < studentCount; i++)
            {
                string performance = DeterminePerformance(grades[i], averageGrade);
                Console.WriteLine($"{names[i]}: {grades[i]} ({performance})");
            }
            
            Console.ReadKey();
        }
        
        static double CalculateAverage(int[] values)
        {
            int sum = 0;
            foreach (int value in values)
            {
                sum += value;
            }
            return (double)sum / values.Length;
        }
        
        static int FindMax(int[] values)
        {
            int max = values[0];
            foreach (int value in values)
            {
                if (value > max)
                {
                    max = value;
                }
            }
            return max;
        }
        
        static int FindMin(int[] values)
        {
            int min = values[0];
            foreach (int value in values)
            {
                if (value < min)
                {
                    min = value;
                }
            }
            return min;
        }
        
        static string DeterminePerformance(int grade, double average)
        {
            if (grade >= average + 10)
            {
                return "Excellent";
            }
            else if (grade >= average)
            {
                return "Above Average";
            }
            else if (grade >= average - 10)
            {
                return "Average";
            }
            else
            {
                return "Below Average";
            }
        }
    }
}
```

## Session 2 Mini Quiz

Let's test your understanding with a short quiz:

1. What will be the output of this code?
   ```csharp
   int x = 10;
   if (x > 5)
   {
       Console.Write("A");
   }
   else if (x > 8)
   {
       Console.Write("B");
   }
   Console.Write("C");
   ```
   a) A
   b) B
   c) C
   d) AC

2. How many times will this loop execute?
   ```csharp
   for (int i = 0; i < 5; i += 2)
   {
       Console.WriteLine(i);
   }
   ```
   a) 2
   b) 3
   c) 5
   d) 6

3. What is the value of `result` after this code runs?
   ```csharp
   int[] numbers = { 5, 10, 15, 20 };
   int result = 0;
   foreach (int num in numbers)
   {
       if (num > 10)
       {
           result += num;
       }
   }
   ```
   a) 10
   b) 25
   c) 35
   d) 50

4. What does the following method return when called with `FindMax(3, 7)`?
   ```csharp
   static int FindMax(int a, int b)
   {
       if (a > b)
       {
           return a;
       }
       else
       {
           return b;
       }
   }
   ```
   a) 3
   b) 7
   c) 10
   d) Error

5. What is stored in the variable `letter` after this code runs?
   ```csharp
   string word = "Hello";
   char letter = word[1];
   ```
   a) H
   b) e
   c) l
   d) o

Answers: 1-d, 2-b, 3-c, 4-b, 5-b

## Session 2 Practice Exercises

### Exercise 1: Number Analyzer
Create a program that asks the user for an integer and then determines if it is:
- Positive, negative, or zero
- Even or odd
- Prime or not prime

### Exercise 2: Guess the Number Game
Create a game where the computer picks a random number between 1 and 100, and the player tries to guess it. After each guess, tell the player if their guess was too high, too low, or correct.

### Exercise 3: Shopping Cart
Create a program that simulates a simple shopping cart. Allow the user to:
- Add items with prices
- View all items
- Calculate the total cost
- Apply a discount code

## Session 2 Summary

Congratulations on completing the second session! You've learned:
- How to make decisions using conditional statements
- How to repeat code efficiently using loops
- How to organize code into reusable methods
- How to work with collections of data using arrays

In the next session, we'll introduce object-oriented programming and learn how to create and use classes to build more complex applications.

---
