namespace Ovning_5_Garage;

public class Program()
{
    public static void Main()
    {
        Garage<Vehicle> parking = new(3);

        parking.ParkVehicle(new Car("123qwe", "#ffffff", 4, "Volvo", 5));
        parking.ParkVehicle(new Car("543qwe", "#ff0", 4, "Volvo", 5));
        parking.ParkVehicle(new Motorcycle("321ewq", "#123", 2, "Yamaha", 54));

        foreach (Vehicle v in parking)
        {
            Console.WriteLine(v);
        }

        foreach (var v in parking.GetVehicleTypes())
        {
            Console.WriteLine($"{v.Key}: {v.Count()}.");
        }

        Console.WriteLine(parking.FindVehicle("123qwe"));
        Console.WriteLine(parking.Count);
        parking.RemoveVehicle("123qwe");
        Console.WriteLine(parking.Count);

        Console.WriteLine(parking.ParkVehicle(new Motorcycle("321ewq", "#123", 2, "Yamaha", 54)));

        Console.WriteLine(parking.ParkVehicle(new Motorcycle("321ewq", "#123", 2, "Yamaha", 54)));
    }
}
