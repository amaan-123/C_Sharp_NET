namespace M3_OOPS_Interface
{
    class Animal : IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("Animal eats!");
        }
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound!");
        }
    }
    class Dog : Animal
    {
        public void Eat()
        {
            Console.WriteLine("Dog eats!");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks!");
        }
    }
    class Cat : Animal
    {
        public void Eat()
        {
            Console.WriteLine("Cat eats!");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Cat meows!");
        }
    }


}