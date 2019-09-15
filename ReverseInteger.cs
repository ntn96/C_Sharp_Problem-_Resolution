using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class ReverseInteger
    {
        //You can find this problem at https://leetcode.com/problems/reverse-integer/

        static void Main(string[] args)
        {
            Console.WriteLine("Input: 123");
            Console.WriteLine("Output: " + Reverse(123));
            Console.WriteLine("Input: -123");
            Console.WriteLine("Output: " + Reverse(-123));
            Console.WriteLine("Input: 120");
            Console.WriteLine("Output: " + Reverse(120));
            Console.ReadKey(true);
        }

        public static int Reverse(int x)
        {
            int result = 0, mod = 0;
            while (x != 0)
            {
                mod = x % 10;
                x /= 10;
                result += mod;
                try
                {
                    if (x != 0) result = checked(result * 10);
                }
                catch
                {
                    return 0;
                }
            }
            return result;
        }
    }
}
