using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using interfacesLab02;

namespace Interfaces;

class Program
{

    static void Main(string[] args)
    {
        Krok4();
        //Krok3();
        //Krok2();
        //Krok1();
    }

    static void Krok3()
    {
        List<Pracownik> Pracownicy = new List<Pracownik>();

        Pracownicy.Add(new Pracownik("Abacki", new DateTime(2017, 12, 11), 160));
        Pracownicy.Add(new Pracownik("Abacki", new DateTime(2010, 1, 23), 250));
        Pracownicy.Add(new Pracownik("Molenda", new DateTime(2015, 3, 10), 200));
        Pracownicy.Add(new Pracownik("Kowalski", new DateTime(2011, 8, 9), 200));
        Pracownicy.Add(new Pracownik("Nowicki", new DateTime(2011, 8, 9), 180));

        foreach (Pracownik p in Pracownicy)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("Zewnętrzny porządek z użyciem IComparer");

        Pracownicy.Sort(new WgCzasuZatrudnieniaPotemWgWynagrodzeniaComparer());
        foreach (Pracownik p in Pracownicy)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("Zewnętrzny porządek z delegatą typu Comparison");

        Pracownicy.Sort((p1, p2) => (p1.CzasZatrudnienia.ToString("D3") + p1.Nazwisko +
        p1.Wynagrodzenie.ToString("00000.00")).CompareTo(p2.CzasZatrudnienia.ToString("D3")+
        p2.Nazwisko + p2.Wynagrodzenie.ToString("00000.00")));

        foreach (Pracownik p in Pracownicy)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("Metoda Comparsion malejąco według wynagrodzenia, później rosnąco według czasu zatrudnienia");

        Pracownicy.Sort((p1, p2) => (p1.Wynagrodzenie != p2.Wynagrodzenie) ?
        (-1) * (p1.Wynagrodzenie.CompareTo(p2.Wynagrodzenie)) : p1.CzasZatrudnienia.CompareTo(p2.CzasZatrudnienia));

        foreach (Pracownik p in Pracownicy)
        {
            Console.WriteLine(p);
        }

        
    }
    static void Krok4()
    {
        List<Pracownik> Pracownicy = new List<Pracownik>();

        Pracownicy.Add(new Pracownik("Abacki", new DateTime(2017, 12, 11), 160));
        Pracownicy.Add(new Pracownik("Abacki", new DateTime(2010, 1, 23), 250));
        Pracownicy.Add(new Pracownik("Molenda", new DateTime(2015, 3, 10), 200));
        Pracownicy.Add(new Pracownik("Kowalski", new DateTime(2011, 8, 9), 200));
        Pracownicy.Add(new Pracownik("Nowicki", new DateTime(2011, 8, 9), 180));

        foreach (Pracownik p in Pracownicy)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("Metoda rozszerzona LINQ");

        var query = Pracownicy.OrderBy(p => p.Wynagrodzenie).ThenByDescending(p => p.Nazwisko);

        foreach (Pracownik p in query)
        {
            Console.WriteLine(p);
        }
    }







static void Krok2()
    {
        List<Pracownik> Pracownicy = new List<Pracownik>();

        Pracownicy.Add(new Pracownik("Abacki", new DateTime(2017, 12, 11), 160));
        Pracownicy.Add(new Pracownik("Abacki", new DateTime(2010, 1, 23), 250));
        Pracownicy.Add(new Pracownik("Molenda", new DateTime(2015, 3, 10), 200));
        Pracownicy.Add(new Pracownik("Kowalski", new DateTime(2011, 8, 9), 200));
        Pracownicy.Add(new Pracownik("Nowicki", new DateTime(2011, 8, 9), 180));

        foreach (Pracownik p in Pracownicy)
        {
           // Console.WriteLine($"{p.Nazwisko} {p.DataZatrudnienia: d MMM yyyy} {p.Wynagrodzenie}");
            Console.WriteLine(p);
        }

        Pracownicy.Sort();
        Console.WriteLine("Po sortowaniu");
        foreach (Pracownik p in Pracownicy)
        {
            Console.WriteLine(p);
        }

        Console.ReadKey();
    }

    static void Krok1()
    {
        Console.WriteLine("--- Sprawdzenie poprawności tworzenia obiektu ---");
        Pracownik p = new Pracownik("Kowalski", new DateTime(2010, 10, 1), 1_000);
        Console.WriteLine(p);

        Console.WriteLine("--- Sprawdzenie równości obiektów ---");
        Pracownik p1 = new Pracownik("Nowak", new DateTime(2010, 10, 1), 1_000);
        Pracownik p2 = new Pracownik("Nowak", new DateTime(2010, 10, 1), 1_000);
        Pracownik p3 = new Pracownik("Kowalski", new DateTime(2010, 10, 1), 1_000);
        Pracownik p4 = p1;
        Console.WriteLine($"p1: {p1} hashCode: {p1.GetHashCode()}");
        Console.WriteLine($"p2: {p2} hashCode: {p2.GetHashCode()}");
        Console.WriteLine($"p3: {p3} hashCode: {p3.GetHashCode()}");
        Console.WriteLine($"p4: {p4} hashCode: {p4.GetHashCode()}");
        Console.WriteLine();

        Console.WriteLine($"--- Równość dla p1 oraz p2 -");
        Console.WriteLine($"Object.ReferenceEquals(p1, p2): {Object.ReferenceEquals(p1, p2)}");
        Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
        Console.WriteLine($"p1 == p2: {p1 == p2}");
        Console.WriteLine();

        Console.WriteLine($"--- Równość dla p1 oraz p3 -");
        Console.WriteLine($"Object.ReferenceEquals(p1, p3): {Object.ReferenceEquals(p1, p3)}");
        Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
        Console.WriteLine($"p1 == p3: {p1 == p3}");
        Console.WriteLine();

        Console.WriteLine($"--- Równość dla p1 oraz p4 -");
        Console.WriteLine($"Object.ReferenceEquals(p1, p4): {Object.ReferenceEquals(p1, p4)}");
        Console.WriteLine($"p1.Equals(p3): {p1.Equals(p4)}");
        Console.WriteLine($"p1 == p4: {p1 == p4}");
    }
}