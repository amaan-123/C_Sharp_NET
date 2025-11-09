namespace M3_OOPS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Dog dog = new Dog();
            //Cat cat = new Cat();
            //dog.MakeSound();
            //cat.MakeSound();

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