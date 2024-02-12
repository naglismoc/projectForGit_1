using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectForGit
{
    internal class ValidateInput
    {
        public static string StringLen(int min, int max)
        {
            string input = Console.ReadLine();
            while (input.Length < 3 || input.Length > 65025)
            {
                Console.WriteLine($"Įveskite tinako ilgio tekstą ({min} - {max})");
                input = Console.ReadLine();
            }
            return input;
        }
        public static bool Bool()
        {
            while (true)
            {
                try
                {
                    return Convert.ToBoolean(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Įveskite 'true' arba 'false'");
                }
            }
        }
        public static double Double()
        {
            while (true)
            {
                try
                {
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Įveskite teisingą skaičių");
                }
            }
        }
        public static int Int()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (isInt(input))
                {
                    return Convert.ToInt32(input);
                }
                else
                {
                    Console.WriteLine("Neteisingas skaičiaus formatas.");
                }
            }
        }

        public static bool isInt(string input)
        {
            try
            {
                Convert.ToInt32(input);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
