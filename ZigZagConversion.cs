using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class ZigZagConversion
    {
        // You can find this problem at: https://leetcode.com/problems/zigzag-conversion/ 
        // Author: Antonio Serrano Miralles
        // 28-09-2019

        public static void Main(string[] args)
        {
            string input = "ABCD";
            int rows = 2;
            Console.WriteLine(Convert(input,rows));
            Console.ReadKey(true);
        }


        public static string ConvertVisual(string s, int numRows)
        {
            string[] lines = new string[numRows];
            int actualIndex = 0;
            int actualRow = 0;
            int firstZigRow = numRows - 2;
            int actualZigRow = firstZigRow;
            bool columnPhase = true;
            while (actualIndex < s.Length)
            {
                if (columnPhase)
                {
                    lines[actualRow] += s[actualIndex]+" ";
                    actualIndex++;
                } else
                {
                    if (actualRow != actualZigRow) lines[actualRow] += "  ";
                    else
                    {
                        lines[actualRow] += s[actualIndex]+" ";
                        actualIndex++;
                        actualZigRow--;
                    }
                        
                }
                actualRow++;
                if (actualRow == numRows)
                {
                    actualRow = 0;
                    if (firstZigRow != 0)
                    {
                        if (columnPhase) columnPhase = !columnPhase;
                        else if (actualZigRow < 1)
                        {
                            actualZigRow = firstZigRow;
                            columnPhase = !columnPhase;
                        }
                    }
                }
            }
            string result = "";
            for (int i = 0; i < numRows; i++) result += lines[i] + "\n";
            return result;
        }

        public static string Convert(string s, int numRows)
        {
            string[] lines = new string[numRows];
            int actualIndex = 0;
            int actualRow = 0;
            int firstZigRow = numRows - 2;
            int actualZigRow = firstZigRow;
            bool columnPhase = true;
            while (actualIndex < s.Length)
            {
                if (columnPhase)
                {
                    lines[actualRow] += s[actualIndex];
                    actualIndex++;
                }
                else
                {
                    if (actualRow == actualZigRow) 
                    {
                        lines[actualRow] += s[actualIndex];
                        actualIndex++;
                        actualZigRow--;
                    }

                }
                actualRow++;
                if (actualRow == numRows)
                {
                    actualRow = 0;
                    if (firstZigRow != 0)
                    {
                        if (columnPhase) columnPhase = !columnPhase;
                        else if (actualZigRow < 1)
                        {
                            actualZigRow = firstZigRow;
                            columnPhase = !columnPhase;
                        }
                    }
                }
            }
            string result = "";
            for (int i = 0; i < numRows; i++) result += lines[i];
            return result;
        }
    }
}
