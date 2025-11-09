namespace M3_OOPS_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dog dog = new Dog();
            //Cat cat = new Cat();

            //dog.MakeSound();
            //cat.MakeSound();

            //dog.Eat();
            //cat.Eat();

            List<Animal> animals = new List<Animal>();
            animals.Add(new Dog());
            animals.Add(new Cat());

            foreach (Animal animal in animals)
            {
                animal.MakeSound();
            }
        }

    }



}