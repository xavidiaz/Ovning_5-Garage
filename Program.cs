namespace Ovning_5_Garage;

interface IGarage<T>
    where T : IVehicle
{
    string Name { get; }
    uint Capacity { get; }
    IEnumerable<T> Vehicles { get; }
    uint Count { get; }

    bool IsFull { get; }

    void ParkVehicle(T vehicle);
    void UnparkVehicle(T vehicle);
    bool IsParked(T vehicle);
}

class Garage<T>
    where T : IVehicle
{
    string Name { get; }
    uint Capacity { get; }

    T[] Vehicles { get; set; }

    uint Count { get; set; }
    bool IsFull => Count >= Capacity;

    public Garage(string name, uint capacity)
    {
        Name = name;
        Capacity = capacity;
        Vehicles = new T[Capacity];
    }

    public override string ToString()
    {
        return $"Garage: {Name}, capacity: {Capacity}";
    }

    public void ParkVehicle(T vehicle)
    {
        // Kolla om garaget är fullt
        if (IsFull)
        {
            Console.WriteLine("Parking it full!");
            return;
        }
        else
        {
            // Hitta en ledig plats i arrayen
            // Lägg in fordonet
            for (int i = 0; i < Capacity; i++)
            {
                if (Vehicles[i] == null)
                {
                    Vehicles[i] = vehicle;
                    Count++;
                    Console.WriteLine(
                        $"{vehicle.Brand} is parked. Avaliable free parking spaces: {Capacity - Count}."
                    );
                    return;
                }
            }
            throw new InvalidOperationException("Garaget är fullt, kan inte parkera fler fordon.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Garage<Vehicle> garage = new("P-Central", 3);

        Car volvo = new("Volvo", 4211);
        Motorcicle yamaha = new("Yamaha", 2435);

        garage.ParkVehicle(volvo);
        garage.ParkVehicle(yamaha);

        Console.WriteLine(garage);
    }
}
