using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class PalindromeNumber
    {
        // You can find this problem at: https://leetcode.com/problems/palindrome-number/
        // Author: Antonio Serrano Miralles
        // 30-09-2019
        public static void Main(string[] args)
        {
            int input = 303;
            Console.WriteLine(isPalindrome(input));
            Console.ReadKey(true);
        }

        public static bool isPalindrome(int x)
        {
            if (x < 0) return false;
            if (x < 10) return true;
            String num = x.ToString();
            int tam = num.Length;
            for (int i = 0; i < tam; i++)
            {
                if (num[i] != num[tam - 1 - i]) return false;
            }
            return true;
        }
    }
}
