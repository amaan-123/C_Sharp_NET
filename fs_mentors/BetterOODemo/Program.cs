namespace BetterOODemo
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.WriteLine("BetterOODemo ");
            Console.WriteLine(new string('-', 64)); ;

            List<IRental> rentals = new List<IRental>();
            rentals.Add(new Truck() { CurrentRenter = "Truck Renter" });
            rentals.Add(new Car() { CurrentRenter = "Car Renter" });
            rentals.Add(new Sailboat() { CurrentRenter = "Sailboat Renter" });

            foreach (var r in rentals)
            {
                ////notice we can't access NumberOfPassengers because it's not an IRental property
                //Console.WriteLine($"Current renter: {r.CurrentRenter}\r\nPricePerDay: {r.PricePerDay}\r\nRentalId: {r.RentalId}");

                //but we can do:
                if (r is Truck t)
                {
                    t.NumberOfPassengers++;
                    t.Style = TruckType.LongBed;
                    Console.WriteLine($"Current renter: {r.CurrentRenter}" +
                        $"\r\nPricePerDay: {r.PricePerDay}" +
                        $"\r\nRentalId: {r.RentalId}" +
                        $"\r\nNumberOfPassengers: {t.NumberOfPassengers}" +
                        $"\r\nTruckType: {t.Style}"
                        );

                }
                if (r is Sailboat s)
                {
                    //sailboat specific...
                }
            }

        }
    }
}
