namespace Ovning_5_Garage;

public class Program
{
    public static void Main(string[] args)
    {
        Car volvo = new("volvo", "TWE 4353", 5);
        Console.WriteLine(volvo);
        Motorcycle yamaha = new("yamaha", "RDW 2443", 85);
        Console.WriteLine(yamaha);
    }
}
