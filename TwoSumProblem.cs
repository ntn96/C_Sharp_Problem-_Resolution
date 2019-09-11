using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class TwoSumProblem
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{ 1, 10, 25, 35, 60};
            int[] result = TwoSum(nums, 60);
            Console.WriteLine(nums[result[0]]+" + "+nums[result[1]]+" = 60");
            Console.ReadKey(true);
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            int length = nums.Length;
            Hashtable table = new Hashtable();
            for (int i = 0; i < length; i++)
            {
                if (table.Contains(nums[i])) return new int[] { (int)table[nums[i]], i };
                int complement = target - nums[i];
                if (!table.Contains(complement))
                    table.Add(complement, i);
            }
            return null;
        }
    }
}
