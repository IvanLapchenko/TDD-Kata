﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace TDD_Kata
{
    class StringCalculator
    {

        public int countAdds;

        public event Action<int> AddOccured;

        public void GetCalledCount(int value)
        {
            countAdds += value;
        }

        public int Add(string numbers)
        {

            if (numbers.Length > 0)
            {
                int[] numbersArray = PreparingNumbersArray(numbers);

                return numbersArray.Sum();
            }

            else 
            {
                return 0;
            }

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
            List<int> negativeNumbers = new List<int>();

            foreach (int num in numbersArray)
            {
                if (num < 0)
                    negativeNumbers.Add(num);   
            }
            if (negativeNumbers.Count > 0) 
            {
                string listOfNegatives;
                listOfNegatives = string.Join(", ", negativeNumbers.ToArray());
                throw new ArgumentException($"negatives not allowed {listOfNegatives}");
            }
            return numbersArray;
        }
    }

    class Program
    {
        
        public static void Main()
        {

            StringCalculator stringCalculator = new();
            stringCalculator.AddOccured += stringCalculator.GetCalledCount;
            stringCalculator.Add("11,2");
            stringCalculator.Add("11,2");
            stringCalculator.Add("11,2");
            Console.WriteLine(stringCalculator.countAdds);
            Console.WriteLine(stringCalculator.Add("1,3"));
        }
       
    }
}
