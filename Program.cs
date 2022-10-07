using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using NUnit.Framework.Internal;

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
            char[] delimiterChars = { '/', ',', ';', ' ', '\n' };

            string[] stringArray;
            int[] numbersArray;

            stringArray = str.Split(delimiterChars);
            stringArray = stringArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            numbersArray = Array.ConvertAll(stringArray, Convert.ToInt32);
            numbersArray = CheckForNegativness(numbersArray);

            return numbersArray;
        }

        public int[] CheckForNegativness(int[] numbersArray)
        {
            foreach (int num in numbersArray)
            {
                if (num < 0)
                    throw new ArgumentException("negatives not allowed"); 
            }
            return numbersArray;
        }
    }

    class Program
    {
        public static void Main()
        {


            StringCalculator stringCalculator = new();
            string str = "//;\n1;-2";
            int[] prepared = stringCalculator.PreparingNumbersArray(str);
            foreach (int c in prepared)
            {
                Console.WriteLine(c);
            }
            



        }
    }
}
