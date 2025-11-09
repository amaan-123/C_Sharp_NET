namespace M3_OOPS
{
    class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound!");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks!");
        }
    }
    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Cat meows!");
        }
    }
}