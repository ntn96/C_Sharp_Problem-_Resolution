using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class MedianOfTwoSortedArrays
    {
        //You can find this problem at https://leetcode.com/problems/median-of-two-sorted-arrays/

        static void Main(string[] args)
        {
            Console.WriteLine("Example 1: [1, 3] [2]");
            Console.WriteLine("The median is " + FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }));
            Console.WriteLine("Example 2: [1, 2] [3, 4]");
            Console.WriteLine("The median is " + FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }));
            Console.ReadKey(true);
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int tam = nums1.Length + nums2.Length;
            bool pair = (tam % 2 == 0);
            int index1 = 0, index2 = 0;
            int median1 = 0, median2 = 0;
            int tam2 = (tam / 2) + 1;

            for (int i = 0; i < tam2; i++)
            {
                median1 = median2;
                if (index1 == nums1.Length)
                {
                    median2 = nums2[index2];
                    index2++;
                }
                else if (index2 == nums2.Length)
                {
                    median2 = nums1[index1];
                    index1++;
                }
                else
                {
                    if (nums1[index1] < nums2[index2])
                    {
                        median2 = nums1[index1];
                        index1++;
                    }
                    else
                    {
                        median2 = nums2[index2];
                        index2++;
                    }
                }
            }
            if (pair) return ((float)median1 + (float)median2) / 2f;
            return median2;
        }
    }
}
