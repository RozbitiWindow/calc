//NOTE this is not my code
using System;

namespace CalculatorApp
{
    /// <summary>
    /// T?�da InputReader odpov?dn� za ?ten� vstup? z konzole.
    /// </summary>
    internal class InputReader
    {
        /// <summary>
        /// Na?te platn� ?�slo typu double z konzole. Pokud vstup nen� platn� ?�slo, opakuje se v�zva.
        /// </summary>
        /// <returns>Platn� ?�slo typu double.</returns>
        public double ReadDouble()
        {
            double result;
            while (true)
            {
                string? input = Console.ReadLine();
                if (double.TryParse(input, out result))
                {
                    return result;
                }

                // toto je zat�m proti SRP (single resposibility principle) proto�e t?�da by m?la d?lat pouze vstup, ne v�stup
                // ale zat�m pro jednoduchost nech�v�m, ?asem m?�eme upravit
                Console.WriteLine("Invalid enterface!");
            }
        }

        /// <summary>
        /// Na?te ?et?zec z konzole. O�et?�, �e nebude v�stup nikdy null
        /// </summary>
        /// <returns>?et?zec na?ten� z konzole.</returns>
        public string ReadString()
        {
            string? s = Console.ReadLine();
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            return s;
        }

        public int ReadInt()
        {
            int result;
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    return result;
                }

                Console.WriteLine("Invalid enterface!");
            }
        }
    }
}