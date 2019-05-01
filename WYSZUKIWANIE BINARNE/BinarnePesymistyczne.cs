using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace BINARNE_PESYMISTYCZNE

{
    class Program
    {
        private static ulong Licznik;
        private static ulong dlugoscTab;
        private static ulong wynik;
        static int Binarne(int[] tabBin, int szukana)
        {
            int prawa = tabBin.Length - 1;
            int lewa = 0;
            int srodek;

            while (lewa <= prawa)
            {
                srodek = (lewa + prawa) / 2;
                if (tabBin[srodek] == szukana)
                {
                    return srodek;
                }
                else if (tabBin[srodek] < szukana)
                {
                    lewa = srodek + 1;
                }
                else
                {
                    prawa = srodek - 1;
                }
            }
            return -1;
        }
        static int Instrumentacja(int[] tabBin, int szukana)
        {
            int prawa = tabBin.Length - 1;
            int lewa = 0;
            int srodek;
            Licznik = 0;
            dlugoscTab = 0;
            wynik = 0;
            while (lewa <= prawa)
            {
                ++Licznik;

                srodek = (lewa + prawa) / 2;
                wynik += (ulong)Licznik * (ulong)Math.Pow(2, Licznik - 1);
                dlugoscTab += (ulong)Math.Pow(2, Licznik - 1);
                if (tabBin[srodek] == szukana)
                {
                    ++Licznik;
                    wynik += (ulong)Licznik * (ulong)Math.Pow(2, Licznik - 1);
                    dlugoscTab += (ulong)Math.Pow(2, Licznik - 1);
                    wynik = wynik / dlugoscTab;
                    return srodek;
                }
                else if (tabBin[srodek] < szukana)
                {
                    lewa = srodek + 1;
                    ++Licznik;
                    wynik += (ulong)Licznik * (ulong)Math.Pow(2, Licznik - 1);
                    dlugoscTab += (ulong)Math.Pow(2, Licznik - 1);
                }
                else
                {
                    prawa = srodek - 1;
                    ++Licznik;
                    wynik += (ulong)Licznik * (ulong)Math.Pow(2, Licznik - 1);
                    dlugoscTab += (ulong)Math.Pow(2, Licznik - 1);

                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("----------Pesymistyczne--------");
            Console.WriteLine("ELEMENT ||POZYCJA||OPERACJE|| CZAS || ROZMIAR");
            Console.WriteLine("----------------------------------------------");
            for (int k = 5368709; k < 268435456; k += 5368709)
            {

                int wyszukiwanaSrednia;
                int Nrindeksu;

                int[] dane = new int[k];
                for (int i = 0; i < dane.Length; i++)
                {
                    dane[i] = i + 1;
                }
                Array.Sort(dane);
                wyszukiwanaSrednia = k + 1;
                Nrindeksu = -1;
                long StartingTime = Stopwatch.GetTimestamp();
                Binarne(dane, wyszukiwanaSrednia);
                long EndingTime = Stopwatch.GetTimestamp();
                long ElapsedTime = EndingTime - StartingTime;
                double ElapsedSeconds = ElapsedTime * (1.0 / Stopwatch.Frequency);
                Console.WriteLine(wyszukiwanaSrednia + " || " + Instrumentacja(dane, wyszukiwanaSrednia) + " || " + Licznik + " || " + ElapsedSeconds.ToString("F8") + " || " + dane.Length);
            }
            Console.ReadKey();
        }
    }
}