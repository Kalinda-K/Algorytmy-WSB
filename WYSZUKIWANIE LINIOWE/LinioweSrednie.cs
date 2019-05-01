using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINIOWE_SREDNIE
{
    class Program
    {
        private static long Licznik;
        private static long Suma;
        private static long Wynik;

        static int Liniowe(int[] tabLin, int szukana)
        {

            for (int i = 0; i < tabLin.Length; i++)
            {


                if (tabLin[i] == szukana)
                {
                    return i;
                }
            }
            return -1;

        }
        static int Instrumentacja(int[] tabLin, int szukana)
        {
            Suma = 0;
            Licznik = 0;
            for (int i = 0; i < tabLin.Length; i++)
            {
                ++Licznik;
                Suma += tabLin[i];
                Wynik = Suma / Licznik;

                if (tabLin[i] == szukana)
                {
                    return i;
                }
            }
            return -1;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------Średnie-----------------------------------");
            Console.WriteLine("ELEMENT || POZYCJA || LICZBA OPERACJI|| CZAS || ROZMIAR || ZŁOŻONOŚĆ");
            Console.WriteLine("---------------------------------------------------------------------");
            for (int k = 5368709; k < 268435456; k += 5368709)
            {

                int wyszukiwanaSrednia;
                int[] dane = new int[k];
                for (int i = 0; i < dane.Length; i++)
                {
                    dane[i] = i + 1;
                }
                wyszukiwanaSrednia= dane.Length / 2;
                long StartingTime = Stopwatch.GetTimestamp();
                Liniowe(dane,wyszukiwanaSrednia);
                long EndingTime = Stopwatch.GetTimestamp();
                long ElapsedTime = EndingTime - StartingTime;
                double ElapsedSeconds = ElapsedTime * (1.0 / Stopwatch.Frequency);

                Console.WriteLine(wyszukiwanaSrednia + " || " + Instrumentacja(dane, wyszukiwanaSrednia) + " || " + Licznik + " || " + ElapsedSeconds.ToString("F8") + " || " + dane.Length + " || " + Wynik);
            }
            Console.ReadKey();
       

    }
}
