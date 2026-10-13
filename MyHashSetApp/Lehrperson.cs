namespace MyHashSetApp;

public class Lehrperson
{
    public string Vorname { get; }
    public string Nachname { get; }
    public DateTime Geburtsdatum { get; }
    public Unterrichtsfach Fach { get; }
    public int Wochenstunden { get; }

    public Lehrperson(string vorname, string nachname, DateTime geburtsdatum, Unterrichtsfach fach, int wochenstunden)
    {
        Vorname = vorname;
        Nachname = nachname;
        Geburtsdatum = geburtsdatum;
        Fach = fach;
        Wochenstunden = wochenstunden;
    }

    // TODO: Coolheitsfaktor (readonly Property, int) berechnen. Siehe Angabe für die Formel.

    // TODO: IEquatable<Lehrperson> implementieren (Equals + GetHashCode).
    // Zwei Lehrpersonen sind gleich, wenn Fach und Wochenstunden übereinstimmen.
    // GetHashCode darf nur Felder verwenden, die auch in Equals verglichen werden.

    // TODO: IComparable<Lehrperson> implementieren (CompareTo).
    // Natürliche Ordnung: aufsteigend nach Coolheitsfaktor.

    public override string ToString()
    {
        return $"{Nachname} {Vorname}, {Fach}, {Wochenstunden} Std., {Geburtsdatum:dd.MM.yyyy}";
    }
}
