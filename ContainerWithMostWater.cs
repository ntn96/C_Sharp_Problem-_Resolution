using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class ContainerWithMostWater
    {
        // You can find this problem at: https://leetcode.com/problems/container-with-most-water/
        // Author: Antonio Serrano Miralles
        // 30-09-2019

        public static void Main(string[] args)
        {
            int[] input = { 177, 112, 74, 197, 90, 16, 4, 61, 103, 133, 198, 4, 121, 143, 55, 138, 47, 167, 165, 159, 93, 85, 53, 118, 127, 171, 137, 65, 135, 45, 151, 64, 109, 25, 61, 152, 194, 65, 165, 97, 199, 163, 53, 72, 58, 108, 10, 105, 27, 127, 64, 120, 164, 70, 190, 91, 41, 127, 109, 176, 172, 12, 193, 34, 38, 54, 138, 184, 120, 103, 33, 71, 66, 86, 143, 125, 146, 105, 182, 173, 184, 199, 46, 148, 69, 36, 192, 110, 116, 53, 38, 40, 65, 31, 74, 103, 86, 12, 39, 158 };
            Console.WriteLine(MaxArea3(input));
            Console.ReadKey(true);
        }

        //Brute Force
        public static int MaxArea(int[] height)
        {
            int actualMaxArea = 0;
            for (int i=0; i<height.Length; i++)
            {
                for(int j=i+1; j<height.Length; j++)
                {
                    int bottom = j - i;
                    int tall = Math.Min(height[i], height[j]);
                    int content = bottom * tall;
                    if (content > actualMaxArea)
                    {
                        actualMaxArea = content;
                    }
                }
            }
            return actualMaxArea;
        }

        public static int MaxArea2(int[] height)
        {
            int maxTall = 0, secondMaxTall = 0;
            int indexFirst = 0, indexSecond = 0;
            for (int i = 0; i < height.Length; i++) //complexity n
            {
                if (maxTall < height[i])
                {
                    secondMaxTall = maxTall;
                    indexSecond = indexFirst;
                    maxTall = height[i];
                    indexFirst = i;
                }
                else if (secondMaxTall <= height[i])
                {
                    secondMaxTall = height[i];
                    indexSecond = i;
                }
            }
            int actualMax = secondMaxTall * Math.Abs(indexSecond - indexFirst);
            int indexLeft, indexRight;
            if (indexFirst > indexSecond)
            {
                indexRight = indexFirst;
                indexLeft = indexSecond;
            } else
            {
                indexRight = indexSecond;
                indexLeft = indexFirst;
            }
            for (int i=indexLeft; i>=0; i--)
            {
                for (int j=indexRight; j < height.Length; j++)
                {
                    int candidate = Math.Min(height[i],height[j]) * Math.Abs(j - i);
                    if (candidate > actualMax)
                    {
                        actualMax = candidate;
                    }
                }
            }
            return actualMax;
        }

        //the faster one, n complexity in time
        public static int MaxArea3(int[] height)
        {
            int leftPointer = 0, rightPointer = height.Length-1;
            int maxArea = 0;
            for (int i=0; i<height.Length; i++)
            {
                int candidate;
                if (height[leftPointer] < height[rightPointer])
                {
                    candidate = height[leftPointer] * (rightPointer - leftPointer);
                    leftPointer++;
                } else
                {
                    candidate = height[rightPointer] * (rightPointer - leftPointer);
                    rightPointer--;
                }
                if (candidate > maxArea) maxArea = candidate;
            }
            return maxArea;
        }
    }
}
