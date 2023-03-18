using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Pracownik: IEquatable<Pracownik>, IComparable<Pracownik>
    {
        private string nazwisko;
        public string Nazwisko
        {
            get => nazwisko; 
            set => nazwisko = (value != null)? value.Trim(): throw new Exception("not null!");
        }

        private DateTime dataZatrudnienia;
        public DateTime DataZatrudnienia
        {
            get => dataZatrudnienia; 
            set => dataZatrudnienia = (dataZatrudnienia > DateTime.Today)? throw new ArgumentException(): value;
        }

        private decimal wynagrodzenie;
        public decimal Wynagrodzenie
        {
                get => wynagrodzenie;
                set => wynagrodzenie = (value < 0) ? 0 : value;
                // {
                //     if (value < 0) _wyn = 0;
                //     else _wyn = value;
                // 
        }

        public Pracownik()
        {
            Nazwisko = "Anonim";
            Wynagrodzenie = 0;
        }

        public Pracownik(string nazwisko, DateTime dataZatrudnienia, decimal wynagrodzenie)
        {
            Nazwisko = nazwisko;
            DataZatrudnienia = dataZatrudnienia;
            Wynagrodzenie = wynagrodzenie;
        }

        public int CzasZatrudnienia => (DateTime.Now - DataZatrudnienia).Days / 30;

        public override string ToString() => $"({Nazwisko}, {DataZatrudnienia: d MMM yyyy} ({CzasZatrudnienia}), {Wynagrodzenie} PLN)";

        public bool Equals(Pracownik other)
        {
            if (other is null) return false;
            if (Object.ReferenceEquals(this, other)) 
                return true;

            return (Nazwisko == other.Nazwisko &&
                    DataZatrudnienia == other.DataZatrudnienia &&
                    Wynagrodzenie == other.Wynagrodzenie);
        }

        public override bool Equals(object obj)
        {
            if (obj is Pracownik)
                return Equals((Pracownik)obj);
            else
                return false;
        }



        //public bool Equals(Pracownik other)
        //{
        //    if (other == null)
        //    {
        //        return false;
        //    }

        //    if (Nazwisko != other.Nazwisko)
        //    {
        //        return false;
        //    }

        //    if (DataZatrudnienia != other.DataZatrudnienia)
        //    {
        //        return false;
        //    }

        //    if (Wynagrodzenie != other.Wynagrodzenie)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        public override int GetHashCode() => (Nazwisko, DataZatrudnienia, Wynagrodzenie).GetHashCode();

        public static bool Equals(Pracownik p1, Pracownik p2)
        {
            if ((p1 is null) && (p2 is null)) return false;
            if (p1 is null) return false;

            return p1.Equals(p2);
        }

        public static bool operator ==(Pracownik p1, Pracownik p2) => Equals(p1, p2);
        public static bool operator !=(Pracownik p1, Pracownik p2) => !(p1 == p2);

        public int CompareTo(Pracownik other)
        {
            if (other is null) return 1; 
            if (this.Equals(other)) return 0; 

            if (this.Nazwisko != other.Nazwisko)
                return this.Nazwisko.CompareTo(other.Nazwisko);

            if (!this.DataZatrudnienia.Equals(other.DataZatrudnienia)) 
                return this.DataZatrudnienia.CompareTo(other.DataZatrudnienia);

            return this.Wynagrodzenie.CompareTo(other.Wynagrodzenie);
        }







    }
}
