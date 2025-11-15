namespace Practice
{
    ////Anagram Question 1
    //    class Program
    //    {

    //        static void Main()
    //        {
    //            Console.Write("Enter String 1: ");
    //            string str1 = Console.ReadLine() ?? string.Empty;

    //            Console.Write("Enter String 2: ");
    //            string str2 = Console.ReadLine() ?? string.Empty;

    //            if (AreAnagramsBySorting(str1, str2))
    //                Console.WriteLine("Anagram");
    //            else
    //                Console.WriteLine("Not an Anagram");
    //        }

    //        static bool AreAnagramsBySorting(string s1, string s2)
    //        {
    //            // Normalize: remove non-letters and convert to lowercase
    //            var clean1 = new string(s1.Where(char.IsLetterOrDigit)
    //                .Select(char.ToLower)
    //                .ToArray());
    //            var clean2 = new string(s2.Where(char.IsLetterOrDigit)
    //                .Select(char.ToLower)
    //                .ToArray());

    //            if (clean1.Length != clean2.Length)
    //                return false;

    //            // Sort and compare
    //            var sorted1 = clean1.OrderBy(c => c);
    //            var sorted2 = clean2.OrderBy(c => c);

    //            return sorted1.SequenceEqual(sorted2);
    //        }
    //}

    //// Leetcode Problem 5
    ////strings
    ////Longest Palindromic substrings

    //using System.Text;

    //string? line = Console.ReadLine();
    //if (line is null)
    //{
    //    Console.WriteLine("Please enter non-empty string");
    //    return;
    //}

    //string s = line.Trim().ToLower();
    //StringBuilder longest = new StringBuilder("");

    //if (!string.IsNullOrEmpty(s))
    //{
    //    if (ValidInput(s))
    //    {
    //        Console.WriteLine("Valid String");
    //        HashSet<char> processed = new HashSet<char>();

    //        // traverse each character once
    //        for (int idx = 0; idx < s.Length; idx++)
    //        {
    //            char character = s[idx];
    //            if (processed.Contains(character))
    //                continue;

    //            processed.Add(character);

    //            // for each pair of occurrences of the character
    //            for (int start = s.IndexOf(character); start != -1; start = s.IndexOf(character, start + 1))
    //            {
    //                for (int end = s.IndexOf(character, start + 1); end != -1; end = s.IndexOf(character, end + 1))
    //                {
    //                    int length = end - start + 1;
    //                    string substr = s.Substring(start, length);
    //                    if (IsPalindrome(substr))
    //                        LongestString(substr);
    //                }
    //            }
    //        }

    //        Console.WriteLine($"Longest Palindromic Substring: {longest}");
    //    }
    //    else
    //    {
    //        Console.WriteLine("Please enter letters a-z & numbers 0-9 only");
    //    }
    //}
    //else
    //{
    //    Console.WriteLine("Please enter non-empty string");
    //}

    //bool ValidInput(string str)
    //{
    //    if (str.Length >= 1 && str.Length <= 1000)
    //    {
    //        return str.All(ch => (ch >= '0' && ch <= '9') || (ch >= 'a' && ch <= 'z'));
    //    }
    //    return false;
    //}

    //bool IsPalindrome(string substring)
    //{
    //    for (int j = 0; j < substring.Length / 2; j++)
    //    {
    //        if (substring[j] != substring[substring.Length - 1 - j])
    //            return false;
    //    }
    //    return true;
    //}

    //void LongestString(string substring)
    //{
    //    if (substring.Length > longest.Length)
    //    {
    //        longest.Clear();
    //        longest.Append(substring);
    //    }
    //}

    //Leetcode Problem 3
    //strings
    //Longest Substring Without Repeating Characters
    //using System.Text;

    //Console.WriteLine("Enter string:");
    //string s = Console.ReadLine() ?? string.Empty;
    //char[] chars = s.ToCharArray();

    //if (s != string.Empty)
    //{
    //    Console.WriteLine(LengthOfLongestSubstring(s));
    //}
    //int LengthOfLongestSubstring(string s)
    //{
    //    if (string.IsNullOrEmpty(s)) return 0;

    //    StringBuilder sb = new StringBuilder();
    //    int length = 0;
    //    for (int i = 0; i < chars.Length; i++)
    //    {
    //        char current = chars[i];
    //        bool hasNext = i + 1 < chars.Length;

    //        if (!sb.ToString().Contains(current))
    //        {
    //            sb.Append(current);

    //            // only compare with next when there is a next
    //            if (hasNext && current == chars[i + 1])
    //            {
    //                if (length < sb.Length) length = sb.Length;
    //                sb.Clear();
    //            }
    //        }
    //        else
    //        {
    //            if (length < sb.Length) length = sb.Length;
    //            sb.Clear();
    //            // start new sb including current char
    //            sb.Append(current);
    //        }
    //    }

    //    if (length < sb.Length) length = sb.Length;
    //    return length;
    //}


    ////1.1
    //class PersonalInfo
    //{
    //    static void Main()
    //    {
    //        Console.Write("Enter your name: ");
    //        string name = Console.ReadLine() ?? "";

    //        Console.Write("Enter your age: ");
    //        string ageInput = Console.ReadLine() ?? "";
    //        int age;
    //        if (!int.TryParse(ageInput.Trim(), out age) || age < 0)
    //        {
    //            Console.WriteLine("Invalid age. Please enter a non-negative integer.");
    //            return;
    //        }

    //        Console.Write("Enter your favorite color: ");
    //        string color = Console.ReadLine() ?? "";

    //        Console.WriteLine();
    //        Console.WriteLine("----- Personal Information -----");
    //        Console.WriteLine($"Name           : {name}");
    //        Console.WriteLine($"Age            : {age}");
    //        Console.WriteLine($"Favorite color : {color}");
    //    }
    //}


    ////1.2
    //class TempConverter
    //{
    //    static void Main()
    //    {
    //        Console.Write("Enter temperature in Fahrenheit: ");
    //        string input = Console.ReadLine() ?? "";

    //        if (!double.TryParse(input.Trim(), out double f))
    //        {
    //            Console.WriteLine("Invalid number entered. Use digits (e.g. 98.6).");
    //            return;
    //        }

    //        double c = (f - 32.0) * 5.0 / 9.0;
    //        Console.WriteLine($"Fahrenheit: {f}");
    //        Console.WriteLine($"Celsius   : {c:F2}");
    //    }
    //}


    ////1.3
    //class AreaCalculator
    //{
    //    static void Main()
    //    {
    //        Console.Write("Enter rectangle length: ");
    //        string lenInput = Console.ReadLine() ?? "";
    //        Console.Write("Enter rectangle width : ");
    //        string widInput = Console.ReadLine() ?? "";

    //        if (!double.TryParse(lenInput.Trim(), out double length)
    //            || !double.TryParse(widInput.Trim(), out double width))
    //        {
    //            Console.WriteLine("Invalid numeric input. Use digits (e.g. 4 or 3.5).");
    //            return;
    //        }

    //        if (length < 0 || width < 0)
    //        {
    //            Console.WriteLine("Length and width must be non-negative.");
    //            return;
    //        }

    //        double area = length * width;
    //        Console.WriteLine();
    //        Console.WriteLine($"Length : {length}");
    //        Console.WriteLine($"Width  : {width}");
    //        Console.WriteLine($"Area   : {area:F2}");
    //    }
    //}





    ////2.1
    //class NumberAnalyzer
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.Write("Enter an integer: ");
    //        string input = Console.ReadLine();

    //        // Validate input
    //        if (!int.TryParse(input, out int number))
    //        {
    //            Console.WriteLine("Invalid input; please enter a valid integer.");
    //            return;
    //        }

    //        // 1. Positive / Negative / Zero
    //        if (number > 0)
    //            Console.WriteLine("The number is positive.");
    //        else if (number < 0)
    //            Console.WriteLine("The number is negative.");
    //        else
    //            Console.WriteLine("The number is zero.");

    //        // 2. Even / Odd
    //        if (number % 2 == 0)
    //            Console.WriteLine("The number is even.");
    //        else
    //            Console.WriteLine("The number is odd.");

    //        // 3. Prime / Not prime
    //        if (IsPrime(number))
    //            Console.WriteLine("The number is prime.");
    //        else
    //            Console.WriteLine("The number is not prime.");
    //    }
    //    // Method to check prime:
    //    static bool IsPrime(int n)
    //    {
    //        // Negative numbers, 0 and 1 are not prime
    //        if (n <= 1) return false;
    //        // 2 and 3 are prime
    //        if (n <= 3) return true;
    //        // eliminate multiples of 2 and 3
    //        if (n % 2 == 0 || n % 3 == 0) return false;

    //        // check for factors up to sq.root of n
    //        for (int i = 5; i * i <= n; i += 6)
    //        {
    //            if (n % i == 0 || n % (i + 2) == 0)
    //                return false;
    //        }
    //        return true;
    //    }

    //}


    ////2.2
    //class GuessNumber
    //{
    //    static void Main(string[] args)
    //    {
    //        var rng = new Random();
    //        int secretNumber = rng.Next(1, 101);  // Random number in [1,100]
    //        int guess;
    //        int attempts = 0;

    //        Console.WriteLine("I picked a no. b/w 1 and 100.");
    //        Console.WriteLine("Try to guess it!");

    //        // Game loop
    //        do
    //        {
    //            Console.Write("Enter your guess: ");
    //            string input = Console.ReadLine();
    //            attempts++;

    //            // Validate input
    //            if (!int.TryParse(input, out guess))
    //            {
    //                Console.WriteLine("Please enter an integer B/W 1 - 100.");
    //                continue;
    //            }

    //            // Provide feedback
    //            if (guess < secretNumber)
    //                Console.WriteLine("   : Too low. Try again.");
    //            else if (guess > secretNumber)
    //                Console.WriteLine("   : Too high. Try again.");
    //            else
    //                Console.WriteLine($"   : Correct! You guessed it in {attempts} attempts.");

    //        } while (guess != secretNumber);

    //        Console.WriteLine("Thanks for playing!");
    //    }

    //}

    //2.3
    class CartItem
    {
        public string Name { get; }
        public decimal Price { get; }

        public CartItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        static void Main(string[] args)
        {
            var cart = new List<CartItem>();
            bool discountApplied = false;
            decimal discountPercent = 0m;

            while (true)
            {
                Console.WriteLine("\n=== Shopping Cart Menu ===");
                Console.WriteLine("1) Add item");
                Console.WriteLine("2) View cart");
                Console.WriteLine("3) View total");
                Console.WriteLine("4) Apply discount code");
                Console.WriteLine("5) Exit");
                Console.Write("Choose an option (1–5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddItem(cart);
                        break;
                    case "2":
                        ViewCart(cart);
                        break;
                    case "3":
                        ViewTotal(cart, discountPercent);
                        break;
                    case "4":
                        if (discountApplied)
                        {
                            Console.WriteLine("A discount has already been applied.");
                        }
                        else
                        {
                            discountPercent = ApplyDiscount();
                            if (discountPercent > 0)
                                discountApplied = true;
                        }
                        break;
                    case "5":
                        Console.WriteLine("Thank you for shopping with us! Goodbye.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice; please enter 1–5.");
                        break;
                }
            }
        }

        static void AddItem(List<CartItem> cart)
        {
            Console.Write("Enter item name: ");
            string name = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Item name cannot be blank.");
                return;
            }

            Console.Write("Enter item price: ");
            string priceInput = Console.ReadLine();
            if (!decimal.TryParse(priceInput, out decimal price)
                || price < 0)
            {
                Console.WriteLine("Invalid price. Please enter a non-negative number.");
                return;
            }

            cart.Add(new CartItem(name, price));
            Console.WriteLine($"Added \"{name}\" at {price:C2} to the cart.");
        }

        static void ViewCart(List<CartItem> cart)
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            Console.WriteLine("Items in your cart:");
            for (int i = 0; i < cart.Count; i++)
            {
                var item = cart[i];
                Console.WriteLine($"{i + 1}. {item.Name} — {item.Price:C2}");
            }
        }

        static void ViewTotal(List<CartItem> cart, decimal discountPercent)
        {
            decimal subtotal = 0m;
            foreach (var item in cart)
                subtotal += item.Price;

            Console.WriteLine($"Subtotal: {subtotal:C2}");

            if (discountPercent > 0)
            {
                decimal discountAmount = subtotal * (discountPercent / 100m);
                decimal total = subtotal - discountAmount;
                Console.WriteLine($"Discount ({discountPercent}%): –{discountAmount:C2}");
                Console.WriteLine($"Total after discount: {total:C2}");
            }
            else
            {
                Console.WriteLine("No discount applied.");
                Console.WriteLine($"Total: {subtotal:C2}");
            }
        }

        static decimal ApplyDiscount()
        {
            Console.Write("Enter discount code: ");
            string code = Console.ReadLine()?.Trim().ToUpper();

            // Example codes
            var codes = new Dictionary<string, decimal>
            {
                { "SAVE10", 10m },
                { "SAVE20", 20m },
                { "FREESHIP", 5m }   // 5% discount
            };

            if (codes.TryGetValue(code, out decimal pct))
            {
                Console.WriteLine($"Code applied! You get {pct}% off.");
                return pct;
            }
            else
            {
                Console.WriteLine("Invalid code. No discount applied.");
                return 0m;
            }

        }
    }

    //namespace OOPExercises
    //{
    //    // -------------------------
    //    // Exercise 2: Shape Hierarchy
    //    // -------------------------

    //    // Abstract base Shape class: forces derived shapes to implement Area and Perimeter
    //    public abstract class Shape
    //    {
    //        // Public read-only properties derived from methods
    //        public abstract double Area { get; }
    //        public abstract double Perimeter { get; }

    //        // Virtual display method - derived classes can override if needed
    //        public virtual void DisplayInfo()
    //        {
    //            Console.WriteLine($"{GetType().Name} - Area: {Area:F2}, Perimeter: {Perimeter:F2}");
    //        }
    //    }

    //    // Circle
    //    public class Circle : Shape
    //    {
    //        // encapsulated field with public property
    //        private double _radius;
    //        public double Radius
    //        {
    //            get => _radius;
    //            set
    //            {
    //                if (value <= 0) throw new ArgumentException("Radius must be positive.");
    //                _radius = value;
    //            }
    //        }

    //        public Circle(double radius)
    //        {
    //            Radius = radius;
    //        }

    //        public override double Area => Math.PI * Radius * Radius;
    //        public override double Perimeter => 2 * Math.PI * Radius;

    //        public override void DisplayInfo()
    //        {
    //            Console.WriteLine($"Circle (r = {Radius:F2}) → Area: {Area:F2}, Circumference: {Perimeter:F2}");
    //        }
    //    }

    //    // Rectangle
    //    public class Rectangle : Shape
    //    {
    //        private double _width;
    //        private double _height;

    //        public double Width
    //        {
    //            get => _width;
    //            set
    //            {
    //                if (value <= 0) throw new ArgumentException("Width must be positive.");
    //                _width = value;
    //            }
    //        }

    //        public double Height
    //        {
    //            get => _height;
    //            set
    //            {
    //                if (value <= 0) throw new ArgumentException("Height must be positive.");
    //                _height = value;
    //            }
    //        }

    //        public Rectangle(double width, double height)
    //        {
    //            Width = width;
    //            Height = height;
    //        }

    //        public override double Area => Width * Height;
    //        public override double Perimeter => 2 * (Width + Height);

    //        public override void DisplayInfo()
    //        {
    //            Console.WriteLine($"Rectangle (w = {Width:F2}, h = {Height:F2}) → Area: {Area:F2}, Perimeter: {Perimeter:F2}");
    //        }
    //    }

    //    // Triangle (by three side lengths). Uses Heron's formula for area.
    //    public class Triangle : Shape
    //    {
    //        private double _a;
    //        private double _b;
    //        private double _c;

    //        public double A
    //        {
    //            get => _a;
    //            private set
    //            {
    //                if (value <= 0) throw new ArgumentException("Side lengths must be positive.");
    //                _a = value;
    //            }
    //        }

    //        public double B
    //        {
    //            get => _b;
    //            private set
    //            {
    //                if (value <= 0) throw new ArgumentException("Side lengths must be positive.");
    //                _b = value;
    //            }
    //        }

    //        public double C
    //        {
    //            get => _c;
    //            private set
    //            {
    //                if (value <= 0) throw new ArgumentException("Side lengths must be positive.");
    //                _c = value;
    //            }
    //        }

    //        public Triangle(double a, double b, double c)
    //        {
    //            // assign then validate triangle inequality
    //            A = a; B = b; C = c;
    //            if (!IsValidTriangle(A, B, C))
    //                throw new ArgumentException("The provided sides do not form a valid triangle.");
    //        }

    //        private static bool IsValidTriangle(double a, double b, double c)
    //        {
    //            return a + b > c && a + c > b && b + c > a;
    //        }

    //        public override double Perimeter => A + B + C;

    //        public override double Area
    //        {
    //            get
    //            {
    //                var s = Perimeter / 2.0;
    //                return Math.Sqrt(Math.Max(0.0, s * (s - A) * (s - B) * (s - C)));
    //            }
    //        }

    //        public override void DisplayInfo()
    //        {
    //            Console.WriteLine($"Triangle (a={A:F2}, b={B:F2}, c={C:F2}) → Area: {Area:F2}, Perimeter: {Perimeter:F2}");
    //        }
    //    }

    //    // -------------------------
    //    // Exercise 3: Product Inventory System
    //    // -------------------------

    //    // Product class with encapsulated fields and properties
    //    public class Product
    //    {
    //        // Use Name as identifier for simplicity (could use SKU/ID in real apps)
    //        private string _name;
    //        public string Name
    //        {
    //            get => _name;
    //            private set
    //            {
    //                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Product name required.");
    //                _name = value.Trim();
    //            }
    //        }

    //        private decimal _price;
    //        public decimal Price
    //        {
    //            get => _price;
    //            set
    //            {
    //                if (value < 0) throw new ArgumentException("Price cannot be negative.");
    //                _price = value;
    //            }
    //        }

    //        private int _quantity;
    //        public int Quantity
    //        {
    //            get => _quantity;
    //            set
    //            {
    //                if (value < 0) throw new ArgumentException("Quantity cannot be negative.");
    //                _quantity = value;
    //            }
    //        }

    //        public Product(string name, decimal price, int quantity)
    //        {
    //            Name = name;
    //            Price = price;
    //            Quantity = quantity;
    //        }

    //        public decimal TotalValue => Price * Quantity;

    //        public override string ToString()
    //        {
    //            return $"{Name} | Price: {Price:C}, Qty: {Quantity}, Value: {TotalValue:C}";
    //        }
    //    }

    //    // Inventory class managing a collection of products
    //    public class Inventory
    //    {
    //        // Use dictionary for fast lookup by product name
    //        private readonly Dictionary<string, Product> _products = new Dictionary<string, Product>(StringComparer.OrdinalIgnoreCase);

    //        // Add a product. If a product with same name exists, throw or merge (we choose to throw to keep beginner logic simple)
    //        public void AddProduct(Product product)
    //        {
    //            if (product == null) throw new ArgumentNullException(nameof(product));
    //            if (_products.ContainsKey(product.Name))
    //                throw new InvalidOperationException($"Product with name '{product.Name}' already exists.");

    //            _products.Add(product.Name, product);
    //        }

    //        // Remove product by name; returns true if removed
    //        public bool RemoveProduct(string name)
    //        {
    //            if (string.IsNullOrWhiteSpace(name)) return false;
    //            return _products.Remove(name.Trim());
    //        }

    //        // Update price and/or quantity for an existing product
    //        public void UpdateProduct(string name, decimal? newPrice = null, int? newQuantity = null)
    //        {
    //            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required.");
    //            if (!_products.TryGetValue(name.Trim(), out var product)) throw new KeyNotFoundException("Product not found.");

    //            if (newPrice.HasValue) product.Price = newPrice.Value;
    //            if (newQuantity.HasValue) product.Quantity = newQuantity.Value;
    //        }

    //        // Safe lookup using TryGetValue pattern
    //        public bool TryGetProduct(string name, out Product product)
    //        {
    //            product = null;
    //            if (string.IsNullOrWhiteSpace(name)) return false;
    //            return _products.TryGetValue(name.Trim(), out product);
    //        }

    //        // Calculate total inventory value (sum of price * quantity)
    //        public decimal CalculateTotalValue()
    //        {
    //            return _products.Values.Sum(p => p.TotalValue);
    //        }

    //        // Expose products as read-only collection for display
    //        public IReadOnlyCollection<Product> GetAllProducts() => _products.Values.ToList().AsReadOnly();
    //    }

    //    // -------------------------
    //    // Program: Demonstration
    //    // -------------------------
    //    class Program
    //    {
    //        static void Main()
    //        {
    //            Console.WriteLine("=== Exercise 2: Shape Hierarchy Demo ===\n");
    //            var shapes = new List<Shape>
    //            {
    //                new Circle(3.5),
    //                new Rectangle(4.0, 6.0),
    //                new Triangle(3.0, 4.0, 5.0)
    //            };

    //            foreach (var shape in shapes)
    //            {
    //                shape.DisplayInfo();
    //            }

    //            Console.WriteLine("\n=== Exercise 3: Product Inventory Demo ===\n");
    //            var inventory = new Inventory();

    //            // Add products
    //            var p1 = new Product("Notebook", 2.50m, 120);
    //            var p2 = new Product("Pen", 0.75m, 300);
    //            var p3 = new Product("Stapler", 6.99m, 15);

    //            inventory.AddProduct(p1);
    //            inventory.AddProduct(p2);
    //            inventory.AddProduct(p3);

    //            Console.WriteLine("Products after adding:");
    //            foreach (var p in inventory.GetAllProducts())
    //                Console.WriteLine(p);

    //            // Update product price and quantity
    //            inventory.UpdateProduct("Pen", newPrice: 0.80m, newQuantity: 250);
    //            Console.WriteLine("\nAfter updating Pen:");
    //            if (inventory.TryGetProduct("Pen", out var pen))
    //                Console.WriteLine(pen);

    //            // Remove a product
    //            inventory.RemoveProduct("Stapler");
    //            Console.WriteLine("\nAfter removing Stapler:");
    //            foreach (var p in inventory.GetAllProducts())
    //                Console.WriteLine(p);

    //            // Total inventory value
    //            Console.WriteLine($"\nTotal Inventory Value: {inventory.CalculateTotalValue():C}");

    //            Console.WriteLine("\nDemo complete.");
    //        }
    //    }
    //}

}