using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class MergeKSortedLists
    {
        // You can find this problem at: https://leetcode.com/problems/merge-k-sorted-lists/
        // Author: Antonio Serrano Miralles
        // 02-10-2019
        public static void Main(string[] args)
        {

            ListNode l1 = new ListNode(new int[]{ -10, -9, -9, -3, -1, -1, 0 });
            ListNode l2 = new ListNode(new int[]{ -5 });
            ListNode l3 = new ListNode(new int[]{ 4 });
            ListNode l4 = new ListNode(new int[] { -8});
            ListNode l5 = new ListNode(new int[] { -9, -6, -5, -4, -2, 2, 3 });
            ListNode l6 = new ListNode(new int[] { -3, -3, -2, -1, 0 });

            Console.WriteLine(MergeDivideAndConquer(new ListNode[] { l1, l2, l3, l4, null, l5, l6}).ToString());
            Console.ReadKey(true);
        }



        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }

            public ListNode(int[] nums)
            {
                if (nums.Length == 0) return;
                val = nums[0];
                ListNode aux = this;
                for (int i=1; i<nums.Length; i++)
                {
                    aux.next = new ListNode(nums[i]);
                    aux = aux.next;
                }
            }

            public override string ToString()
            {
                ListNode aux = this;
                string s = "";
                while(aux != null)
                {
                    s += aux.val;
                    if (aux.next != null) s += "->";
                    aux = aux.next;
                }
                return s;
            }
        }

        //faster function
        public static ListNode MergeDivideAndConquer(ListNode[] lists)
        {
            int listsCount = lists.Length;
            if (listsCount == 0) return null;
            if (listsCount == 1) return lists[0];
            List<ListNode> listResults = new List<ListNode>();
            for (int i=0; i<lists.Length-1; i+=2)
            {
                listResults.Add(MergeTwoList(new ListNode[] { lists[i], lists[i + 1] }));
            }
            if (listsCount % 2 == 0)
            {
                if (listResults.Count == 1) return listResults[0];
                else return MergeDivideAndConquer(listResults.ToArray());
            } else
            {
                if (listResults.Count == 1) return MergeDivideAndConquer(new ListNode[] { listResults[0], lists[lists.Length - 1] });
                else return MergeDivideAndConquer(new ListNode[] { MergeDivideAndConquer(listResults.ToArray()), lists[lists.Length - 1] });
            }
            
        }

        public static ListNode MergeTwoList(ListNode[] lists)
        {
            if (lists[0] == null) return lists[1];
            else if (lists[1] == null) return lists[0];
            ListNode result = null;
            ListNode actual = null;
            int actualList = 0;
            while (lists[0] != null || lists[1] != null)
            {
                if (lists[0] == null) actualList = 1;
                else if (lists[1] == null) actualList = 0;
                else if (lists[0].val <= lists[1].val) actualList = 0;
                else actualList = 1;
                if (actual == null)
                {
                    actual = new ListNode(lists[actualList].val);
                    result = actual;
                }
                else
                {
                    actual.next = new ListNode(lists[actualList].val);
                    actual = actual.next;
                }
                lists[actualList] = lists[actualList].next;
            }
            return result;
        }

        //slower function
        public static ListNode MergeCompareOneByOne(ListNode[] lists)
        {
            ListNode result = null;
            ListNode actual = null;
            bool stillNodes = true;
            while (stillNodes)
            {
                bool someNotNull = false;
                int actualMinValue = int.MaxValue;
                int indexMin = 0;
                for (int i = 0; i < lists.GetLength(0); i++)
                {
                    if (lists[i] != null)
                    {
                        someNotNull = true;
                        if (actualMinValue > lists[i].val)
                        {
                            actualMinValue = lists[i].val;
                            indexMin = i;
                        }
                    }
                }
                if (someNotNull)
                {
                    if (actual == null)
                    {
                        actual = new ListNode(actualMinValue);
                        if (result == null) result = actual;
                    }
                    else
                    {
                        actual.next = new ListNode(actualMinValue);
                        actual = actual.next;
                    }
                    lists[indexMin] = lists[indexMin].next;

                }
                else
                {
                    break;
                }
            }
            return result;
        }
    }
}
