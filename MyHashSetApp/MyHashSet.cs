namespace MyHashSetApp;


public class MyHashSet 
{
    private const int StartCapacity = 8;
    private const int MaxCapacity = 32;

    private Lehrperson[] _slots = new Lehrperson[StartCapacity];

    public int Count { get; private set; }
    public int Capacity => _slots.Length;

   
    public bool Add(Lehrperson item)
    {
        int index = FindIndex(item);

        if (index == -1) // array is full and the item is not in it
        {
            if (_slots.Length == MaxCapacity)
                throw new InvalidOperationException("The set is full.");

            Grow();
            index = FindIndex(item);
        }

        if (_slots[index] != null)
            return false; // duplicate

        _slots[index] = item;
        Count++;
        return true;
    }

    public bool Contains(Lehrperson item)
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

    
    private int FindIndex(Lehrperson item)
    {
        
        int start = Math.Abs(item.GetHashCode()) % _slots.Length;

        for (int step = 0; step < _slots.Length; step++)
        {
            int index = (start + step) % _slots.Length; 

            if (_slots[index] == null || item.Equals(_slots[index]))
                return index;
        }

        return -1;
    }

  
    private void Grow()
    {
        Lehrperson[] oldSlots = _slots;
        _slots = new Lehrperson[oldSlots.Length * 2];

        foreach (Lehrperson item in oldSlots)
        {
            if (item != null)
                _slots[FindIndex(item)] = item;
        }
    }
}
