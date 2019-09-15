using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class LengthOfLongestSubstring
    {
        // You can find this problem in https://leetcode.com/problems/longest-substring-without-repeating-characters/
        static void Main(string[] args)
        {
            string example1 = "abcabcbb";
            string example2 = "bbbbb";
            string example3 = "pwwkew";

            Console.WriteLine("Input: " + example1);
            Console.WriteLine("Output: " + LengthOfLongestSubstringSolution(example1));
            Console.WriteLine("Input: " + example2);
            Console.WriteLine("Output: " + LengthOfLongestSubstringSolution(example2));
            Console.WriteLine("Input: " + example3);
            Console.WriteLine("Output: " + LengthOfLongestSubstringSolution(example3));
            Console.ReadKey(true);
        }

        public static int LengthOfLongestSubstringSolution(string s)
        {
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                HashSet<char> letras = new HashSet<char>();
                letras.Add(s[i]);
                int maxlocal = 1;
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (letras.Contains(s[j]))
                    {
                        if (maxlocal > max) max = maxlocal;
                        break;
                    }
                    letras.Add(s[j]);
                    maxlocal++;
                }
                if (maxlocal > max) max = maxlocal;
            }
            return max;
        }
    }
}
