namespace _01.Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuel, double consumption, double tankCapacity) : base(fuel, consumption, tankCapacity)
        {
            this.FuelConsumptionPerKm += 0.9;
        }
    }
}
