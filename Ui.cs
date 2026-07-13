namespace Ovning_5_Garage;

public static class Ui
{
    static Dictionary<string, string> menuOptions = new()
    {
        ["1"] = "Parkera",
        ["2"] = "Parkera av",
        ["3"] = "Parkerade fordon",
        ["4"] = "Parkerade fordon typer",
        ["5"] = "Seed Data",
        ["A"] = "Avsluta",
    };

    public static void List()
    {
        foreach (var option in menuOptions)
        {
            Console.WriteLine(option);
        }
    }

    public static void View()
    {
        GarageHandler _handler = new GarageHandler("P-central", 32);
        Console.Clear();

        while (true)
        {
            List();
            Console.Write("Mata int din val:");
            string option = Console.ReadLine() ?? "";

            switch (option.ToUpper())
            {
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig val, försök igen!");
                    Console.ResetColor();
                    break;
                case "A":

                    Console.WriteLine("Hej då");
                    return;
                case "1":
                    Console.Clear();
                    Vehicle? vehicle = CreateVehicle();
                    if (vehicle is null)
                    {
                        Console.WriteLine("Avbrutet — kunde inte skapa fordon.");
                        break;
                    }
                    bool parked = _handler.ParkVehicle(vehicle);
                    Console.WriteLine(
                        parked ? "Fordonet parkerat!" : "Kunde inte parkera (fullt?)."
                    );
                    break;
                case "5":
                    Console.Clear();
                    _handler.Seed();
                    Console.WriteLine("Seed data adderade!");
                    break;
            }
        }
    }

    static Vehicle? CreateVehicle()
    {
        // Gemensamma fält
        string regNr = Helpers.Response<string>(
            "Ange registrerings nummer:",
            Helpers.StringTryParse
        );
        string color = Helpers.Response<string>("Ange färg:", Helpers.StringTryParse);
        uint wheels = Helpers.Response<uint>("Ange antal hjul:", uint.TryParse);
        string brand = Helpers.Response<string>("Ange märke:", Helpers.StringTryParse);

        // Visa fordonstyper
        int number = 1;
        foreach (var v in Enum.GetValues<VehicleType>())
        {
            Console.Write($"({number++}) {v}, ");
        }
        Console.WriteLine();

        string vehicleType = Helpers.Response<string>("Välj fordonstyp:", Helpers.StringTryParse);

        // Skapa rätt subklass — typspecifik input inuti varje case
        switch (vehicleType)
        {
            case "1":
                uint numberOfDoors = Helpers.Response<uint>("Ange antal dörrar:", uint.TryParse);
                return new Car(regNr, color, wheels, brand, numberOfDoors);

            case "2":
                uint handlebarWidth = Helpers.Response<uint>(
                    "Ange styrbredd (cm): ",
                    uint.TryParse
                );
                return new Motorcycle(regNr, color, wheels, brand, handlebarWidth);

            case "3":
                Console.WriteLine("Bus — not implemented");
                return null;

            case "4":
                Console.WriteLine("Boat — not implemented");
                return null;

            case "5":
                Console.WriteLine("Airplane — not implemented");
                return null;

            default:
                Console.WriteLine("Ogiltig fordonstyp!");
                return null;
        }
    }
}
