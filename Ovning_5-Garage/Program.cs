//
namespace Ovning_5_Garage;

public class Program
{
    public static void Main(string[] args)
    {
        Garage<Vehicle> park = new("Park", 50);
        park.Seed();

        ConsoleUI ui = new();
        ui.Run();
    }
}
