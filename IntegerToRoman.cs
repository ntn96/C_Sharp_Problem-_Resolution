using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class IntegerToRoman
    {
        // You can find this problem at: https://leetcode.com/problems/integer-to-roman/
        // Author: Antonio Serrano Miralles
        // 30-09-2019
        public static void Main(string[] args)
        {
            int input = 1994;
            Console.WriteLine(IntToRoman(input));
            Console.ReadKey(true);
        }

        private static string IntToRoman(int num)
        {
            StringBuilder sb = new StringBuilder("", 15);
            int aux = num / 1000;
            int rest = num % 1000;
            for (int i = 0; i < aux; i++) sb.Append('M');
            aux = rest / 900;
            if (aux == 1) sb.Append(new char[] {'C','M'});
            rest %= 900;
            aux = rest / 500;
            rest %= 500;
            if (aux > 0) sb.Append('D');
            aux = rest / 100;
            rest %= 100;
            if (aux == 4) sb.Append(new char[] { 'C', 'D' });
            else
            {
                for (int i = 0; i < aux; i++) sb.Append('C');
            }
            aux = rest / 90;
            rest %= 90;
            if (aux == 1) sb.Append(new char[] { 'X', 'C' });
            aux = rest / 50;
            rest %= 50;
            if (aux == 1) sb.Append('L');
            aux = rest / 10;
            rest %= 10;
            if (aux == 4) sb.Append(new char[] { 'X', 'L' });
            else for (int i = 0; i < aux; i++) sb.Append('X');
            aux = rest / 9;
            rest %= 9;
            if (aux == 1) sb.Append(new char[] { 'I', 'X' });
            aux = rest / 5;
            rest %= 5;
            if (aux == 1) sb.Append('V');
            if (rest == 4) sb.Append(new char[] { 'I', 'V' });
            else for (int i = 0; i < rest; i++) sb.Append('I');
            return sb.ToString();
        }
    }
}
