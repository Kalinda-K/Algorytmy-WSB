using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINIOWE_PESYMISTYCZNE
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
                

                if (tabLin[i] == szukana)
                {
                    return i;
                }
            }
            return -1;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------Pesymistyczne------------------------------");
            Console.WriteLine("ELEMENT || POZYCJA || LICZBA OPERACJI|| CZAS || ROZMIAR || ZŁOŻONOŚĆ");
            Console.WriteLine("---------------------------------------------------------------------");
            for (int k = 5368709; k < 268435456; k += 5368709)
            {
                int Nrindeksu;
                int wyszukiwanaPesymistyczna;
                int[] dane = new int[k];
                for (int i = 0; i < dane.Length; i++)
                {
                    dane[i] = i + 1;
                }
                wyszukiwanaPesymistyczna = dane.Length + 1;
                Nrindeksu = -1;
                long StartingTime = Stopwatch.GetTimestamp();
                Liniowe(dane, wyszukiwanaPesymistyczna);
                long EndingTime = Stopwatch.GetTimestamp();
                long ElapsedTime = EndingTime - StartingTime;
                double ElapsedSeconds = ElapsedTime * (1.0 / Stopwatch.Frequency);

                Console.WriteLine(wyszukiwanaPesymistyczna + " || " + Instrumentacja(dane, wyszukiwanaPesymistyczna) + " || " + Licznik + " || " + ElapsedSeconds.ToString("F8") + " || " + dane.Length + " || " + Wynik);
            }
            Console.ReadKey();

        }
    }
}
