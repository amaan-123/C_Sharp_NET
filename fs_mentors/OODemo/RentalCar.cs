namespace OODemo
{
    public class RentalCar : RentalVehicle
    {
        public CarType Style { get; set; }
        public int Weight { get; set; } // range in thousand kilograms
    }

    //public class MatchboxCar
    //{
    //    public int Weight { get; set; } // range in grams
    //    // so even if Property name & type same, doesn't mean they are the same
    //}

}
