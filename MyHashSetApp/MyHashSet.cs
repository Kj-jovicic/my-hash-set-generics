namespace MyHashSetApp;

/// <summary>
/// A deliberately simple hash set: one array, one item per slot.
/// Collisions are resolved with linear probing (try the next slot).
/// Empty slots are null. Starts with 8 slots, doubles when full, up to 32. No Remove.
/// </summary>
public class MyHashSet
{
    private const int StartCapacity = 8;
    private const int MaxCapacity = 32;

    private Lehrperson[] _slots = new Lehrperson[StartCapacity];

    public int Count { get; private set; }
    public int Capacity => _slots.Length;

    /// <summary>Adds the item. Returns false if it was already in the set.</summary>
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

    // TODO: IEnumerable<Lehrperson> implementieren, damit man mit foreach über das Set iterieren kann.
    // Von hinten nach vorne iterieren (letzter Index zuerst), leere Slots (null) überspringen.
    // Dazu einen eigenen Enumerator (z.B. MyHashSetEnumerator) schreiben.

    /// <summary>Shows every slot, index 0 first, e.g. "[3] Huber Anna, Informatik, 12.03.1980".</summary>
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

    /// <summary>
    /// Returns the slot where the item lives, or the first empty slot
    /// where it would be inserted. Returns -1 if the array is full
    /// and does not contain the item.
    /// </summary>
    private int FindIndex(Lehrperson item)
    {
        // GetHashCode can be negative, but an array index cannot.
        int start = Math.Abs(item.GetHashCode()) % _slots.Length;

        for (int step = 0; step < _slots.Length; step++)
        {
            int index = (start + step) % _slots.Length; // wrap around at the end

            if (_slots[index] == null || item.Equals(_slots[index]))
                return index;
        }

        return -1;
    }

    /// <summary>Doubles the array. Every item gets a new slot, because hash % length changes.</summary>
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
