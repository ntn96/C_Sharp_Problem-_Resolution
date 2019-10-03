using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class SubstringWithConcatenationOfAllWords
    {
        // You can find this problem at: https://leetcode.com/problems/substring-with-concatenation-of-all-words/
        // Author: Antonio Serrano Miralles
        // 03-10-2019

        public static void Main(string[] args)
        {
            string inputString = "aaaaaaaa";
            string[] inputWords = new string[] { "aa", "aa", "aa" };
            IList<int> output = FindSubstring(inputString, inputWords);
            for(int i=0; i<output.Count-1; i++)
            {
                Console.Write(output[i] + ",");
            }
            if(output.Count > 0) Console.WriteLine(output[output.Count - 1]);
            Console.ReadKey(true);
        }

        public static IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> result = new List<int>();
            if (words.Length == 0 || s.Length < words[0].Length) return result;
            bool allSame = true;
            string sumStrings = "";
            for (int i=0; i < words.Length-1; i++)
            {
                if (words[i] != words[i+1])
                {
                    allSame = false;
                    break;
                }
                sumStrings += words[i];
            }
            sumStrings += words[words.Length - 1];
            if (allSame) words = new string[] { sumStrings };
            Char[] firstChars = new Char[words.Length];
            int firstIndex = -1;
            int jumps = 0;
            for (int i = 0; i < words.Length; i++)
            {
                firstChars[i] = words[i][0];
                if (!s.Contains(firstChars[i])) return result;
            }
            for (int i=0; i<s.Length; i++)
            {
                bool[] checkedChars = new bool[words.Length];
                for (int j=0; j<firstChars.Length; j++)
                {
                    if (checkedChars[j]) continue;
                    if (s[i] == firstChars[j] && CheckSubstring(s, i, words[j]))
                    {
                        if (firstIndex < 0) firstIndex = i;
                        checkedChars[j] = true;
                        j = -1;
                        i += words[0].Length;
                        jumps++;
                    }
                    if (i >= s.Length) break;
                }
                if (!checkedChars.Contains(false))
                {
                    result.Add(firstIndex);
                }
                i -= words[0].Length * (jumps);
                jumps = 0;
                firstIndex = -1;
                
            }
            return result;
        }

        public static bool CheckSubstring(string original, int index, string word)
        {
            if (index + word.Length > original.Length) return false;
            if (original.Substring(index, word.Length) == word) return true;
            else return false;
        }
    }
}
