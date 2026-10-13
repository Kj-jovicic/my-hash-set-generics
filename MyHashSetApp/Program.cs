namespace MyHashSetApp;

class Program
{
    static void Main(string[] args)
    {
        MyHashSet set = new MyHashSet();

        // TODO 1) Datei-Einlesen: lehrpersonen.txt mit using und StreamReader einlesen.
        // Kopfzeile, Kommentarzeilen (#), falsche Zeilen und leere Zeilen überspringen.
        // Jede eingelesene Lehrperson mit Add in das Set einfügen (siehe Angabe: File I/O).
        // Vorerst 3 fixe Lehrpersonen zum Testen der Grundfunktionen:
        Lehrperson anna = new Lehrperson("Anna", "Huber", new DateTime(1980, 3, 12), Unterrichtsfach.Informatik, 18);
        Lehrperson anna2 = new Lehrperson("Anna", "Petrovic", new DateTime(1977, 5, 4), Unterrichtsfach.Informatik, 18);
        Lehrperson jose = new Lehrperson("José", "Rojas", new DateTime(1975, 11, 5), Unterrichtsfach.Mathematik, 20);
        Lehrperson shirin = new Lehrperson("Shirin", "Karimi", new DateTime(1990, 7, 23), Unterrichtsfach.Deutsch, 22);

        set.Add(anna);
        set.Add(anna2);
        set.Add(jose);
        set.Add(shirin);

        Console.WriteLine($"\nCount: {set.Count}, Capacity: {set.Capacity}");
        Console.WriteLine(set); // ToString: alle Slots, Index 0 zuerst

        // TODO 2) IEnumerable: mit foreach über das Set iterieren (von hinten nach vorne)

        // TODO 3) IEquatable: prüfen, ob eine neu erstellte Lehrperson mit gleichem Fach
        // und gleichen Wochenstunden (aber anderem Namen) mit Contains gefunden wird

        // TODO 4) IComparable und IComparer: Lehrpersonen aus dem Set in eine List<Lehrperson>
        // kopieren und mit Sort() (natürliche Ordnung), FachNachnameComparer und
        // DekadeFachNachnameComparer sortieren. Jedes Ergebnis ausgeben.

        // TODO 5) Szenario Projekttag: Queue (Anmeldung, mit Peek) und Stack (Aufräumdienst)

        // TODO Erweiterungen zum Üben: RandomIterator, AmountIterator, DoubleIterator,
        // JumpingIterator, ZigZagIterator
    }
}
