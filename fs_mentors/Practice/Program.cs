namespace NumberAnalysis
{
    class Program
    {
        //Question 1

        static void Main()
        {
            Console.Write("Enter String 1: ");
            string str1 = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter String 2: ");
            string str2 = Console.ReadLine() ?? string.Empty;

            if (AreAnagramsBySorting(str1, str2))
                Console.WriteLine("Anagram");
            else
                Console.WriteLine("Not an Anagram");
        }

        static bool AreAnagramsBySorting(string s1, string s2)
        {
            // Normalize: remove non-letters and convert to lowercase
            var clean1 = new string(s1.Where(char.IsLetterOrDigit)
                .Select(char.ToLower)
                .ToArray());
            var clean2 = new string(s2.Where(char.IsLetterOrDigit)
                .Select(char.ToLower)
                .ToArray());

            if (clean1.Length != clean2.Length)
                return false;

            // Sort and compare
            var sorted1 = clean1.OrderBy(c => c);
            var sorted2 = clean2.OrderBy(c => c);

            return sorted1.SequenceEqual(sorted2);
        }


        //Exercise 1
        //static void Main(string[] args)
        //{
        //    Console.Write("Enter an integer: ");
        //    string input = Console.ReadLine();

        //    // 1. Validate input
        //    if (!int.TryParse(input, out int number))
        //    {
        //        Console.WriteLine("Invalid input; please enter a valid integer.");
        //        return;
        //    }

        //    // 2. Positive / Negative / Zero
        //    if (number > 0)
        //        Console.WriteLine("The number is positive.");
        //    else if (number < 0)
        //        Console.WriteLine("The number is negative.");
        //    else
        //        Console.WriteLine("The number is zero.");

        //    // 3. Even / Odd
        //    if (number % 2 == 0)
        //        Console.WriteLine("The number is even.");
        //    else
        //        Console.WriteLine("The number is odd.");

        //    // 4. Prime / Not prime
        //    if (IsPrime(number))
        //        Console.WriteLine("The number is prime.");
        //    else
        //        Console.WriteLine("The number is not prime.");
        //}

        //// Helper method to check primality
        //static bool IsPrime(int n)
        //{
        //    // Negative numbers, 0 and 1 are not prime
        //    if (n <= 1) return false;
        //    // 2 and 3 are prime
        //    if (n <= 3) return true;
        //    // eliminate multiples of 2 and 3
        //    if (n % 2 == 0 || n % 3 == 0) return false;

        //    // check for factors up to √n
        //    for (int i = 5; i * i <= n; i += 6)
        //    {
        //        if (n % i == 0 || n % (i + 2) == 0)
        //            return false;
        //    }
        //    return true;
        //}

        //Exercise 2
        //static void Main(string[] args)
        //{
        //    var rng = new Random();
        //    int secretNumber = rng.Next(1, 101);  // Random number in [1,100]
        //    int guess;
        //    int attempts = 0;

        //    Console.WriteLine("I have picked a number between 1 and 100.");
        //    Console.WriteLine("Try to guess it!");

        //    // Game loop
        //    do
        //    {
        //        Console.Write("Enter your guess: ");
        //        string input = Console.ReadLine();
        //        attempts++;

        //        // Validate input
        //        if (!int.TryParse(input, out guess))
        //        {
        //            Console.WriteLine("   : That’s not a valid number. Please enter an integer.");
        //            continue;
        //        }

        //        // Provide feedback
        //        if (guess < secretNumber)
        //            Console.WriteLine("   : Too low. Try again.");
        //        else if (guess > secretNumber)
        //            Console.WriteLine("   : Too high. Try again.");
        //        else
        //            Console.WriteLine($"   : Correct! You guessed it in {attempts} attempts.");

        //    } while (guess != secretNumber);

        //    Console.WriteLine("Thanks for playing!");
        //}

        //Exercise 3
        // A simple class to hold item info
        //class CartItem
        //{
        //    public string Name { get; }
        //    public decimal Price { get; }

        //    public CartItem(string name, decimal price)
        //    {
        //        Name = name;
        //        Price = price;
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    var cart = new List<CartItem>();
        //    bool discountApplied = false;
        //    decimal discountPercent = 0m;

        //    while (true)
        //    {
        //        Console.WriteLine("\n=== Shopping Cart Menu ===");
        //        Console.WriteLine("1) Add item");
        //        Console.WriteLine("2) View cart");
        //        Console.WriteLine("3) View total");
        //        Console.WriteLine("4) Apply discount code");
        //        Console.WriteLine("5) Exit");
        //        Console.Write("Choose an option (1–5): ");

        //        string choice = Console.ReadLine();
        //        Console.WriteLine();

        //        switch (choice)
        //        {
        //            case "1":
        //                AddItem(cart);
        //                break;
        //            case "2":
        //                ViewCart(cart);
        //                break;
        //            case "3":
        //                ViewTotal(cart, discountPercent);
        //                break;
        //            case "4":
        //                if (discountApplied)
        //                {
        //                    Console.WriteLine("A discount has already been applied.");
        //                }
        //                else
        //                {
        //                    discountPercent = ApplyDiscount();
        //                    if (discountPercent > 0)
        //                        discountApplied = true;
        //                }
        //                break;
        //            case "5":
        //                Console.WriteLine("Thank you for shopping with us! Goodbye.");
        //                return;
        //            default:
        //                Console.WriteLine("Invalid choice; please enter 1–5.");
        //                break;
        //        }
        //    }
        //}

        //static void AddItem(List<CartItem> cart)
        //{
        //    Console.Write("Enter item name: ");
        //    string name = Console.ReadLine()?.Trim();
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        Console.WriteLine("Item name cannot be blank.");
        //        return;
        //    }

        //    Console.Write("Enter item price: ");
        //    string priceInput = Console.ReadLine();
        //    if (!decimal.TryParse(priceInput, NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal price)
        //        || price < 0)
        //    {
        //        Console.WriteLine("Invalid price. Please enter a non-negative number.");
        //        return;
        //    }

        //    cart.Add(new CartItem(name, price));
        //    Console.WriteLine($"Added \"{name}\" at {price:C2} to the cart.");
        //}

        //static void ViewCart(List<CartItem> cart)
        //{
        //    if (cart.Count == 0)
        //    {
        //        Console.WriteLine("Your cart is empty.");
        //        return;
        //    }

        //    Console.WriteLine("Items in your cart:");
        //    for (int i = 0; i < cart.Count; i++)
        //    {
        //        var item = cart[i];
        //        Console.WriteLine($"{i + 1}. {item.Name} — {item.Price:C2}");
        //    }
        //}

        //static void ViewTotal(List<CartItem> cart, decimal discountPercent)
        //{
        //    decimal subtotal = 0m;
        //    foreach (var item in cart)
        //        subtotal += item.Price;

        //    Console.WriteLine($"Subtotal: {subtotal:C2}");

        //    if (discountPercent > 0)
        //    {
        //        decimal discountAmount = subtotal * discountPercent / 100m;
        //        decimal total = subtotal - discountAmount;
        //        Console.WriteLine($"Discount ({discountPercent}%): –{discountAmount:C2}");
        //        Console.WriteLine($"Total after discount: {total:C2}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("No discount applied.");
        //        Console.WriteLine($"Total: {subtotal:C2}");
        //    }
        //}

        //static decimal ApplyDiscount()
        //{
        //    Console.Write("Enter discount code: ");
        //    string code = Console.ReadLine()?.Trim().ToUpperInvariant();

        //    // Example codes
        //    var codes = new Dictionary<string, decimal>
        //    {
        //        { "SAVE10", 10m },
        //        { "SAVE20", 20m },
        //        { "FREESHIP", 5m }   // could represent a 5% offset for shipping
        //    };

        //    if (codes.TryGetValue(code, out decimal pct))
        //    {
        //        Console.WriteLine($"Code applied! You get {pct}% off.");
        //        return pct;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid code. No discount applied.");
        //        return 0m;
        //    }
        //}
    }
}