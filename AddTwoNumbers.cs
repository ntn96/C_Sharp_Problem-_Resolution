using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    // You can find this problem in https://leetcode.com/problems/add-two-numbers/

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public override string ToString()
        {
            ListNode actual = this;
            string representation = "";
            while (actual.next != null)
            {
                representation += actual.val.ToString() + " -> ";
                actual = actual.next;
            }
            representation += actual.val.ToString();
            return representation;
        }
    }

    class AddTwoNumbers
    {
        static void Main(string[] args)
        {
            ListNode first = new ListNode(2);
            first.next = new ListNode(4);
            first.next.next = new ListNode(3);

            ListNode second = new ListNode(5);
            second.next = new ListNode(6);
            second.next.next = new ListNode(4);

            Console.WriteLine("(" + first.ToString() + ") + (" + second.ToString() + ") = ");

            ListNode result = AddTwoNumbersSolution(first, second);

            Console.WriteLine(result);
            Console.ReadKey(true);
        }

        public static ListNode AddTwoNumbersSolution(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode((l1.val + l2.val) % 10);
            ListNode aux = result;
            int acarreo = (l1.val + l2.val) / 10;
            while (l1.next != null || l2.next != null || acarreo != 0)
            {
                int val1 = 0, val2 = 0;
                if (l1.next != null)
                {
                    val1 = l1.next.val;
                    l1 = l1.next;
                }
                if (l2.next != null)
                {
                    val2 = l2.next.val;
                    l2 = l2.next;
                }
                int valor = (val1 + val2 + acarreo) % 10;
                acarreo = (val1 + val2 + acarreo) / 10;
                if (valor > 0 || acarreo > 0 || l1 != null || l2 != null)
                {
                    result.next = new ListNode(valor);
                    result = result.next;
                }
            }
            return aux;
        }
    }
}
