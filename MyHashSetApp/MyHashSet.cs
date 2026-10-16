namespace MyHashSetApp;


public class MyHashSet<T>
{
    private const int StartCapacity = 8;
    private const int MaxCapacity = 32;

    private T[] _slots = new T[StartCapacity];

    public int Count { get; private set; }
    public int Capacity => _slots.Length;

  
    public bool Add(T item)
    {
        int index = FindIndex(item);

        if (index == -1)
        {
            if (_slots.Length == MaxCapacity)
                throw new InvalidOperationException("The set is full.");

            Grow();
            index = FindIndex(item);
        }

        if (_slots[index] != null)
            return false; 

        _slots[index] = item;
        Count++;
        return true;
    }

    public bool Contains(T item)
    {
        int index = FindIndex(item);
        return index != -1 && _slots[index] != null;
    }

    
    public override string ToString()
    {
        string result = "";

        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i] == null)
                result += $"[{i}] null\n";
            else
                result += $"[{i}] {_slots[i]}\n";
        }

        return result;
    }

    
    private int FindIndex(T item)
    {
       
        int start = Math.Abs(item.GetHashCode()) % _slots.Length;

        for (int step = 0; step < _slots.Length; step++)
        {
            int index = (start + step) % _slots.Length; // wrap around at the end

            if (_slots[index] == null || item.Equals(_slots[index]))
                return index;
        }

        return -1;
    }

    
    private void Grow()
    {
        T[] oldSlots = _slots;
        _slots = new T[oldSlots.Length * 2];

        foreach (T item in oldSlots)
        {
            if (item != null)
                _slots[FindIndex(item)] = item;
        }
    }
}
