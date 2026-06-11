namespace Ovning_5_Garage;

class Program
{
    static void Main(string[] args)
    {
        Garage<Vehicle> garage = new("P-Central", 4);
        garage.Seed();

        foreach (IGrouping<string, Vehicle> VehicleType in garage.VehicleTypes)
        {
            Console.WriteLine($"{VehicleType.Key}: {VehicleType.Count()}");
        }

        garage.UnparkVehicle(1001u);

        GarageHandler.Hello();
    }
}
