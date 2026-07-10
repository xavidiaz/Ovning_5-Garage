using System.Collections;

namespace Ovning_5_Garage;

public class Garage<T> : IEnumerable<T>
    where T : Vehicle
{
    T?[] _slots;
    uint Capacity { get; }
    public int Count { get; private set; }
    bool IsFull => Capacity == Count;

    public Garage(uint capacity)
    {
        Capacity = capacity;
        _slots = new T[Capacity];
    }

    public int FirstEmptySlot()
    {
        if (IsFull is false)
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (_slots[i] is null)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    public (bool, int) FindVehicle(string id)
    {
        for (int i = 0; i < Capacity; i++)
        {
            if (
                _slots[i] is T v
                && v.RegistrationNumber.Equals(id, StringComparison.OrdinalIgnoreCase)
            )
            {
                return (true, i);
            }
        }
        return (false, -1);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Capacity; i++)
        {
            if (_slots[i] is T v)
            {
                yield return v;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable<IGrouping<string, T>> GetVehicleTypes()
    {
        return this.GroupBy(v => v.GetType().Name);
    }

    public bool ParkVehicle(T vehicle)
    {
        if (IsFull)
        {
            return false;
        }
        // look after first empty space
        int index = FirstEmptySlot();

        if (index == -1)
            return false;

        _slots[index] = vehicle;
        Count++;
        return true;
    }

    public bool RemoveVehicle(string id)
    {
        var (v, index) = FindVehicle(id);
        if (v)
        {
            _slots[index] = default;
            Count--;
            return true;
        }
        return false;
    }
}
