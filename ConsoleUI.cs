namespace Ovning_5_Garage;

// Constructor: ta emot handler
public class ConsoleUI
{
    private Handler _handler;

    // Run() — huvudloop
    public void Run()
    {
        bool running = true;
        while (running)
        {
            Thread.Sleep(1000);
            Console.Clear();
            ShowMenu();
            Console.Write("Välj ett alternativ: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGarage();
                    break;
                case "2":
                    ParkVehicle();
                    break;
                case "3":
                    UnparkVehicle();
                    break;
                case "4":
                    FindVehicle();
                    break;
                case "5":
                    ListVehicles();
                    break;
                case "6":
                    ListVehicleTypes();
                    break;
                case "7":
                    SearchVehicles();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen");
                    break;
            }
        }
    }

    public void ShowMenu()
    {
        Console.WriteLine("\n--- GARAGE MENY ---");
        Console.WriteLine("1. Skapa Garage");
        Console.WriteLine("2. Parkera Fordon");
        Console.WriteLine("3. Hämta ut Fordon");
        Console.WriteLine("4. Hitta Fordon");
        Console.WriteLine("5. Lista alla Fordon");
        Console.WriteLine("6. Lista Fordonstyper");
        Console.WriteLine("7. Sök Fordon");
        Console.WriteLine("0. Avsluta");
    }

    public void CreateGarage()
    {
        Console.WriteLine("CreateGarage method");
        string name = ReadInput<string>("Ange namn: ");
        uint capacity = ReadInput<uint>("Ange kapacitet: ");
        _handler.CreateGarage(name, capacity);
        Console.WriteLine("Garage skapat!");
    }

    public void ParkVehicle()
    {
        Console.WriteLine("ParkVehicle method");
        string vehicleType = ReadInput<string>("Ange fordontyp: ");
        // Fråga gemensamma: brand, id, color, wheels

        string brand = ReadInput<string>("Ange brand: ");
        string id = ReadInput<string>("Ange registreringsnummer: ");
        string color = ReadInput<string>("Ange färg: ");
        Vehicle vehicle = vehicleType.ToLower() switch
        {
            "car" => new Car(
                brand,
                id,
                color,
                ReadInput<uint>("Antal hjul: "),
                ReadInput<uint>("Antal dörrar: ")
            ),
            "motorcycle" => new Motorcycle(
                brand,
                id,
                color,
                ReadInput<uint>("Antal hjul: "),
                ReadInput<uint>("Styrbredd: ")
            ),
            _ => throw new ArgumentException("Okänd fordonstyp"),
        };
        _handler.ParkVehicle(vehicle);
    }

    public void UnparkVehicle()
    {
        string id = ReadInput<string>("Ange registreringsnummer: ");
        _handler.UnparkVehicle(id);
        Console.WriteLine($"Fordon {id} hämtat.");
    }

    public void FindVehicle()
    {
        string id = ReadInput<string>("Ange registreringsnummer: ");
        var (found, index) = _handler.FindVehicle(id);
        if (found)
            Console.WriteLine($"Fordon hittat på plats {index}.");
        else
            Console.WriteLine("Fordon ej hittat.");
    }

    public void ListVehicles()
    {
        foreach (var vehicle in _handler.ListVehicles())
        {
            Console.WriteLine(vehicle);
        }
    }

    public void ListVehicleTypes()
    {
        foreach (var group in _handler.ListVehicleTypes())
        {
            Console.WriteLine($"{group.Key}: {group.Count()}");
        }
    }

    public void SearchVehicles()
    {
        Console.WriteLine("Sök på: 1. Färg  2. Antal hjul  3. Båda");
        string choice = ReadInput<string>("Val: ");

        Func<Vehicle, bool> filter = choice switch
        {
            "1" => v =>
                v.Color.Equals(
                    ReadInput<string>("Ange färg: "),
                    StringComparison.OrdinalIgnoreCase
                ),
            "2" => v => v.NumerOfWheels == ReadInput<uint>("Ange antal hjul: "),
            "3" => BuildCombinedFilter(),
            _ => v => true,
        };

        foreach (var vehicle in _handler.SearchVehicles(filter))
        {
            Console.WriteLine(vehicle);
        }
    }

    private Func<Vehicle, bool> BuildCombinedFilter()
    {
        string color = ReadInput<string>("Ange färg: ");
        uint wheels = ReadInput<uint>("Ange antal hjul: ");
        return v =>
            v.Color.Equals(color, StringComparison.OrdinalIgnoreCase) && v.NumerOfWheels == wheels;
    }

    // --- Hjälpmetoder ---
    T ReadInput<T>(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? answer = Console.ReadLine();
            try
            {
                return (T)Convert.ChangeType(answer, typeof(T));
            }
            catch
            {
                Console.WriteLine("Ogiltig inmatning, försök igen.");
            }
        }
    }
}
