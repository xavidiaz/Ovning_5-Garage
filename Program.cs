namespace Ovning_5_Garage;

public class Program()
{
    public static void Main()
    {
        GarageHandler _handler = new GarageHandler("P-central", 32);

        _handler.Seed();

        foreach (var item in _handler.ListVehicleTypes())
        {
            Console.WriteLine($"{item.Key}: {item.Count()}");
        }
    }
}
