using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class LongestCommonPrefix
    {
        // You can find this problem at: https://leetcode.com/problems/longest-common-prefix/
        // Author: Antonio Serrano Miralles
        // 30-09-2019
        public static void Main(string[] args)
        {
            string[] input = { "flower", "flow", "flight" };
            Console.WriteLine(LongestCommonPrefixFunction(input));
            Console.ReadKey(true);
        }

        public static string LongestCommonPrefixFunction(string[] strs)
        {
            int lowerLength = int.MaxValue;
            int indexLower = 0;
            string result = "";
            if (strs.Length == 0) return result;
            if (strs.Length == 1) return strs[0];
            for (int i = 0; i < strs.Length; i++)
                if (strs[i].Length < lowerLength)
                {
                    lowerLength = strs[i].Length;
                    indexLower = i;
                }
            for (int i=0; i < lowerLength; i++)
            {
                Char actualChar = strs[indexLower][i];
                for (int j=0; j<strs.Length; j++)
                {
                    if (strs[j][i] != actualChar) return result;
                }
                result += actualChar;
            }
            return result;
        }

    }
}
