using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD_Kata
{
    class StringCalculator
    {
        public int Add(string numbers)
        {
            

            if (numbers.Length > 0)
            {
                int[] numbersArray = PreparingNumbersArray(numbers);

                return numbersArray.Sum();
            }

            else { return 0; }
                   
            
        }

        public int[] PreparingNumbersArray(string str)
        {
            string[] stringArray;
            int[] numbersArray;

            str = str.Replace("\n", ",");
            stringArray = str.Split(',');
            numbersArray = Array.ConvertAll(stringArray, Convert.ToInt32);

            return numbersArray;
        }
    }

    class Program
    {
        public static void Main()
        {
            StringCalculator stringCalculator = new();

            string num = "";
            Console.WriteLine(num.Split(',').Length);
            Console.WriteLine(stringCalculator.Add("1\n2,3"));
            Console.WriteLine("1\n2,3");
        }
    }
}
