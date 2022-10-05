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
            string[] stringArray;
            int[] numbersArray;

            if (numbers == "")
                return 0;
            if (numbers.Split(',').Length == 1)
                return Convert.ToInt32(numbers);
            if (numbers.Split(',').Length > 1)
            {
                stringArray = numbers.Split(',');
                numbersArray = Array.ConvertAll(stringArray, Convert.ToInt32);
                return numbersArray.Sum();
            }
            else { return 0; }
                   
            
        }
    }

    class Program
    {
        public static void Main()
        {
            StringCalculator stringCalculator = new();

            string num = "12,25,17";
            Console.WriteLine(num.Split(',').Length);
            Console.WriteLine(stringCalculator.Add("1,3") ); 
        }
    }
}
