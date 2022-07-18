namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuel, double consumption, double tankCapacity) : base(fuel, consumption, tankCapacity)
        {
            this.FuelConsumptionPerKm += 1.6;
        }
        public override void Refuel(double fuelLitres)
        {
            base.Refuel(fuelLitres * 0.95);
        }
    }
}
