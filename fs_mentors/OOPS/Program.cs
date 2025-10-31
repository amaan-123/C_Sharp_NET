// In MyApp.dll
internal class InternalClass
{
    internal void Show() => Console.WriteLine("Hello from internal class");
}

// In another class in same project:



// //Messages.Hello();
// //Messages.Waiting();

// Human human1 = new Human();

// human1.name = "Serenity";
// human1.age = 100;
// human1.Eat();
// human1.Sleep();

// // Instead of the above way, we can use constructors like the Car method in the Car class & then
// // Instantiate
// Car car2 = new Car("Ford", "Figo", 2012, "White");

// car2.Drive();

// class Human
// {
//     public string name;
//     public int age;

//     public void Eat()
//     {
//         Console.WriteLine(name + " is eating.");
//     }
//     public void Sleep()
//     {
//         Console.WriteLine(name + " is sleeping.");
//     }
// }
// class Car
// {
//     string make;
//     string model;
//     int year;
//     string color;

//     // A constructor is a special method found within a class. It has the same name as the class name.
//     // It allows for manually assigning values to fields of an object when it is created.
//     public Car(string make, string model, int year, string color)
//     {
//         this.make = make;
//         this.model = model;
//         this.year = year;
//         this.color = color;
//     }
//     public void Drive()
//     {
//         Console.WriteLine("You drive the " + make + " " + model);
//     }
// }