using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeC_problem
{
    public static class Brain
    {
        public static int ReverseANumber(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = (result * 10) + (num % 10);
                num = num / 10;
            }

            return result;
        }

        public static string ReverseAString(string str)
        {
            string result="";
            int count = str.Length;
            for (int i = count - 1; i >= 0;i--)
            {
                result=result+ str[i];
            }

            return result;
        }

        public static int CountNoOfLetter(string str)
        {
            int countOfA=0;
            foreach(char c in str)
            {
                if(c == 'a')
                {
                    countOfA++;
                }
            }
            return countOfA;
        }

        public static void CountNoOfAlphabet(string str)
        {
            str = str.ToLower();
            Dictionary<char,int> dict = new Dictionary<char,int>();
            foreach (char character in str)
            {
                if (dict.ContainsKey(character))
                {
                    
                    dict[character] = dict[character]+1;
                    
                }
                else
                {
                    dict.Add(character, 1);
                }
            }
            var sorted = from item in dict orderby item.Key select item;
            Console.WriteLine(sorted);
            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key} has count {item.Value}");
            }
        }
        
        public static void DisplayUniqueAlphabet(string sentence)
        {
            sentence = sentence.ToLower();
            List<char> alphabet = new List<char>();

            for(int i=0; i < sentence.Length; i++)
            {
                char c = sentence[i];
                if (!alphabet.Contains(c))
                {
                    alphabet.Add(c);
                }

            }
            alphabet.Sort();
            var alphabetWord = "";
            foreach (char character in alphabet)
            {
                alphabetWord += character;
                Console.WriteLine(character);
            }

            Console.WriteLine(alphabetWord);
        }

        public static double SumOfInteger(int number)
        {
            var result=0;
                
            while (number > 0)
            {

                result = result + number % 10;
                number = number / 10;
            }

            return result;
        }
    
    }
}
