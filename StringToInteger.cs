using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class StringToInteger
    {
        // You can find this problem at: https://leetcode.com/problems/string-to-integer-atoi/
        // Author: Antonio Serrano Miralles
        // 28-09-2019
        public static void Main(string[] args)
        {
            string input = "2147483646";
            Console.WriteLine(MyAtoi(input));
            Console.ReadKey(true);
        }

        public static int MyAtoi(string str)
        {
            bool allowSpace = true;
            bool signAllow = true;
            int sign = 1;
            int actualnum = 0;
            for (int i=0; i<str.Length; i++)
            {
                int code = (int)str[i];
                if ((code < 48 || code > 57) && (code != 45 && code != 43 && code != 32)) return sign*actualnum;
                switch (code)
                {
                    case 32:
                        if (!allowSpace) return sign*actualnum;
                        else break;
                    case 45:
                        if (!signAllow) return sign*actualnum;
                        else signAllow = false;
                        sign = -1;
                        allowSpace = false;
                        break;
                    case 43:
                        if (!signAllow) return sign*actualnum;
                        else signAllow = false;
                        allowSpace = false; 
                        break;
                    default:
                        allowSpace = false;
                        signAllow = false;
                        if ((int.MaxValue-(code-48))/10<actualnum)
                        {
                            if (sign > 0) return int.MaxValue;
                            else return int.MinValue;
                        }
                        actualnum = actualnum * 10 + (code - 48);
                        break;
                }
            }
            return sign * actualnum;
        }
    }
}
