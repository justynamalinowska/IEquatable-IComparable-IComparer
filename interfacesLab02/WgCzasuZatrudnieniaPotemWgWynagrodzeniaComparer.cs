using System;
using Interfaces;
using System.Collections.Generic;

namespace interfacesLab02
{
	public class WgCzasuZatrudnieniaPotemWgWynagrodzeniaComparer: IComparer<Pracownik>
	{
        public WgCzasuZatrudnieniaPotemWgWynagrodzeniaComparer()
        {

        }

        public int Compare(Pracownik x, Pracownik y)
        {
            if (x is null && y is null) return 0;
            if (x is null && !(y is null)) return -1;
            if (!(x is null) && y is null) return +1;

            if (x.CzasZatrudnienia != y.CzasZatrudnienia)
            {
                return (x.CzasZatrudnienia).CompareTo(y.CzasZatrudnienia);
            }

            //if (x.Nazwisko != y.Nazwisko)
            //{
            //    return x.Nazwisko.CompareTo(y.Nazwisko);
            //}

            return x.Wynagrodzenie.CompareTo(y.Wynagrodzenie);
        }
    }
}

