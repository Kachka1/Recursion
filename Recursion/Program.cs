using System;

namespace TransportSystemsRecursion
{
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1
            Console.WriteLine("1: Реверс");
            string inputStr = "tiger";
            Console.Write($"Input: \"{inputStr}\" -> Output: \"");
            PrintReverse(inputStr);
            Console.WriteLine("\"\n");

            // 2
            Console.WriteLine("2: Обмін сусідніх вузлів");
            int[] arr1 = { 1, 2, 3, 4 };
            ListNode? head1 = CreateListRecursive(arr1);
            Console.Write("Input1:  ");
            PrintListRecursive(head1);
            ListNode? swapped1 = SwapPairs(head1);
            Console.Write("Output1: ");
            PrintListRecursive(swapped1);

            int[] arr2 = Array.Empty<int>();
            ListNode? head2 = CreateListRecursive(arr2);
            Console.Write("Input2:  ");
            PrintListRecursive(head2);
            Console.Write("Output2: ");
            PrintListRecursive(SwapPairs(head2));

            int[] arr3 = { 1 };
            ListNode? head3 = CreateListRecursive(arr3);
            Console.Write("Input3:  ");
            PrintListRecursive(head3);
            Console.Write("Output3: ");
            PrintListRecursive(SwapPairs(head3));
            Console.WriteLine();

            // 3
            Console.WriteLine("3: Фібоначчі");
            Console.WriteLine($"Input: n = 2 -> Output: {Fibonacci(2)}");
            Console.WriteLine($"Input: n = 3 -> Output: {Fibonacci(3)}");
            Console.WriteLine($"Input: n = 4 -> Output: {Fibonacci(4)}\n");

            // 4
            Console.WriteLine("4: Підйом по сходах");
            Console.WriteLine($"Input: n = 2  -> Output: {ClimbStairs(2)}");
            Console.WriteLine($"Input: n = 3  -> Output: {ClimbStairs(3)}");
            Console.WriteLine($"Input: n = 45 -> Output: {ClimbStairs(45)}\n");

            // 5
            Console.WriteLine("5: pow(x, n)");
            Console.WriteLine($"Input: x = 2.00000, n = 10 -> Output: {MyPow(2.00000, 10):F5}");
            Console.WriteLine($"Input: x = 2.10000, n = 3  -> Output: {MyPow(2.10000, 3):F5}");
            Console.WriteLine($"Input: x = 2.00000, n = -2 -> Output: {MyPow(2.00000, -2):F5}");
        }
        static void PrintReverse(string str, int index = 0)
        {
            if (string.IsNullOrEmpty(str) || index >= str.Length)
                return;

            PrintReverse(str, index + 1);
            Console.Write(str[index]);
        }
        static ListNode? SwapPairs(ListNode? head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode firstNode = head;
            ListNode secondNode = head.next;

            firstNode.next = SwapPairs(secondNode.next);
            secondNode.next = firstNode;

            return secondNode;
        }

        static ListNode? CreateListRecursive(int[] arr, int index = 0)
        {
            if (index >= arr.Length)
                return null;
            return new ListNode(arr[index], CreateListRecursive(arr, index + 1));
        }

        static void PrintListRecursive(ListNode? head, bool isFirst = true)
        {
            if ( isFirst ) Console.Write("[");
            if (head == null)
            {
                Console.WriteLine("]");
                return;
            }
            Console.Write(head.val + (head.next != null ? "," : ""));
            PrintListRecursive(head.next, false);
        }
        static int Fibonacci(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        static int ClimbStairs(int n, int[]? memo = null)
        {
            if (n <= 2) return n;

            memo ??= new int[n + 1];
            if (memo[n] != 0) return memo[n];

            memo[n] = ClimbStairs(n - 1, memo) + ClimbStairs(n - 2, memo);
            return memo[n];
        }
        static double MyPow(double x, int n)
        {
            long exp = n;
            if (exp < 0)
            {
                x = 1.0 / x;
                exp = -exp;
            }
            return FastPowRecursive(x, exp);
        }

        static double FastPowRecursive(double x, long n)
        {
            if (n == 0) return 1.0;

            double half = FastPowRecursive(x, n / 2);

            if (n % 2 == 0)
                return half * half;
            else
                return half * half * x;
        }
    }
}