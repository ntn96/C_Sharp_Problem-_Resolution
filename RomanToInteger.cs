using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class RomanToInteger
    {
        // You can find this problem at: https://leetcode.com/problems/roman-to-integer/
        // Author: Antonio Serrano Miralles
        // 30-09-2019
        public static void Main(string[] args)
        {
            string input = "MCMXCIV";
            Console.WriteLine(RomanToInt(input));
            Console.ReadKey(true);
        }

        public static int RomanToInt(string s)
        {
            int result = 0;
            int check = 0;
            int numChecked = 0;
            for (int i=0; i<s.Length-1; i++)
            {
                result += CheckPosition(s, i, out check);
                if (check == 2) i++;
                numChecked += check;
            }
            if(numChecked < s.Length) result += CheckPosition(s,s.Length - 1, out check);
            return result;
        }

        public static int CheckPosition(string s, int i, out int check)
        {
            int result = 0;
            check = 0;
            switch (s[i])
            {
                case 'M':
                    result += 1000;
                    break;
                case 'C':
                    if (i+1 < s.Length)
                    {
                        if (s[i + 1] == 'D')
                        {
                            result += 400;
                            check++;
                        }
                        else if (s[i + 1] == 'M')
                        {
                            result += 900;
                            check++;
                        }
                        else
                        {
                            result += 100;
                        }
                    }
                    else
                    {
                        result += 100;
                    }
                    break;
                case 'D':
                    result += 500;
                    break;
                case 'X':
                    if (i+1 < s.Length)
                    {
                        if (s[i + 1] == 'L')
                        {
                            result += 40;
                            check++;
                        }
                        else if (s[i + 1] == 'C')
                        {
                            result += 90;
                            check++;
                        }
                        else result += 10;
                    }
                    else result += 10;
                    break;
                case 'L':
                    result += 50;
                    break;
                case 'I':
                    if (i+1 < s.Length)
                    {
                        if (s[i + 1] == 'X')
                        {
                            result += 9;
                            check++;
                        }
                        else if (s[i + 1] == 'V')
                        {
                            result += 4;
                            check++;
                        }
                        else result += 1;
                    }
                    else result += 1;
                    break;
                case 'V':
                    result += 5;
                    break;
            }
            check += 1;
            return result;
        }
    }
}
