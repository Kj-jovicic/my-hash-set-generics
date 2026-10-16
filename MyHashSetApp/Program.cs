namespace MyHashSetApp;

class Program
{
    static void Main(string[] args)
    {
        MyHashSet<Lehrperson> set = new MyHashSet<Lehrperson>();

        
        Lehrperson anna = new Lehrperson("Anna", "Huber", new DateTime(1980, 3, 12), Unterrichtsfach.Informatik, 18);
        Lehrperson anna2 = new Lehrperson("Anna", "Petrovic", new DateTime(1977, 5, 4), Unterrichtsfach.Informatik, 18);
        Lehrperson jose = new Lehrperson("José", "Rojas", new DateTime(1975, 11, 5), Unterrichtsfach.Mathematik, 20);
        Lehrperson shirin = new Lehrperson("Shirin", "Karimi", new DateTime(1990, 7, 23), Unterrichtsfach.Deutsch, 22);

        set.Add(anna);
        set.Add(anna2);
        set.Add(jose);
        set.Add(shirin);

        Console.WriteLine($"\nCount: {set.Count}, Capacity: {set.Capacity}");
        Console.WriteLine(set); 

        
    }
}
