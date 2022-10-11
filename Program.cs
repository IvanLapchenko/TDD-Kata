using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
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

        public delegate void Notify();
        
        public event Notify? AddOccured;

        public void AddCounter()
        {
            countAdds++;
        }

        public int Add(string numbers)
        {
            AddOccured?.Invoke();

            if (numbers.Length > 1)
            {
                int[] numbersArray = PreparingNumbersArray(numbers);

                return numbersArray.Sum();
            }

            if (numbers.Length == 1)
            {
                return Convert.ToInt32(numbers);
            }    

            else 
            {
                return 0;
            }

        }

        public int[] PreparingNumbersArray(string str)
        {
            string[] stringArray;
            int[] numbersList;

            char[] delimiterChars = DefiningDelimiters(str);
            foreach (char c in delimiterChars)
            {
                Console.WriteLine(c);
            }
            stringArray = str.Split(delimiterChars);
            stringArray = stringArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            numbersList = Array.ConvertAll(stringArray, Convert.ToInt32);

            numbersList = CheckForNegativness(numbersList);
            numbersList = CheckIfMoreThan1000(numbersList);

            return numbersList;
        }
        
        public char[] DefiningDelimiters(string str)
        {
            Regex regex = new Regex("\\[.*\\]");

            HashSet<char> delimiterChars = new() { ',', ' ', '\n', '/' };

            if (str[..3] == "//[")
            {
                Match match = regex.Match(str);
                var delimiter = match.Value;

                foreach (char c in delimiter)
                {
                    delimiterChars.Add(c);
                }
            }

            else if (str.Substring(0, 2) == "//")
            {
                delimiterChars.Add(str[2]);
            }

            char [] delimiters = delimiterChars.ToArray();

            return delimiters;
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

        public int[] CheckIfMoreThan1000(int[] numbers)
        {
            List<int> moreThan1000 = new List<int>();

            foreach (int num in numbers)
            {
                if (num < 1000)
                    moreThan1000.Add(num);
            }
            return moreThan1000.ToArray();
        }


    }

    class Program
    {

        
        public static void Main()
        {
            StringCalculator stringCalculator = new();
            stringCalculator.AddOccured += stringCalculator.AddCounter;
            stringCalculator.Add("//[###]\n12###2");
        }
       
    }
}
