using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    // You can find this problem at: https://leetcode.com/problems/reverse-nodes-in-k-group/
    // Author: Antonio Serrano Miralles
    // 03-10-2019
    /*
     //Definition for singly-linked list.
     public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }

            public ListNode(int[] nums)
            {
                if (nums.Length == 0) return;
                val = nums[0];
                ListNode aux = this;
                for (int i = 1; i < nums.Length; i++)
                {
                    aux.next = new ListNode(nums[i]);
                    aux = aux.next;
                }
            }

            public override string ToString()
            {
                ListNode aux = this;
                string s = "";
                while (aux != null)
                {
                    s += aux.val;
                    if (aux.next != null) s += "->";
                    aux = aux.next;
                }
                return s;
            }
     }
     */
    class ReverseNodeInKGroup
    {
        public static void Main(string[] args)
        {
            ListNode list = new ListNode(new int[] { 1, 2, 3, 4, 5 });
            Console.WriteLine(ReverseKGroup(list, 2).ToString());
            Console.ReadKey(true);
        }

        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode[] buffer = new ListNode[k];
            ListNode actual = head;
            ListNode prev = null;
            ListNode newHead = null;
            int bufferCount = 0;
            while(actual != null || bufferCount == k)
            {
                buffer[bufferCount] = actual;
                actual = actual.next;
                bufferCount++;
                if (bufferCount == k)
                {
                    if (buffer[0] == head) newHead = buffer[k - 1];
                    ListNode aux = buffer[k - 1].next;
                    if (prev != null) prev.next = buffer[k - 1];
                    for (int i=k-1; i>0; i--)
                    {
                        buffer[i].next = buffer[i-1];
                    }
                    buffer[0].next = aux;
                    prev = buffer[0];
                    bufferCount = 0;
                    
                } 
            }
            if (newHead == null) return head;
            return newHead;
        }
    }
}
