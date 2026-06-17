using System.Collections;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Ovning_5-Garage.Tests")]

namespace Ovning_5_Garage;

public class Garage<T> : IEnumerable<T>
    where T : IVehicle
{
    string Name { get; }
    uint Capacity { get; }
    private T?[] _list;
    public IEnumerable<T?> List
    {
        get => _list;
    }

    // T?[] List { get; }
    internal uint VehicleCount { get; set; }
    bool IsFull => VehicleCount >= Capacity;

    public Garage(string name, uint capacity)
    {
        Name = name;
        Capacity = capacity;
        VehicleCount = 0;
        _list = new T?[capacity];
    }

    private int FirstEmptySpace()
    {
        if (IsFull)
        {
            return -1;
        }

        for (int i = 0; i < Capacity; i++)
        {
            if (_list[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

    public void ParkVehicle(T vehicle)
    {
        if (IsFull)
        {
            Console.WriteLine("Paking är full!");
        }
        else
        {
            _list[FirstEmptySpace()] = vehicle;
            VehicleCount++;
        }
    }

    public (bool, int) FindVehicle(string id)
    {
        int index = -1;
        foreach (T? vehicle in List)
        {
            index++;
            if (
                vehicle != null
                && string.Equals(vehicle.Id, id, StringComparison.OrdinalIgnoreCase)
            )
            {
                return (true, index);
            }
        }
        return default;
    }

    public void UnparkVehicle(string id)
    {
        (bool isParked, int index) = FindVehicle(id);
        if (isParked)
        {
            _list[index] = default;
            VehicleCount--;
        }
    }

    public IEnumerable<T> SearchVehicles(Func<T, bool> filter) =>
        _list.Where(v => v != null).Select(v => v!).Where(filter);

    public IEnumerable<IGrouping<string, T?>> VehicleTypes =>
        _list.Where(v => v != null).GroupBy(v => v!.GetType().Name);

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T? vehicle in _list)
        {
            if (vehicle != null)
            {
                yield return vehicle;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Seed()
    {
        ParkVehicle((T)(IVehicle)new Car("Volvo", "ABC 123", "Red", 4, 5));
        ParkVehicle((T)(IVehicle)new Car("Toyota", "DEF 456", "Blue", 4, 4));
        ParkVehicle((T)(IVehicle)new Motorcycle("Yamaha", "GHI 789", "Black", 2, 85));
        ParkVehicle((T)(IVehicle)new Motorcycle("Honda", "JKL 012", "White", 2, 90));
    }
}
