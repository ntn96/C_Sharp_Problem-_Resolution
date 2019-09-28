using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class LongestPalindromicSubstring
    {
        public static void Main(string[] args)
        {
            string input = "ffffffg";
            Console.WriteLine(LongestPalindrome(input));
            Console.ReadKey(true);
        }


        public static string LongestPalindrome(string s)
        {
            string finalResult = "";
            //Base case, string is size 1 or less, then is a palindrome by itself
            if (s.Length <= 1) return s;
            if (s.Length == 2)
            {
                if (s[0] == s[1]) return s;
                else return finalResult + s[0];
            }
            for (int i = 0; i < s.Length - 1; i++)
            {
                int tam = Math.Max(ExpandFromCenter(s, i, i), ExpandFromCenter(s, i, i + 1));
                if (tam > finalResult.Length) finalResult = s.Substring(i - (tam - 1) / 2, tam);
            }
            return finalResult;
        }

        public static int ExpandFromCenter(string s, int i, int j)
        {
            while (i >= 0 && j < s.Length && s[i] == s[j])
            {
                i--;
                j++;
            }
            return j - i - 1;
        }
    }
}
