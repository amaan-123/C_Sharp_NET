//### Exercise 2: Shape Hierarchy

//Create a class hierarchy for geometric shapes:

//- A base Shape class with area and perimeter calculations
//- Derived classes for Circle, Rectangle, and Triangle
//- A method to display information about each shape

interface IShape
{
    double Area { get; set; }
    double Perimeter { get; set; }
    void CalculateArea();
    void CalculatePerimeter();

    void DisplayInfo(IShape shape);
}

interface ILengthValidate
{
    bool Validate(uint numberOfMeasures);
}

abstract class Shape : IShape, ILengthValidate
{
    public double Area { get; set; }
    public double Perimeter { get; set; }

    public List<double> Measurements = new List<double>();

    public abstract void CalculateArea();

    public abstract void CalculatePerimeter();
    public void DisplayInfo(IShape shape)
    {
        Console.WriteLine($"======={shape} Info:=======");
        Console.WriteLine($"Area: {shape.Area}");
        Console.WriteLine($"Perimeter: {shape.Perimeter}");
    }

    public bool Validate(uint numberOfMeasures)
    {
        Measurements.Clear();
        for (int i = 0; i < numberOfMeasures; i++)
        {
            string? measure = Console.ReadLine().Trim();
            if (!double.TryParse(measure, out double value))
            {
                Console.WriteLine($"{measure} is invalid. Please enter valid number (e.g 7, or 4.23, or 100) ");
                return false;
            }
            Measurements.Add(value);
        }
        return true;
    }
}

class Circle : Shape
{
    public double Radius { get; set; }
    public Circle()
    {
        if (Validate(1))
        {
            Radius = Measurements[0];
        }
    }
    public override void CalculateArea()
    {
        Area = double.Pi * (Math.Pow(Radius, 2));
    }

    public override void CalculatePerimeter()
    {
        Perimeter = 2 * double.Pi * Radius;
    }
}
class Rectangle : Shape
{
    public double Length { get; set; }
    public double Breadth { get; set; }
    public Rectangle()
    {
        if (Validate(2))
        {
            Length = Measurements[0];
            Breadth = Measurements[1];
        }
    }
    public override void CalculateArea()
    {
        Area = Length * Breadth;
    }

    public override void CalculatePerimeter()
    {
        Perimeter = 2 * (Length + Breadth);
    }
}
class Triangle : Shape
{
    public double a { get; set; }
    public double b { get; set; }
    public double c { get; set; }
    public Triangle()
    {
        if (Validate(3))
        {
            a = Measurements[0];
            b = Measurements[1];
            c = Measurements[2];
        }
    }
    double CalculateSemiPerimeter()
    {
        return (a + b + c) / 2;
    }
    public override void CalculateArea()
    {
        double s = CalculateSemiPerimeter();
        Area = s * (s - a) * (s - b) * (s - c);
    }

    public override void CalculatePerimeter()
    {
        Perimeter = a + b + c;
    }
}

class Program
{
    static void Main()
    {
        bool validNumber = false;
        bool exitMenu = false;
        var validChoices = new List<uint>() { 0, 1, 2, 3 };
        do
        {
            DisplayMenu();
            validNumber = uint.TryParse(Console.ReadLine(), out uint choice) && validChoices.Contains(choice);
            switch (choice)
            {
                case 0:
                    Console.WriteLine("=======Exiting program=======");
                    exitMenu = true;
                    break;
                case 1:
                    Console.WriteLine("=======Circle Calculations=======");
                    Console.WriteLine("Enter Radius");
                    // Calls Validate() first, then sets Properties:
                    var circle = new Circle();
                    circle.CalculateArea();
                    circle.CalculatePerimeter();
                    circle.DisplayInfo(circle);
                    break;
                case 2:

                    Console.WriteLine("=======Rectangle Calculations=======");

                    Console.WriteLine("Enter Length");
                    Console.WriteLine("Enter Breadth");
                    // Calls Validate() first, then sets Properties:
                    var rectangle = new Rectangle();
                    rectangle.CalculateArea();
                    rectangle.CalculatePerimeter();
                    rectangle.DisplayInfo(rectangle);
                    break;
                case 3:
                    Console.WriteLine("=======Triangle Calculations=======");

                    Console.WriteLine("Enter Side 1");
                    Console.WriteLine("Enter Side 2");
                    Console.WriteLine("Enter Side 3");
                    // Calls Validate() first, then sets Properties:
                    var triangle = new Triangle();
                    triangle.CalculateArea();
                    triangle.CalculatePerimeter();
                    triangle.DisplayInfo(triangle);
                    break;

                default:
                    if (!validNumber)
                    {
                        Console.WriteLine($"Your choice: {choice} is not valid!");
                        DisplayMenu();
                    }
                    break;
            }
            Console.WriteLine("Enter Y to continue or N to exit:");
            exitMenu = Console.ReadLine().Trim().ToUpper() == "Y" ? false : true;
        }
        while (validNumber && !exitMenu);

        void DisplayMenu()
        {
            Console.WriteLine("=======Geometric Shape Calculations=======");
            Console.WriteLine("Options:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Circle Calculation");
            Console.WriteLine("2. Rectangle Calculation");
            Console.WriteLine("3. Triangle Calculation");
            Console.WriteLine($"Please enter any one choice: {validChoices.Min()} to {validChoices.Max()}");
        }
    }
}