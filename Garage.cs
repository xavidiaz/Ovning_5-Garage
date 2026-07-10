namespace Garage;

public class Garage<T>
    where T : Vehicle
{
    T[] _slots;
    uint Capacity { get; }
    int Count => _slots.Length;
    bool IsFull => Capacity == Count;

    public Garage(uint capacity)
    {
        Capacity = capacity;
        _slots = new T[Capacity];
    }
}
