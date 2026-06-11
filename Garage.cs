namespace Ovning_5_Garage;

class Garage<T>
    where T : class, IVehicle
{
    string Name { get; }
    uint Capacity { get; }

    T?[] Vehicles { get; set; }
    public IEnumerable<T?> VehiclesList => Vehicles.Where(v => v != null);
    public IEnumerable<IGrouping<string, T?>> VehicleTypes =>
        Vehicles.Where(v => v != null).GroupBy(v => v!.GetType().Name);

    uint Count { get; set; }
    bool IsFull => Count >= Capacity;
    bool IsEmpty => Count == 0;

    public Garage(string name, uint capacity)
    {
        Name = name;
        Capacity = capacity;
        Vehicles = new T?[Capacity];
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
                    // Console.WriteLine(
                    //     $"{vehicle.Brand} is parked. Avaliable free parking spaces: {Capacity - Count}."
                    // );
                    return;
                }
            }
            throw new InvalidOperationException("Garaget är fullt, kan inte parkera fler fordon.");
        }
    }

    public void UnparkVehicle(uint id)
    {
        var (v, index) = FindVehicle(id);
        if (v == null)
        {
            Console.WriteLine("Vehicle finns inte i Garaget!");
            return;
        }
        if (v != null)
        {
            Vehicles[index] = null;
            Count--;
            Console.WriteLine($"{v.Brand} is unparked.");
        }
    }

    public (T?, int) FindVehicle(uint id)
    {
        int index = -1;
        if (IsEmpty) // parkering tom
        {
            Console.WriteLine("Parking is empty");
            return (null, -1);
        }

        for (int i = 0; i < Capacity; i++)
        {
            index++;
            if (Vehicles[i] != null && Vehicles[i]!.Id == id)
            {
                return (Vehicles[i], index);
            }
        }

        return (null, -1); // fordon hittades inte
    }

    public void Seed()
    {
        ParkVehicle((T)(IVehicle)new Car("Volvo", 1001));
        ParkVehicle((T)(IVehicle)new Car("Toyota", 1002));
        ParkVehicle((T)(IVehicle)new Motorcicle("Yamaha", 2001));
        ParkVehicle((T)(IVehicle)new Motorcicle("Honda", 2002));
    }
}
