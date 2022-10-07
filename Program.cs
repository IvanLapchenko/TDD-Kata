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

            return numbersArray;
        }

        public void CheckForNegativness()
        {

        }
    }

    class Program
    {
        public static void Main()
        {


            StringCalculator stringCalculator = new();

            string str = "//;\n1;2";


        }
    }
}
